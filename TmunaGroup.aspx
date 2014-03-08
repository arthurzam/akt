<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TmunaGroup.aspx.cs" Inherits="TmunaGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>צפה בתמונות</title>
    <link href="main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div runat="server" id="panel_table" visible="true">
        <asp:Table ID="main_table" runat="server" BorderWidth="2" GridLines="Both" CellPadding="2">
            <asp:TableRow>
                <asp:TableHeaderCell>מספר</asp:TableHeaderCell>
                <asp:TableHeaderCell>תאריך הוספה</asp:TableHeaderCell>
                <asp:TableHeaderCell>כותרת</asp:TableHeaderCell>
                <asp:TableHeaderCell>תמונה</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div runat="server" id="panel_image" visible="false">
        <asp:Button ID="bt_back" runat="server" Text="חזור" OnClick="bt_back_Click" />
        <asp:Image ID="Image_big" runat="server" Width="400" />
    </div>
    </form>
</body>
</html>
