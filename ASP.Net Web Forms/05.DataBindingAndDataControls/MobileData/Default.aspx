<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MobileData.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span><b>Make</b></span>
            <asp:DropDownList ID="ddlProducers" AutoPostBack="true" runat="server" DataSource="<%# producers %>" DataTextField="Name" OnSelectedIndexChanged="ddlProducers_SelectedIndexChanged">
            </asp:DropDownList>
            <span><b>Model</b></span>
            <asp:DropDownList ID="ddlModels" AutoPostBack="true" runat="server" DataTextField="Name">
            </asp:DropDownList>
            <hr /><span><b>Features</b></span>
            <asp:CheckBoxList ID="cblExtras" runat="server" RepeatColumns="2">
            </asp:CheckBoxList>
            <hr />
            <span><b>Engine Type</b></span>
            <asp:RadioButtonList ID="rblTypeOfEngine" runat="server" RepeatDirection="Horizontal" >
            </asp:RadioButtonList>
            <hr />
            <asp:Button runat="server" OnClick="Submit_Click" Text="Submit" />
            <hr />
            <asp:Literal ID="lblInfo" runat="server" />
        </div>
    </form>
</body>
</html>
