<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>אק"ת - אחזקת קו התפר</title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8;he" />
    <style type="text/css">
        #panel
        {
            height: 500px;
            margin: 0 0 auto 0;
        }

        .style1
        {
            height: 100%;
            width: 100%;
        }

        .panel_menu
        {
            margin-top: 5px;
            padding-top: 5px;
            height: 500px;
            margin: 0 0 auto 0;
        }

        .td
        {
            width:14%;
            text-align:center;
        }
    </style>
</head>
<body dir="rtl" style="font-family: David; font-size: x-large; background-color: #DDEEEE;">
    <form id="form1" runat="server">
        <span style="text-align: center;" id="span_logOut">
            <asp:Button ID="Button1" runat="server" Text="התנתק" OnClick="bt_log_out_Click" Font-Names="David"
                Font-Size="X-Large" />
            תאריך נוכחי: 
            <%Response.Write(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year); %>
            <asp:Button ID="bt_admin" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David" Width="100%"
                                        Visible="false" Enabled="false" Font-Size="X-Large" Text="מנהל ראשי"
                                        Height="60px" OnClick="bt_admin_Click" />
        </span>
        <table width="100%">
            <!-- start 16.12.12 change  --><tr>
                <td class="td"><asp:Button ID="Button3" runat="server" Font-Names="David" Width="100%"
                                        Font-Size="X-Large" Text="נתונים" OnClick="Button3_Click" Height="60px" /></td>
                <td class="td"><asp:Button ID="Button4" runat="server" Font-Names="David" Width="100%"
                                        Font-Size="X-Large" Text="חוזה א &#010;אחזקה מקיפה" Height="60px" OnClick="Button4_Click" /></td>
                <td class="td"><asp:Button ID="Button5" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David" Width="100%"
                                        Font-Size="X-Large" Text="חוזה ב &#010;אחזקת שבר" Height="60px" OnClick="Button5_Click" /></td>
                <td class="td"><asp:Button ID="Button6" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David" Width="100%"
                                        Font-Size="X-Large" Text="משימות &#010;ותקלות" Height="60px" OnClick="Button6_Click" /></td>
                <td class="td"><asp:Button ID="Button7" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David" Width="100%"
                                        Font-Size="X-Large" Text="תמונות" Height="60px" OnClick="Button7_Click" /></td>
                <td class="td"><asp:Button ID="Button9" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David" Width="100%"
                                        Font-Size="X-Large" Text="דוח חודשי" Height="60px" OnClick="Button9_Click" /></td>
                <td class="td"><asp:Button ID="Button8" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David" Width="100%"
                                        Font-Size="X-Large" Text="דוח מרוכז" Height="60px" OnClick="Button8_Click" /></td>
            </tr><!-- end 16.12.12 change  -->
            <tr>
                <td>
                    <%--<asp:Panel ID="panel_menu" runat="server" CssClass="panel_menu">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Font-Size="X-Large" Text="נתונים" Width="230px" OnClick="Button3_Click" Height="60px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Font-Size="X-Large" Text="חוזה א אחזקה מקיפה" Width="230px" Height="60px" OnClick="Button4_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button5" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Font-Size="X-Large" Text="חוזה ב אחזקת שבר" Width="230px" Height="60px" OnClick="Button5_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Font-Size="X-Large" Text="משימות ותקלות" Width="230px" Height="60px" OnClick="Button6_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button7" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Font-Size="X-Large" Text="תמונות" Width="230px" Height="60px" OnClick="Button7_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="margin-top: 0px">
                                    <asp:Button ID="Button9" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Font-Size="X-Large" Text="דוח חודשי" Width="230px" Height="60px" OnClick="Button9_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button8" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Font-Size="X-Large" Text="דוח מרוכז" Width="230px" Height="60px" OnClick="Button8_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Button ID="bt_admin" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="David"
                                        Visible="false" Enabled="false" Font-Size="X-Large" Text="מנהל ראשי" Width="230px"
                                        Height="60px" OnClick="bt_admin_Click" />
                                    <%--<br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />--%>
                </td>
            </tr>
    </table>
    <div id="panel" runat="server" width="100%" height="100%" />
    </form>
</body>
</html>