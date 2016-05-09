package com.mygateglobal.client;

//Required for debugging
/****************************************************************************/
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

import javax.xml.namespace.QName;
import javax.xml.soap.SOAPMessage;
import javax.xml.ws.Service;
import javax.xml.ws.handler.Handler;
import javax.xml.ws.handler.HandlerResolver;
import javax.xml.ws.handler.MessageContext;
import javax.xml.ws.handler.PortInfo;
import javax.xml.ws.handler.soap.SOAPHandler;
import javax.xml.ws.handler.soap.SOAPMessageContext;
/****************************************************************************/



import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;

import com.mygateglobal.api.*;

public class apiExample
{
	/****************************************************************************/
	public static void main(String[] args)
	{

		WsAPIService apiService = new WsAPIService();

		// Required for debugging
		addDebugSupport(apiService);

		APIService api = apiService.getAPIPort();

		Authenticate authHeader = new Authenticate();
		authHeader.setMerchantUID("F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3");
		authHeader.setMerchantToken("F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3");
		
//		Action	Action Name
//		1		Authorise
//		2		Authorise - Reversal
//		3		Capture
//		4		Credits (Follow-On)
//		5		Sale
//		6		Void - Capture
//		7		Void - Credit (Follow-On)
//		8		Void - Credit (Stand-Alone)
//		9		Capture (With Auth)
//		10		Credit - Capture (With Auth)
//		11		Credits (Stand-Alone)
//		12		Credits - Sale
//		13		Void - Credit (Sale)
//		14		ThreeD Secure - Lookup
//		15		ThreeD Secure - Authenticate
//		16		Void - Sale
//		19		Reports
//		20		Visa Checkout - Decrypt		
		
		authHeader.setActionTypeID("1");

		String actionXML = getActionXML("https://api.mygateglobal.com/api/xmlactions/action_"+ authHeader.getActionTypeID() +".xml");
		
		DecimalFormat numFormat = new DecimalFormat("0.00");

		String mode = "0";
		//String applicationUID_3d = "5A02E47D-7E2E-452B-A940-E3E946265037";
		String applicationUID_non3d = "A06033E6-43CF-471A-A985-E16442ED1FFF";
		String transactionIndex = "00000000-0000-0000-0000-000000000000";
		String merchantReference = "Test_Ref1";
		String cardHolder = "Test Card";
		String cardNumber = "4111111111111111";
		String expiryMonth = "02";
		String expiryYear = "2019";
		String cvvNumber = "123";
		double amount = 10.3;
		String verbalAuthCode = "123456";
		String paresPayload = "paresPayload_goes_here";
		
		actionXML = actionXML.replace("{mode}", mode);
		actionXML = actionXML.replace("{applicationUID}", applicationUID_non3d);
		actionXML = actionXML.replace("{transactionIndex}", transactionIndex);
		actionXML = actionXML.replace("{merchantReference}", merchantReference);
		actionXML = actionXML.replace("{cardHolder}", cardHolder);
		actionXML = actionXML.replace("{cardNumber}", cardNumber);
		actionXML = actionXML.replace("{expiryMonth}", expiryMonth);
		actionXML = actionXML.replace("{expiryYear}", expiryYear);
		actionXML = actionXML.replace("{cvvNumber}", cvvNumber);
		actionXML = actionXML.replace("{amount}", numFormat.format(amount));
		actionXML = actionXML.replace("{verbalAuthCode}", verbalAuthCode);
		actionXML = actionXML.replace("{paresPayload}", paresPayload);
		
		System.out.println("Actino XML:");
		System.out.println(actionXML);

		
		ResponseMessage apiResponse = api.execRequest(actionXML, authHeader);

		System.out.println("\n\nResponse:");
		System.out.println("Status: " + apiResponse.getStatus());
		System.out.println("Transaction Index: " + apiResponse.getUidTransactionIndex());
		System.out.println("Transaction Time: " + apiResponse.getTransactionDateTime());
		if (apiResponse.getStatus().equals("-1"))
		{
			System.out.println("Failed");
			ResError errors = apiResponse.getErrors();

			System.out.println("\nErrors");
			System.out.println("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n");
			for (ResMessages error : errors.getError())
			{
				System.out.println("Error code: " + error.getCode());
				System.out.println("Error message: " + error.getMessage());
				System.out.println("Error description: " + error.getDescription());
				System.out.println("");
			}
			System.out.println("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

		} else if (apiResponse.getStatus().equals("0") || apiResponse.getStatus().equals("1"))
		{
			System.out.println("Successful");
			// Get Financial Service Provider details on credit card transaction
			// (Actions 1- 13,16,20)
			
			ResWarning warnings = apiResponse.getWarnings();
			if (warnings != null)
			{
				System.out.println("\nWarnings");
				System.out.println("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n");
				for (ResMessages warning : warnings.getWarning())
				{
					System.out.println("Warning code: " + warning.getCode());
					System.out.println("Warning message: " + warning.getMessage());
					System.out.println("Warning description: " + warning.getDescription());
					System.out.println("");
				}
				System.out.println("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
			}
			
			
			ResFspMessage fspMessage = apiResponse.getFspMessage();
			if (fspMessage != null)
				System.out.println("Do Financial Service Provider Logic");

			// Get 3D Secure Lookup details (Actions 14)
			ResTdsLookup tdsLookup = apiResponse.getTdsLookup();
			if (tdsLookup != null)
				System.out.println("Do 3D Secure Lookup Logic");

			// Get 3D Secure Authenticate details (Actions 15)
			ResTdsAuth tdsAuth = apiResponse.getTdsAuth();
			if (tdsAuth != null)
				System.out.println("Do 3D Secure Authenticate Logic");

			// Get Transaction Reporting details (Actions 19)
			String rptReport = apiResponse.getRptReports();
			if (rptReport != null)
				System.out.println("Do Transaction Reporting Logic");

		} else
		{
			System.out.println("Failed - Unknown status");
		}

	}

	public static String getActionXML(String url)
	{
		StringBuilder response = null;
		try
		{
			URL website = new URL(url);
			URLConnection connection = website.openConnection();
			BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));

			response = new StringBuilder();
			String inputLine;

			while ((inputLine = in.readLine()) != null)
				response.append(inputLine);

			in.close();
		} finally
		{
			return response.toString();
		}
	}

	/****************************************************************************/
	private static void addDebugSupport(Service service)
	{
		service.setHandlerResolver(new HandlerResolver() {
			public List<Handler> getHandlerChain(PortInfo portInfo)
			{
				List<Handler> handlerChain = new ArrayList<Handler>();
				handlerChain.add(new SOAPHandler<SOAPMessageContext>() {
					public boolean handleMessage(SOAPMessageContext context)
					{
						SOAPMessage msg = context.getMessage();

						boolean request = ((Boolean) context.get(SOAPMessageContext.MESSAGE_OUTBOUND_PROPERTY)).booleanValue();
						if (request)
						{
							System.out.println("OUTBOUND MESSAGE");

						} else
						{
							System.out.println("\n\nINBOUND MESSAGE");
						}
						try
						{
							msg.writeTo(System.out);
						} catch (Exception e)
						{
							e.printStackTrace();
						}
						return true;
					}

					public boolean handleFault(SOAPMessageContext context)
					{
						return true;
					}

					public void close(MessageContext context)
					{
					}

					public Set<QName> getHeaders()
					{
						return null;
					}
				});
				return handlerChain;
			}
		});
	}
}