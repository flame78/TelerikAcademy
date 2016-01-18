<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:Label runat="server">Hello, ASP.NET</asp:Label>
        <br />
        <asp:Label ID="lbHello" runat="server"></asp:Label>   
        <br />
        <asp:Label ID="lbAssemblyLocation" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
