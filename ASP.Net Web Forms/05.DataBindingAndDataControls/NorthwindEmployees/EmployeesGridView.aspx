<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesGridView.aspx.cs" Inherits="NorthwindEmployees.EmployeesGridView" %>

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
                    <asp:HyperLinkField DataTextField="FirstName" HeaderText="FirstName" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="LastName" HeaderText="LastName" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Title" HeaderText="Title" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="BirthDate" HeaderText="BirthDate" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="HireDate" HeaderText="HireDate" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Country" HeaderText="Country" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Region" HeaderText="Region" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="City" HeaderText="City" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="Address" HeaderText="Address" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                    <asp:HyperLinkField DataTextField="HomePhone" HeaderText="HomePhone" DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
