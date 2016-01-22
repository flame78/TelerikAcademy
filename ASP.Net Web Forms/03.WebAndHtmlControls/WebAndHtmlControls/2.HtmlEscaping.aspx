<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2.HtmlEscaping.aspx.cs" Inherits="WebAndHtmlControls.HtmlEscaping" validateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormHtmlEscaping" runat="server">
    <div>
        <asp:TextBox ID="TextBoxSampleText" runat="server" />
        <asp:Button ID="ButtpnShowText" Text="Show text" OnClick="ButtonShowTextClick" runat="server" />
    </div>
    </form>
</body>
</html>
