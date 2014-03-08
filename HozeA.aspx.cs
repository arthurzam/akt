using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class HozeA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]))
        {
            if (first.Value == "1")
            {
                LoadFile();
                first.Value = "0";
            }
            setVisibility();
            setAllSums();
        }
        else
        {
            Response.Redirect("needLogin.html", true);
        }
    }

    #region basic func

    private void setVisibility()
    {
        if (!Directory.Exists(Server.MapPath("~/files/hozeA/")))
            Directory.CreateDirectory(Server.MapPath("~/files/hozeA/"));
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
    }

    private void SetSum(ITextControl lb_sum, ITextControl tb1, ITextControl tb2, ITextControl tb3, ITextControl tb4, ITextControl tb5)
    {
        double a, b, c, d, e;
        double.TryParse(tb1.Text, out a);
        double.TryParse(tb2.Text, out b);
        double.TryParse(tb3.Text, out c);
        double.TryParse(tb4.Text, out d);
        double.TryParse(tb5.Text, out e);
        lb_sum.Text = (a + b + c + d + e) + "";
    }

    private void SetSpecialSum(ITextControl to, ITextControl fisrt, params ITextControl[] from)
    {
        double sum = 0;
        double.TryParse(fisrt.Text, out sum);
        foreach (ITextControl c in from)
        {
            double a = 0;
            double.TryParse(c.Text, out a);
            sum -= a;
        }
        to.Text = sum + "";
    }

    private void setAllSums()
    {
        SetSum(tb_2_6, tb_2_1, tb_2_2, tb_2_3, tb_2_4, tb_2_5);
        SetSum(tb_3_6, tb_3_1, tb_3_2, tb_3_3, tb_3_4, tb_3_5);
        SetSum(tb_4_6, tb_4_1, tb_4_2, tb_4_3, tb_4_4, tb_4_5);
        SetSum(tb_5_6, tb_5_1, tb_5_2, tb_5_3, tb_5_4, tb_5_5);
        SetSum(tb_6_6, tb_6_1, tb_6_2, tb_6_3, tb_6_4, tb_6_5);
        SetSum(tb_7_6, tb_7_1, tb_7_2, tb_7_3, tb_7_4, tb_7_5);
        SetSum(tb_8_6, tb_8_1, tb_8_2, tb_8_3, tb_8_4, tb_8_5);
        SetSum(tb_9_6, tb_9_1, tb_9_2, tb_9_3, tb_9_4, tb_9_5);
        SetSum(tb_10_6, tb_10_1, tb_10_2, tb_10_3, tb_10_4, tb_10_5);
        SetSum(tb_11_6, tb_11_1, tb_11_2, tb_11_3, tb_11_4, tb_11_5);
        SetSum(tb_12_6, tb_12_1, tb_12_2, tb_12_3, tb_12_4, tb_12_5);
        SetSum(tb_13_6, tb_13_1, tb_13_2, tb_13_3, tb_13_4, tb_13_5);
        SetSum(tb_14_6, tb_14_1, tb_14_2, tb_14_3, tb_14_4, tb_14_5);

        SetSpecialSum(tb_15_1, tb_2_1, tb_3_1, tb_4_1, tb_5_1, tb_6_1, tb_7_1, tb_8_1, tb_9_1, tb_10_1, tb_11_1, tb_12_1, tb_13_1, tb_14_1);
        SetSpecialSum(tb_15_2, tb_2_2, tb_3_2, tb_4_2, tb_5_2, tb_6_2, tb_7_2, tb_8_2, tb_9_2, tb_10_2, tb_11_2, tb_12_2, tb_13_2, tb_14_2);
        SetSpecialSum(tb_15_3, tb_2_3, tb_3_3, tb_4_3, tb_5_3, tb_6_3, tb_7_3, tb_8_3, tb_9_3, tb_10_3, tb_11_3, tb_12_3, tb_13_3, tb_14_3);
        SetSpecialSum(tb_15_4, tb_2_4, tb_3_4, tb_4_4, tb_5_4, tb_6_4, tb_7_4, tb_8_4, tb_9_4, tb_10_4, tb_11_4, tb_12_4, tb_13_4, tb_14_4);
        SetSpecialSum(tb_15_5, tb_2_5, tb_3_5, tb_4_5, tb_5_5, tb_6_5, tb_7_5, tb_8_5, tb_9_5, tb_10_5, tb_11_5, tb_12_5, tb_13_5, tb_14_5);
        SetSum(tb_15_6, tb_15_1, tb_15_2, tb_15_3, tb_15_4, tb_15_5);
    }

    private void LoadFile()
    {
        string path = Server.MapPath("~/data/hozeA.txt");
        if (File.Exists(path))
        {
            FileStream fs = File.OpenRead(path);
            BinaryReader br = new BinaryReader(fs);

            string current = "";

            #region row2

            current = br.ReadString();
            tb_2_1.Text = current;
            tb_2_1.Enabled = current == "";
            current = br.ReadString();
            tb_2_2.Text = current;
            tb_2_2.Enabled = current == "";
            current = br.ReadString();
            tb_2_3.Text = current;
            tb_2_3.Enabled = current == "";
            current = br.ReadString();
            tb_2_4.Text = current;
            tb_2_4.Enabled = current == "";
            current = br.ReadString();
            tb_2_5.Text = current;
            tb_2_5.Enabled = current == "";

            #endregion row2

            #region row3

            current = br.ReadString();
            tb_3_1.Text = current;
            tb_3_1.Enabled = current == "";
            current = br.ReadString();
            tb_3_2.Text = current;
            tb_3_2.Enabled = current == "";
            current = br.ReadString();
            tb_3_3.Text = current;
            tb_3_3.Enabled = current == "";
            current = br.ReadString();
            tb_3_4.Text = current;
            tb_3_4.Enabled = current == "";
            current = br.ReadString();
            tb_3_5.Text = current;
            tb_3_5.Enabled = current == "";

            #endregion row3

            #region row4

            current = br.ReadString();
            tb_4_1.Text = current;
            tb_4_1.Enabled = current == "";
            current = br.ReadString();
            tb_4_2.Text = current;
            tb_4_2.Enabled = current == "";
            current = br.ReadString();
            tb_4_3.Text = current;
            tb_4_3.Enabled = current == "";
            current = br.ReadString();
            tb_4_4.Text = current;
            tb_4_4.Enabled = current == "";
            current = br.ReadString();
            tb_4_5.Text = current;
            tb_4_5.Enabled = current == "";

            #endregion row4

            #region row5

            current = br.ReadString();
            tb_5_1.Text = current;
            tb_5_1.Enabled = current == "";
            current = br.ReadString();
            tb_5_2.Text = current;
            tb_5_2.Enabled = current == "";
            current = br.ReadString();
            tb_5_3.Text = current;
            tb_5_3.Enabled = current == "";
            current = br.ReadString();
            tb_5_4.Text = current;
            tb_5_4.Enabled = current == "";
            current = br.ReadString();
            tb_5_5.Text = current;
            tb_5_5.Enabled = current == "";

            #endregion row5

            #region row6

            current = br.ReadString();
            tb_6_1.Text = current;
            tb_6_1.Enabled = current == "";
            current = br.ReadString();
            tb_6_2.Text = current;
            tb_6_2.Enabled = current == "";
            current = br.ReadString();
            tb_6_3.Text = current;
            tb_6_3.Enabled = current == "";
            current = br.ReadString();
            tb_6_4.Text = current;
            tb_6_4.Enabled = current == "";
            current = br.ReadString();
            tb_6_5.Text = current;
            tb_6_5.Enabled = current == "";

            #endregion row6

            #region row7

            current = br.ReadString();
            tb_7_1.Text = current;
            tb_7_1.Enabled = current == "";
            current = br.ReadString();
            tb_7_2.Text = current;
            tb_7_2.Enabled = current == "";
            current = br.ReadString();
            tb_7_3.Text = current;
            tb_7_3.Enabled = current == "";
            current = br.ReadString();
            tb_7_4.Text = current;
            tb_7_4.Enabled = current == "";
            current = br.ReadString();
            tb_7_5.Text = current;
            tb_7_5.Enabled = current == "";

            #endregion row7

            #region row8

            current = br.ReadString();
            tb_8_1.Text = current;
            tb_8_1.Enabled = current == "";
            current = br.ReadString();
            tb_8_2.Text = current;
            tb_8_2.Enabled = current == "";
            current = br.ReadString();
            tb_8_3.Text = current;
            tb_8_3.Enabled = current == "";
            current = br.ReadString();
            tb_8_4.Text = current;
            tb_8_4.Enabled = current == "";
            current = br.ReadString();
            tb_8_5.Text = current;
            tb_8_5.Enabled = current == "";

            #endregion row8

            #region row9

            current = br.ReadString();
            tb_9_1.Text = current;
            tb_9_1.Enabled = current == "";
            current = br.ReadString();
            tb_9_2.Text = current;
            tb_9_2.Enabled = current == "";
            current = br.ReadString();
            tb_9_3.Text = current;
            tb_9_3.Enabled = current == "";
            current = br.ReadString();
            tb_9_4.Text = current;
            tb_9_4.Enabled = current == "";
            current = br.ReadString();
            tb_9_5.Text = current;
            tb_9_5.Enabled = current == "";

            #endregion row9

            #region row10

            current = br.ReadString();
            tb_10_1.Text = current;
            tb_10_1.Enabled = current == "";
            current = br.ReadString();
            tb_10_2.Text = current;
            tb_10_2.Enabled = current == "";
            current = br.ReadString();
            tb_10_3.Text = current;
            tb_10_3.Enabled = current == "";
            current = br.ReadString();
            tb_10_4.Text = current;
            tb_10_4.Enabled = current == "";
            current = br.ReadString();
            tb_10_5.Text = current;
            tb_10_5.Enabled = current == "";

            #endregion row10

            #region row11

            current = br.ReadString();
            tb_11_1.Text = current;
            tb_11_1.Enabled = current == "";
            current = br.ReadString();
            tb_11_2.Text = current;
            tb_11_2.Enabled = current == "";
            current = br.ReadString();
            tb_11_3.Text = current;
            tb_11_3.Enabled = current == "";
            current = br.ReadString();
            tb_11_4.Text = current;
            tb_11_4.Enabled = current == "";
            current = br.ReadString();
            tb_11_5.Text = current;
            tb_11_5.Enabled = current == "";

            #endregion row11

            #region row12

            current = br.ReadString();
            tb_12_1.Text = current;
            tb_12_1.Enabled = current == "";
            current = br.ReadString();
            tb_12_2.Text = current;
            tb_12_2.Enabled = current == "";
            current = br.ReadString();
            tb_12_3.Text = current;
            tb_12_3.Enabled = current == "";
            current = br.ReadString();
            tb_12_4.Text = current;
            tb_12_4.Enabled = current == "";
            current = br.ReadString();
            tb_12_5.Text = current;
            tb_12_5.Enabled = current == "";

            #endregion row12

            #region row13

            current = br.ReadString();
            tb_13_1.Text = current;
            tb_13_1.Enabled = current == "";
            current = br.ReadString();
            tb_13_2.Text = current;
            tb_13_2.Enabled = current == "";
            current = br.ReadString();
            tb_13_3.Text = current;
            tb_13_3.Enabled = current == "";
            current = br.ReadString();
            tb_13_4.Text = current;
            tb_13_4.Enabled = current == "";
            current = br.ReadString();
            tb_13_5.Text = current;
            tb_13_5.Enabled = current == "";

            #endregion row13

            #region row14

            current = br.ReadString();
            tb_14_1.Text = current;
            tb_14_1.Enabled = current == "";
            current = br.ReadString();
            tb_14_2.Text = current;
            tb_14_2.Enabled = current == "";
            current = br.ReadString();
            tb_14_3.Text = current;
            tb_14_3.Enabled = current == "";
            current = br.ReadString();
            tb_14_4.Text = current;
            tb_14_4.Enabled = current == "";
            current = br.ReadString();
            tb_14_5.Text = current;
            tb_14_5.Enabled = current == "";

            #endregion row14

            setAllSums();

            br.Close();
            fs.Close();
        }
    }

    #endregion basic func

    protected void bt_save_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/data/hozeA.txt");
        if (!Directory.Exists(Path.GetDirectoryName(path)))
            Directory.CreateDirectory(Path.GetDirectoryName(path));

        FileStream fs = File.OpenWrite(path);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(tb_2_1.Text);
        bw.Write(tb_2_2.Text);
        bw.Write(tb_2_3.Text);
        bw.Write(tb_2_4.Text);
        bw.Write(tb_2_5.Text);

        bw.Write(tb_3_1.Text);
        bw.Write(tb_3_2.Text);
        bw.Write(tb_3_3.Text);
        bw.Write(tb_3_4.Text);
        bw.Write(tb_3_5.Text);

        bw.Write(tb_4_1.Text);
        bw.Write(tb_4_2.Text);
        bw.Write(tb_4_3.Text);
        bw.Write(tb_4_4.Text);
        bw.Write(tb_4_5.Text);

        bw.Write(tb_5_1.Text);
        bw.Write(tb_5_2.Text);
        bw.Write(tb_5_3.Text);
        bw.Write(tb_5_4.Text);
        bw.Write(tb_5_5.Text);

        bw.Write(tb_6_1.Text);
        bw.Write(tb_6_2.Text);
        bw.Write(tb_6_3.Text);
        bw.Write(tb_6_4.Text);
        bw.Write(tb_6_5.Text);

        bw.Write(tb_7_1.Text);
        bw.Write(tb_7_2.Text);
        bw.Write(tb_7_3.Text);
        bw.Write(tb_7_4.Text);
        bw.Write(tb_7_5.Text);

        bw.Write(tb_8_1.Text);
        bw.Write(tb_8_2.Text);
        bw.Write(tb_8_3.Text);
        bw.Write(tb_8_4.Text);
        bw.Write(tb_8_5.Text);

        bw.Write(tb_9_1.Text);
        bw.Write(tb_9_2.Text);
        bw.Write(tb_9_3.Text);
        bw.Write(tb_9_4.Text);
        bw.Write(tb_9_5.Text);

        bw.Write(tb_10_1.Text);
        bw.Write(tb_10_2.Text);
        bw.Write(tb_10_3.Text);
        bw.Write(tb_10_4.Text);
        bw.Write(tb_10_5.Text);

        bw.Write(tb_11_1.Text);
        bw.Write(tb_11_2.Text);
        bw.Write(tb_11_3.Text);
        bw.Write(tb_11_4.Text);
        bw.Write(tb_11_5.Text);

        bw.Write(tb_12_1.Text);
        bw.Write(tb_12_2.Text);
        bw.Write(tb_12_3.Text);
        bw.Write(tb_12_4.Text);
        bw.Write(tb_12_5.Text);

        bw.Write(tb_13_1.Text);
        bw.Write(tb_13_2.Text);
        bw.Write(tb_13_3.Text);
        bw.Write(tb_13_4.Text);
        bw.Write(tb_13_5.Text);

        bw.Write(tb_14_1.Text);
        bw.Write(tb_14_2.Text);
        bw.Write(tb_14_3.Text);
        bw.Write(tb_14_4.Text);
        bw.Write(tb_14_5.Text);

        bw.Close();
        fs.Close();

        LoadFile();
    }

    protected void bt_clear_Click(object sender, EventArgs e)
    {
        File.Delete(Server.MapPath("~/data/hozeA.txt"));
        Response.Redirect("HozeA.aspx");
        LoadFile();
        setVisibility();
    }

    protected void bt_hozeTohen_Click(object sender, EventArgs e)
    {
        string id = ((Button)sender).ID;
        string gizra = id.Split('_')[2];
        int type = int.Parse(id.Split('_')[1]);
        Session["HozeTohen_gizra"] = gizra;
        Session["HozeTohen_type"] = type;
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('HozeTohen.aspx', 'mywindow', 'width=300,height=500,resizable=no')", true);
    }
}