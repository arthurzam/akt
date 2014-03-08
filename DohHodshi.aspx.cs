using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

/// <version>18.12.2012</version>
public partial class DohHodshi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            if (Hidden_first.Value == "1")
            {
                ddp_month.Items.Clear();
                int monthNum = General.getTheReadyMonth() + 1;
                if (monthNum == 13)
                {
                    ddp_year.SelectedIndex--;
                    monthNum = 12;
                }
                for (int i = 1; i <= monthNum; i++)
                    ddp_month.Items.Add(new ListItem(General.monthText[i - 1], i + ""));
                ddp_month.SelectedIndex = monthNum - 1;
                Hidden_first.Value = "0";
            }
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
        int result;
        try
        {
            FileStream fs = File.OpenRead(Server.MapPath("~/data/hoze" + hoze + ".txt"));
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < (ddp_month.SelectedIndex + 1) * 5 + gizra; i++)
                br.ReadString();
            result = int.Parse(br.ReadString());
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
            for (int x = 0; x < ddp_month.SelectedIndex + 1; x++)
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
                ((Label)FindControl("lb_hA_" + gizra)).Text = hozeA + "";
            }
            {
                int hozeTA = ReadTotalHoze("A", i);
                total_tA += hozeTA;
                ((Label)FindControl("lb_hAT_" + gizra)).Text = hozeTA + "";
            }
            {
                int hozeB = ReadMoneyHoze("B", i);
                total_B += hozeB;
                ((Label)FindControl("lb_hB_" + gizra)).Text = hozeB + "";
            }
            {
                int hozeTB = ReadTotalHoze("B", i);
                total_tB += hozeTB;
                ((Label)FindControl("lb_hBT_" + gizra)).Text = hozeTB + "";
            }
            {
                if(!Directory.Exists(Server.MapPath("~/data/mesimot/" + gizra + "/")))
                    Directory.CreateDirectory(Server.MapPath("~/data/mesimot/" + gizra + "/"));
                int mesimot = Directory.GetFiles(Server.MapPath("~/data/mesimot/" + gizra + "/"), "*_0_" + ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*_*.txt").Length;
                total_mes += mesimot;
                ((Label)FindControl("lb_mes_" + gizra)).Text = mesimot + "";
            }
            {
                if (!Directory.Exists(Server.MapPath("~/data/takalot/" + gizra + "/")))
                    Directory.CreateDirectory(Server.MapPath("~/data/takalot/" + gizra + "/"));
                int takalot = Directory.GetFiles(Server.MapPath("~/data/takalot/" + gizra + "/"), "*_0_"+ ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*_*.txt").Length;
                total_tak += takalot;
                ((Label)FindControl("lb_tak_" + gizra)).Text = takalot + "";
            }
            {
                int images = 0;
                if (Directory.Exists(Server.MapPath("~/files/pictures/A/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/A/" + gizra + "/"), ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*.*").Length;
                if(Directory.Exists(Server.MapPath("~/files/pictures/B/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/B/" + gizra + "/"), ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*.*").Length;
                if(Directory.Exists(Server.MapPath("~/files/pictures/mes/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/mes/" + gizra + "/"), ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*.*").Length;
                if(Directory.Exists(Server.MapPath("~/files/pictures/tak/" + gizra + "/")))
                    images += Directory.GetFiles(Server.MapPath("~/files/pictures/tak/" + gizra + "/"), ddp_year.SelectedValue + "_" + ddp_month.SelectedValue + "_*.*").Length;
                total_img += images;
                ((Label)FindControl("lb_img_" + gizra)).Text = images + "";
            }
        }
        lb_hA_all.Text = total_A + "";
        lb_hAT_all.Text = total_tA + "";
        lb_hB_all.Text = total_B + "";
        lb_hBT_all.Text = total_tB + "";
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
        Session["HozeTohen_special"] = "hodesh_" + ddp_month.SelectedValue + "_" + ddp_year.SelectedValue;
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('HozeTohen.aspx', 'mywindow', 'width=300,height=500,resizable=no')", true);
    }
}