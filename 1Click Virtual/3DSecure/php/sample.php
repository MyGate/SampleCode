<!---
+-----------------------------------------------------------------------------+
| MyGate Communications - PHP Enterprise Auth and Settle Sample               |
| Copyright (c) 2007 MyGate Communications (Pty) Ltd                  		  |
| All rights reserved.                                                        |
+-----------------------------------------------------------------------------+
| The initial developer of the original code is MyGate Global		          |
+-----------------------------------------------------------------------------+
 * "PHP MyVirtual Sample" payment page
 *
 * @category   Code Sample
 * @package    MyGate Communications (Pty) Ltd
 * @subpackage Virtual Transaction (Please contact MyGate to enable immediate settlement if your account requires it)
 * @author     MyGate Global - support@mygateglobal.com
 * @copyright  Copyright (c) 2007 MyGate Communications (Pty) Ltd
 * @link       http://www.mygateglobal.com/
 * 
 * @Note	   This code serves as an example only. It is not recommended that you use this code for production purposes.
 --->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>PHP MyVirtual Example</title>
</head>
<body>
<?php
//Setting variables for use in the webservice invokation...
$URL = "https://virtual.mygateglobal.com/PaymentPage.cfm";
$Mode = "0"; //0 = Test Mode. 1 = Live Mode
$MerchantID = "F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3";
$ApplicationID = "C572C9CC-F2C8-4DC8-AC5E-48784B83AB35";
//Currency and price of transaction
$Price = "0.01";
$Currency = "ZAR";
//Merchant Reference
$MerchantReference = "";
//Client Token
$ClientToken = "YourUniqueToken";
//Redirect Details
$RedirectSuccess = "http://localhost:8888/CodeSnippets/Virtual/processResults.php";
$RedirectFailed = "http://localhost:8888/CodeSnippets/Virtual/processResults.php";
?>
<h1>My Virtual Example</h1>
<form name="Virtual Post" action="<?php echo($URL); ?>" method="post">
    <input name="Mode" type="hidden" value="<?php echo($Mode); ?>" /> <br />
    <input name="MerchantID" type="hidden" value="<?php echo($MerchantID); ?>" /><br />
    <input name="ApplicationID" type="hidden" value="<?php echo($ApplicationID); ?>" /><br />
    <input name="MerchantReference" type="hidden" value="<?php echo($MerchantReference); ?>" /><br />
    <input name="RedirectSuccessfulURL" type="hidden" value="<?php echo($RedirectSuccess); ?>" /><br />
    <input name="RedirectFailedURL" type="hidden" value="<?php echo($RedirectFailed); ?>" /><br />
	<input name="Amount" type="hidden" value="<?php echo($Price); ?>" /><br />
    Amount: R<input name="Price" type="text" value="<?php echo($Price); ?>" /><br />
	<input name="CurrencyCode" type="hidden" value="<?php echo($Currency); ?>" /><br />
    <input name="DisplayPrice" type="hidden" value="<?php echo($Price); ?>" /><br />
    <input name="DisplayCurrencyCode" type="hidden" value="<?php echo($Currency); ?>" /><br />
	<input name="ClientToken" type="hidden" value="<?php echo($ClientToken); ?>" /><br />
    <input type="submit" name="submit" value="Process Transaction">
</form>
</body>
</html>
