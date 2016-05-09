    <%@ Page 
        Language="C#" 
        AutoEventWireup="true" 
        CodeBehind="PageEvent.aspx.cs" 
        Inherits="MyGateGlobalVisa3DSIntergration.PageEvent" 
     %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MyGate Global Site Wide Error Handler</title>
</head>
<body>
    <script language="C#" runat="server">

        void Page_Load(object sender, System.EventArgs e)
        {
            throw (new ArgumentNullException());
        }

        public void Page_Error(object sender, EventArgs e)
        {

            Exception objErr = Server.GetLastError().GetBaseException();
            string err = "<b>Error In Page_Error Event</b><hr><br>" + 
                     "<br><b>Error in: </b>" + Request.Url.ToString() +
                     "<br><b>Error Message: </b>" + objErr.Message.ToString() +
                     "<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString();

            Response.Write(err.ToString());

            Server.ClearError();
        }
    </script>
</body>
</html>
