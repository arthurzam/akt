using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <remarks>
/// indexing of mesimot:
///     file: /data/[mesimot?takalot]/[gizra]/
///     name: [num]_[bool_ready?1:0]_[year]_[month]_[day]_[title].txt
/// </remarks>
/// <version>16.12.2012</version>
public partial class Mesimot : System.Web.UI.Page
{
    private string file_name = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            if (Hidden_first.Value == "1")
            {
                ddp_month.SelectedIndex = DateTime.Now.Month - 1;
                Hidden_first.Value = "0";
            }

            file_name = ddp_year.SelectedValue + "_" + ddp_month.SelectedValue;

            {
                setAll();
            }

            /*SetAllPanels("menashe", Panel_menashe);
            SetAllPanels("efraim", Panel_efraim);
            SetAllPanels("binyamin", Panel_binyamin);
            SetAllPanels("jerusalem", Panel_jerusalem);
            SetAllPanels("yehuda", Panel_yehuda);*/
        }
        else
        {
            Response.Redirect("needLogin.html", true);
        }
    }

    protected void bt_add_Click(object sender, EventArgs e)
    {
        string id = ((Button)sender).ID;
        Session["mesima_upload"] = id.Split('_')[1] + "/" + id.Split('_')[2];
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "popupwindow('MesimaCreator.aspx', 'mywindow', 480, 600)", true);
    }

    protected void Timer_refresh_Tick(object sender, EventArgs e)
    {
        /*SetAllPanels("menashe", Panel_menashe);
        SetAllPanels("efraim", Panel_efraim);
        SetAllPanels("binyamin", Panel_binyamin);
        SetAllPanels("jerusalem", Panel_jerusalem);
        SetAllPanels("yehuda", Panel_yehuda);*/
    }

    /// <param name="label">the label to be changed</param>
    /// <param name="searchName">the search file name, {"1","*","0"}</param>
    /// <param name="searchFolder">the folder, "{"mesimot","takalot"}/[gizra / "*"]"</param>
    private void SetTheAmount(Button label, string searchName, string searchFolder)
    {
        string folder = Server.MapPath("~/data/" + searchFolder + "/");
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        int number = Directory.GetFiles(folder, "*_" + searchName + "_" + ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*").Length;
        label.Text = (number > 0 ? number + "" : "0");
        label.Enabled = (label.Text != "0");
    }

    private void setAll()
    {
        string[] type = { "takalot", "mesimot" };
        string[] search = { "total", "yes", "no" };
        string[] gizrot = { "menashe", "efraim", "binyamin", "jerusalem", "yehuda" };
        foreach (string typeOfMesima in type)
        {
            foreach (string searchPattern in search)
            {
                foreach (string gizra in gizrot)
                {
                    string searchFile = "";
                    switch (searchPattern)
                    {
                        case "total": searchFile = "*"; break;
                        case "yes": searchFile = "1"; break;
                        case "no": searchFile = "0"; break;
                    }
                    SetTheAmount((Button)FindControl("lb_" + typeOfMesima + "_" + searchPattern + "_" + gizra),
                        searchFile, typeOfMesima + "/" + gizra);
                }

                try
                {
                    ((Label)FindControl("lb_" + typeOfMesima + "_" + searchPattern + "_all")).Text = calculateTheSum("lb_" + typeOfMesima + "_" + searchPattern).ToString();
                }
                catch { throw new System.Exception("lb_" + typeOfMesima + "_" + searchPattern + "_all"); }
            }
        }
    }

    protected void lb_watch_Click(object sender, EventArgs e)
    {
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "popupwindow('MesimaGroupViewer.aspx', '', 480, 600)", true);
        string id = ((Button)sender).ID;
        //lb_mesimot_no_efraim
        Session["Mesima_folder"] = id.Split('_')[1] + "/" + id.Split('_')[3];
        string searchFile = "";
        switch (id.Split('_')[2])
        {
            case "total": searchFile = "*"; break;
            case "yes": searchFile = "1"; break;
            case "no": searchFile = "0"; break;
        }
        Session["Mesima_search"] = searchFile + "_" + ddp_year.SelectedValue + "_" + ddp_month.SelectedValue;
        ClientScript.RegisterClientScriptBlock(GetType(), "Open", "window.open('MesimaGroupViewer.aspx','','location=0, width=480, height=600',false)", true);
    }

    private int calculateTheSum(string groupName)
    {
        return int.Parse(((Button)FindControl(groupName + "_menashe")).Text) +
               int.Parse(((Button)FindControl(groupName + "_efraim")).Text) +
               int.Parse(((Button)FindControl(groupName + "_binyamin")).Text) +
               int.Parse(((Button)FindControl(groupName + "_jerusalem")).Text) +
               int.Parse(((Button)FindControl(groupName + "_yehuda")).Text);
    }
}