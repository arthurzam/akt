<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HozeTohen.aspx.cs" Inherits="HozeTohen" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="border:1px solid black;padding:5px;">
            <asp:FileUpload ID="FileUploader" runat="server" />
            <br />
            <asp:Button ID="bt_upload" runat="server" Text="העלה" OnClick="bt_upload_Click" />
        </div>
        <asp:Table ID="table" runat="server">       
            <asp:TableRow>
                <asp:TableHeaderCell>מספר</asp:TableHeaderCell>
                <asp:TableHeaderCell>תאריך</asp:TableHeaderCell>
                <asp:TableHeaderCell>בחירה</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>