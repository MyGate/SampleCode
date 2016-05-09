<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateXML.aspx.cs" Inherits="MyGateGlobalVisa3DSIntergration.UpdateXML.UpdateXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Submission XML</title>
</head>
<body>

    <form id="form1" runat="server">
        <br /><br />
<%--    <asp:Button ID="cmdSave" runat="server" OnClick="cmdSave_Click" Text="Save Contents" />
    <asp:Button ID="cmdLoad" runat="server" OnClick="cmdLoad_Click" Text="Load Contents" />--%></div>
    </form>
    <table align='left' width='40%' style='border: 1px solid black;'>
        <tr>
            <td align='center' colspan='2' style='background-color: green; font-size: 14px; font-family: Verdana;'><font color='FFFFFF'><b>*** U P D A T E ** A C T I O N ** 1 4 ** D A T A ***</b></font></td>
        </tr>
        <tr>
            <td><div align='left'>Mode :</div></td>
            <td><div><input type='text' style='width: 300pt' name='mode' value='<%= mode %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>ApplicationUID :</div></td>
            <td><div><input type='text' style='width: 300pt' name='applicationUID' value='<%= applicationUID %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>MerchRef :</div></td>
            <td><div><input type='text' style='width: 300pt' name='merchantReference' value='<%= merchantReference %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>Terminal :</div></td>
            <td><div><input type='text' style='width: 300pt' name='terminal' value='<%= terminal %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>ProcessorId :</div></td>
            <td><div><input type='text' style='width: 300pt' name='processorId' value='<%= processorId %>' /></div></td>
        </tr>
         <tr>
            <td><div align='left'>MerchantId :</div></td>
            <td><div><input type='text' style='width: 300pt' name='merchantId' value='<%= merchantId %>' /></div></td>
        </tr>
         <tr>
            <td><div align='left'>TransactionPwd :</div></td>
            <td><div><input type='text' style='width: 300pt' name='transactionPwd' value='<%= transactionPwd %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>CardHolder :</div></td>
            <td><div><input type='text' style='width: 300pt' name='cardHolder' value='<%= cardHolder %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>CardNumber :</div></td>
            <td><div><input type='text' style='width: 300pt' name='cardNumber' value='<%= cardNumber %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>ExpiryMonth :</div></td>
            <td><div><input type='text' style='width: 300pt' name='expiryMonth' value='<%= expiryMonth %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>ExpiryYear :</div></td>
            <td><div><input type='text' style='width: 300pt' name='expiryYear' value='<%= expiryYear %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>Amount :</div></td>
            <td><div><input type='text' style='width: 300pt' name='amount' value='<%= amount %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>UserAgent :</div></td>
            <td><div><input type='text' style='width: 300pt' name='userAgent' value='<%= userAgent %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>BrowserHeader :</div></td>
            <td><div><input type='text' style='width: 300pt' name='browserHeader' value='<%= browserHeader %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>ipAddressv4 :</div></td>
            <td><div><input type='text' style='width: 300pt' name='ipAddressv4' value='<%= ipAddressv4 %>' /></div></td>
        </tr>
        <tr>
            <td colspan="2"><div align="centre"><input type="submit" value="Save Changes" style="width:150pt" /></div></td>
        </tr>
    </table>

    <table align='right' width='40%' style='border: 1px solid black;'>
        <tr>
            <td align='center' colspan='2' style='background-color: green; font-size: 14px; font-family: Verdana;'><font color='FFFFFF'><b>*** U P D A T E ** A C T I O N ** 1 5 ** D A T A ***</b></font></td>
        </tr>
        <tr>
            <td><div align='left'>applicationUID :</div></td>
            <td><div><input type='text' style='width: 300pt' name='applicationUID' value='<%= applicationUID %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>paresPayload :</div></td>
            <td><div><input type='text' style='width: 300pt' name='paresPayload' value='<%= paresPayload_15 %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>merchRef :</div></td>
            <td><div><input type='text' style='width: 300pt' name='merchRef' value='<%= merchantReference %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>Terminal :</div></td>
            <td><div><input type='text' style='width: 300pt' name='terminal' value='<%= terminal_15 %>' /></div></td>
        </tr>
        <tr>
            <td><div align='left'>transactionIndex :</div></td>
            <td><div><input type='text' style='width: 300pt' name='transactionIndex' value='<%= transactionIndex_15 %>' /></div></td>
        </tr>
        <tr>
            <td colspan="2"><div align="centre"><input type="submit" value="Save Changes" style="width:150pt" /></div></td>
        </tr>
    </table>
</body>
</html>
