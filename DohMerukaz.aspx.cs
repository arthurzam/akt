using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DohMerukaz : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            setAll();
        }
        else
        {
            Response.Redirect("needLogin.html", true);
        }
    }


    /// <summary>
    /// get the row of money per hoze
    /// </summary>
    /// <param name="hoze">A or B - the hoze</param>
    /// <returns></returns>
    private int ReadMoneyHoze(string hoze, int gizra)
    {
        int result = 0;
        try
        {
            FileStream fs = File.OpenRead(Server.MapPath("~/data/hoze" + hoze + ".txt"));
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < 5; ++i)
                br.ReadString();
            for (int x = 0; x < General.getTheReadyMonth(); x++)
            {
                for (int i = 0; i < gizra; ++i)
                    br.ReadString();
                try
                {
                    int current = int.Parse(br.ReadString());
                    result += current;
                }
                catch { }
                for (int i = 0; i < 4 - gizra; ++i)
                    br.ReadString();
            }
            br.Close();
            fs.Close();
        }
        catch
        {
            return 0;
        }
        return result;
    }

    /// <summary>
    /// get the row of total per hoze
    /// </summary>
    /// <param name="hoze">A or B - the hoze</param>
    /// <returns></returns>
    private int ReadTotalHoze(string hoze, int gizra)
    {
        int result;
        try
        {
            FileStream fs = File.OpenRead(Server.MapPath("~/data/hoze" + hoze + ".txt"));
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < gizra; ++i)
                br.ReadString();
            int.TryParse(br.ReadString(), out result);
            for (int i = 0; i < 4 - gizra; ++i)
                br.ReadString();
            for (int x = 0; x < General.getTheReadyMonth(); x++)
            {
                for (int i = 0; i < gizra; ++i)
                    br.ReadString();
                try
                {
                    int current = int.Parse(br.ReadString());
                    result -= current;
                }
                catch { }
                for (int i = 0; i < 4 - gizra; ++i)
                    br.ReadString();
            }
            br.Close();
            fs.Close();
        }
        catch
        {
            return 0;
        }
        return result;
    }

    private void setAll()
    {
        string[] gizrot = { "menashe", "efraim", "binyamin", "jerusalem", "yehuda" };
        int total_A = 0, total_tA = 0, total_B = 0, total_tB = 0, total_mes = 0, total_tak = 0, total_img = 0;
        for (int i = 0; i < 5; i++)
        {
            string gizra = gizrot[i];
            {
                int hozeA = ReadMoneyHoze("A", i);
                total_A += hozeA;
                ((HtmlGenericControl)FindControl("lb_hA_" + gizra)).InnerHtml = hozeA + "";
            }
            {
                int hozeTA = ReadTotalHoze("A", i);
                total_tA += hozeTA;
                ((HtmlGenericControl)FindControl("lb_hTA_" + gizra)).InnerHtml = hozeTA + "";
            }
            {
                int hozeB = ReadMoneyHoze("B", i);
                total_B += hozeB;
                ((HtmlGenericControl)FindControl("lb_hB_" + gizra)).InnerHtml = hozeB + "";
            }
            {
                int hozeTB = ReadTotalHoze("B", i);
                total_tB += hozeTB;
                ((HtmlGenericControl)FindControl("lb_hTB_" + gizra)).InnerHtml = hozeTB + "";
            }
            {
                try
                {
                    int mesimot = Directory.GetFiles(Server.MapPath("~/data/mesimot/" + gizra + "/"), "*_0_" + DateTime.Now.Year + "_" + General.getTheReadyMonth() + "_*_*.txt").Length;
                    total_mes += mesimot;
                    ((Label)FindControl("lb_mes_" + gizra)).Text = mesimot + "";
                }
                catch { ((Label)FindControl("lb_mes_" + gizra)).Text = "0"; }
            }
            {
                try
                {
                    int takalot = Directory.GetFiles(Server.MapPath("~/data/takalot/" + gizra + "/"), "*_0_" + DateTime.Now.Year + "_" + General.getTheReadyMonth() + "_*_*.txt").Length;
                    total_tak += takalot;
                    ((Label)FindControl("lb_tak_" + gizra)).Text = takalot + "";
                }
                catch { ((Label)FindControl("lb_tak_" + gizra)).Text = "0"; }
            }
            {
                int images = 0;
                string searchFile = DateTime.Now.Year + "_" + General.getTheReadyMonth() + "_*.*";
                if (Directory.Exists(Server.MapPath("~/files/pictures/A/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/A/" + gizra + "/"), searchFile).Length;
                if (Directory.Exists(Server.MapPath("~/files/pictures/B/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/B/" + gizra + "/"), searchFile).Length;
                if (Directory.Exists(Server.MapPath("~/files/pictures/mes/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/mes/" + gizra + "/"), searchFile).Length;
                if (Directory.Exists(Server.MapPath("~/files/pictures/tak/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/tak/" + gizra + "/"), searchFile).Length;
                total_img += images;
                ((Label)FindControl("lb_img_" + gizra)).Text = images + "";
            }
        }
        lb_hA_all.InnerHtml = total_A + "";
        lb_hTA_all.InnerHtml = total_tA + "";
        lb_hB_all.InnerHtml = total_B + "";
        lb_hTB_all.InnerHtml = total_tB + "";
        lb_mes_all.Text = total_mes + "";
        lb_tak_all.Text = total_tak + "";
        lb_img_all.Text = total_img + "";
    }

    protected void bt_open_Click(object sender, EventArgs e)
    {
        //bt_michtavim_binyamin
        string id = ((Button)sender).ID;
        string gizra = id.Split('_')[2];
        int type = 4;
        if (id.Split('_')[1] == "michtavim") type = 3;
        Session["HozeTohen_gizra"] = gizra;
        Session["HozeTohen_type"] = type;
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('HozeTohen.aspx', 'mywindow', 'width=300,height=500,resizable=no')", true);
    }
}