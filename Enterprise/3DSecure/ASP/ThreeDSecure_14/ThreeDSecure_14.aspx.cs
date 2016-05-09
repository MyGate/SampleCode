using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;
using System.Web.Services;
using System.Configuration;
using System.Net;

namespace MyGateGlobalVisa3DSIntergration.ThreeDSecure_14
{
    public partial class ThreeDSecure_14 : System.Web.UI.Page
    {
        public string ACSCallbackURL = ConfigurationManager.AppSettings["ACSCallbackURL"];
        public string ThreeDSecureLoopUp14 = ConfigurationManager.AppSettings["ThreeDSecure14"];
        
        private void Page_Load(object sender, EventArgs e)
        {   //**NB** GP: Added This Code To Ignore Certificate Validation In Staging ** Has To Be Removed When Code Is Published
            ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);
            {
                try
                {
                    XmlDocument Action_14 = new XmlDocument();
                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);

                    Action_14.Load(ThreeDSecureLoopUp14);
                    Action_14.WriteTo(xmlTextWriter);

                    string WS_Action14 = stringWriter.ToString();
                    
                    MyGate_Global_3D_Secure_Enterprise_Example.API.APIServiceClient MGAPI = new MyGate_Global_3D_Secure_Enterprise_Example.API.APIServiceClient();

                    try
                    {
                        var ThreeDSecure_LookUp_Response = MGAPI.execRequest(WS_Action14);

                        try
                        {   
                            if (ThreeDSecure_LookUp_Response.status.Equals("-1"))
                            {
                                Response.Write("<br />");
                                Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                Response.Write("<tr>");
                                Response.Write("<td align='center' colspan='2' style='background-color:Red; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** E R R O R S ** D U R R I N G **  I N V O K A T I O N ***</b></font></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Error Code :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + ThreeDSecure_LookUp_Response.errors.error.code + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Error Desc :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecure_LookUp_Response.errors.error.message + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>Remidiate Action :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecure_LookUp_Response.errors.error.description + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>DateTime :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecure_LookUp_Response.dtResponseSent + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td ><div align='left'>TransactionIndex :</div></td>");
                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecure_LookUp_Response.uidTransactionIndex + "'/></td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td  align='center'><a href='http://localhost:33213/Response_SubData/UpdateXML.aspx'><button>Show SubMission Data</button></a></td>");
                                Response.Write("</tr>");
                                Response.Write("</table>");
                            }
                            else
                            {
                                try
                                {
                                    //CARD HOLDER ENROLLED
                                    if (ThreeDSecure_LookUp_Response.tdsLookup.enrolled.Equals("Y"))
                                    {
                                        Response.Write("<br />");
                                        Response.Write("<form name='frmLaunchACS' runat ='server' method='POST' action='" + ThreeDSecure_LookUp_Response.tdsLookup.acsUrl + "'>");
                                        Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                        Response.Write("<tr>");
                                        Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>** POST ** DATA ** TO ** ACS ** *** ** CARD ** HOLDER ** ENROLLED **</b></font></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>PaReq :<font><font color='FFFFFF'>__________</font></div></td>");
                                        Response.Write("<td ><textarea cols='50' rows='5' style='width:550' name='PaReq' >" + ThreeDSecure_LookUp_Response.tdsLookup.payload + "</textarea></textarea></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>TermUrl :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:550' name='TermUrl' value='" + ACSCallbackURL + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td ><div align='left'>MD :</div></td>");
                                        Response.Write("<td ><input type='text' style='width:550' name='MD' value='" + ThreeDSecure_LookUp_Response.uidTransactionIndex + "'/></td>");
                                        Response.Write("</tr>");
                                        Response.Write("<tr>");
                                        Response.Write("<td colspan='2' align='center'><input type='submit' value='Submit Form' runat= server'style='width:250'></td>");
                                        Response.Write("</tr>");
                                        Response.Write("</table>");
                                        Response.Write("</form>");
                                    }
                                    else
                                    {
                                        try
                                        {   //CARD HOLDER NOT ENROLLED OR UNDEFINED
                                            if (ThreeDSecure_LookUp_Response.tdsLookup.enrolled.Equals("N") || ThreeDSecure_LookUp_Response.tdsLookup.enrolled.Equals("U"))
                                            {
                                                Response.Write("<br />");
                                                Response.Write("<table align='center'  width='75%' style='border:1px solid black;'>");
                                                Response.Write("<tr>");
                                                Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** LOOKUP RESULTS *** CARD ** HOLDER ** NOT ENROLLED ***</b></font></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td ><div align='left'>Enrolled :</div></td>");
                                                Response.Write("<td ><input type='text' style='width:572' name='Error Desc' value='" + ThreeDSecure_LookUp_Response.tdsLookup.enrolled + "'/></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td ><div align='left'>ECI Flag :</div></td>");
                                                Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + ThreeDSecure_LookUp_Response.tdsLookup.eciFlag + "'/></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td ><div align='left'>Auth Required :</div></td>");
                                                Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + ThreeDSecure_LookUp_Response.tdsLookup.authRequired + "'/></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td ><div align='left'>Liability Shift :</div></td>");
                                                Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + ThreeDSecure_LookUp_Response.tdsLookup.liabilityShift + "'/></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td ><div align='left'>DateTime :</div></td>");
                                                Response.Write("<td ><input type='text' style='width:572' name='Error Code' value='" + ThreeDSecure_LookUp_Response.dtResponseSent + "'/></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td ><div align='left'>TransactionIndex :</div></td>");
                                                Response.Write("<td ><input type='text' style='width:572' name='TransactionIndex' value='" + ThreeDSecure_LookUp_Response.uidTransactionIndex + "'/></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td ><div align='left'>Message :</div></td>");
                                                Response.Write("<td ><input type='text' style='width:572' name='Message' value='" + ThreeDSecure_LookUp_Response.tdsLookup.message + "'/></td>");
                                                Response.Write("</tr>");
                                                Response.Write("<tr>");
                                                Response.Write("<td  align='center'><a href='http://localhost:33213/Response_SubData/UpdateXML.aspx'><button>Show SubMission Data</button></a></td>");
                                                Response.Write("</tr>");
                                                Response.Write("</table>");
                                            }
                                        }
                                        catch (InvalidDataException DataMissMatch)
                                        {
                                            PageEvent.LogErrorIntoTextFile(DataMissMatch, "ThreeDSecure_14: ThreeDSecure_LookUp_Response");
                                        }
                                    }
                                }
                                catch (XmlException WriteRequestData)
                                {
                                    PageEvent.LogErrorIntoTextFile(WriteRequestData, "ThreeDSecure_14: RequestXML_14.Load(Action_14_3DSLookUp)");
                                }
                            }
                        }
                        catch (HttpRequestValidationException requestVarrialbes)
                        {
                            PageEvent.LogErrorIntoTextFile(requestVarrialbes, "ThreeDSecure_14: ThreeDSecure");
                        }
                    }
                    catch (DataMisalignedException Response)
                    {
                        PageEvent.LogErrorIntoTextFile(Response, "ThreeDSecure_14: Error Mapping Response To Action 15 XML");
                    }
                }
                catch (NullReferenceException ResError)
                {
                    PageEvent.LogErrorIntoTextFile(ResError, "ThreeDSecure_14: Error Retrieving Response From WebService Action 14");
                }
            }
        }
    }
}





