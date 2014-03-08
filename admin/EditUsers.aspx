<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUsers.aspx.cs" Inherits="admin_EditUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .panel
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="table" runat="server" CssClass="panel"  BorderWidth="2" GridLines="Both" CellPadding="2">
        </asp:Table>
        <br />
        <asp:Button ID="bt_delete" runat="server" Text="מחק" OnClick="bt_delete_Click" />
        <asp:Button ID="bt_save" runat="server" Text="שמור" OnClick="bt_save_Click" />
    </form>
</body>
</html>