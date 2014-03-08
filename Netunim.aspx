<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Netunim.aspx.cs" Inherits="netunim" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        td
        {
            width: 14%;
            text-align: center;
        }
    </style>
    <link href="main.css" rel="stylesheet" type="text/css" />
    <script src="JavaScriptMain.js" type="text/javascript"></script>
    <script type="text/javascript">
        function calcSum() {
            var sum = 0;
            if (document.getElementById('<%=tb_2_1.ClientID %>').value != "")
                sum += parseInt(document.getElementById('<%=tb_2_1.ClientID %>').value);
            if (document.getElementById('<%=tb_2_2.ClientID %>').value != "")
                sum += parseInt(document.getElementById('<%=tb_2_2.ClientID %>').value);
            if (document.getElementById('<%=tb_2_3.ClientID %>').value != "")
                sum += parseInt(document.getElementById('<%=tb_2_3.ClientID %>').value);
            if (document.getElementById('<%=tb_2_4.ClientID %>').value != "")
                sum += parseInt(document.getElementById('<%=tb_2_4.ClientID %>').value);
            if (document.getElementById('<%=tb_2_5.ClientID %>').value != "")
                sum += parseInt(document.getElementById('<%=tb_2_5.ClientID %>').value);
            tb_2_6.innerHTML = sum;
        }
    </script>
