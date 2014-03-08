using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <remarks>
/// file format:
///     title
///     text (replace '\n' into "<br />")
///     date
///     omdan
///     luz
///     Horaot file [location]
/// </remarks>
/// <version>16.12.2012</version>
public partial class MesimaCreator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            if (Hidden_first.Value == "1")
            {

                if ((string)Session["view_open_mesima"] != null && (string)Session["view_open_mesima"] != "")
                {
                    string file = Server.MapPath("~/data/") + (string)Session["view_open_mesima"];
                    StreamReader sr = File.OpenText(file);
                    tb_title.Text = sr.ReadLine();

                    lb_date.Text = sr.ReadLine();
                    tb_omdan.Value = sr.ReadLine();
                    tb_luz.Value = sr.ReadLine();

                    Hidden_horaotFile.Value = sr.ReadLine();
                    if (Hidden_horaotFile.Value == "-")
                        bt_horaot_watch.Visible = !(bt_horaot_upload.Visible = FileUpload_horaot.Visible = true);
                    else
                        bt_horaot_watch.Visible = !(bt_horaot_upload.Visible = FileUpload_horaot.Visible = false);
                    tb_text.Text = sr.ReadToEnd();
                    sr.Close();

                    cb_ready.Checked = (Path.GetFileName(file).Split('_')[1] == "1" ? true : false);
                    lb_number.Text = Path.GetFileName(file).Split('_')[0];

                    Hidden_first.Value = "open";
                    Hidden_pathToFile.Value = file;
                    Session.Remove("view_open_mesima");
                }
                else
                {
                    bt_horaot_watch.Visible = !(bt_horaot_upload.Visible = FileUpload_horaot.Visible = true);
                    lb_date.Text = DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
                    lb_number.Text = getNumberForNew() + "";
                    Hidden_first.Value = "new";
                }
            }
        }
        else
        {
            Response.Redirect("default.aspx", true);
        }
    }

    protected void bt_ok_Click(object sender, EventArgs e)
    {
        if (Hidden_first.Value == "new")
        {
            if (tb_title.Text.Length > 0 && tb_text.Text.Length > 0)
            {
                string folder = Server.MapPath("~/data/") + (string)Session["mesima_upload"] + "/";
                string file = lb_number.Text + "_" + (cb_ready.Checked ? "1" : "0") + "_" +
                    DateTime.Today.Year + "_" + DateTime.Today.Month + "_" + DateTime.Today.Day + "_" + tb_title.Text + ".txt";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                FileStream fs = File.Create(folder + file);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(tb_title.Text);
                sw.WriteLine(lb_date.Text);
                sw.WriteLine(tb_omdan.Value);
                sw.WriteLine(tb_luz.Value);
                sw.WriteLine((Hidden_horaotFile.Value == "-" ? "-" : Hidden_horaotFile.Value));
                sw.WriteLine(tb_text.Text); //.Replace("\n", "<br />")
                sw.Close();
                fs.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
            }
        }
        else if (Hidden_first.Value == "open")
        {
            if (tb_title.Text.Length > 0 && tb_text.Text.Length > 0)
            {
                string folder = Path.GetDirectoryName(Hidden_pathToFile.Value) + "/";
                string file = lb_number.Text + "_" + (cb_ready.Checked ? "1" : "0") + "_" +
                    lb_date.Text.Split('/')[2] + "_" + lb_date.Text.Split('/')[1] + "_" + lb_date.Text.Split('/')[0] + "_" + tb_title.Text + ".txt";
                FileStream fs = new FileStream(Hidden_pathToFile.Value, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(tb_title.Text);
                sw.WriteLine(lb_date.Text);
                sw.WriteLine(tb_omdan.Value);
                sw.WriteLine(tb_luz.Value);
                sw.WriteLine((Hidden_horaotFile.Value == "-" ? "-" : Hidden_horaotFile.Value));
                sw.WriteLine(tb_text.Text); //.Replace("\n", "<br />")
                sw.Close();
                fs.Close();
                if (Path.GetFileName(Hidden_pathToFile.Value) != file)
                    File.Move(Hidden_pathToFile.Value, folder + file);
                Response.Redirect("MesimaGroupViewer.aspx", true);
            }
        }
    }

    protected void bt_horaot_Click(object sender, EventArgs e)
    {
        if (((Button)sender).ID == "bt_horaot_upload") // to upload
        {
            if (FileUpload_horaot.HasFile)
            {
                string folder = Server.MapPath("~/files/") + (string)Session["mesima_upload"] + "/";
                string file = lb_number.Text + Path.GetExtension(FileUpload_horaot.FileName);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                FileUpload_horaot.SaveAs(folder + file);
                Hidden_horaotFile.Value = folder + file;
                bt_horaot_watch.Visible = !(bt_horaot_upload.Visible = FileUpload_horaot.Visible = false);
            }
        }
        else // watch
        {
            Session["view_path"] = Hidden_horaotFile.Value;
            ClientScript.RegisterClientScriptBlock(GetType(), "Open", "window.open('FileViewer.aspx','','location=0, width=480, height=600',false)", true);
        }
    }

    private int getNumberForNew()
    {
        int r = 0;
        string folder = Server.MapPath("~/data/") + (string)Session["mesima_upload"] + "/";
        r = Directory.GetFiles(folder).Length;
        return r;
    }
}