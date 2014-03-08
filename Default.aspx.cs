using System;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null &&
            ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void bt_start_Click(object sender, EventArgs e)
    {
        bool isOk = false;
        string file = Server.MapPath("~/admin/users.dat");
        //Hash.DecryptFile(file);
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string username = line.Split('$')[0];
            string password = line.Split('$')[1];
            string aviables = line.Split('$')[2];
            if (username == tb_username.Text && password == tb_password.Text)
            {
                isOk = true;
                Session["login_permission"] = aviables;
            }
        }
        //Hash.EcryptFile(file);

        if (isOk)
        {
            Session["Login"] = tb_username.Text + tb_password.Text + "$" + Hash.CalculateSHA1(tb_username.Text + tb_password.Text);
            Session.Timeout = 30;
            Response.Redirect("Home.aspx");
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert(\" נסה שוב\")", true);
        }
    }
}