<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="WebFormsSumator.Sumator" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="tbFirstNumber" runat="server"></asp:TextBox>
    <asp:TextBox ID="tbSecondNumber" runat="server"></asp:TextBox>
    <asp:Button ID="btnCalculateSum" Text="Calculate Sum" runat="server" OnClick="btnCalculateSum_Click"/>
    <hr />
    <label>Sum:</label>
    <asp:Label ID="lblSum" runat="server"></asp:Label>
</asp:Content>
