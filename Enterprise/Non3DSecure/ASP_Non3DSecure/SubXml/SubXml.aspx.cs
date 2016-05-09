using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;
using System.Configuration;

namespace MyGate_Global__Visa_AuthActions.SubXml
{
    public partial class SubXml : System.Web.UI.Page
    {
        public string ccPayements_1 = ConfigurationManager.AppSettings["Action1"];

        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument WebServiceSubmissionDoc1 = new XmlDocument();
            WebServiceSubmissionDoc1.Load(ccPayements_1);

            var Submissionxml1 = WebServiceSubmissionDoc1.OuterXml;

            Response.Write("<table align='center' width='75%' style='border:10px solid black;'>");
            Response.Write("<tr>");
            Response.Write("<td align='center' colspan='2' style='background-color:Green; font-size:14px; font-family:Verdana;'><font color='FFFFFF'><b>*** A C T I O N ** 1 S U B M I S S I O N ** D A T A ***</b></font></td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td align='center'><textarea rows='1' style='height:22em; width:100%;'  id='text'>" + Submissionxml1 + "</textarea></td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</br>");
        }
    }
}