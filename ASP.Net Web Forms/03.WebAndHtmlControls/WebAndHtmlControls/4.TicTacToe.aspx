<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4.TicTacToe.aspx.cs" Inherits="WebAndHtmlControls.TicTacToe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .cell {
            font-size: 32px;
            background: white;
            color: black;
            height: 50px;
            width: 50px;
        }

            .cell:hover {
                background: gray;
            }
    </style>
    <title></title>
</head>
<body>
    <form id="GameForm" runat="server">
        <div>
            <asp:Table ID="GameField" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="Cell11" runat="server" CommandArgument="11" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Cell12" runat="server" CommandArgument="12" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Cell13" runat="server" CommandArgument="13" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="Cell21" runat="server" CommandArgument="21" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Cell22" runat="server" CommandArgument="22" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Cell23" runat="server" CommandArgument="231" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="Cell31" runat="server" CommandArgument="31" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Cell32" runat="server" CommandArgument="32" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Cell33" runat="server" CommandArgument="33" OnCommand="CellClick" CssClass="cell" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
