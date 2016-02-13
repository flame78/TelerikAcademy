<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilesList.aspx.cs" Inherits="WebFormsCaching.FilesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="lvFiles" runat="server" ItemType="System.String">
        <ItemTemplate>
            <div><%#:Item%></div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