</head>
<body dir="ltr">
    <form id="form1" runat="server" style="font-family: David; font-size: x-large;">
        <table id="Table1" border="2" runat="server" frame="border" width="100%">
            <tr>
                <td>&nbsp;
                </td>
                <td>מנשה
                </td>
                <td>אפרים
                </td>
                <td>בנימין
                </td>
                <td>עוטף ירושלים
                </td>
                <td>עציון ויהודה
                </td>
                <td>סה&quot;כ
                </td>
            </tr>
            <tr>
                <td>דף קשר
                </td>
                <td>
                    <asp:Button ID="bt_kesher_menashe_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_kesher_upload_Click" />
                    <asp:Button ID="bt_kesher_menashe_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_kesher_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_kesher_efraim_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_kesher_upload_Click" />
                    <asp:Button ID="bt_kesher_efraim_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_kesher_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_kesher_binyamin_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_kesher_upload_Click" />
                    <asp:Button ID="bt_kesher_binyamin_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_kesher_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_kesher_jerusalem_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_kesher_upload_Click" />
                    <asp:Button ID="bt_kesher_jerusalem_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_kesher_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_kesher_yehuda_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_kesher_upload_Click" />
                    <asp:Button ID="bt_kesher_yehuda_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_kesher_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_kesher_all_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_kesher_upload_Click" />
                    <asp:Button ID="bt_kesher_all_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_kesher_watch_Click" />
                </td>
            </tr>
            <tr>
                <td>קבלן המבצע
                </td>
                <td>
                    <asp:TextBox ID="tb_manager_1" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="tb_manager_2" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="tb_manager_3" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="tb_manager_4" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="tb_manager_5" runat="server" />
                </td>
            </tr>
            <tr>
                <td>אורך קטע (ק"מ)
                </td>
                <td><input type="text" runat="server" id="tb_2_1" onchange="javascript:return calcSum();" 
                            onkeypress="javascript:return TextBoxDecimal_onKeyPress(event);" class="textBox" /></td>
                <td><input type="text" runat="server" id="tb_2_2" onchange="javascript:return calcSum();"
                            onkeypress="javascript:return TextBoxDecimal_onKeyPress(event);" class="textBox" /></td>
                <td><input type="text" runat="server" id="tb_2_3" onchange="javascript:return calcSum();"
                            onkeypress="javascript:return TextBoxDecimal_onKeyPress(event);" class="textBox" /></td>
                <td><input type="text" runat="server" id="tb_2_4" onchange="javascript:return calcSum();"
                            onkeypress="javascript:return TextBoxDecimal_onKeyPress(event);" class="textBox" /></td>
                <td><input type="text" runat="server" id="tb_2_5" onchange="javascript:return calcSum();"
                            onkeypress="javascript:return TextBoxDecimal_onKeyPress(event);" class="textBox" /></td>
                <td style="border:0">
                    <span id="tb_2_6" />
                    <script type="text/javascript">calcSum();</script>
                </td>
            </tr>
            <tr>
                <td>מק.ד.<br />
                    עד ק.ד.
                </td>
                <td>
                    <asp:TextBox ID="tb_3_1" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_3_2" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_3_3" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_3_4" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_3_5" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>חוזה א - אחזקה מקיפה
                </td>
                <td>
                    <asp:Button ID="bt_A_Ahzaka_1_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Ahzaka_1_upload_Click" />
                    <asp:Button ID="bt_A_Ahzaka_1_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Ahzaka_1_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Ahzaka_2_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Ahzaka_2_upload_Click" />
                    <asp:Button ID="bt_A_Ahzaka_2_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Ahzaka_2_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Ahzaka_3_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Ahzaka_3_upload_Click" />
                    <asp:Button ID="bt_A_Ahzaka_3_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Ahzaka_3_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Ahzaka_4_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Ahzaka_4_upload_Click" />
                    <asp:Button ID="bt_A_Ahzaka_4_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Ahzaka_4_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Ahzaka_5_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Ahzaka_5_upload_Click" />
                    <asp:Button ID="bt_A_Ahzaka_5_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Ahzaka_5_watch_Click" />
                </td>
            </tr>
            <tr>
                <td>חוזה א - כתב כמויות
                </td>
                <td>
                    <asp:Button ID="bt_A_Kamut_1_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Kamut_1_upload_Click" />
                    <asp:Button ID="bt_A_Kamut_1_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Kamut_1_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Kamut_2_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Kamut_2_upload_Click" />
                    <asp:Button ID="bt_A_Kamut_2_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Kamut_2_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Kamut_3_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Kamut_3_upload_Click" />
                    <asp:Button ID="bt_A_Kamut_3_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Kamut_3_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Kamut_4_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Kamut_4_upload_Click" />
                    <asp:Button ID="bt_A_Kamut_4_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Kamut_4_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_A_Kamut_5_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_A_Kamut_5_upload_Click" />
                    <asp:Button ID="bt_A_Kamut_5_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_A_Kamut_5_watch_Click" />
                </td>
            </tr>
            <tr>
                <td>חוזה ב - חוזה שבר
                </td>
                <td>
                    <asp:Button ID="bt_B_Ahzaka_1_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Ahzaka_1_upload_Click" />
                    <asp:Button ID="bt_B_Ahzaka_1_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Ahzaka_1_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Ahzaka_2_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Ahzaka_2_upload_Click" />
                    <asp:Button ID="bt_B_Ahzaka_2_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Ahzaka_2_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Ahzaka_3_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Ahzaka_3_upload_Click" />
                    <asp:Button ID="bt_B_Ahzaka_3_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Ahzaka_3_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Ahzaka_4_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Ahzaka_4_upload_Click" />
                    <asp:Button ID="bt_B_Ahzaka_4_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Ahzaka_4_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Ahzaka_5_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Ahzaka_5_upload_Click" />
                    <asp:Button ID="bt_B_Ahzaka_5_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Ahzaka_5_watch_Click" />
                </td>
            </tr>
            <tr>
                <td>חוזה ב - כתב כמויות
                </td>
                <td>
                    <asp:Button ID="bt_B_Kamut_1_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Kamut_1_upload_Click" />
                    <asp:Button ID="bt_B_Kamut_1_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Kamut_1_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Kamut_2_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Kamut_2_upload_Click" />
                    <asp:Button ID="bt_B_Kamut_2_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Kamut_2_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Kamut_3_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Kamut_3_upload_Click" />
                    <asp:Button ID="bt_B_Kamut_3_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Kamut_3_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Kamut_4_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Kamut_4_upload_Click" />
                    <asp:Button ID="bt_B_Kamut_4_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Kamut_4_watch_Click" />
                </td>
                <td>
                    <asp:Button ID="bt_B_Kamut_5_upload" runat="server" Text="העלה" CssClass="control"
                        OnClick="bt_B_Kamut_5_upload_Click" />
                    <asp:Button ID="bt_B_Kamut_5_watch" runat="server" Text="צפה" CssClass="control"
                        Visible="false" OnClick="bt_B_Kamut_5_watch_Click" />
                </td>
            </tr>
            <tr>
                <td>מיקום<br />
                    חניון קבלן
                </td>
                <td>
                    <asp:TextBox ID="tb_1_1" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_1_2" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_1_3" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_1_4" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_1_5" runat="server" CssClass="textBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>מתקנים הנדסיים
                </td>
                <td align="center">
                    <asp:Button ID="bt_4_1_upload" runat="server" Text="העלה" CssClass="control" OnClick="bt_4_upload_Click" />
                    <asp:Button ID="bt_4_1_watch" runat="server" Text="צפה" CssClass="control" OnClick="bt_4_watch_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="bt_4_2_upload" runat="server" Text="העלה" CssClass="control" OnClick="bt_4_upload_Click" />
                    <asp:Button ID="bt_4_2_watch" runat="server" Text="צפה" CssClass="control" OnClick="bt_4_watch_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="bt_4_3_upload" runat="server" Text="העלה" CssClass="control" OnClick="bt_4_upload_Click" />
                    <asp:Button ID="bt_4_3_watch" runat="server" Text="צפה" CssClass="control" OnClick="bt_4_watch_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="bt_4_4_upload" runat="server" Text="העלה" CssClass="control" OnClick="bt_4_upload_Click" />
                    <asp:Button ID="bt_4_4_watch" runat="server" Text="צפה" CssClass="control" OnClick="bt_4_watch_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="bt_4_5_upload" runat="server" Text="העלה" CssClass="control" OnClick="bt_4_upload_Click" />
                    <asp:Button ID="bt_4_5_watch" runat="server" Text="צפה" CssClass="control" OnClick="bt_4_watch_Click" />
                </td>
            </tr>
        </table>
        <asp:Button ID="bt_save" runat="server" Text="שמור" CssClass="control" OnClick="bt_save_Click" />
        <asp:Button ID="bt_clear" runat="server" Text="נקה" CssClass="control" OnClick="bt_clear_Click" />
    </form>
</body>
</html>