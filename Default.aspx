<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>אק"ת - אחזקת קו התפר</title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8;he" />
    <link href="main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        td
        {
            width: 33%;
            text-align: center;
        }

        .style1
        {
            width: 4000px;
            height: 3000px;
        }
    </style>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
        <table align="center" cellpadding="5" border="0">
            <tr>
                <td colspan="3">
                    <img src="Pictures/menora.png" alt="menora" height="100" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <span style="font-size: xx-large"><b>מדינת ישראל</b><br />
                        משרד הביטחון</span>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <img src="Pictures/logo.jpg" alt="logo" height="100" />
                </td>
                <td style="text-align: center">
                    <h2>אגף ההנדסה והבינוי</h2>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">
                    <h2>מנהלת פרויקט מרחב התפר</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="Pictures/default_1.jpg" width="400" alt="picture 1" />
                </td>
                <td>
                    <img src="Pictures/default_2.jpg" width="400" alt="picture 2" />
                </td>
                <td>
                    <img src="Pictures/default_3.jpg" width="400" alt="picture 3" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <h2>א.ק.ת. - אחזקת קו התפר</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="Pictures/default_4.jpg" width="400" alt="picture 4" />
                </td>
                <td>
                    <img src="Pictures/default_5.jpg" width="400" alt="picture 5" />
                </td>
                <td>
                    <img src="Pictures/default_6.jpg" width="400" alt="picture 6" />
                </td>
            </tr>
            <tr>
                <td>שם משתמש:&nbsp;
                <asp:TextBox ID="tb_username" runat="server" CssClass="control" />
                </td>
                <td>סיסמה:&nbsp;
                <asp:TextBox ID="tb_password" runat="server" TextMode="Password" CssClass="control" />
                </td>
                <td>
                    <asp:Button ID="bt_start" runat="server" Text="התחל" OnClick="bt_start_Click" CssClass="control" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>