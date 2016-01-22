<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TreeViewXml.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-6">
            <asp:XmlDataSource ID="xds" DataFile="~/App_Data/books.xml" runat="server" />
            <asp:TreeView ID="tvXml" DataSourceID="xds" runat="server" OnSelectedNodeChanged="tvXml_SelectedNodeChanged"></asp:TreeView>
        </div>
        <div class="col-md-6">
            <asp:Label ID="lbSelectedNode" runat="server">
            </asp:Label>
        </div>
    </form>
</body>
</html>
