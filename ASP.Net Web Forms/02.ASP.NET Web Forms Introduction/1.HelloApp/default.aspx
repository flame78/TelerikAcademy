<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HelloApp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <asp:Button runat="server" OnClick="ButtonClick" Text="Click Me!"/>
        <asp:Label ID="lbHelloMsg" runat="server" />
    </div>
    </form>
</body>
</html>
