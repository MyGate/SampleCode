<?php

try
{
	/******************************************************************************************************/
	

	$merchantUID = 'F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3';
	$merchantToken = 'F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3';
	$applicationUID = "5A02E47D-7E2E-452B-A940-E3E946265037";	// 3D Secure
	//$applicationUID = "A06033E6-43CF-471A-A985-E16442ED1FFF";	// Non 3D Secure

	//		Action	Action Name
	//		1		Authorise
	//		2		Authorise - Reversal
	//		3		Capture
	//		4		Credits (Follow-On)
	//		5		Sale
	//		12		Credits - Sale
	//		14		ThreeD Secure - Lookup
	//		15		ThreeD Secure - Authenticate
	//		19		Reports
	
	$actionTypeID = '1';
	
	$replace = array (
			'mode' => '0',
			'applicationUID' => $applicationUID,
			'transactionIndex' => '00000000-0000-0000-0000-000000000000',
			'merchantReference' => 'merchantReference_'. date('Ymd_His'),
			'cardHolder' => 'Test Card',
			'cardNumber' => '4000000000000002',
			'expiryMonth' => '02',
			'expiryYear' => '2020',
			'cvvNumber' => '123',
			'amount' => '10.36',
			'verbalAuthCode' => '123456',
			'paresPayload' => '' );

	if ($actionTypeID == 1 || $actionTypeID == 5)
	{
		if (isset($_GET["tdsAuthenticate"]) && isset($_POST["MD"]) && isset($_POST["PaRes"]))
		{
				$replace['transactionIndex'] = $_POST["MD"];
				$replace['paresPayload'] = $_POST["PaRes"];
			
				$authResponse = processRequest($merchantUID, $merchantToken, 15, $replace);
				
				echo '<br><b>=================================================</b><br>';
				echo '<b>ThreeDSecure Auth Response</b>';
				echo '<br><b>=================================================</b><br>';
				echo '<pre>' . htmlentities(print_r($authResponse, true)) . '</pre>';
				echo '<br><b>=================================================</b><br>';
				
				$replace['transactionIndex'] = $authResponse->uidTransactionIndex;
				$actionResponse = processRequest($merchantUID, $merchantToken, $actionTypeID, $replace);
		}
		else
		{
			$lookupResponse = processRequest($merchantUID, $merchantToken, 14, $replace);
			
			echo '<br><b>=================================================</b><br>';
			echo '<b>ThreeDSecure Lookup Response</b>';
			echo '<br><b>=================================================</b><br>';
			echo '<pre>' . htmlentities(print_r($lookupResponse, true)) . '</pre>';
			echo '<br><b>=================================================</b><br>';
	
			if (isset($lookupResponse->tdsLookup->authRequired) && $lookupResponse->tdsLookup->authRequired == 'Y')
				acsPage($lookupResponse->tdsLookup->acsUrl, 'https://'.$_SERVER['HTTP_HOST'].'/'.$_SERVER['PHP_SELF'].'?tdsAuthenticate=true', $lookupResponse->tdsLookup->payload, $lookupResponse->uidTransactionIndex);
			else
				$replace['transactionIndex'] = $lookupResponse->uidTransactionIndex;
				$actionResponse = processRequest($merchantUID, $merchantToken, $actionTypeID, $replace);
		}
	}
	else
		$actionResponse = processRequest($merchantUID, $merchantToken, $actionTypeID, $replace);
	
	echo '<br><b>=================================================</b><br>';
	echo '<b>Action '.$actionTypeID.' Response</b>';
	echo '<br><b>=================================================</b><br>';
	echo '<pre>' . htmlentities(print_r($actionResponse, true)) . '</pre>';
	echo '<br><b>=================================================</b><br>';
	
}
catch ( Exception $fault )
{
	echo '<br>=================================================<br>';
	echo '<br>                E R R O R<br>';
	echo '<br>=================================================<br>';
	print_r ( $fault );
}

