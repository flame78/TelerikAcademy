﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="TodoList.Admin.Todos" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DetailsView runat="server" ID="DetailsViewTodos" ItemType="TodoList.Models.Todo" AutoGenerateRows="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" AutoGenerateInsertButton="true" SelectMethod="DetailsViewTodos_GetItem" DataKeyNames="Id" AllowPaging="true" InsertMethod="DetailsViewTodos_InsertItem" UpdateMethod="DetailsViewTodos_UpdateItem">
    </asp:DetailsView>
    
</asp:Content>
