<%@ Page Title="An Error Has Occurred" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="BookReviewsWAP.ErrorPages.Oops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        An Error Has Occurred</h2>
    <p>
        An unexpected error occurred on our website. The website administrator has been notified.</p>
    <ul>
        <li>
            <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx">Return to the homepage</asp:HyperLink></li>
    </ul>
</asp:Content>
