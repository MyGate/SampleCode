<%@ Page Title="Page Not Found" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="BookReviewsWAP.ErrorPages._04" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Page Not Found</h2>
    <p>
        The page you requested could not be found.
    </p>
    <p>
        Perhaps you would like to visit one of these pages?
    </p>
    <ul>
        <asp:Repeater ID="rptMenu" runat="server" DataSourceID="GenresDataSource">
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server" ID="lnkGenre" NavigateUrl='<%# Eval("GenreId", "~/Genre.aspx?Id={0}") %>'><%#Eval("Genre", "{0} Book Reviews")%></asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>    
    </ul>
    <asp:SqlDataSource ID="GenresDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ReviewsConnectionString %>" 
        SelectCommand="SELECT [GenreId], [Genre] FROM [Genres] ORDER BY [Genre]"></asp:SqlDataSource>
</asp:Content>
