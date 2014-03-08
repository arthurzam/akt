<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DohMerukaz.aspx.cs" Inherits="DohMerukaz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        th
        {
            width:14%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        כולל חודש 
        <% Response.Write(General.monthText[General.getTheReadyMonth() - 1] + " (" + General.getTheReadyMonth() + ")"); %><br />
        שנה: 
        <% Response.Write(General.getTheReadyYear()); %>
        <br /><br />
        <table border="1">
            <tr>
                <th></th>
                <th>מנשה</th>
                <th>אפרים</th>
                <th>בנימין</th>
                <th>עוטף ירושלים</th>
                <th>עציון ויהודה</th>
                <th>סה"כ</th>
            </tr>
            <tr>
                <td>חוזה א - אחזקה מקיפה</td>
                <td><span id="lb_hA_menashe" runat="server" /></td>
                <td><span id="lb_hA_efraim" runat="server" /></td>
                <td><span id="lb_hA_binyamin" runat="server" /></td>
                <td><span id="lb_hA_jerusalem" runat="server" /></td>
                <td><span id="lb_hA_yehuda" runat="server" /></td>
                <td><span id="lb_hA_all" runat="server" /></td>
            </tr>
            <tr>
                <td>סה"כ נשאר ב-2013 בש"ח</td>
                <td><span id="lb_hTA_menashe" runat="server" /></td>
                <td><span id="lb_hTA_efraim" runat="server" /></td>
                <td><span id="lb_hTA_binyamin" runat="server" /></td>
                <td><span id="lb_hTA_jerusalem" runat="server" /></td>
                <td><span id="lb_hTA_yehuda" runat="server" /></td>
                <td><span id="lb_hTA_all" runat="server" /></td>
            </tr>
            <tr>
                <td>חוזה ב - אחזקת שבר</td>
                <td><span id="lb_hB_menashe" runat="server" /></td>
                <td><span id="lb_hB_efraim" runat="server" /></td>
                <td><span id="lb_hB_binyamin" runat="server" /></td>
                <td><span id="lb_hB_jerusalem" runat="server" /></td>
                <td><span id="lb_hB_yehuda" runat="server" /></td>
                <td><span id="lb_hB_all" runat="server" /></td>
            </tr>
            <tr>
                <td>סה"כ נשאר ב-2013 בש"ח</td>
                <td><span id="lb_hTB_menashe" runat="server" /></td>
                <td><span id="lb_hTB_efraim" runat="server" /></td>
                <td><span id="lb_hTB_binyamin" runat="server" /></td>
                <td><span id="lb_hTB_jerusalem" runat="server" /></td>
                <td><span id="lb_hTB_yehuda" runat="server" /></td>
                <td><span id="lb_hTB_all" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="7" style="background-color: Black; height: 1px" />
            </tr>
            <tr>
                <td><a href="Mesimot.aspx">משימות שטרם טופלו</a></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_mes_menashe" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_mes_efraim" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_mes_binyamin" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_mes_jerusalem" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_mes_yehuda" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_mes_all" /></td>
            </tr>
            <tr>
                <td><a href="Mesimot.aspx">תקלות שטרם טופלו</a></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_tak_menashe" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_tak_efraim" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_tak_binyamin" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_tak_jerusalem" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_tak_yehuda" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_tak_all" /></td>
            </tr>
            <tr>
                <td><a href="Tmunot.aspx">תמונות</a></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_img_menashe" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_img_efraim" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_img_binyamin" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_img_jerusalem" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_img_yehuda" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_img_all" /></td>
            </tr>
            <tr>
                <td colspan="7" style="background-color: Black; height: 1px" />
            </tr>
            <tr>
                <td>מכתבים</td>
                <td><asp:Button ID="bt_michtavim_menashe" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_michtavim_efraim" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_michtavim_binyamin" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_michtavim_jerusalem" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_michtavim_yehuda" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
            </tr>
            <tr>
                <td>פרוטוקולים</td>
                <td><asp:Button ID="bt_protocol_menashe" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_protocol_efraim" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_protocol_binyamin" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_protocol_jerusalem" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
                <td><asp:Button ID="bt_protocol_yehuda" OnClick="bt_open_Click" Text="פתח" runat="server" CssClass="control" /></td>
            </tr>
        </table>
    </form>
</body>
</html>