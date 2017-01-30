<?php

try
{
	/******************************************************************************************************/
	function processRequest($merchantUID,$applicationUID,$actionTypeID,$xmlRequest)
	{
	    $url = 'http://api.mygateglobal.com/api/api.wsdl';

	    $ns   = "authenticate";
		$auth->merchantUID = $merchantUID;
		$auth->merchantToken = $applicationUID;
		$auth->actionTypeID = $actionTypeID;

		$auth_vals    = new SoapVar($auth, SOAP_ENC_OBJECT);
		$authenticate = new SoapHeader($ns,'authenticate',$auth_vals, false);
		
		$client = new SoapClient ( $url );
		$client->__setSoapHeaders(array($authenticate));
		return $client->execRequest ( new SoapVar ($xmlRequest, XSD_STRING) );
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
					<noscript>
					<table align="center"  width="50%">
						<tr>
							<td>
								<h1>3D Secure</h1>
								<div><img src="https://www.securepay.com.au/_uploads/images/_medium/combined.jpg" alt=""></div>
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
					</noscript>
					<input type="hidden" style="width:400" id="PaReq" name="PaReq" value="'.$payload.'"/>
					<input type="hidden" style="width:400" id="TermUrl" name="TermUrl" value="'.$retrunUrl.'"/>
					<input type="hidden" style="width:400" id="MD" name="MD" value="'.$transactionIndex.'"/>
				</form>
				<script type="text/javascript">
					window.name = "#MAIN_BROWSER_WINDOW_NAME#";
					document.getElementById("frmLaunchACS").submit();
				</script>
			');
			exit;
	}
	/******************************************************************************************************/
	function ccAuth($merchantToken, $applicationUID, $transactionID, $merchantReference)
	{
		$xmlRequest = '<xmlField>
			<mode>0</mode>
			<applicationUID>'.$applicationUID.'</applicationUID>
			<transactionAuth>
				<transactionIndex>'.$transactionID.'</transactionIndex>
			</transactionAuth>
			<merchantReference>123456789012347</merchantReference>
			<cardDetails>
				<cardHolder>Joe Bloggs</cardHolder>
				<cardNumber>4000000000000002</cardNumber>
				<expiryMonth>01</expiryMonth>
				<expiryYear>2020</expiryYear>
				<cvvNumber>123</cvvNumber>
			</cardDetails>
			<amount>12.34</amount>
			<billingDetails>
				<customerID>Test</customerID>
				<invoiceID>Test</invoiceID>
				<contact>
					<firstName>firstName</firstName>
					<lastName>lastName</lastName>
					<company>company</company>
					<contactNumber>contactNumber</contactNumber>
					<email>support@mygateglobal.com</email>
				</contact>
				<address>
					<address1>address1</address1>
					<address2>address2</address2>
					<address3>address3</address3>
					<suburb>suburb</suburb>
					<city>city</city>
					<postalCode>12345</postalCode>
					<country>ZA</country>
				</address>
			</billingDetails>
			<shippingDetails>
				<contact>
					<firstName>firstName</firstName>
					<lastName>lastName</lastName>
					<company>company</company>
					<contactNumber>contactNumber</contactNumber>
					<email>support@mygateglobal.com</email>
				</contact>
				<address>
					<address1>address1</address1>
					<address2>address2</address2>
					<address3>address3</address3>
					<suburb>suburb</suburb>
					<city>city</city>
					<postalCode>12345</postalCode>
					<country>ZA</country>
				</address>
			</shippingDetails>
			<salesItems>
				<item>
					<description>description1</description>
					<unitPrice>1.00</unitPrice>
					<quantity>1</quantity>
					<totalAmount>1.00</totalAmount>
				</item>
				<item>
					<description>description2</description>
					<unitPrice>1.00</unitPrice>
					<quantity>2</quantity>
					<totalAmount>2.00</totalAmount>
				</item>
				<item>
					<description>description3</description>
					<unitPrice>1.00</unitPrice>
					<quantity>3</quantity>
					<totalAmount>3.00</totalAmount>
				</item>
			</salesItems>
			<browserDetails>
				<userAgent>Test</userAgent>
				<browserHeader>Test</browserHeader>
				<ipAddressv4>196.30.66.11</ipAddressv4>
			</browserDetails>
			<terminal>Terminal</terminal>
			<businessRules>
				<doFraudValidation>false</doFraudValidation>
				<doAddressVerification>true</doAddressVerification>
				<doCardVerification>true</doCardVerification>
			</businessRules>
			</xmlField>';
		$ccAuthResponse = processRequest($merchantToken, $applicationUID, 1, $xmlRequest);
		echo '<br><b>=================================================</b><br>';
		echo '<b>ccPayment Response</b>';
		echo '<br><b>=================================================</b><br>';
		echo '<pre>' . htmlentities(print_r($ccAuthResponse, true)) . '</pre>';
		echo '<br><b>=================================================</b><br>';
		echo '<b>ccPayment Submission Data</b>';
		echo '<br><b>=================================================</b><br>';
		echo '<pre>' . htmlentities(print_r($xmlRequest, true)) . '</pre>';
		echo '<br><b>=================================================</b><br>';
	}
	/******************************************************************************************************/
	$auth = new stdClass();
	
	$merchantUID = 'F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3';
	$merchantToken = '5A02E47D-7E2E-452B-A940-E3E946265037N3DS';

	$merchantReference = 'merchantReference_'. date('Ymd_His');
	
	if (isset($_GET["tdsAuthenticate"]) && isset($_POST["MD"]) && isset($_POST["PaRes"]))
	{
			$xmlRequest = '<xmlField>
							<applicationUID>'.$merchantToken.'</applicationUID>
								<transactionAuth>
									<transactionIndex>'.trim ($_POST["MD"]).'</transactionIndex>
									<paresPayload>'.trim ($_POST["PaRes"]).'</paresPayload>
								</transactionAuth>
									<merchantReference>'.$merchantReference.'</merchantReference>
								<terminal>Test</terminal>
						  </xmlField>';
			$authResponse = processRequest($merchantUID, $merchantToken, 15, $xmlRequest);
			echo '<b>=================================================</b><br>';
			echo '<b>ThreeDSecure Response</b>';
			echo '<br><b>=================================================</b><br>';
			echo '<pre>' . htmlentities(print_r($authResponse, true)) . '</pre>';
			echo '<b>3D Secure Submission Data</b>';
			echo '<br><b>=================================================</b><br>';
			echo '<pre>' . htmlentities(print_r($xmlRequest, true)) . '</pre>';
			echo '<br><b>=================================================</b><br>';
		ccAuth($merchantUID, $merchantToken, $authResponse->uidTransactionIndex, $merchantReference);
	}
	elseif (isset($_GET["tdslookup"]))
	{
		$xmlRequest = '<xmlField>
							<mode>0</mode>
								<applicationUID>'.$merchantToken.'</applicationUID>
									<merchantReference>123456789012347</merchantReference>
								<terminal>Terminal1 - David</terminal>
								<cardDetails>
									<cardHolder>Test Holder</cardHolder>
									<cardNumber>4000000000000002</cardNumber>
									<expiryMonth>01</expiryMonth>
									<expiryYear>2020</expiryYear>
								</cardDetails>
								<amount>126.00</amount>
								<browserDetails>
									<userAgent>Test</userAgent>
									<browserHeader>Test</browserHeader>
									<ipAddressv4>196.30.66.11</ipAddressv4>
								</browserDetails>
						</xmlField>';

						$lookupResponse = processRequest($merchantUID, $merchantToken, 14, $xmlRequest);
		//print_r($lookupResponse);
		if (isset($lookupResponse->tdsLookup->authRequired) && $lookupResponse->tdsLookup->authRequired == 'Y')
			acsPage($lookupResponse->tdsLookup->acsUrl, 'http://localhost/Results/Results.php?tdsAuthenticate=true', $lookupResponse->tdsLookup->payload, $lookupResponse->uidTransactionIndex);
				else
			ccAuth($merchantUID, $merchantToken, $lookupResponse->uidTransactionIndex, $merchantReference);
	}
}
catch ( Exception $fault )
{
	echo '<br>=================================================<br>';
	echo '<br>                S O A P - E R R O R<br>';
	echo '<br>=================================================<br>';
	print_r ( $fault );
	echo '<br>=================================================<br>';
	print_r ( htmlspecialchars ( $client->__getLastRequest () ) );
	echo '<br>=================================================<br>';
	print_r ( htmlspecialchars ( $client->__getLastResponse () ) );
	echo '<br>=================================================<br>';
	echo $fault->getMessage ();
}
?>