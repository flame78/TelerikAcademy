<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TodoList.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewCategories" runat="server" SelectMethod="ListViewCategories_GetData" DataKeyNames="Id" ItemType="TodoList.Models.Category" GroupItemCount="3">
        <GroupTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            <div class="clearfix"></div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                Category: 
                <asp:HyperLink runat="server" ID="HyperLinkCategory" Text="<%#: Item.Name %>" NavigateUrl='<%# string.Format("~/CategoryDetails?id={0}", Item.Id) %>' />
                <asp:ListView ID="ListViewTodo" runat="server" ItemType="TodoList.Models.Todo" DataSource="<%# ListViewTodo_GetData(Item.Id) %>">
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
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
