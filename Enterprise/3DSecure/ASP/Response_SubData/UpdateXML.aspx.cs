using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;
using System.Configuration;

namespace MyGateGlobalVisa3DSIntergration.UpdateXML
{
    public partial class UpdateXML : System.Web.UI.Page
    {
        public string ThreeDSecureLoopUp14 = ConfigurationManager.AppSettings["ThreeDSecure14"];
        public string ThreeDSecureAuthenticate15 = ConfigurationManager.AppSettings["ThreeDSecure15"];
        public string ccPayements_1 = ConfigurationManager.AppSettings["ccPayements_1"];
        public string Submissionxml14 = "";
        public string Submissionxml15 = "";
        public string Submissionxml1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument WebServiceSubmissionDoc14 = new XmlDocument();
            WebServiceSubmissionDoc14.Load(ThreeDSecureLoopUp14);

            var Submissionxml14 = WebServiceSubmissionDoc14.OuterXml;

            Response.Write("<table align='center' width='75%' style='border:10px solid black;'>");
            Response.Write("<tr>");
            Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** A C T I O N ** 14 S U B M I S S I O N ** D A T A ***</b></font></td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td align='center'><textarea rows='1' style='height:10em; width:100%;'  id='text'>" + Submissionxml14 + "</textarea></td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</br>");

            XmlDocument WebServiceSubmissionDoc15 = new XmlDocument();
            WebServiceSubmissionDoc15.Load(ThreeDSecureAuthenticate15);

            var Submissionxml15 = WebServiceSubmissionDoc15.OuterXml;

            Response.Write("<table align='center' width='75%' style='border:10px solid black;'>");
            Response.Write("<tr>");
            Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** A C T I O N ** 15 S U B M I S S I O N ** D A T A ***</b></font></td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td align='center'><textarea rows='1' style='height:40em; width:100%;'  id='text'>" + Submissionxml15 + "</textarea></td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</br>");

            XmlDocument WebServiceSubmissionDoc1 = new XmlDocument();
            WebServiceSubmissionDoc1.Load(ccPayements_1);

            var Submissionxml1 = WebServiceSubmissionDoc1.OuterXml;

            Response.Write("<table align='center' width='75%' style='border:10px solid black;'>");
            Response.Write("<tr>");
            Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** A C T I O N ** 1 S U B M I S S I O N ** D A T A ***</b></font></td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td align='center'><textarea rows='1' style='height:25em; width:100%;'  id='text'>" + Submissionxml1 + "</textarea></td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</br>");
        }
    }
}