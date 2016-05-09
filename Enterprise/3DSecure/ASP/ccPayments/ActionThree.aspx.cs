using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace MyGate_Global_3D_Secure_Enterprise_Example.ccPayments
{
    public partial class ActionThree : System.Web.UI.Page
    {
        public string ccPayements_3 = ConfigurationManager.AppSettings["ccPayements_3"];

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument Action_14 = new XmlDocument();
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

                Action_14.Load(ccPayements_3);
                Action_14.WriteTo(xmlTextWriter);

                string WS_Action3 = stringWriter.ToString();
                
                ccPaymentsActionThree.APIServiceClient PerformSettle = new ccPaymentsActionThree.APIServiceClient();

                try
                {
                    var ResponseSettleTransaction = PerformSettle.execRequest(WS_Action3);

                    if(ResponseSettleTransaction.status.Equals("-1"))
                        
                        try
                        {
                            Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                            Response.Write("<tr>");
                            Response.Write("<td align='center' colspan='2' style='background-color:Red; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** E R R O R S ** D U R R I N G **  I N V O K A T I O N ***</b></font></td>");
                            Response.Write("</tr>");
                            Response.Write("<tr>");
                            Response.Write("<td ><div align='left'>Error Code :</div></td>");
                            Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + ResponseSettleTransaction.errors.error.code + "'/></td>");
                            Response.Write("</tr>");
                            Response.Write("<tr>");
                            Response.Write("<td ><div align='left'>Error Desc :</div></td>");
                            Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ResponseSettleTransaction.errors.error.message + "'/></td>");
                            Response.Write("</tr>");
                            Response.Write("<tr>");
                            Response.Write("<td ><div align='left'>Remidiate Action :</div></td>");
                            Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ResponseSettleTransaction.errors.error.description + "'/></td>");
                            Response.Write("</tr>");
                            Response.Write("<tr>");
                            Response.Write("<td ><div align='left'>DateTime :</div></td>");
                            Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ResponseSettleTransaction.dtResponseSent + "'/></td>");
                            Response.Write("</tr>");
                            Response.Write("<tr>");
                            Response.Write("<td ><div align='left'>TransactionIndex :</div></td>");
                            Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ResponseSettleTransaction.uidTransactionIndex + "'/></td>");
                            Response.Write("</tr>");
                            Response.Write("<tr>");
                            Response.Write("<td  align='center'><a href='http://localhost:33213/Response_SubData/UpdateXML.aspx'><button>Show SubMission Data</button></a></td>");
                            Response.Write("</tr>");
                            Response.Write("</table>");
                        }
                        catch(HttpParseException)
                        {
                            throw new HttpParseException();
                        }
                    else
                    {
                        Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                        Response.Write("<tr>");
                        Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** ACTION ** 1 ** RESULTS *** BANK ** RESPONSE ***</b></font></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>status :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='status' value='" + ResponseSettleTransaction.status + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>Date :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='Date' value='" + ResponseSettleTransaction.dtRequestReceived + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>code :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='code' value='" + ResponseSettleTransaction.fspMessage.code + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>Processor Response :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='processorResponse' value='" + ResponseSettleTransaction.fspMessage.processorResponse + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>message :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='message' value='" + ResponseSettleTransaction.fspMessage.message + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>uiTransactionIndex :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='uiTransactionIndex' value='" + ResponseSettleTransaction.uidTransactionIndex + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>authorizationCode :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='authorizationCode' value='" + ResponseSettleTransaction.fspMessage.authorizationCode + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>cardCountry :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='cardCountry' value='" + ResponseSettleTransaction.mgMessage.cardCountry + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>currencyCode :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='currencyCode' value='" + ResponseSettleTransaction.mgMessage.currencyCode + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("<tr>");
                        Response.Write("<td ><div align='left'>eciFlag :</div></td>");
                        Response.Write("<td ><input type='text' style='width:572' name='eciFlag' value='" + ResponseSettleTransaction.mgMessage.eciFlag + "'/></td>");
                        Response.Write("</tr>");
                        Response.Write("</table>");
                    }
                }
                catch (HttpException)
                {
                    throw new HttpException();
                }
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
    }
}