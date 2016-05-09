using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace MyGateGlobalVisa3DSIntergration
{
    public partial class PageEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void LogErrorIntoTextFile(Exception ex, string method)
        {
            try
            {
                string filePath = HttpContext.Current.Server.MapPath("ErrorLog.txt");

                if (File.Exists(filePath))
                {
                    StreamWriter writer = new StreamWriter(filePath, true);

                    string logMessage = "Error time: " + DateTime.Now.ToString() + "\n";
                    logMessage += "Error Page: " + HttpContext.Current.Request.Url.ToString() + "\n";
                    logMessage += "Error method: " + method + "\n";
                    logMessage += "Error Message: " + ex.Message.ToString() + "\n";
                    writer.WriteLine(logMessage);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }
     }
}