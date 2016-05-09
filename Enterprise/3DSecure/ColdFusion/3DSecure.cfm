<cfset requestMessage = HTMLEditFormat("<xmlField>
										  <mode>0</mode>
										  <applicationUID>5A02E47D-7E2E-452B-A940-E3E946265037</applicationUID>
										  <merchantReference>123456789012347</merchantReference>
										  <terminal>Terminal1 - David</terminal>
										  <processorDetails>
											<processorId>478</processorId>
											<merchantId>mygateTEST</merchantId>
											<transactionPwd>KeSFRD6BEr</transactionPwd>
										  </processorDetails>
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
										</xmlField>")>
<cfsavecontent variable="soapBody">
    <cfoutput>
		<?xml version="1.0" encoding="UTF-8"?>
		<env:Envelope xmlns:env="http://www.w3.org/2003/05/soap-envelope" xmlns:ns1="http://api.mygateglobal.com/" xmlns:ns2="authenticate">
		<env:Header>
			<ns2:authenticate>
				<merchantUID>F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3</merchantUID>
				<merchantToken>5A02E47D-7E2E-452B-A940-E3E946265037N3DS</merchantToken>
				<actionTypeID>14</actionTypeID>
			</ns2:authenticate>
		</env:Header>
		<env:Body>
			<ns1:requestMessage>
				#requestMessage#
			</ns1:requestMessage>
		</env:Body>
		</env:Envelope> 
    </cfoutput>
</cfsavecontent>
<!--Enter Production URL Details Issued By MyGate-->
<cfhttp url="http://api.mygateglobal.com/api/api.php" method="POST" result="httpResponse"> 
	<cfhttpparam type="cgi" 
      encoded="false" 
      name="Content_Type" 
      value="application/soap+xml; charset=utf-8; action=""http://api.mygateglobal.com/execRequest""">
    <cfhttpparam type="xml" 
     value="#trim(soapBody)#"/>
 </cfhttp>
 
<cfif find( "200", httpResponse.statusCode )>
    <cfset soapResponse = xmlParse( httpResponse.fileContent ) />
    <cfset responseNodes = xmlSearch(soapResponse, "/env:Envelope/env:Body/ns1:responseMessage") />
    
   <cfoutput>
    <table align='center' width='75%' style='border: 1px solid black;'>
        <tr>
            <td align='center' colspan='2' style='background-color: Black; font-size: 14px; font-family: Verdana;'><font color='FFFFFF'><b>*** R E Q U E S T ** D A T A ** A C T I O N ** 1 4 ***</b></font></td></tr>
        <tr><td><div align='left'>mode :</div></td><td><input type='text' style='width: 550' name='mode' value='<mode>0</mode>' /></td></tr>
        <tr><td><div align='left'>applicationUID :</div></td>
            <td><input type='text' style='width: 550' name='applicationUID' value='<applicationUID>AF64C172-620D-4741-AD88-EDB0F2AF3008</applicationUID>' /></td></tr>
        <tr><td><div align='left'>merchantReference :</div></td>
            <td><input type='text' style='width: 550' name='merchantReference' value='<merchantReference>123456789012347</merchantReference>' /></td></tr>
        <tr><td><div align='left'>terminal :</div></td>
            <td><input type='text' style='width: 550' name='terminal' value='<terminal>Test</terminal>' /></td></tr>
        <tr><td><div align='left'>processorId :</div></td>
            <td><input type='text' style='width: 550' name='processorId' value='<processorId>478</processorId>' /></td></tr>
        <tr><td><div align='left'>transactionPwd :</div></td>
            <td><input type='text' style='width: 550' name='transactionPwd' value='<transactionPwd>KeSFRD6BEr</transactionPwd>' /></td></tr>
        <tr><td><div align='left'>cardHolder :</div></td>
            <td><input type='text' style='width: 550' name='cardHolder' value='<cardHolder>Joe Bloggs</cardHolder>' /></td></tr>
        <tr><td><div align='left'>cardNumber :</div></td>
            <td><input type='text' style='width: 550' name='cardNumber' value='<cardNumber>4000000000000012</cardNumber>' /></td></tr>
        <tr><td><div align='left'>expiryMonth :</div></td>
            <td><input type='text' style='width: 550' name='expiryMonth' value='<expiryMonth>01</expiryMonth>' /></td></tr>
        <tr><td><div align='left'>expiryYear :</div></td>
            <td><input type='text' style='width: 550' name='expiryYear' value='<expiryYear>2020</expiryYear>' /></td></tr>
        <tr><td><div align='left'>amount :</div></td>
            <td><input type='text' style='width: 550' name='amount' value='<amount>12.34</amount>' /></td></tr>
        <tr><td><div align='left'>userAgent :</div></td>
            <td><input type='text' style='width: 550' name='userAgent' value='<userAgent>Test</userAgent>' /></td></tr>
        <tr><td><div align='left'>browserHeader :</div></td>
            <td><input type='text' style='width: 550' name='browserHeader' value='<browserHeader>Test</browserHeader>' /></td></tr>
        <tr><td><div align='left'>ipAddressv4 :</div></td>
            <td><input type='text' style='width: 550' name='ipAddressv4' value='<ipAddressv4>196.30.66.11</ipAddressv4>' /></td>
        </tr>
    </table>
    <br />
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------<br>
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------<br>
	<table align='center' width='75%' style='border: 1px solid black;'>
        <tr>
            <td align='center' colspan='2' style='background-color: Black; font-size: 14px; font-family: Verdana;'><font color='FFFFFF'><b>*** R E Q U E S T ** D A T A ** A C T I O N ** 1 5 ***</b></font></td></tr>
        <tr><td><div align='left'>applicationUID :</div>
           </td><td><input type='text' style='width: 560' name='applicationUID' value='<applicationUID>AF64C172-620D-4741-AD88-EDB0F2AF3008</applicationUID>' /></td></tr>
        <tr><td><div align='left'>transactionIndex :</div></td>
            <td><input type='text' style='width: 560' name='transactionIndex' value='<transactionIndex>#responseNodes[ 1 ].uidTransactionIndex.xmlText#</transactionIndex>' /></td></tr>
        <tr><td><div align='left'>paresPayload :</div></td>
            <td><input type='text' style='width: 560' name='paresPayload' value='<paresPayload>#responseNodes[ 1 ].tdsLookup.payload.xmlText#</paresPayload>' /></td></tr>
        <tr><td><div align='left'>merchantReference :</div></td>
            <td><input type='text' style='width: 560' name='merchReference' value='<merchantReference>123456789012347</merchantReference>' /></td></tr>
        <tr><td><div align='left'>terminal :</div></td>
            <td><input type='text' style='width: 560' name='terminal' value='<terminal>Test</terminal>' /></td>
        </tr>
    </table>
    <br />
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------<br>
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------<br>
	<form name='frmLaunchACS' method='POST' action="#responseNodes[ 1 ].tdsLookup.acsUrl.xmlText#">
        <table align='center' width='75%' style='border: 1px solid black;'>
            <tr>
                <td align='center' colspan='2' style='background-color: Green; font-size: 14px; font-family: Verdana;'><font color='FFFFFF'><b>** POST ** DATA ** TO ** ACS ** *** ** CARD ** HOLDER ** ENROLLED **</b></font></td>
            </tr><tr><td><div align='left'>PaReq :</div></td>
                <td><textarea cols='50' rows='5' style='width: 572' name='PaReq'>"#responseNodes[ 1 ].tdsLookup.payload.xmlText#"</textarea></td></tr>
            <tr><td><div align='left'>TermUrl :</div></td>
                <td><input type='text' style='width: 572' name='TermUrl' value="http://192.168.1.100/Results/Results.php?tdsAuthenticate=true"/></td></tr>
            <tr><td><div align='left'>Transaction Index :</div></td>
                <td><input type='text' style='width: 572' name='MD' value="#responseNodes[ 1 ].uidTransactionIndex.xmlText#"/></td></tr>
            <tr><td colspan='2' align='center'><input type='submit' value='Submit Form' style='width: 250'/></td>
            </tr>
        </table>
    </form>
</cfoutput>
</cfif>