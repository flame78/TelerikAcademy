<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebFormsCaching.About" %>
<%@ OutputCache Duration='3600' VaryByParam='none' %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Cached in <%: DateTime.UtcNow %> UTC</h3>
    <p>Use this area to provide additional information.</p>
    <controls:Cached runat="server"></controls:Cached>
</asp:Content>
