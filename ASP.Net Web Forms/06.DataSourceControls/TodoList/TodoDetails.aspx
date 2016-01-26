<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="TodoList.TodoDetails" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DetailsView ID="DetailsViewTodo" runat="server" ItemType="TodoList.Models.Todo" SelectMethod="DetailsViewTodo_GetItem" DefaultMode="ReadOnly" AutoGenerateRows="true">
    </asp:DetailsView>

</asp:Content>
