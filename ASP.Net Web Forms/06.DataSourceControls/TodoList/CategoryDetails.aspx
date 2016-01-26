<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="TodoList.CategoryDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Category: 
        <asp:Label runat="server" ID="LabelCategoryName"></asp:Label>
    </h1>
    <asp:ListView runat="server" ID="ListViewTodos" SelectMethod="ListViewTodos_GetData" ItemType="TodoList.Models.Todo">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink runat="server" Text="<%# Item.Title %>" NavigateUrl='<%# string.Format("~/TodoDetails.aspx?id={0}", Item.Id) %>' />
            </li>
        </ItemTemplate>
        <EmptyItemTemplate>
            No todos.
        </EmptyItemTemplate>
    </asp:ListView>

</asp:Content>
