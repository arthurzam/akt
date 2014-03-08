using System;
using System.Globalization;
using System.Threading;
using System.Drawing;

public partial class _Home : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        if (Request.Form["ddp_language"] != null)
        {
            string selectedLanguage = Request.Form["ddp_language"];
            UICulture = selectedLanguage;
            Culture = selectedLanguage;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        }
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bool isLogged = Session["Login"] != null;
        isLogged = isLogged && (((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]));
        if (isLogged)
        {
            isLogged = isLogged && (Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]) == Hash.adminHash);
            if (isLogged) // admin
            {
                bt_admin.Enabled = bt_admin.Visible = true;
            }
        }
        else
            Response.Redirect("default.aspx", true);
    }

    protected void bt_log_out_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("default.aspx", true);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='Netunim.aspx' width='100%' height='100%' border='0'> </iframe>";
        Button3.BackColor = System.Drawing.Color.Yellow;
        Button4.BackColor = Button1.BackColor;
        Button5.BackColor = Button1.BackColor;
        Button6.BackColor = Button1.BackColor;
        Button7.BackColor = Button1.BackColor;
        Button8.BackColor = Button1.BackColor;
        Button9.BackColor = Button1.BackColor;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='HozeA.aspx' width='100%' height='100%' border='0'> </iframe>";
        Button3.BackColor = Button1.BackColor;
        Button4.BackColor = System.Drawing.Color.Yellow;
        Button5.BackColor = Button1.BackColor;
        Button6.BackColor = Button1.BackColor;
        Button7.BackColor = Button1.BackColor;
        Button8.BackColor = Button1.BackColor;
        Button9.BackColor = Button1.BackColor;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='HozeB.aspx' width='100%' height='100%' border='0'> </iframe>";
        Button3.BackColor = Button1.BackColor;
        Button4.BackColor = Button1.BackColor;
        Button5.BackColor = System.Drawing.Color.Yellow;
        Button6.BackColor = Button1.BackColor;
        Button7.BackColor = Button1.BackColor;
        Button8.BackColor = Button1.BackColor;
        Button9.BackColor = Button1.BackColor;
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='Mesimot.aspx' width='100%' height='100%' border='0'> </iframe>";
        Button3.BackColor = Button1.BackColor;
        Button4.BackColor = Button1.BackColor;
        Button5.BackColor = Button1.BackColor;
        Button6.BackColor = System.Drawing.Color.Yellow;
        Button7.BackColor = Button1.BackColor;
        Button8.BackColor = Button1.BackColor;
        Button9.BackColor = Button1.BackColor;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='Tmunot.aspx' width='100%' height='100%' border='0'> </iframe>";
        Button3.BackColor = Button1.BackColor;
        Button4.BackColor = Button1.BackColor;
        Button5.BackColor = Button1.BackColor;
        Button6.BackColor = Button1.BackColor;
        Button7.BackColor = System.Drawing.Color.Yellow;
        Button8.BackColor = Button1.BackColor;
        Button9.BackColor = Button1.BackColor;
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='DohHodshi.aspx' width='100%' height='100%' border='0'> </iframe>";
        Button3.BackColor = Button1.BackColor;
        Button4.BackColor = Button1.BackColor;
        Button5.BackColor = Button1.BackColor;
        Button6.BackColor = Button1.BackColor;
        Button7.BackColor = Button1.BackColor;
        Button8.BackColor = Button1.BackColor;
        Button9.BackColor = System.Drawing.Color.Yellow;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='DohMerukaz.aspx' width='100%' height='100%' border='0'> </iframe>";
        Button3.BackColor = Button1.BackColor;
        Button4.BackColor = Button1.BackColor;
        Button5.BackColor = Button1.BackColor;
        Button6.BackColor = Button1.BackColor;
        Button7.BackColor = Button1.BackColor;
        Button8.BackColor = System.Drawing.Color.Yellow;
        Button9.BackColor = Button1.BackColor;
    }

    protected void bt_admin_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin/controlPanel.aspx");
    }

    protected bool checkIsAdmin()
    {
        bool isLogged = Session["Login"] != null;
        isLogged = isLogged && (((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]));
        isLogged = isLogged && (Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]) == Hash.adminHash);
        return isLogged;
    }
}