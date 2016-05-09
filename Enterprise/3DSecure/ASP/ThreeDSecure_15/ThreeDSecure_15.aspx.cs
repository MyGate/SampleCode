using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;

namespace MyGateGlobalVisa3DSIntergration.ThreeDSecure_15
{
    public partial class ThreeDSecure_15 : System.Web.UI.Page
      {
        public string ThreeDSecure15 = ConfigurationManager.AppSettings["ThreeDSecure15"];
        public string ccPayements_1 =  ConfigurationManager.AppSettings["ccPayements_1"];
        public string ccPayements_2 =  ConfigurationManager.AppSettings["ccPayements_2"];
        public string ccPayements_3 =  ConfigurationManager.AppSettings["ccPayements_3"];
        public string AuthTxnID = "";

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string MD = Request.Form["MD"];
                string PaRes = Request.Form["PaRes"];

                try
                {
                    XmlDocument Action15_XML = new XmlDocument();
                    Action15_XML.Load(ThreeDSecure15);
                    Action15_XML.SelectSingleNode("//transactionIndex").InnerText = MD;
                    Action15_XML.SelectSingleNode("//paresPayload").InnerText = PaRes;
                    Action15_XML.Save(ThreeDSecure15);

                    try 
                    {
                        XmlDocument Action_15 = new XmlDocument();
                        StringWriter stringWriter = new StringWriter();
                        XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

                        Action_15.Load(ThreeDSecure15);
                        Action_15.WriteTo(xmlTextWriter);

                        string WS_Action15 = stringWriter.ToString();
                        
                        //**NB** GP: Added This Code To Ignore Certificate Validation In Staging ** Has To Be Removed When Code Is Published
                        ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);

                        MyGate_Global_3D_Secure_Enterprise_Example.Authenticate.APIServiceClient ThreeDSecureAuthenticate = new MyGate_Global_3D_Secure_Enterprise_Example.Authenticate.APIServiceClient();

                        try
                        {
                            var ThreeDSecureAuthenticateResponse = ThreeDSecureAuthenticate.execRequest(WS_Action15);

                            if (ThreeDSecureAuthenticateResponse.status.Equals("0"))
                            {
                                Response.Write("<br />");
                                Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                Response.Write("<tr>");
                                Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** AUTHENTICATION RESULTS *** CARD ** HOLDER ** ENROLLED ***</b></font></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>cavv :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='cavv' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.cavv + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>code :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Code' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.code + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>eciFlag :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='eciFlag' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.eciFlag + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Liability Shift :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Liability Shift' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.liabilityShift + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>message :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='message' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.message + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>ParesStatus :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='ParesStatus' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.paresStatus + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>signatureVerification :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='signatureVerification' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.signatureVerification + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>xid :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='xid' value='" + ThreeDSecureAuthenticateResponse.tdsAuth.xid + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td  align='center'><a href='http://localhost:33213/Response_SubData/UpdateXML.aspx'><button>ShowAllSubMissionData</button></a></td>");
                                Response.Write("</tr>");
                                Response.Write("</table>");
                            }
                            else

                                if (ThreeDSecureAuthenticateResponse.status.Equals("-1"))
                                {

                                    Response.Write("<br />");
                                    Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                    Response.Write("<tr>");
                                    Response.Write("<td align='center' colspan='2' style='background-color:Red; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** E R R O R S ** D U R R I N G **  I N V O K A T I O N ***</b></font></td>");
                                    Response.Write("</tr>");
                                    Response.Write("<tr>");
                                    Response.Write("<td ><div align='left'>Error Code :</div></td>");
                                    Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + ThreeDSecureAuthenticateResponse.errors.error.code + "'/></td>");
                                    Response.Write("</tr>");
                                    Response.Write("<tr>");
                                    Response.Write("<td ><div align='left'>Error Desc :</div></td>");
                                    Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecureAuthenticateResponse.errors.error.message + "'/></td>");
                                    Response.Write("</tr>");
                                    Response.Write("<tr>");
                                    Response.Write("<td ><div align='left'>Remidiate Action :</div></td>");
                                    Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecureAuthenticateResponse.errors.error.description + "'/></td>");
                                    Response.Write("</tr>");
                                    Response.Write("<tr>");
                                    Response.Write("<td ><div align='left'>DateTime :</div></td>");
                                    Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecureAuthenticateResponse.dtResponseSent + "'/></td>");
                                    Response.Write("</tr>");
                                    Response.Write("<tr>");
                                    Response.Write("<td ><div align='left'>TransactionIndex :</div></td>");
                                    Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecureAuthenticateResponse.uidTransactionIndex + "'/></td>");
                                    Response.Write("</tr>");
                                    Response.Write("<tr>");
                                    Response.Write("<td  align='center'><a href='http://localhost:33213/Response_SubData/UpdateXML.aspx'><button>Show SubMission Data</button></a></td>");
                                    Response.Write("</tr>");
                                    Response.Write("</table>");
                                }
                        }
                        catch (HttpRequestValidationException CallWS_ACT15_PostConstruction)
                        {
                            PageEvent.LogErrorIntoTextFile(CallWS_ACT15_PostConstruction, "ThreeDSecure_15: CallWS_ACT15_PostConstruction");
                        }
                    }
                    catch (XmlException ConstructAction_15_XML_Doccument)
                    {
                        PageEvent.LogErrorIntoTextFile(ConstructAction_15_XML_Doccument, "ThreeDSecure_15: ConstructAction_15_XML_Doccument");
                    }
                    try
                    {
                        XmlDocument Action1_XML = new XmlDocument();
                        Action1_XML.Load(ccPayements_1);
                        Action1_XML.SelectSingleNode("//transactionIndex").InnerText = MD;
                        Action1_XML.Save(ccPayements_1);

                        try
                        {
                            AuthTxnID = MD;
                        }
                        catch (NullReferenceException PrePareForAction_1)
                        {
                            PageEvent.LogErrorIntoTextFile(PrePareForAction_1, "ThreeDSecure_15: PrePareForAction_1");
                        }

                        try
                        {
                            XmlDocument Action_1 = new XmlDocument();
                            StringWriter stringWriter = new StringWriter();
                            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

                            Action_1.Load(ccPayements_1);
                            Action_1.WriteTo(xmlTextWriter);

                            string WS_Action_1 = stringWriter.ToString();

                            MyGate_Global_3D_Secure_Enterprise_Example.ccPayments.APIServiceClient ccPayment = new MyGate_Global_3D_Secure_Enterprise_Example.ccPayments.APIServiceClient();

                            try
                            {
                                if (AuthTxnID == MD)
                                {
                                    var Action_1_Response = ccPayment.execRequest(WS_Action_1);
                                    
                                    if(Action_1_Response.status.Equals("0"))
                                    {
                                        Response.Write("<br />");
                                        Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                        Response.Write("<tr>");
                                        Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** ACTION ** 1 ** RESULTS *** BANK ** RESPONSE ***</b></font></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>status :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='status' value='" + Action_1_Response.status + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>Date :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='Date' value='" + Action_1_Response.dtRequestReceived + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>code :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='code' value='" + Action_1_Response.fspMessage.code + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>Processor Response :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='processorResponse' value='" + Action_1_Response.fspMessage.processorResponse + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>message :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='message' value='" + Action_1_Response.fspMessage.message + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>uiTransactionIndex :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='uiTransactionIndex' value='" + Action_1_Response.uidTransactionIndex + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>authorizationCode :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='authorizationCode' value='" + Action_1_Response.fspMessage.authorizationCode + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>cardCountry :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='cardCountry' value='" + Action_1_Response.mgMessage.cardCountry + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>currencyCode :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='currencyCode' value='" + Action_1_Response.mgMessage.currencyCode + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>eciFlag :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='eciFlag' value='" + Action_1_Response.mgMessage.eciFlag + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td  align='center'><a href='http://localhost:33213/Response_SubData/UpdateXML.aspx'><button>Show SubMission Data</button></a></td>");
                                        Response.Write("</tr>");
                                        Response.Write("</table>");

                                        try
                                        {
                                            XmlDocument Action3_XML = new XmlDocument();
                                            Action3_XML.Load(ccPayements_3);
                                            Action3_XML.SelectSingleNode("//transactionIndex").InnerText = MD;
                                            Action3_XML.Save(ccPayements_3);

                                            XmlDocument Action2_XML = new XmlDocument();
                                            Action2_XML.Load(ccPayements_2);
                                            Action2_XML.SelectSingleNode("//transactionIndex").InnerText = MD;
                                            Action2_XML.Save(ccPayements_2);
                                        }
                                        catch (XmlException)
                                        {
                                            throw new XmlException();
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<br />");
                                        Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                        Response.Write("<tr>");
                                        Response.Write("<td align='center' colspan='2' style='background-color:Red; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** A C T I O N - 1 **  E R R O R S ** D U R R I N G **  I N V O K A T I O N ***</b></font></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>Error Code :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + Action_1_Response.errors.error.code + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>Error Desc :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + Action_1_Response.errors.error.message + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>Remidiate Action :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + Action_1_Response.errors.error.description + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>DateTime :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + Action_1_Response.dtResponseSent + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>TransactionIndex :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + Action_1_Response.uidTransactionIndex + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td  align='center'><a href='http://localhost:33213/Response_SubData/UpdateXML.aspx'><button>Show SubMission Data</button></a></td>");
                                        Response.Write("</tr>");
                                        Response.Write("</table>");
                                    }
                                }
                            }
                            catch (HttpRequestValidationException CallWS_ACT1_PostConstruction)
                            {
                                PageEvent.LogErrorIntoTextFile(CallWS_ACT1_PostConstruction, "ThreeDSecure_15: CallWS_ACT1_PostConstruction");
                            }
                        }
                        catch (XmlException ConstructAction_1_XML_Doccument)
                        {
                            PageEvent.LogErrorIntoTextFile(ConstructAction_1_XML_Doccument, "ThreeDSecure_15: ConstructAction_1_XML_Doccument");
                        }
                    }
                    catch (XmlException UpdateAction_1_RequestData)
                    {
                        PageEvent.LogErrorIntoTextFile(UpdateAction_1_RequestData, "ThreeDSecure_15: UpdateAction_1_RequestData");
                    }
                }
                catch (XmlException UpdateAction_15_RequestData)
                {
                    PageEvent.LogErrorIntoTextFile(UpdateAction_15_RequestData, "ThreeDSecure_15: UpdateAction_15_RequestData");
                }
            }
            catch (NullReferenceException SetPostBackValues)
            {
                PageEvent.LogErrorIntoTextFile(SetPostBackValues, "ThreeDSecure_15: SetPostBackValues");
            }
        }
    }
}


   
