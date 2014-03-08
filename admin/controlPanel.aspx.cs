using System;

public partial class admin_controlPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isLogged = Session["Login"] != null;
        isLogged = isLogged && (((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]));
        isLogged = isLogged && (Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]) == Hash.adminHash);
        if (isLogged)
        {
        }
        else
        {
            Response.Redirect("../default.aspx", true);
        }
    }

    protected void bt_return_Click(object sender, EventArgs e)
    {
        Response.Redirect("../default.aspx", true);
    }

    protected void bt_menu_seeAllFiles_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='BrowseServer.aspx' width='100%' height='100%' border='0'> </iframe>";
        bt_menu_seeAllFiles.BackColor = System.Drawing.Color.Yellow;
        bt_menu_users.BackColor = bt_return.BackColor;
    }

    protected void bt_menu_users_Click(object sender, EventArgs e)
    {
        panel.InnerHtml = "<iframe name='iframe' src='EditUsers.aspx' width='100%' height='100%' border='0'> </iframe>";
        bt_menu_seeAllFiles.BackColor = bt_return.BackColor;
        bt_menu_users.BackColor = System.Drawing.Color.Yellow;
    }
}