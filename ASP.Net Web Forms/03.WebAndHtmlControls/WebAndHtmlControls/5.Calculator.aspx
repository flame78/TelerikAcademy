<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="5.Calculator.aspx.cs" Inherits="WebAndHtmlControls.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        input {
            width: 55px;
        }
        span {
            text-align:right;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="CalculatorForm" runat="server">
        <div>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Value" runat="server" Width="235px" BorderStyle="Solid" BorderWidth="2px"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button CommandArgument="1" OnCommand="DigitClick" Text="1" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="2" OnCommand="DigitClick" Text="2" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="3" OnCommand="DigitClick" Text="3" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="+" OnCommand="CalculationCommandClick" Text="+" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button CommandArgument="4" OnCommand="DigitClick" Text="4" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="5" OnCommand="DigitClick" Text="5" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="6" OnCommand="DigitClick" Text="6" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="-" OnCommand="CalculationCommandClick" Text="-" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button CommandArgument="7" OnCommand="DigitClick" Text="7" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="8" OnCommand="DigitClick" Text="8" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="9" OnCommand="DigitClick" Text="9" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="*" OnCommand="CalculationCommandClick" Text="*" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button OnClick="ClearClick" Text="Clear" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="0" OnCommand="DigitClick" Text="0" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="/" OnCommand="CalculationCommandClick" Text="/" runat="server"/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button CommandArgument="S" OnCommand="CalculationCommandClick" Text="Sqrt" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                <asp:Button CommandArgument="=" OnCommand="CalculationCommandClick" text="=" runat="server" Width="235px"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
