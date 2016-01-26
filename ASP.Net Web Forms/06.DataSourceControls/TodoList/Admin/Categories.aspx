<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TodoList.Categories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Categories:</h2>
    <asp:ListView ID="ListViewCategories" runat="server" ItemType="TodoList.Models.Category" SelectMethod="ListViewCategories_GetData" InsertMethod="ListViewCategories_InsertItem" UpdateMethod="ListViewCategories_UpdateItem" DataKeyNames="Id" InsertItemPosition="LastItem" DeleteMethod="ListViewCategories_DeleteItem">
        <ItemTemplate>
            <div class="col-md-10">
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Category.aspx?id={0}",Item.Id) %>' Text="<%#: Item.Name %>" />
            </div>
            <div class="col-md-2">
                <asp:LinkButton runat="server" CommandName="Edit" Text="Edit" />
                <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxCategoryName" runat="server" Text="<%#: BindItem.Name %>" />
            </div>
            <div class="col-md-2">
                <asp:LinkButton ID="SaveButton" runat="server" CommandName="Update" Text="Save" />
                <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxCategoryName" runat="server" Text="<%#: BindItem.Name %>" />
            </div>
            <div class="col-md-2">
                <asp:LinkButton runat="server" CommandName="Insert" Text="Insert" />
                <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </div>
        </InsertItemTemplate>
    </asp:ListView>




</asp:Content>
