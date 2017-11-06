<?php
error_reporting(-1);
ini_set('display_errors', 'On');
set_time_limit(86400);
try
{
  /**************************************************************************************************************/
  // * The xml files here are only used as an example. It should be changed to the requirements of the customer.
  // * The sample xml can be downloaded from https://github.com/MyGate/SampleCode/tree/master/XML%20Actions
  // * or generated according to specifications on https://developers.mygateglobal.com
  /**************************************************************************************************************/

  $merchantUID = 'F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3';
  $merchantToken = 'F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3';
  $applicationUID = 'A06033E6-43CF-471A-A985-E16442ED1FFF';


	//		Action	Action Name
	//		1		 Authorise
	//		2		 Authorise - Reversal
	//		3		 Capture
	//		4		 Credits (Follow-On)
	//		14       ThreeD Secure - Lookup
	//		15	     ThreeD Secure - Authenticate
	//		21       Create Token
        //              22       Read Token
        //              23       Delete Token
        //              24       Update Token

	$actions = '21';

    //Used for Processing Transactions (Actions 1,2,3,4,14,15)
     $replace = array (
	        'mode' => '0',
	        'applicationUID' => $applicationUID,
	        'transactionIndex' => '', //populate with transaction index received from Action 14 or 15
	        'merchantReference' => "merchantReference_". date('Ymd_His'),
	        'token'=> '', //Populate with Token generated from Action 21
	        'cvvNumber' => '123',
	        'budgetPeriod' => '00',
	        'amount' => '5.00',
	        'verbalAuthCode' => '123456',
	        'paresPayload' => '',
			    'payload'=> '',);


	if (isset($_GET["tdsAuthenticate"]))
	{
    	$replace['transactionIndex'] = $_POST["MD"];
    	$replace['paresPayload'] = $_POST["PaRes"];
	}

	if (isset($_GET["lastPos"]))
    	$lastPos = $_GET["lastPos"];
    else
	    $lastPos = 0;

	$arrActionTypeID = explode(',',$actions);
    foreach ($arrActionTypeID AS $index  => $actionTypeID)
    {
        if ($index < $lastPos)
            continue;

        $actionResponse = processRequest($merchantUID, $merchantToken, $actionTypeID, $replace);
        $replace['transactionIndex'] = $actionResponse->uidTransactionIndex;

        if (isset($actionResponse->token))
        {
            $replace['token'] = $actionResponse->token;
            $replace['cardNumber'] = '4000000000011112';

        }

        if ($actionTypeID == 14)
        {
            if (isset($actionResponse->tdsLookup->authRequired) && $actionResponse->tdsLookup->authRequired == 'Y')
            {
                echo '<br><b>=================================================</b><br>';
                echo '<b>Action '.$actionTypeID.' Response</b>';
                echo '<br><b>=================================================</b><br>';
                echo '<pre>' . htmlentities(print_r($actionResponse, true)) . '</pre>';
                echo '<br><b>=================================================</b><br>';

                $index += 1;
				        echo 'https://'.$_SERVER['HTTP_HOST'].$_SERVER['PHP_SELF'].'?tdsAuthenticate=true&lastPos='.$index;
                acsPage($actionResponse->tdsLookup->acsUrl, 'http://localhost/Production/Tokenization/Tokenization.php?tdsAuthenticate=true&lastPos='.$index, $actionResponse->tdsLookup->payload, $actionResponse->uidTransactionIndex);
            }
        }



    	echo '<br><b>=================================================</b><br>';
    	echo '<b>Action '.$actionTypeID.' Response</b>';
    	echo '<br><b>=================================================</b><br>';
    	echo '<pre>' . htmlentities(print_r($actionResponse, true)) . '</pre>';
    	echo '<br><b>=================================================</b><br>';

	}
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

		/**************************************************************************************************************/
		// * The xml files here are only used as an example. It should be changed to the requirements of the customer.
		// * The sample xml can be downloaded from https://github.com/MyGate/SampleCode/tree/master/XML%20Actions
		// * or generated according to specifications on https://developers.mygateglobal.com
    /**************************************************************************************************************/

		$arrContextOptions=array("ssl"=>array( "verify_peer"=>false, "verify_peer_name"=>false,'crypto_method' => STREAM_CRYPTO_METHOD_TLS_CLIENT));

        if($actionTypeID == 14 || $actionTypeID == 1) {
            $file = file_get_contents('https://api.mygateglobal.com/api/xmlactions/action_'.$actionTypeID.'_Tokenization.xml', false, stream_context_create($arrContextOptions));
            $search = array('{mode}','{applicationUID}','{transactionIndex}','{merchantReference}','{token}','{cvvNumber}','{budgetPeriod}','{amount}','{verbalAuthCode}','{paresPayload}','{payload}','{callid}');
        }

        else
        {
            $file = file_get_contents('https://api.mygateglobal.com/api/xmlactions/action_'.$actionTypeID.'.xml', false, stream_context_create($arrContextOptions));
            $search = array('{mode}','{applicationUID}','{transactionIndex}','{merchantReference}','{token}','{cvvNumber}','{budgetPeriod}','{amount}','{verbalAuthCode}','{paresPayload}','{payload}','{callid}');
        }


        // Comment out when doing action 21 - 24 / Uncomment when doing actions 1,2,3,4,14,15
      	//   $xmlRequest = str_replace($search, $replace, $file);

/***********************************************************************************/


        //Action 21
  	$xmlRequest	= '<xmlField>
    			 <applicationUID>A06033E6-43CF-471A-A985-E16442ED1FFF</applicationUID>
    			 <merchantReference>Tokenization</merchantReference>
    			 <cardDetails>
    			 <cardHolder>Test Card</cardHolder>
    			 <cardNumber>4000000000000002</cardNumber>
    			 <expiryMonth>01</expiryMonth>
    			 <expiryYear>2020</expiryYear>
    			 </cardDetails>
                 </xmlField>';


    		//Action 22,23
/*     		$xmlRequest = '<xmlField>
    			 <applicationUID>A06033E6-43CF-471A-A985-E16442ED1FFF</applicationUID>
    			 <token></token>
    			 <merchantReference>Tokenization</merchantReference>
    		   	 </xmlField>';
*/

    		 //Action 24
/*    		 $xmlRequest = '<xmlField>
    			 <applicationUID>A06033E6-43CF-471A-A985-E16442ED1FFF</applicationUID>
    			 <token></token>
    			 <merchantReference>Tokenization</merchantReference>
    			 <cardDetails>
    			 <cardHolder>Test User</cardHolder>
    			 <cardNumber>4111111111111111</cardNumber>
    			 <expiryMonth>11</expiryMonth>
    			 <expiryYear>2022</expiryYear>
    			 </cardDetails>
    			 <!-- <bankAccount>
    			 <accountHolder>Joe Soap</accountHolder>
    			 <bank>FNB</bank>
    			 <branch>Cape Town</branch>
    			 <accountNumber></accountNumber>
    			 <branchCode>203109</accountNumber>
    			 </bankAccount>
    			 <bitcoinWallet>
    			 <userName></userName?>
    			 <privateKey></privateKey>
    			 </bitcoinWallet>
    			 <keyValuePair>
    			 <key></key>
    			 <value></value>
    			 </keyValuePair>
    			 -->
    			</xmlField>';

*/

/*************************************************************************************************/
		$auth = new stdClass();

		$auth->merchantUID = $merchantUID;
		$auth->merchantToken = $merchantToken;
		$auth->actionTypeID = $actionTypeID;

		$auth_vals    = new SoapVar($auth, SOAP_ENC_OBJECT);
		$authenticate = new SoapHeader($ns,'authenticate',$auth_vals, false);
		$client = new SoapClient ( $url, array ('soap_version' => SOAP_1_1,
		        'trace' => 1,
		        'exceptions' => true,
		        'cache_wsdl'=>WSDL_CACHE_NONE,
		        'stream_context' => stream_context_create($arrContextOptions)
		) );

		$client->__setSoapHeaders(array($authenticate));
		$rtnResults = $client->execRequest ( new SoapVar ($xmlRequest, XSD_STRING) );

		return $rtnResults;
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
				document.getElementById("frmLaunchACS").submit();
			</script>');
		exit;
}
?>
