<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1.2.RandomGeneratorWithWebServerControls.aspx.cs" Inherits="WebAndHtmlControls.RandomNumbersWebServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label id="RandomNumber" runat="server" visible="false" />
            </div>
            <div>
                <label>Lower Range: </label>
                <asp:TextBox id="TextLowerRange"
                    runat="server" />
            </div>
            <div>
                <label>Upper Range: </label>
                <asp:TextBox id="TextUpperRange"
                    runat="server" />
            </div>
            <div>
                <asp:Button runat="server"
                    text="Generate Random Number in Range"
                    onclick="GenerateRandomNumber" />
            </div>
        </div>
    </form>
</body>
</html>
