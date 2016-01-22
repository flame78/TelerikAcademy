<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1.1.RandomGeneratorWithHtmlServerControls.aspx.cs" Inherits="WebAndHtmlControls.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formRandomNumbers" runat="server">
        <div>
            <label id="RandomNumber" runat="server" visible="false"/>
        </div>
        <div>
            <label>Lower Range: </label>
            <input id="TextLowerRange"
                type="text"
                runat="server" />
        </div>
        <div>
            <label>Upper Range: </label>
            <input id="TextUpperRange"
                type="text"
                runat="server" />
        </div>
        <div>
            <input type="button"
                id="Submit"
                runat="server"
                value="Generate Random Number in Range"
                onserverclick="GenerateRandomNumber" />
        </div>
    </form>
</body>
</html>