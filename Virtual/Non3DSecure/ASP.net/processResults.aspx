<!---
+-----------------------------------------------------------------------------+
| MyGate Communications - ASP.NET Enterprise Auth and Settle Sample           |
| Copyright (c) 2007 MyGate Communications (Pty) Ltd                  		  |
| All rights reserved.                                                        |
+-----------------------------------------------------------------------------+
| The initial developer of the original code is MyGate Global		          |
+-----------------------------------------------------------------------------+

 * "ASP.NET MyVirtual Sample" payment page
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

<%@ Page Language="C#" ContentType="text/html" ResponseEncoding="iso-8859-1" %>
<html>
<head>
<title>ASP.NET Results</title>
</head>

<%
//Populate ASP.NET variables with the POST back variables MyGate sends
int result;

string threeDSecure;
string price;
string cardCountry;
string countryCode;
string currencyCode;
string merchantReference;
string transactionIndex;
string payMethod;

string errorCode;
string errorSource; 
string errorMessage;
string errorDetail;

string bankErrorCode;
string bankErrorMessage;

result = Convert.ToInt32(Request["_RESULT"]);
threeDSecure = Request["_3DSTATUS"];
price = Request["_AMOUNT"];
cardCountry = Request["_CARDCOUNTRY"];
countryCode = Request["_COUNTRYCODE"];
currencyCode = Request["_CURRENCYCODE"];
merchantReference = Request["_MERCHANTREFERENCE"];
transactionIndex = Request["_TRANSACTIONINDEX"];
payMethod = Request["_PAYMETHOD"];

errorCode = Request["_ERROR_CODE"];
errorSource = Request["_ERROR_SOURCE"];
errorMessage = Request["_ERROR_MESSAGE"];
errorDetail = Request["_ERROR_DETAIL"];

bankErrorCode = Request["_BANK_ERROR_CODE"];
bankErrorMessage = Request["_BANK_ERROR_MESSAGE"];

%>

<body>
	<!---The Request["_RESULT"] element of the form post is the transaction result. 0=Successful, 1=Warning (A result of 1 is returned either when the fraud module is providing a flag or if unnecessary parameters were sent to the API in the request message). Note: A result code of 1 is still a successful transaction.--->
	<%
    if (result >= 0) //Successful
    {
    %>
        Successful Transaction <br />
        Result: <%Response.Write(result);%> <br />
        3D-Secure Status: <%Response.Write(threeDSecure);%> <br />
        Processed Amount: <%Response.Write(price);%> <br />
        Card Country: <%Response.Write(cardCountry);%> <br />
        Country Code: <%Response.Write(countryCode);%> <br />
        Currency Code:<%Response.Write(currencyCode);%> <br />
        Merchant Reference:<%Response.Write(merchantReference);%> <br />
        Transaction Index:<%Response.Write(transactionIndex);%> <br />
        Pay Method:<%Response.Write(payMethod);%>
    <%
    } 
    else //Declined
    {
    %>
    	<!---In the event of a failed transaction, most merchants will only display the bank error message to the client as this will often give the most descriptive message relevant to the client. E.g. Insufficient funds, Blocked Card, etc. --->
        Failed Transaction <br />
        Result: <%Response.Write(result);%> <br />
        Error Code: <%Response.Write(errorCode);%> <br />
        Error Message: <%Response.Write(errorMessage);%> <br />
        Error Details: <%Response.Write(errorDetail);%> <br />
        Error Source: <%Response.Write(errorSource);%> <br /> <br />
        Bank Error Code: <%Response.Write(bankErrorCode);%> <br />
        Bank Error Message: <%Response.Write(bankErrorMessage);%> <br />
    <%}%>
</body>
</html>