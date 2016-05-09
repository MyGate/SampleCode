using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;

namespace MyGateGlobalVisa3DSIntergration.UpdateXML
{
    public partial class UpdateXML : System.Web.UI.Page
    {
        //ACT_14_DATA
        public string ThreeDSecure = "C:\\integrationCode\\C#\\Actions_ThreeDSecure\\";
        public string ccPayments = "C:\\integrationCode\\C#\\Actions_ThreeDSecure\\";
        public string Action14 = "Action14.xml";
        public string Action15 = "Action15.xml";
        public string Action1  = "Action_1.xml";
        
        public string mode = ""; 
        public string applicationuid = ""; 
        public string merchantreference = ""; 
        public string terminal = ""; 
        public string processorId = ""; 
        public string merchantId = ""; 
        public string transactionpassword = ""; 
        public string cardholder = ""; 
        public string cardnumber = ""; 
        public string expirymonth =""; 
        public string expiryyear = ""; 
        public string amount = ""; 
        public string useragent = ""; 
        public string browserheader = "";
        public string ipaddressv4 = "";

        //ACT_15_DATA
        public string mode15 = "";
        public string applicationuid15 = "";
        public string parespayload15 = "";
        public string merchantreference15 = "";
        public string terminal15 = "";
        public string transactionindex15 = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void updatethreedsecurexmldoc(object sender, EventArgs e)
        {
            if (Action14 == "Action14.xml")
            {
                try
                {
                    string threedsecuredata14 = string.Concat(ThreeDSecure, Action14);
                    XmlDocument updatexml14 = new XmlDocument();
                    updatexml14.Load(threedsecuredata14);

                    updatexml14.SelectSingleNode("//mode").InnerText = mode;
                    updatexml14.SelectSingleNode("//applicationUID").InnerText = applicationuid;
                    updatexml14.SelectSingleNode("//merchantReference").InnerText = merchantreference;
                    updatexml14.SelectSingleNode("//terminal").InnerText = terminal;
                    updatexml14.SelectSingleNode("//processorId").InnerText = processorId;
                    updatexml14.SelectSingleNode("//merchantId").InnerText = merchantId;
                    updatexml14.SelectSingleNode("//transactionPwd").InnerText = transactionpassword;
                    updatexml14.SelectSingleNode("//cardHolder").InnerText = cardholder;
                    updatexml14.SelectSingleNode("//cardNumber").InnerText = cardnumber;
                    updatexml14.SelectSingleNode("//expiryMonth").InnerText = expirymonth;
                    updatexml14.SelectSingleNode("//expiryYear").InnerText = expiryyear;
                    updatexml14.SelectSingleNode("//amount").InnerText = amount;
                    updatexml14.SelectSingleNode("//userAgent").InnerText = useragent;
                    updatexml14.SelectSingleNode("//browserHeader").InnerText = browserheader;
                    updatexml14.SelectSingleNode("//ipAddressv4").InnerText = ipaddressv4;
                    updatexml14.Save(threedsecuredata14);
                }
                catch (XmlException)
                {
                    throw new XmlException();
                }
            }
            else if (Action15 == "Action15.xml")
            {
                try
                {
                    string ThreeDSecureData15 = string.Concat(ThreeDSecure, Action15);

                    XmlDocument updatexml15 = new XmlDocument();
                    updatexml15.Load(ThreeDSecureData15);

                    updatexml15.SelectSingleNode("//applicationUID").InnerText = mode15;
                    updatexml15.SelectSingleNode("//transactionIndex").InnerText = transactionindex15;
                    updatexml15.SelectSingleNode("//paresPayload").InnerText = parespayload15;
                    updatexml15.SelectSingleNode("//merchantReference").InnerText = merchantreference15;
                    updatexml15.SelectSingleNode("//terminal").InnerText = terminal15;
                    updatexml15.Save(ThreeDSecureData15);
                }
                catch (XmlException)
                {
                    throw new XmlException();
                }
            }
            else if (Action1 == "Action_1.xml")
            {
                try
                {
                    //string ccPayment = string.Concat(ccPayments, Action_1);
                }
                catch (XmlException)
                {
                    throw new XmlException();
                }

            }
        }

    }
}