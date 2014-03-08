<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mesimot.aspx.cs" Inherits="Mesimot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .td
        {
            width: 20%;
        }

        body
        {
            direction: rtl;
        }

        .control
        {
            font-family: David;
            font-size: x-large;
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
    <script type="text/javascript">
        function popupwindow(url, title, w, h) {
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);
            return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }
    </script>
</head>
<body dir="rtl" style="background-color: #DDEEEE;">
    <form id="form1" runat="server" class="control">
        <asp:HiddenField ID="Hidden_first" runat="server" Value="1" />
        <table dir="rtl" border="1" class="table">
            <tr>
                <td colspan="7">
                    <table border="1">
                        <tr>
                            <td>בחר תאריך:</td>
                            <td>חודש</td>
                            <td>
                                <asp:DropDownList ID="ddp_month" runat="server" AutoPostBack="True" CssClass="control" Width="100%">
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
                            <td>שנה</td>
                            <td>
                                <asp:DropDownList ID="ddp_year" runat="server" AutoPostBack="True" CssClass="control" Width="100%">
                                    <asp:ListItem Text="2012" Value="2012" />
                                    <asp:ListItem Text="2013" Value="2013" Selected="True" />
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="td"></td>
                <td class="td">מנשה
                </td>
                <td class="td">אפרים
                </td>
                <td class="td">בנימין
                </td>
                <td class="td">עוטף ירושלים
                </td>
                <td class="td">עציון ויהודה
                </td>
                <td class="td">סה"כ
                </td>
            </tr>
            <tr>
                <td class="td">סה"כ משימות</td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_total_menashe" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_total_efraim" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_total_binyamin" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_total_jerusalem" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_total_yehuda" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Label ID="lb_mesimot_total_all" runat="server" Text="0" CssClass="control" />
                </td>
            </tr>
            <tr>
                <td class="td">סה"כ משימות<br />
                    שטופלו
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_yes_menashe" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_yes_efraim" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_yes_binyamin" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_yes_jerusalem" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_yes_yehuda" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Label ID="lb_mesimot_yes_all" runat="server" Text="0" CssClass="control" />
                </td>
            </tr>
            <tr>
                <td class="td">סה"כ משימות<br />
                    שלא טופלו
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_no_menashe" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_no_efraim" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_no_binyamin" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_no_jerusalem" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_mesimot_no_yehuda" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Label ID="lb_mesimot_no_all" runat="server" Text="0" CssClass="control" />
                </td>
            </tr>
            <tr>
                <td class="td">להוסיף משימה</td>
                <td class="td">
                    <asp:Button ID="bt_mesimot_menashe_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_mesimot_efraim_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_mesimot_binyamin_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_mesimot_jerusalem_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_mesimot_yehuda_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
            </tr>
            <tr>
                <td class="td">סה"כ תקלות</td>
                <td class="td">
                    <asp:Button ID="lb_takalot_total_menashe" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_total_efraim" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_total_binyamin" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_total_jerusalem" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_total_yehuda" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Label ID="lb_takalot_total_all" runat="server" Text="0" CssClass="control" />
                </td>
            </tr>
            <tr>
                <td class="td">סה"כ תקלות<br />
                    שטופלו
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_yes_menashe" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_yes_efraim" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_yes_binyamin" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_yes_jerusalem" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_yes_yehuda" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Label ID="lb_takalot_yes_all" runat="server" Text="0" CssClass="control" />
                </td>
            </tr>
            <tr>
                <td class="td">סה"כ תקלות<br />
                    שלא טופלו
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_no_menashe" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_no_efraim" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_no_binyamin" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_no_jerusalem" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Button ID="lb_takalot_no_yehuda" runat="server" Text="0" OnClick="lb_watch_Click" CssClass="control" />
                </td>
                <td class="td">
                    <asp:Label ID="lb_takalot_no_all" runat="server" Text="0" CssClass="control" />
                </td>
            </tr>
            <tr>
                <td class="td">להוסיף תקלה</td>
                <td class="td">
                    <asp:Button ID="bt_takalot_menashe_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_takalot_efraim_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_takalot_binyamin_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_takalot_jerusalem_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
                <td class="td">
                    <asp:Button ID="bt_takalot_yehuda_add" runat="server" Text="הוסף" OnClick="bt_add_Click" />
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer_refresh" runat="server" Interval="4000" OnTick="Timer_refresh_Tick" />
    </form>
</body>
</html>