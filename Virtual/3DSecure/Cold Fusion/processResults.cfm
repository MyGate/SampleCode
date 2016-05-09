<!---
+-----------------------------------------------------------------------------+
| MyGate Communications - ColdFusion Enterprise Auth and Settle Sample        |
| Copyright (c) 2007 MyGate Communications (Pty) Ltd                  		  |
| All rights reserved.                                                        |
+-----------------------------------------------------------------------------+
| The initial developer of the original code is MyGate Global		          |
+-----------------------------------------------------------------------------+

 * "ColdFusion MyVirtual Sample" payment page
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
<title>ColdFusion MyVirtual Results</title>
</head>

<body>

<!---Populate PHP variables with the POST back variables MyGate sends--->
<cfset Result = "#POST._RESULT#" />

<cfset ThreeDSecure = "#POST._3DSTATUS#" />
<cfset Price = "#POST._AMOUNT#" />
<cfset CardCountry = "#POST._CARDCOUNTRY#" />
<cfset CountryCode = "#POST._COUNTRYCODE#" />
<cfset CurrencyCode = "#POST._CURRENCYCODE#" />
<cfset MerchantReference = "#POST._MERCHANTREFERENCE#" />
<cfset TransactionIndex = "#POST._TRANSACTIONINDEX#" />
<cfset PayMethod = "#POST._PAYMETHOD#" />

<cfset ErrorCode = "#POST._ERROR_CODE#" />
<cfset ErrorMessage = "#POST._ERROR_MESSAGE#" />
<cfset ErrorDetail = "#POST._ERROR_DETAIL#" />
<cfset ErrorSource = "#POST._ERROR_SOURCE#" />

<cfset BankErrorCode = "#POST._BANK_ERROR_CODE#" />
<cfset BankErrorMessage = "#POST._BANK_ERROR_MESSAGE#" />

<!---The POST._RESULT element of the form post is the transaction result. 0=Successful, 1=Warning (A result of 1 is returned either when the fraud module is providing a flag or if unnecessary parameters were sent to the API in the request message). Note: A result code of 1 is still a successful transaction.--->
<cfif Result GTE 0>
	<cfoutput>
        Successful Transaction
		Result: #Result#
        3D-Secure Status: #ThreeDSecure#
        Processed Amount: #Price#
        Card Country: #CardCountry#
        Country Code: #CountryCode#
        Currency Code: #CurrencyCode#
        Merchant Reference: #MerchantReference#
        Transaction Index: #TransactionIndex#
        Pay Method: #PayMethod#
    </cfoutput>
<cfelse>
	<!---In the event of a failed transaction, most merchants will only display the bank error message to the client as this will often give the most descriptive message relevant to the client. E.g. Insufficient funds, Blocked Card, etc. --->
	<cfoutput>
        Failed Transaction
		Result: #Result#
        Error Code: #ErrorCode#
        Error Message: #ErrorMessage#
        Error Details: #ErrorDetail#
        Error Source: #ErrorSource#
        Bank Error Code: #BankErrorCode#
        Bank Error Message: #BankErrorMessage#
    </cfoutput>
</cfif>

</body>
</html>