using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <remarks>
/// needs some sessions:
///     HozeTohen_gizra - the gizra [- string in engish]
///     HozeTohen_type - the type [- byte of the type]
///     HozeTohen_special - for example "hodesh_[month]_[year]" will show only for that month
/// folder: /files/hoze/[HozeTohen_type]/[HozeTohen_gizra]
/// file: [day]_[month]_[year]_[number].[extension]
/// </remarks>
/// <version>5.12.12</version>
public partial class HozeTohen : System.Web.UI.Page
{
    private string folder;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            folder = Server.MapPath("~/files/hoze/" + (int)Session["HozeTohen_type"] + "/" + (string)Session["HozeTohen_gizra"] + "/");
            string gizra = "";
            switch ((string)Session["HozeTohen_gizra"])
            {
                case "menashe": gizra = "מנשה"; break;
                case "efraim": gizra = "אפרים"; break;
                case "binyamin": gizra = "בנימין"; break;
                case "jerusalem": gizra = "עוטף ירושלים"; break;
                case "yehuda": gizra = "עציון ויהודה"; break;
            }
            string type = "";
            switch ((int)Session["HozeTohen_type"])
            {
                case 1: type = "תכנית עבודה שבועית"; break;
                case 2: type = "יומן עבודה"; break;
                case 3: type = "מכתבים"; break;
                case 4: type = "פרוטוקולים"; break;
            }
            Page.Title = gizra + " - " + type;

            GetAll();
        }
        else
        {
            Response.Redirect("default.aspx", true);
        }
    }

    protected void bt_upload_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Today;
        string today_str = today.Day + "_" + today.Month + "_" + today.Year;
        if (FileUploader.HasFile)
        {
            string filePath = Server.MapPath("~/files/hoze/" + (int)Session["HozeTohen_type"] + "/" 
                + (string)Session["HozeTohen_gizra"] + "/" + today_str + "_" + getNumber())
                + Path.GetExtension(FileUploader.FileName);
            FileUploader.SaveAs(filePath);
            TableRow tr = new TableRow();
            string file_name = Path.GetFileNameWithoutExtension(filePath);
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = file_name.Split('_')[3];
                lb.Width = Unit.Percentage(100);
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = file_name.Split('_')[0] + "/" + file_name.Split('_')[1] + "/" + file_name.Split('_')[2];
                lb.Width = Unit.Percentage(100);
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Button bt = new Button();
                bt.Text = "צפה";
                bt.Click += this.ReactOnopen_Click;
                bt.ID = Path.GetFileName(filePath);
                bt.ToolTip = Path.GetFileName(filePath);
                bt.Width = Unit.Percentage(100);
                td.Controls.Add(bt);
                tr.Cells.Add(td);
            }
            table.Rows.Add(tr);
        }
    }

    protected void ReactOnopen_Click(object sender, EventArgs e)
    {
        string file = folder + ((Button)sender).ID;
        Response.AddHeader("Content-Disposition", "inline;filename=" + Path.GetFileName(file));
        Response.ContentType = "application/" + Path.GetExtension(file);
        Response.WriteFile(file);
    }

    /// <summary>
    /// sets the table for all files
    /// </summary>
    private void GetAll()
    {
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
            return;
        }
        string[] files = Directory.GetFiles(folder, "*.*");
        if (Session["HozeTohen_special"] != null && ((string)Session["HozeTohen_special"]).Split('_')[0] == "hodesh")
            files = Directory.GetFiles(folder, "*_" + ((string)Session["HozeTohen_special"]).Split('_')[1]
                + "_" + ((string)Session["HozeTohen_special"]).Split('_')[2] + "_*.*");
        for (int i = 0; i < files.Length; i++)
        {
            string file_name = Path.GetFileNameWithoutExtension(files[i]);
            TableRow tr = new TableRow();
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = file_name.Split('_')[3];
                lb.Width = Unit.Percentage(100);
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = file_name.Split('_')[0] + "/" + file_name.Split('_')[1] + "/" + file_name.Split('_')[2];
                lb.Width = Unit.Percentage(100);
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Button bt = new Button();
                bt.Text = "צפה";
                bt.Click += this.ReactOnopen_Click;
                bt.ID = Path.GetFileName(files[i]);
                bt.ToolTip = Path.GetFileName(files[i]);
                bt.Width = Unit.Percentage(100);
                td.Controls.Add(bt);
                tr.Cells.Add(td);
            }
            table.Rows.Add(tr);
        }
    }

    private int getNumber()
    {
        return Directory.GetFiles(folder).Length;
    }
}