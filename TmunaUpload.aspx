<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TmunaUpload.aspx.cs" Inherits="TmunaUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>העלאת תמונה</title>
    <link href="main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table border="0">
            <tr>
                <th>לשייך תמונה לקבוצה:</th>
                <td>
                    <asp:DropDownList ID="ddp_type" runat="server" AutoPostBack="true">
                        <asp:ListItem Value="A">חוזה א - אחזקה מקיפה</asp:ListItem>
                        <asp:ListItem Value="B">חוזה ב - אחזקת שבר</asp:ListItem>
                        <asp:ListItem Value="mes">משימות</asp:ListItem>
                        <asp:ListItem Value="tak">תקלות</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>גזרה:</th>
                <td><asp:Label ID="lb_gizra" runat="server" Text="#" /></td>
            </tr>
            <tr>
                <th>מספר התמונה:</th>
                <td><asp:Label ID="lb_number" runat="server" Text="#" /></td>
            </tr>
            <tr>
                <th>כותרת:</th>
                <td>
                    
                    <input type="text" runat="server" id="tb_title" maxlength="40" />
                    <asp:RequiredFieldValidator runat="server" ID="val_tb_title" ControlToValidate="tb_title" ValidationGroup="val"
                        ErrorMessage="חסר" ForeColor="#FF0000" />
                </td>
            </tr>
            <tr>
                <th>העלה</th>
                <td>
                    <asp:FileUpload ID="FileUpload_picture" runat="server" /><br />
                    <asp:RegularExpressionValidator runat="server" ID="val_FileUpload_picture" ControlToValidate="FileUpload_picture"
                        ErrorMessage="תמונות מהסיומות הבאות בלבד (jpg, bmp, png, gif)"  ValidationGroup="val" ForeColor="Red"
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="bt_ok" runat="server" Text="העלה" OnClick="bt_ok_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
