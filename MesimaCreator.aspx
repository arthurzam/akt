<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MesimaCreator.aspx.cs" Inherits="MesimaCreator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>יוצר המשימות / תקלות</title>
    <link href="main.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Language" content="he" />
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <script src="JavaScriptMain.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1
        {
            height: 24px;
        }
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server" dir="rtl">
            <asp:HiddenField ID="Hidden_first" runat="server" Value="1" />
            <asp:HiddenField ID="Hidden_pathToFile" runat="server" Value="" />
            <table border="0">
                <tr>
                    <td>מספר משימה/תקלה:</td>
                    <td><asp:Label ID="lb_number" runat="server" Text="Label" /></td>
                </tr>
                <tr>
                    <td>תאריך הזנה:</td>
                    <td><asp:Label ID="lb_date" runat="server" CssClass="control" /></td>
                </tr>
                <tr>
                    <td>כותרת:</td>
                    <td><asp:TextBox ID="tb_title" runat="server" CssClass="control" Width="98%" MaxLength="40" /></td>
                </tr>
                <tr>
                    <td>תיאור:</td>
                    <td>
                        <asp:TextBox ID="tb_text" runat="server" CssClass="control" Columns="30" Rows="3"
                            TextMode="MultiLine" Width="329px" />
                    </td>
                </tr>
                <tr>
                    <td>אומדן</td>
                    <td>
                        <input type="text" runat="server" id="tb_omdan"
                            onkeypress="javascript:return TextBoxDecimal_onKeyPress(event);" class="control"
                            style="width:98%" />
                    </td>
                </tr>
                <tr>
                    <td>לו"ז לבירור</td>
                    <td>
                        <input type="text" runat="server" id="tb_luz"
                            onkeypress="javascript:return TextBoxDecimal_onKeyPress(event);" class="control"
                            style="width:98%" />
                    </td>
                </tr>
                <tr>
                    <td>הוראות</td>
                    <td align="right">
                        <asp:HiddenField ID="Hidden_horaotFile" runat="server" Value="-" />
                        <asp:FileUpload ID="FileUpload_horaot" CssClass="control" runat="server" Width="100%" /><br />
                        <asp:Button ID="bt_horaot_upload" runat="server" CssClass="control" Text="הוסף" OnClick="bt_horaot_Click" Width="60%" /><br />
                        <asp:Button ID="bt_horaot_watch" runat="server" CssClass="control" Text="צפה" OnClick="bt_horaot_Click" Width="60%" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right" class="auto-style1">
                        <asp:CheckBox ID="cb_ready" runat="server" Text="מוכן וטופל" />
                    </td>
                </tr>
                <%--<tr>
                    <td>תמונות
                    </td>
                    <td>
                        <asp:Panel ID="panel_pictures_create" runat="server">
                            <asp:CheckBoxList ID="cbl_pictures" runat="server" Visible="False">
                            </asp:CheckBoxList>
                            <asp:FileUpload ID="FileUpload_pictures" CssClass="control" runat="server" Width="100%" /><br />
                            <asp:Button ID="bt_pictures" runat="server" CssClass="control" Text="הוסף" OnClick="bt_pictures_Click" />
                        </asp:Panel>
                        <asp:Panel ID="panel_pictures_open" runat="server" Width="100%">
                        </asp:Panel>
                    </td>
                </tr>--%>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Button ID="bt_ok" runat="server" CssClass="control" Text="שמור" OnClick="bt_ok_Click" Width="60%" />
                    </td>
                </tr>
            </table>
        </form>
    </center>
</body>
</html>