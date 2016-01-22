<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="NorthwindEmployees.EmployeesFormView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        a {
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField DataTextField="FirstName" HeaderText="FirstName" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="LastName" HeaderText="LastName" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Title" HeaderText="Title" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="BirthDate" HeaderText="BirthDate" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="HireDate" HeaderText="HireDate" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Country" HeaderText="Country" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Region" HeaderText="Region" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="City" HeaderText="City" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Address" HeaderText="Address" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="HomePhone" HeaderText="HomePhone" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmployeesFormView.aspx?id={0}" />
                </Columns>
            </asp:GridView>
            <asp:FormView ID="fvEmployee" runat="server" AutoGenerateColumns="false" AllowPaging="true" Visible="false" OnPageIndexChanging="fvEmployee_PageIndexChanging" DataKeyNames="EmployeeID">
                <ItemTemplate>
                    <table>
                        <tr>
                            <th>FirstName
                            </th>
                            <td>
                                <%#: Eval("FirstName") %>
                            </td>
                        </tr>
                        <tr>
                            <th>LastName
                            </th>
                            <td>
                                <%#: Eval("LastName") %>
                            </td>
                        </tr>
                        <tr>
                            <th>Title
                            </th>
                            <td>
                                <%#: Eval("Title") %>
                            </td>
                        </tr>
                        <tr>
                            <th>BirthDate
                            </th>
                            <td>
                                <%#: Eval("BirthDate") %>
                            </td>
                        </tr>
                        <tr>
                            <th>HireDate
                            </th>
                            <td>
                                <%#: Eval("HireDate") %>
                            </td>
                        </tr>
                        <tr>
                            <th>Country
                            </th>
                            <td>
                                <%#: Eval("Country") %>
                            </td>
                        </tr>
                        <tr>
                            <th>Region
                            </th>
                            <td>
                                <%#: Eval("Region") %>
                            </td>
                        </tr>
                        <tr>
                            <th>City
                            </th>
                            <td>
                                <%#: Eval("City") %>
                            </td>
                        </tr>
                        <tr>
                            <th>Address
                            </th>
                            <td>
                                <%#: Eval("Address") %>
                            </td>
                        </tr>
                        <tr>
                            <th>HomePhone
                            </th>
                            <td>
                                <%#: Eval("HomePhone") %>
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton PostBackUrl="~/EmployeesFormView.aspx" Text="Back" runat="server" />
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
