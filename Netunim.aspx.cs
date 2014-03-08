using System;
using System.IO;
using System.Web.UI.WebControls;

public partial class netunim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            if (!Directory.Exists(Server.MapPath("~/files/netunim/")))
                Directory.CreateDirectory(Server.MapPath("~/files/netunim/"));
            if (bt_4_1_upload.Visible == bt_4_1_watch.Visible)
                LoadFile();
            setVisibility();
        }
        else
        {
            Response.Redirect("needLogin.html", true);
        }
    }

    protected void bt_4_upload_Click(object sender, EventArgs e)
    {
        string path = "netunim/";
        switch (((Button)sender).ID.Split('_')[2])
        {
            case "1":
                path += "menashe";
                break;

            case "2":
                path += "efraim";
                break;

            case "3":
                path += "binyamin";
                break;

            case "4":
                path += "jerusalem";
                break;

            case "5":
                path += "yehuda";
                break;
        }
        Session["upload_file_name"] = path;
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_4_watch_Click(object sender, EventArgs e)
    {
        string path = "";
        switch (((Button)sender).ID.Split('_')[2])
        {
            case "1":
                path = "menashe";
                break;

            case "2":
                path = "efraim";
                break;

            case "3":
                path = "binyamin";
                break;

            case "4":
                path = "jerusalem";
                break;

            case "5":
                path = "yehuda";
                break;
        }
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/netunim/"), path + ".*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_kesher_upload_Click(object sender, EventArgs e)
    {
        string path = "netunim/kesher_";
        path += ((Button)sender).ID.Split('_')[2];
        Session["upload_file_name"] = path;
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_kesher_watch_Click(object sender, EventArgs e)
    {
        string path = "kesher_";
        path += ((Button)sender).ID.Split('_')[2];
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/netunim/"), path + ".*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    private void LoadFile()
    {
        string path = Server.MapPath("~/data/netunim.txt");
        if (File.Exists(path))
        {
            FileStream fs = File.OpenRead(path);
            BinaryReader br = new BinaryReader(fs);

            string current = br.ReadString();
            tb_1_1.Text = current;
            tb_1_1.Enabled = new Permissions((string)Session["login_permission"]).canEditMenashe;
            current = br.ReadString();
            tb_1_2.Text = current;
            current = br.ReadString();
            tb_1_3.Text = current;
            current = br.ReadString();
            tb_1_4.Text = current;
            current = br.ReadString();
            tb_1_5.Text = current;

            current = br.ReadString();
            tb_2_1.Value = current;
            tb_2_1.Disabled = current != "";
            current = br.ReadString();
            tb_2_2.Value = current;
            tb_2_2.Disabled = current != "";
            current = br.ReadString();
            tb_2_3.Value = current;
            tb_2_3.Disabled = current != "";
            current = br.ReadString();
            tb_2_4.Value = current;
            tb_2_4.Disabled = current != "";
            current = br.ReadString();
            tb_2_5.Value = current;
            tb_2_5.Disabled = current != "";

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

            current = br.ReadString();
            tb_manager_1.Text = current;
            tb_manager_1.Enabled = current == "";
            current = br.ReadString();
            tb_manager_2.Text = current;
            tb_manager_2.Enabled = current == "";
            current = br.ReadString();
            tb_manager_3.Text = current;
            tb_manager_3.Enabled = current == "";
            current = br.ReadString();
            tb_manager_4.Text = current;
            tb_manager_4.Enabled = current == "";
            current = br.ReadString();
            tb_manager_5.Text = current;
            tb_manager_5.Enabled = current == "";

            br.Close();
            fs.Close();
        }
    }

    protected void bt_save_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/data/netunim.txt");
        if (!Directory.Exists(Path.GetDirectoryName(path)))
            Directory.CreateDirectory(Path.GetDirectoryName(path));

        FileStream fs = File.OpenWrite(path);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(tb_1_1.Text);
        bw.Write(tb_1_2.Text);
        bw.Write(tb_1_3.Text);
        bw.Write(tb_1_4.Text);
        bw.Write(tb_1_5.Text);

        bw.Write(tb_2_1.Value);
        bw.Write(tb_2_2.Value);
        bw.Write(tb_2_3.Value);
        bw.Write(tb_2_4.Value);
        bw.Write(tb_2_5.Value);

        bw.Write(tb_3_1.Text);
        bw.Write(tb_3_2.Text);
        bw.Write(tb_3_3.Text);
        bw.Write(tb_3_4.Text);
        bw.Write(tb_3_5.Text);

        bw.Write(tb_manager_1.Text);
        bw.Write(tb_manager_2.Text);
        bw.Write(tb_manager_3.Text);
        bw.Write(tb_manager_4.Text);
        bw.Write(tb_manager_5.Text);

        bw.Close();
        fs.Close();

        LoadFile();
    }

    protected void bt_clear_Click(object sender, EventArgs e)
    {
        File.Delete(Server.MapPath("~/data/netunim.txt"));
        Response.Redirect("Netunim.aspx");
    }

    private void setVisibility()
    {
        if (!Directory.Exists(Server.MapPath("~/files/netunim/")))
            Directory.CreateDirectory(Server.MapPath("~/files/netunim/"));
        if (!Directory.Exists(Server.MapPath("~/files/hozeA/")))
            Directory.CreateDirectory(Server.MapPath("~/files/hozeA/"));
        if (!Directory.Exists(Server.MapPath("~/files/hozeB/")))
            Directory.CreateDirectory(Server.MapPath("~/files/hozeB/"));

        bt_4_1_upload.Visible = !(bt_4_1_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "menashe.*").Length > 0));
        bt_4_2_upload.Visible = !(bt_4_2_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "efraim.*").Length > 0));
        bt_4_3_upload.Visible = !(bt_4_3_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "binyamin.*").Length > 0));
        bt_4_4_upload.Visible = !(bt_4_4_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "jerusalem.*").Length > 0));
        bt_4_5_upload.Visible = !(bt_4_5_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "yehuda.*").Length > 0));

        bt_kesher_menashe_upload.Visible = !(bt_kesher_menashe_watch.Visible =
            (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "kesher_menashe.*").Length > 0));
        bt_kesher_efraim_upload.Visible = !(bt_kesher_efraim_watch.Visible =
            (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "kesher_efraim.*").Length > 0));
        bt_kesher_binyamin_upload.Visible = !(bt_kesher_binyamin_watch.Visible =
            (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "kesher_binyamin.*").Length > 0));
        bt_kesher_jerusalem_upload.Visible = !(bt_kesher_jerusalem_watch.Visible =
            (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "kesher_jerusalem.*").Length > 0));
        bt_kesher_yehuda_upload.Visible = !(bt_kesher_yehuda_watch.Visible =
            (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "kesher_yehuda.*").Length > 0));
        bt_kesher_all_upload.Visible = !(bt_kesher_all_watch.Visible =
            (Directory.GetFiles(Server.MapPath("~/files/netunim/"), "kesher_all.*").Length > 0));

        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";

        #region buttons of hoze

        bt_A_Ahzaka_1_upload.Visible = !(bt_A_Ahzaka_1_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "menashe_hoze.*").Length > 0));
        bt_A_Kamut_1_upload.Visible = !(bt_A_Kamut_1_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "menashe_kamuyot.pdf").Length > 0));
        bt_A_Ahzaka_2_upload.Visible = !(bt_A_Ahzaka_2_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "efraim_hoze.pdf").Length > 0));
        bt_A_Kamut_2_upload.Visible = !(bt_A_Kamut_2_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "efraim_kamuyot.pdf").Length > 0));
        bt_A_Ahzaka_3_upload.Visible = !(bt_A_Ahzaka_3_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "binyamin_hoze.*").Length > 0));
        bt_A_Kamut_3_upload.Visible = !(bt_A_Kamut_3_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "binyamin_kamuyot.*").Length > 0));
        bt_A_Ahzaka_4_upload.Visible = !(bt_A_Ahzaka_4_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "jerusalem_hoze.*").Length > 0));
        bt_A_Kamut_4_upload.Visible = !(bt_A_Kamut_4_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "jerusalem_kamuyot.*").Length > 0));
        bt_A_Ahzaka_5_upload.Visible = !(bt_A_Ahzaka_5_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "yehuda_hoze.*").Length > 0));
        bt_A_Kamut_5_upload.Visible = !(bt_A_Kamut_5_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeA/"), "yehuda_kamuyot.*").Length > 0));

        bt_B_Ahzaka_1_upload.Visible = !(bt_B_Ahzaka_1_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "menashe_hoze.*").Length > 0));
        bt_B_Kamut_1_upload.Visible = !(bt_B_Kamut_1_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "menashe_kamuyot.pdf").Length > 0));
        bt_B_Ahzaka_2_upload.Visible = !(bt_B_Ahzaka_2_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "efraim_hoze.pdf").Length > 0));
        bt_B_Kamut_2_upload.Visible = !(bt_B_Kamut_2_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "efraim_kamuyot.pdf").Length > 0));
        bt_B_Ahzaka_3_upload.Visible = !(bt_B_Ahzaka_3_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "binyamin_hoze.*").Length > 0));
        bt_B_Kamut_3_upload.Visible = !(bt_B_Kamut_3_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "binyamin_kamuyot.*").Length > 0));
        bt_B_Ahzaka_4_upload.Visible = !(bt_B_Ahzaka_4_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "jerusalem_hoze.*").Length > 0));
        bt_B_Kamut_4_upload.Visible = !(bt_B_Kamut_4_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "jerusalem_kamuyot.*").Length > 0));
        bt_B_Ahzaka_5_upload.Visible = !(bt_B_Ahzaka_5_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "yehuda_hoze.*").Length > 0));
        bt_B_Kamut_5_upload.Visible = !(bt_B_Kamut_5_watch.Visible = (Directory.GetFiles(Server.MapPath("~/files/hozeB/"), "yehuda_kamuyot.*").Length > 0));

        #endregion buttons of hoze
    }

    protected void bt_hoze_upload_Click(object sender, EventArgs e)
    {
        string id = ((Button)sender).ID;

        string hoze = id.Split('_')[1];
        string typeOfFile = "";
        string gizra = "";

        switch (id.Split('_')[2])
        {
            case "Kamut":
                typeOfFile = "kamuyot";
                break;

            case "Ahzaka":
                typeOfFile = "hoze";
                break;
        }
        switch (id.Split('_')[3])
        {
            case "1": gizra = "menashe"; break;
            case "2": gizra = "efraim"; break;
            case "3": gizra = "binyamin"; break;
            case "4": gizra = "jerusalem"; break;
            case "5": gizra = "yehuda"; break;
        }

        Session["upload_file_name"] = "hoze" + hoze + "/" + gizra + "_" + typeOfFile;
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
    }

    protected void bt_hoze_watch_Click(object sender, EventArgs e)
    {
        string id = ((Button)sender).ID;

        string hoze = id.Split('_')[1];
        string typeOfFile = "";
        string gizra = "";

        switch (id.Split('_')[2])
        {
            case "Kamut":
                typeOfFile = "kamuyot";
                break;

            case "Ahzaka":
                typeOfFile = "hoze";
                break;
        }
        switch (id.Split('_')[3])
        {
            case "1": gizra = "menashe"; break;
            case "2": gizra = "efraim"; break;
            case "3": gizra = "binyamin"; break;
            case "4": gizra = "jerusalem"; break;
            case "5": gizra = "yehuda"; break;
        }

        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hoze" + hoze + "/"), gizra + "_" + typeOfFile + ".*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
        }
    }

    #region bt hoze events

    #region hoze A - Ahzaka

    protected void bt_A_Ahzaka_1_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "menashe_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Ahzaka_1_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "menashe_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_A_Ahzaka_2_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "efraim_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Ahzaka_2_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "efraim_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Ahzaka_3_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "binyamin_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Ahzaka_3_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "binyamin_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_A_Ahzaka_4_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "jerusalem_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Ahzaka_4_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "jerusalem_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_A_Ahzaka_5_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "yehuda_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Ahzaka_5_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "yehuda_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    #endregion hoze A - Ahzaka

    #region hoze A - Kamuyot

    protected void bt_A_Kamut_1_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "menashe_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Kamut_1_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "menashe_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_A_Kamut_2_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "efraim_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Kamut_2_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "efraim_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_A_Kamut_3_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "binyamin_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Kamut_3_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "binyamin_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_A_Kamut_4_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "jerusalem_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Kamut_4_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "jerusalem_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_A_Kamut_5_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeA/" + date + "yehuda_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_A_Kamut_5_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeA/"), date + "yehuda_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    #endregion hoze A - Kamuyot

    #region hoze B - Ahzaka

    protected void bt_B_Ahzaka_1_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "menashe_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Ahzaka_1_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "menashe_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Ahzaka_2_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "efraim_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Ahzaka_2_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "efraim_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Ahzaka_3_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "binyamin_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Ahzaka_3_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "binyamin_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Ahzaka_4_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "jerusalem_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Ahzaka_4_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "jerusalem_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Ahzaka_5_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "yehuda_hoze";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Ahzaka_5_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "yehuda_hoze.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    #endregion hoze B - Ahzaka

    #region hoze B - Kamuyot

    protected void bt_B_Kamut_1_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "menashe_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Kamut_1_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "menashe_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Kamut_2_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "efraim_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Kamut_2_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "efraim_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Kamut_3_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "binyamin_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Kamut_3_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "binyamin_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Kamut_4_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "jerusalem_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Kamut_4_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "jerusalem_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    protected void bt_B_Kamut_5_upload_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        Session["upload_file_name"] = "hozeB/" + date + "yehuda_kamuyot";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('Upload.aspx', 'mywindow', 'width=300,height=400,resizable=no')", true);
        setVisibility();
    }

    protected void bt_B_Kamut_5_watch_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.Year + "_" + DateTime.Now.Month + "_";
        foreach (string s in Directory.GetFiles(Server.MapPath("~/files/hozeB/"), date + "yehuda_kamuyot.*"))
        {
            Session["view_path"] = s;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.open('FileViewer.aspx', 'mywindow', 'width=400,height=200,resizable=no')", true);
            setVisibility();
        }
        setVisibility();
    }

    #endregion hoze B - Kamuyot

    #endregion bt hoze events
}