<%@ Page Language="C#" AutoEventWireup="true" CodeFile="controlPanel.aspx.cs" Inherits="admin_controlPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>כלי ניהול האתר</title>
    <link href="../main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #panel
        {
            height: 500px;
            width: 100%;
        }

        #span_menu
        {
            height: 150px;
            margin: 0 0 auto 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2" dir="ltr">
                    <asp:Button ID="bt_return" runat="server" Text="חזור לאתר" CssClass="control" OnClick="bt_return_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <span id="span_menu">
                        <asp:Button ID="bt_menu_seeAllFiles" runat="server" Text="צפה במערכת הקבצים" CssClass="menu_button"
                            OnClick="bt_menu_seeAllFiles_Click" /><br />
                        <asp:Button ID="bt_menu_users" runat="server" Text="ערוך משתמשים באתר" CssClass="menu_button"
                            OnClick="bt_menu_users_Click" />
                    </span>
                </td>
                <td style="width: 100%">
                    <div id="panel" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>