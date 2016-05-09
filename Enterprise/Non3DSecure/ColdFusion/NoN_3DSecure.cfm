<cfset requestMessage = HTMLEditFormat("<xmlField>
										  <mode>0</mode>
										  <applicationUID>A06033E6-43CF-471A-A985-E16442ED1FFF</applicationUID>
										  <merchantReference>SALES 12345</merchantReference>
										  <cardDetails>
											<cardHolder>Joe Bloggs</cardHolder>
											<cardNumber>4111111111111111</cardNumber>
											<expiryMonth>02</expiryMonth>
											<expiryYear>2021</expiryYear>
											<cvvNumber>123</cvvNumber>
										  </cardDetails>
										  <amount>12.34</amount>
										  <billingDetails>
											<customerID>A132452345</customerID>
											<invoiceID>INV_1234</invoiceID>
											<contact>
											  <firstName>firstName</firstName>
											  <lastName>lastName</lastName>
											  <company>company</company>
											  <contactNumber>contactNumber</contactNumber>
											  <email>name@somewebsite.com</email>
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
											  <email>name@somewebsite.com</email>
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
											  <description>Tomatoes</description>
											  <unitPrice>10.00</unitPrice>
											  <quantity>1</quantity>
											  <totalAmount>10.00</totalAmount>
											</item>
											<item>
											  <description>Tomatoes</description>
											  <unitPrice>10.00</unitPrice>
											  <quantity>1</quantity>
											  <totalAmount>10.00</totalAmount>
											</item>
											<item>
											  <description>Tomatoes</description>
											  <unitPrice>10.00</unitPrice>
											  <quantity>1</quantity>
											  <totalAmount>10.00</totalAmount>
											</item>
										  </salesItems>
										  <userAgent>Test</userAgent>
										  <browserHeader>Test</browserHeader>
										  <ipAddress>
											<ipAddressv4>196.30.66.11</ipAddressv4>
										  </ipAddress>
										  <terminal>Parker - Test01</terminal>
										  <businessRules>
											<doFraudValidation>false</doFraudValidation>
											<doAddressVerification>true</doAddressVerification>
											<doCardVerification>true</doCardVerification>
										  </businessRules>
										</xmlField>")>

<cfsavecontent variable="soapBody">
    <cfoutput>
		<?xml version="1.0" encoding="UTF-8"?>
		<env:Envelope xmlns:env="http://www.w3.org/2003/05/soap-envelope" xmlns:ns1="http://api.mygateglobal.com/" xmlns:ns2="authenticate">
		<env:Header>
			<ns2:authenticate>
				<merchantUID>F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3</merchantUID>
				<merchantToken>A06033E6-43CF-471A-A985-E16442ED1FFF</merchantToken>
				<actionTypeID>1</actionTypeID>
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
   <table>
	 <table align="center"  width='50%' style="border:1px solid black;">
	  <tr>
	   <td align="center" colspan="2" style="background-color:Red; font-size:16px;"><font color="FFFFFF">Transaction Results</font></td>
		  </tr><tr>
				<td ><div align="right">TransID :</div></td>
                <td ><input type="text" style="width:400" name="TermUrl" value="#responseNodes[ 1 ].uidTransactionIndex.xmlText#"/></td>
			  </tr><tr>
				<td ><div align="right">Code :</div></td>
				<td ><input type="text" style="width:400" name="TermUrl" value="#responseNodes[ 1 ].fspmessage.code.xmlText#"/></td>
			  </tr><tr>
				  <td ><div align="right">Message :</div></td>
				  <td ><input type="text" style="width:400" name="MD" value="#responseNodes[ 1 ].fspmessage.message.xmlText#"/></td>
			  </tr><tr>
            	  <td ><div align="right">Auth Code :</div></td>
				  <td ><input type="text" style="width:400" name="MD" value="#responseNodes[ 1 ].fspmessage.authorizationCode.xmlText#"/></td>
			  </tr>
		  </table>
        ---------------------------------------------
        ---------------------------------------------<br>				  
		Request Data<br>
		---------------------------------------------
        ---------------------------------------------<br>
    </cfoutput>
    <cfoutput>
    #requestMessage#  
	</cfoutput>

</cfif>