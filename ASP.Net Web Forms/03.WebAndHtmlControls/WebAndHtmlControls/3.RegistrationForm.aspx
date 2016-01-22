<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3.RegistrationForm.aspx.cs" Inherits="WebAndHtmlControls.RegistrationForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <form id="RegistrationForm" runat="server">
        <div>
            <asp:Table runat="server"
                CellPadding="10"
                HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell>
                        <b>First name</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbFirstName" runat="server" />
                        <asp:RegularExpressionValidator runat="server"
                            ErrorMessage="Invalid name"
                            ControlToValidate="tbFirstName"
                            ValidationExpression="^[a-zA-Z''-'\s]{2,40}$"
                            ForeColor="Red" />
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbFirstName"
                            ErrorMessage="Enter name"
                            ForeColor="Red" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <b>Last name</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbLastName" runat="server" />
                        <asp:RegularExpressionValidator runat="server"
                            ErrorMessage="Invalid name"
                            ControlToValidate="tbLastName"
                            ValidationExpression="^[a-zA-Z''-'\s]{2,40}$"
                            ForeColor="Red" />
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbLastName"
                            ErrorMessage="Enter name"
                            ForeColor="Red" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <b>Faculty number</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="tbFacultyNumber" runat="server" />
                        <asp:RegularExpressionValidator runat="server"
                            ErrorMessage="Invalid number"
                            ControlToValidate="tbFacultyNumber"
                            ValidationExpression="^\d+$"
                            ForeColor="Red" />
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="tbFacultyNumber"
                            ErrorMessage="Enter number"
                            ForeColor="Red" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <b>University</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlUniversities" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <b>Specialty</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlSpecialities" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <b>Courses</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBoxList ID="lbCourses" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button runat="server" Text="Register" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
        <hr />
        <div  id="Wraper" runat="server" />
    </form>
</body>
</html>
