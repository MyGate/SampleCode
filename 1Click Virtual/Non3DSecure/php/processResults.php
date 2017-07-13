<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta
	http-equiv="Content-Type"
	content="text/html; charset=UTF-8"
/>
<title>PHP MyVirtual Results</title>
</head>

<body>

<?php

// var_dump ( $_POST ); //Uncomment this line if you want to print out every value MyGate sends back.

// Populate PHP variables with the POST back variables MyGate sends
$result = $_POST ['_RESULT'];

$threedsecure = $_POST ["_3DSTATUS"];
$acquirerDateTime = $_POST ["_ACQUIRERDATETIME"];
$price = $_POST ["_AMOUNT"];
$cardCountry = $_POST ["_CARDCOUNTRY"];
$countryCode = $_POST ["_COUNTRYCODE"];
$currencyCode = $_POST ["_CURRENCYCODE"];
$merchantReference = $_POST ["_MERCHANTREFERENCE"];
$transactionIndex = $_POST ["_TRANSACTIONINDEX"];
$payMethod = $_POST ["_PAYMETHOD"];

$errorCode = $_POST ['_ERROR_CODE'];
$errorMessage = $_POST ['_ERROR_MESSAGE'];
$errorDetail = $_POST ['_ERROR_DETAIL'];
$errorSource = $_POST ['_ERROR_SOURCE'];

$bankErrorCode = $_POST ["_BANK_ERROR_CODE"];
$bankErrorMessage = $_POST ["_BANK_ERROR_MESSAGE"];

// The $_POST['_RESULT'] element of the form post is the transaction result. 0=Successful, 1=Warning (A result of 1 is returned either when the fraud module is providing a flag or if unnecessary parameters were sent to the API in the request message). Note: A result code of 1 is still a successful transaction.
if ($result >= 0) {
	echo ("Successful Transaction");
	echo ("<br />");
	echo ("Result: " . $result);
	echo ("<br />");
	echo ("3D-Secure Status: " . $threedsecure);
	echo ("<br />");
	echo ("Acquirer Date Time: " . $acquirerDateTime);
	echo ("<br />");
	echo ("Processed Amount: " . $price);
	echo ("<br />");
	echo ("Card Country: " . $cardCountry);
	echo ("<br />");
	echo ("Country Code: " . $countryCode);
	echo ("<br />");
	echo ("Currency Code: " . $currencyCode);
	echo ("<br />");
	echo ("Merchant Reference: " . $merchantReference);
	echo ("<br />");
	echo ("Transaction Index: " . $transactionIndex);
	echo ("<br />");
	echo ("Pay Method: " . $payMethod);
} else {
	// In the event of a failed transaction, most merchants will only display the bank error message to the client as this will often give the most descriptive message relevant to the client. E.g. Insufficient funds, Blocked Card, etc.
	echo ("Failed Transaction");
	echo ("<br />");
	echo ("Result: " . $result);
	echo ("<br />");
	echo ("Error Code: " . $errorCode);
	echo ("<br />");
	echo ("Error Message: " . $errorMessage);
	echo ("<br />");
	echo ("Error Details: " . $errorDetail);
	echo ("<br />");
	echo ("Error Source: " . $errorSource);
	echo ("<br />");
	echo ("Bank Error Code: " . $bankErrorCode);
	echo ("<br />");
	echo ("Bank Error Message: " . $bankErrorMessage);
}

?>

</body>
</html>