<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DohHodshi.aspx.cs" Inherits="DohHodshi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="main.css" type="text/css" />
    <style type="text/css">
        th
        {
            width:14%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="Hidden_first" runat="server" Value="1" />
        <table border="1">
            <tr>
                <td colspan="7">
                    <table>
                        <tr>
                            <td>חודש:</td>
                            <td>
                                <asp:DropDownList ID="ddp_month" runat="server" AutoPostBack="True" CssClass="control"
                                    Width="100%" />
                            </td>
                        </tr>
                        <tr>
                            <td>שנה</td>
                            <td>
                                <asp:DropDownList ID="ddp_year" runat="server" AutoPostBack="True" CssClass="control" Width="100%">
                                    <asp:ListItem Text="2012" Value="2012" />
                                    <asp:ListItem Text="2013" Value="2013" Selected="True" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
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
                <td><a href="HozeA.aspx">חוזה א - אחזקה מקיפה</a></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hA_menashe" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hA_efraim" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hA_binyamin" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hA_jerusalem" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hA_yehuda" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hA_all" /></td>
            </tr>
            <tr>
                <td><a href="HozeA.aspx">סה"כ כסף שנשאר ב-2013 בש"ח</a></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hAT_menashe" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hAT_efraim" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hAT_binyamin" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hAT_jerusalem" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hAT_yehuda" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hAT_all" /></td>
            </tr>
            <tr>
                <td><a href="HozeB.aspx">חוזה ב - אחזקת שבר</a></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hB_menashe" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hB_efraim" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hB_binyamin" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hB_jerusalem" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hB_yehuda" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hB_all" /></td>
            </tr>
            <tr>
                <td><a href="HozeB.aspx">סה"כ כסף שנשאר ב-2013 בש"ח</a></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hBT_menashe" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hBT_efraim" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hBT_binyamin" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hBT_jerusalem" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hBT_yehuda" /></td>
                <td><asp:Label runat="server" CssClass="control" ID="lb_hBT_all" /></td>
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