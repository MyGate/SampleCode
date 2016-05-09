using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Net;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace MyGate_Global__Visa_AuthActions
{
    public partial class _Default : System.Web.UI.Page
    {
        public string Authpurchase = ConfigurationManager.AppSettings["Action1"];
        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //**NB** GP: Added This Code To Ignore Certificate Validation In Staging ** Has To Be Removed When Code Is Published
                ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);

                XmlDocument AuthTransaction = new XmlDocument();

                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

                AuthTransaction.Load(Authpurchase);
                AuthTransaction.WriteTo(xmlTextWriter);

                string WS_Action1 = stringWriter.ToString();

                try
                {
                    VisaCardinal_Auth.APIServiceClient MGAPI = new VisaCardinal_Auth.APIServiceClient();

                    try
                    {
                        var AuthTransactionResponse = MGAPI.execRequest(WS_Action1);
                        
                        {
                            if (AuthTransactionResponse.status.Equals("-1"))

                            try
                            {
                                Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                Response.Write("<tr>");
                                Response.Write("<td align='center' colspan='2' style='background-color:Red; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** E R R O R S ** D U R R I N G **  I N V O K A T I O N ***</b></font></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Error Code :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + AuthTransactionResponse.errors.error.code + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Error Desc :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + AuthTransactionResponse.errors.error.message + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Remidiate Action :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + AuthTransactionResponse.errors.error.description + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>DateTime :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + AuthTransactionResponse.dtResponseSent + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>TransactionIndex :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + AuthTransactionResponse.uidTransactionIndex + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td  align='center'><a href='http://localhost:56626/SubXml/SubXml.aspx'><button>ShowAllSubMissionData</button></a></td>");
                                Response.Write("</tr>");
                                Response.Write("</table>");
                            }
                            catch (HttpUnhandledException)
                            {
                                throw new HttpUnhandledException();
                            }
                            else
                            {
                                Response.Write("<br />");
                                Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                Response.Write("<tr>");
                                Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** ACTION ** 1 ** RESULTS *** BANK ** RESPONSE ***</b></font></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>status :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='status' value='" + AuthTransactionResponse.status + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Date :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Date' value='" + AuthTransactionResponse.dtRequestReceived + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>code :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='code' value='" + AuthTransactionResponse.fspMessage.code + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Processor Response :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='processorResponse' value='" + AuthTransactionResponse.fspMessage.processorResponse + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>message :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='message' value='" + AuthTransactionResponse.fspMessage.message + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>uiTransactionIndex :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='uiTransactionIndex' value='" + AuthTransactionResponse.uidTransactionIndex + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>authorizationCode :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='authorizationCode' value='" + AuthTransactionResponse.fspMessage.authorizationCode + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>cardCountry :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='cardCountry' value='" + AuthTransactionResponse.mgMessage.cardCountry + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>currencyCode :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='currencyCode' value='" + AuthTransactionResponse.mgMessage.currencyCode + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td  align='center'><a href='http://localhost:56626/SubXml/SubXml.aspx'><button>ShowAllSubMissionData</button></a></td>");
                                Response.Write("</tr>");
                                Response.Write("</table>");
                            }
                       }
                    }
                    catch (HttpRequestValidationException)
                    {
                        throw new HttpRequestValidationException();
                    }
                }
                catch (XmlException)
                {
                    throw new XmlException();
                }
            }
            catch (HttpParseException)
            {
                throw new HttpParseException();
            }
        }
    }
}