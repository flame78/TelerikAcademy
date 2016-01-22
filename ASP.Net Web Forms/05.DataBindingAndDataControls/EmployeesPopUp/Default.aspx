<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeesPopUp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="lvEmployees"
                runat="server"
                DataKeyNames="EmployeeID"
                ItemType="NorthwindData.Employee"
                SelectMethod="lvEmployees_GetData">
                <LayoutTemplate>
                    <table class="table table-bordered">
                        <thead>
                            <tr>

                                <th>
                                    <asp:LinkButton runat="server" CssClass="btn btn-info" Text="First Name" CommandName="Sort" CommandArgument="FirstName" />
                                </th>
                                <th>
                                    <asp:LinkButton runat="server" CssClass="btn btn-info" Text="Last Name" CommandName="Sort" CommandArgument="LastName" />
                                </th>
                                <th>
                                    <asp:LinkButton runat="server" CssClass="btn btn-info" Text="Country" CommandName="Sort" CommandArgument="Country" />
                                </th>
                                <th>
                                    <asp:LinkButton runat="server" CssClass="btn btn-info" Text="City" CommandName="Sort" CommandArgument="City" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="4" class="text-center">
                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvEmployees" PageSize="5" Visible="true" CssClass="btn btn-info">
                                        <Fields>
                                            <asp:NextPreviousPagerField ShowNextPageButton="false" ShowFirstPageButton="true" />
                                            <asp:NumericPagerField ButtonCount="5" />
                                            <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowLastPageButton="true" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>

                        </tfoot>
                    </table>

                </LayoutTemplate>
                <ItemTemplate>
                    <tr onmouseover="__doPostBack('UpdatePanel1', '<%#: Item.EmployeeID %>');" onmouseout="__doPostBack('UpdatePanel1', '');">
                        <td class="col"><%#: Item.FirstName %>
                        </td>
                        <td class="col"><%#: Item.LastName %>
                        </td>
                        <td class="col"><%#: Item.Country %>
                        </td>
                        <td class="col"><%#: Item.City %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <div id="Container">
                <asp:UpdatePanel runat="server" ID="UpdatePanel1"
                    OnLoad="UpdatePanel1_Load">
                    <ContentTemplate>
                        <div id="Label1" runat="server" visible="false">
                            <asp:DetailsView ID="dvEmployee" runat="server" AutoGenerateRows="true" ItemType="NorthwindData.Employee">
                                <Fields>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <tr>
                                                <td>Picture</td>
                                                <td><img src="data:image/jpeg;base64, <%#: Convert.ToBase64String(Item.Photo, 78,Item.Photo.Length - 78 ) %>" /></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                            </asp:DetailsView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