/******************************************************************************************************/
function processRequest($merchantUID,$merchantToken,$actionTypeID, $replace)
{
    try
	{
		$ns   = "https://api.mygateglobal.com/";
		$url = $ns.'api/api.wsdl';
		
		/*
		 * The xml files here are only used as an example. It should be changed to the requirements of the customer.
		 * The sample xml can be downloaded from https://github.com/MyGateGlobal/SampleCode/tree/master/XML%20Actions
		 * or generated according to specifications on https://developers.mygateglobal.com
		 */
		$file = file_get_contents($ns.'api/xmlactions/action_'.$actionTypeID.'.xml', false);
		$search = array('{mode}','{applicationUID}','{transactionIndex}','{merchantReference}','{cardHolder}','{cardNumber}','{expiryMonth}','{expiryYear}','{cvvNumber}','{amount}','{verbalAuthCode}','{paresPayload}');
		$xmlRequest = str_replace($search, $replace, $file);		
		
		
		
		
		echo '<b>Submission Data for action :'.$actionTypeID.'</b>';
		echo '<br><b>=================================================</b><br>';
		echo '<pre>' . htmlentities(print_r($xmlRequest, true)) . '</pre>';
		echo '<br><b>=================================================</b><br>';
		
		$auth = new stdClass();

		$auth->merchantUID = $merchantUID;
		$auth->merchantToken = $merchantToken;
		$auth->actionTypeID = $actionTypeID;

		$auth_vals    = new SoapVar($auth, SOAP_ENC_OBJECT);
		$authenticate = new SoapHeader($ns,'authenticate',$auth_vals, false);
		
		$client = new SoapClient ( $url );
		$client->__setSoapHeaders(array($authenticate));
		return $client->execRequest ( new SoapVar ($xmlRequest, XSD_STRING) );
	}
	catch ( Exception $fault )
	{
		echo '<br>=================================================<br>';
		echo '<br>            S O A P  -  E R R O R<br>';
		echo '<br>=================================================<br>';
		print_r ( htmlspecialchars ( $client->__getLastRequest () ) );
		echo '<br>=================================================<br>';
		print_r ( htmlspecialchars ( $client->__getLastResponse () ) );
		echo '<br>=================================================<br>';
	}
}
/******************************************************************************************************/
function acsPage($acsUrl,$retrunUrl,$payload,$transactionIndex)
{
	echo ('	<script type="text/javascript">
				if (window.parent.document.getElementById("divProcessingImage"))
					window.parent.fadeProcessingImage();
					
				setTimeout( function(){ window.parent.fadeProcessingImage() },90000 );
			</script>
			
			<form id="frmLaunchACS" name="frmLaunchACS" method="POST" action="'.$acsUrl.'">
				<!--<noscript>-->
				<table align="center"  width="50%">
					<tr>
						<td>
							<h1>3D Secure</h1>
							<div>
								<p>3D Secure is led by the credit card schemes and is designed to make online shopping transactions safer by authenticating a cardholder&rsquo;s identity at the time of purchase, through the likes of Verified by Visa and MasterCard SecureCode.</p>
								<p>A transaction using Verified by Visa or SecureCode will redirect cardholders to the website of their card-issuing bank. The cardholder may then be requested by their bank to enter a password to be authenticated. If a customer is not registered with 3D Secure they are still able to make a purchase from your website.</p>
								<p>3D Secure is one method for online merchants to combat fraud.</p>
							</div>
							<h3>Benefits</h3>
							<div>
								<ul>
									<li>Creates a level of consumer trust and confidence in online shopping.</li>
									<li>Reduces disputes and fraudulent activity.</li>
								</ul>
							</div>

						</td>
					</tr>
					
					<tr>
						<td colspan="2">
							<div align="center">
								<input type="submit" value="Authenticate" style="width:250" >
							</div>
						</td>
					</tr>
				</table>
				<!--</noscript>-->
				<input type="hidden" style="width:400" id="PaReq" name="PaReq" value="'.$payload.'"/>
				<input type="hidden" style="width:400" id="TermUrl" name="TermUrl" value="'.$retrunUrl.'"/>
				<input type="hidden" style="width:400" id="MD" name="MD" value="'.$transactionIndex.'"/>
			</form>
			<script type="text/javascript">
				//window.name = "#MAIN_BROWSER_WINDOW_NAME#";
				//document.getElementById("frmLaunchACS").submit();
			</script>');
		exit;
}
?>
