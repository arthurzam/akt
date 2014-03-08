<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tmunot.aspx.cs" Inherits="Tmunot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            direction: rtl;
        }

        .control
        {
            font-family: David;
            font-size: x-large;
        }
        .td
        {
            width:14%;
        }
        .table
        {
            width: 100%;
            border-style: solid;
            border-width: 2px;
            font-family: David;
            font-size: x-large;
        }
    </style>
</head>
<body dir="rtl" style="background-color: #DDEEEE;">
    <form id="form1" runat="server" class="control">
        <asp:HiddenField ID="Hidden_first" runat="server" Value="1" />
        <div>
            <table border="1">
                <tr>
                    <td>בחר תאריך:</td>
                    <td>חודש
                    </td>
                    <td>
                        <asp:DropDownList ID="ddp_month" runat="server" AutoPostBack="True" CssClass="control"
                            Width="100%">
                            <asp:ListItem Text="ינואר" Value="1" />
                            <asp:ListItem Text="פברואר" Value="2" />
                            <asp:ListItem Text="מרץ" Value="3" />
                            <asp:ListItem Text="אפריל" Value="4" />
                            <asp:ListItem Text="מאי" Value="5" />
                            <asp:ListItem Text="יוני" Value="6" />
                            <asp:ListItem Text="יולי" Value="7" />
                            <asp:ListItem Text="אוגוסט" Value="8" />
                            <asp:ListItem Text="סבטמבר" Value="9" />
                            <asp:ListItem Text="אוקטובר" Value="10" />
                            <asp:ListItem Text="נובמבר" Value="11" />
                            <asp:ListItem Text="דצמבר" Value="12" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>שנה
                    </td>
                    <td>
                        <asp:DropDownList ID="ddp_year" runat="server" AutoPostBack="True" CssClass="control"
                            Width="100%">
                            <asp:ListItem Text="2012" Value="2012" />
                            <asp:ListItem Text="2013" Value="2013" Selected="True" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <table class="table">
            <tr>
                <td></td>
                <td>מנשה</td>
                <td>אפרים</td>
                <td>בנימין</td>
                <td>עוטף ירושלים</td>
                <td>עציון ויהודה</td>
                <td>סה"כ</td>
            </tr>
            <tr>
                <td>סה"כ</td>
                <td><asp:Label ID="lb_total_menashe" runat="server" Text="-" /></td>
                <td><asp:Label ID="lb_total_efraim" runat="server" Text="-" /></td>
                <td><asp:Label ID="lb_total_binyamin" runat="server" Text="-" /></td>
                <td><asp:Label ID="lb_total_jerusalem" runat="server" Text="-" /></td>
                <td><asp:Label ID="lb_total_yehuda" runat="server" Text="-" /></td>
                <td><asp:Label ID="lb_total_all" runat="server" Text="-" /></td>
            </tr>
            <tr>
                <td>חוזה א<br />אחזקה מקיפה</td>
                <td><asp:Button ID="bt_A_menashe" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_A_efraim" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_A_binyamin" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_A_jerusalem" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_A_yehuda" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Label ID="bt_A_all" runat="server" Text="-" /></td>
            </tr>
            <tr>
                <td>חוזה ב<br />אחזקת שבר</td>
                <td><asp:Button ID="bt_B_menashe" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_B_efraim" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_B_binyamin" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_B_jerusalem" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_B_yehuda" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Label ID="bt_B_all" runat="server" Text="-" /></td>
            </tr>
            <tr>
                <td>משימות</td>
                <td><asp:Button ID="bt_mes_menashe" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_mes_efraim" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_mes_binyamin" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_mes_jerusalem" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_mes_yehuda" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Label ID="bt_mes_all" runat="server" Text="-" /></td>
            </tr>
            <tr>
                <td>תקלות</td>
                <td><asp:Button ID="bt_tak_menashe" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_tak_efraim" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_tak_binyamin" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_tak_jerusalem" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Button ID="bt_tak_yehuda" runat="server" Text="-" OnClick="bt_watch_Click" /></td>
                <td><asp:Label ID="bt_tak_all" runat="server" Text="-" /></td>
            </tr>
            <tr>
                <td>העלה תמונה</td>
                <td><asp:Button ID="bt_upload_menashe" runat="server" Text="הוסף תמונה" OnClick="bt_upload_Click" /></td>
                <td><asp:Button ID="bt_upload_efraim" runat="server" Text="הוסף תמונה" OnClick="bt_upload_Click" /></td>
                <td><asp:Button ID="bt_upload_binyamin" runat="server" Text="הוסף תמונה" OnClick="bt_upload_Click" /></td>
                <td><asp:Button ID="bt_upload_jerusalem" runat="server" Text="הוסף תמונה" OnClick="bt_upload_Click" /></td>
                <td><asp:Button ID="bt_upload_yehuda" runat="server" Text="הוסף תמונה" OnClick="bt_upload_Click" /></td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer_refresh" runat="server" Interval="4000" OnTick="Timer_refresh_Tick" />
    </form>
</body>
</html>