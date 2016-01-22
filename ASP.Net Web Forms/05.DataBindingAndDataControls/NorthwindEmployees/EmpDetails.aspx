<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="NorthwindEmployees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="dvEmployee" runat="server" AutoGenerateRows="true" OnPageIndexChanging="dvEmployee_PageIndexChanging" AllowPaging="true"/>
        <asp:Button Text="Back to GridView" OnClick="Back_Click" runat="server"/>
        <input type="button" value="Go Back From Whence You Came!" onclick="history.back(-1)" />
    </div>
    </form>
</body>
</html>
