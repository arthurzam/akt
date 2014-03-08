using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <remarks>
/// [type] - {"A","B","mes","tak"}
/// folder: /files/pictures/[type]/[gizra]
/// name: [year]_[month]_[day]_[num]_[title].[extension]
/// </remarks>
/// <version>17.12.2012</version>
public partial class Tmunot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Hidden_first.Value == "1")
        {
            ddp_month.SelectedIndex = DateTime.Now.Month - 1;
            Hidden_first.Value = "0";
        }
        setVisibile();
    }

    protected void bt_upload_Click(object sender, EventArgs e)
    {
        Session["image_upload_gizra"] = ((Button)sender).ID.Split('_')[2];
        ClientScript.RegisterClientScriptBlock(GetType(), "Open", "window.open('TmunaUpload.aspx','','location=0, width=480, height=600',false)", true);
    }

    private void setVisibile()
    {
        string[] gizras = { "menashe", "efraim", "binyamin", "jerusalem", "yehuda" };
        string[] types = { "A", "B", "mes", "tak" };
        foreach (string type in types)
        {
            int total = 0;
            foreach(string gizra in gizras)
            {
                int amount = 0;
                if(Directory.Exists(Server.MapPath("~/files/pictures/" + type + "/" + gizra + "/")))
                    amount = Directory.GetFiles(Server.MapPath("~/files/pictures/" + type + "/" + gizra + "/"), 
                        ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*_*.*").Length;
                Button bt = (Button)FindControl("bt_" + type + "_" + gizra);
                bt.Text = amount + "";
                bt.Enabled = amount > 0;
                total += amount;
            }
            ((Label)FindControl("bt_" + type + "_all")).Text = total + "";
        }
    }

    protected void bt_watch_Click(object sender, EventArgs e)
    {
        //bt_A_binyamin
        Session["tmuna_group_name"] = ((Button)sender).ID.Split('_')[1] + "/" + ((Button)sender).ID.Split('_')[2];
        ClientScript.RegisterClientScriptBlock(GetType(), "Open", "window.open('TmunaGroup.aspx','','location=0, width=480, height=600',false)", true);
    }

    protected void Timer_refresh_Tick(object sender, EventArgs e)
    {
        setVisibile();
    }
}