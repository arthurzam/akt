<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MesimaGroupViewer.aspx.cs" Inherits="MesimaGroupViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="Table_main" runat="server" BorderWidth="2" GridLines="Both" CellPadding="2">
            <asp:TableRow>
                <asp:TableHeaderCell>מספר</asp:TableHeaderCell>
                <asp:TableHeaderCell>כותרת</asp:TableHeaderCell>
                <asp:TableHeaderCell>תאריך</asp:TableHeaderCell>
                <asp:TableHeaderCell>האם כבר טופל</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>