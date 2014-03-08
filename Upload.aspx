<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>העלאת קובץ</title>
    <link href="main.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Language" content="he" />
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button ID="ButtonUpload" runat="server" Text="שלח" OnClick="ButtonUpload_Click" />
            <br />
            <asp:Image ID="Image_loading" runat="server" ImageUrl="~/Pictures/loading.gif" Visible="false" />
        </div>
    </form>
</body>
</html>