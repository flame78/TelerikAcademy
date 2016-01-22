<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="NorthwindEmployees.EmployeesListView" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        input {
            width: 90px;
        }

        .col {
            width: 100px;
        }

        .centered {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ListView ID="lvEmployees"
                runat="server"
                DataKeyNames="EmployeeID"
                ItemType="NorthwindData.Employee"
                UpdateMethod="lvEmployees_UpdateItem"
                DeleteMethod="lvEmployees_DeleteItem"
                OnItemCommand="lvEmployees_ItemCommand"
                SelectMethod="lvEmployees_GetData">
                <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Photo
                                </th>
                                <th class="col">FirstName
                                </th>
                                <th class="col">LastName
                                </th>
                                <th class="col">Title
                                </th>
                                <th class="col">BirthDate
                                </th>
                                <th class="col">HireDate
                                </th>
                                <th class="col">Country
                                </th>
                                <th class="col">Region
                                </th>
                                <th class="col">City
                                </th>
                                <th class="col">Address
                                </th>
                                <th class="col">HomePhone
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="11" class="centered">
                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvEmployees" PageSize="2" Visible="true">
                                        <Fields>
                                            <asp:NextPreviousPagerField ShowNextPageButton="false" ShowFirstPageButton="true" />
                                            <asp:NumericPagerField ButtonCount="3" />
                                            <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowLastPageButton="true" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>

                        </tfoot>
                    </table>

                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="data:image/jpeg;base64, <%#: Convert.ToBase64String(Item.Photo, 78,Item.Photo.Length - 78 ) %>" /></td>
                        <td class="col"><%#: Item.FirstName %>
                        </td>
                        <td class="col"><%#: Item.LastName %>
                        </td>
                        <td class="col"><%#: Item.Title %>
                        </td>
                        <td class="col"><%#: Item.BirthDate %>
                        </td>
                        <td class="col"><%#: Item.HireDate %>
                        </td>
                        <td class="col"><%#: Item.Country %>
                        </td>
                        <td class="col"><%#: Item.Region %>
                        </td>
                        <td class="col"><%#: Item.City %>
                        </td>
                        <td class="col"><%#: Item.Address %>
                        </td>
                        <td class="col"><%#: Item.HomePhone %>
                        </td>
                        <td class="col">
                            <asp:LinkButton ID="EditButton" runat="Server" Text="Edit" CommandName="Edit" />
                            <asp:LinkButton ID="DeleteButton" runat="Server" Text="Delete" CommandName="Delete" />
                            <asp:LinkButton ID="CloneButton" runat="server" Text="Clone" CommandName="Clone" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <img src="data:image/jpeg;base64, <%#: Convert.ToBase64String(Item.Photo, 78,Item.Photo.Length - 78 ) %>" /></td>
                        <td>
                            <asp:TextBox ID="tbFirstName" Text='<%#: BindItem.FirstName %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbLastName" Text='<%#: BindItem.LastName %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbTitle" Text='<%#: BindItem.Title %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbBirthDate" Text='<%#: BindItem.BirthDate %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbHireDate" Text='<%#: BindItem.HireDate %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbCountry" Text='<%#: BindItem.Country %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbRegion" Text='<%#: BindItem.Region %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbCity" Text='<%#: BindItem.City %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbAddress" Text='<%#: BindItem.Address %>' runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbHomePhone" Text='<%#: BindItem.HomePhone %>' runat="server" />
                        </td>
                        <td>
                            <asp:LinkButton ID="UpdateButton" runat="Server" Text="Save" CommandName="Update" />
                            <asp:LinkButton ID="CancleButton" runat="Server" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
