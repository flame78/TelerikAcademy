<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="NorthwindEmployees.EmployeesRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rpEmployees" runat="server" ItemType="NorthwindData.Employee">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>FirstName
                            </th>
                            <th>LastName
                            </th>
                            <th>Title
                            </th>
                            <th>BirthDate
                            </th>
                            <th>HireDate
                            </th>
                            <th>Country
                            </th>
                            <th>Region
                            </th>
                            <th>City
                            </th>
                            <th>Address
                            </th>
                            <th>HomePhone
                            </th>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.FirstName %>
                        </td>
                        <td><%#: Item.LastName %>
                        </td>
                        <td><%#: Item.Title %>
                        </td>
                        <td><%#: Item.BirthDate %>
                        </td>
                        <td><%#: Item.HireDate %>
                        </td>
                        <td><%#: Item.Country %>
                        </td>
                        <td><%#: Item.Region %>
                        </td>
                        <td><%#: Item.City %>
                        </td>
                        <td><%#: Item.Address %>
                        </td>
                        <td><%#: Item.HomePhone %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
