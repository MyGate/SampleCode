<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>PHP MyVirtual Example</title>
</head>

<body>

<?php

$Mode = "0"; 
$MerchantID = "F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3";
$ApplicationID = "1DBBBAAE-958E-4346-A27A-6BB5171CEEDC";
$Price = "12.34";
$Currency = "USD";
$MerchantReference = "";
$RedirectSuccess = "http://localhost/Sample/php/processResults.php";
$RedirectFailed = "http://localhost/Sample/php/processResults.php";
?>

<h1>My Virtual Example</h1>

<form name="PostTest"  onSubmit="return chkTerms()" action="https://virtual.mygateglobal.com/PaymentPage.cfm" method="post">
        <table width="800" border="0" cellpadding="0" cellspacing="0" bordercolor="#f8f9e8"  style="background-image: url())">
            <tr valign="top"> 
                <td height="500">
                    <table border="0">
                        <tr>
                            <th rowspan="2"><br></th>
                            <th align="left">Payment Amount:</th>
                            <td width="5">&nbsp;</td>
                            <td>1.23</td>
                        </tr>
                        <tr>
                            <th align="left">Payment For:</th>
                            <td width="5">&nbsp;</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td width="5">&nbsp;</td>
                            <th align="left">Merchant Reference : </th>
                            <td width="5">&nbsp;</td>
                            <td>
                                <input type="text" id="txtMerchantReference" name="txtMerchantReference" value="My Merchant Ref #">
                            </td>
                        </tr>
                    </table>
                   
                    <input type="hidden" id="txtRecipient" name="txtRecipient" value="Someone">
                    <input type="hidden" id="Mode" name="Mode" value="0">
                    <input type="hidden" name="txtMerchantID" value="F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3">
                    <input type="hidden" name="txtApplicationID" value="1DBBBAAE-958E-4346-A27A-6BB5171CEEDC">
                    <input type="hidden" name="txtPrice" value="1.23">
					<input type="hidden" name="txtCurrencyCode" value="USD">
                    <!--- change to your live/test environment URLs --->
					<input type="hidden" name="txtRedirectSuccessfulURL" value="http://localhost:8888/test/processResults.php">
                    <input type="hidden" name="txtRedirectFailedURL" value="http://localhost:8888/test/processResults.php">
                    <input type="hidden" name="TXTDISCOUNT" value="0">
                    <input type="hidden" name="TXTITEMAMOUNT1" value="89">
                    <input type="hidden" name="TXTITEMAMOUNT2" value="30">
                    <input type="hidden" name="TXTITEMAMOUNT3" value="35">
                    <input type="hidden" name="TXTITEMAMOUNT4" value="35">
                    <input type="hidden" name="TXTITEMDESCR1" value="desc 1">
                    <input type="hidden" name="TXTITEMDESCR2" value="desc 2">
                    <input type="hidden" name="TXTITEMDESCR3" value="desc 3">
                    <input type="hidden" name="TXTITEMDESCR4" value="desc 4">
                    <input type="hidden" name="TXTITEMREF1" value="Item Ref 15784 - 018179">
                    <input type="hidden" name="TXTITEMREF2" value="Item Ref 17872 - 012482">
                    <input type="hidden" name="TXTITEMREF3" value="Item Ref 19421 - 015497">
                    <input type="hidden" name="TXTITEMREF4" value="Item Ref 13355 - 010766">
                    <input type="hidden" name="TXTQTY1" value="1">
                    <input type="hidden" name="TXTQTY2" value="1">
                    <input type="hidden" name="TXTQTY3" value="1">
                    <input type="hidden" name="TXTQTY4" value="1">
                    <input type="hidden" name="TXTRECIPIENT" value="Cisco Sam">
                    <input type="hidden" name="TXTSHIPPINGADDRESS1" value="42 Somewhere Road">
                    <input type="hidden" name="TXTSHIPPINGADDRESS2" value="Somewheresville">
                    <input type="hidden" name="TXTSHIPPINGADDRESS3" value="Some Provide">
                    <input type="hidden" name="TXTSHIPPINGADDRESS4" value="Some Country">
                    <input type="hidden" name="TXTSHIPPINGADDRESS5" value="1701">
                    <input type="hidden" name="TXTSHIPPINGCOST" value="65">
                    
                    <b style="color: black">I Have carefully read the above terms and conditions, and agree to abide by them</b>:<br>
                    I agree <input type="radio" name="tc[]" value="1" checked="true">  I do not agree <input type="radio" name="tc[]" value="0"><p>
                    <input type="submit" value="Continue" onClick="return chkParms(this.form)">
                    
                    </form>

</body>  
</html>  