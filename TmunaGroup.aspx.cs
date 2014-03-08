using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/// <remarks>
/// sessions:
///     tmuna_group_name
/// </remarks>
/// <version>18.12.2012</version>
public partial class TmunaGroup : System.Web.UI.Page
{
    private const int image_little_width = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        setTable();
    }

    private void setTable()
    {
        main_table.Rows.Clear();
        addHeaders();
        string folder = Server.MapPath("~/files/pictures/" + (string)Session["tmuna_group_name"] + "/");
        string[] all_images = Directory.GetFiles(folder);
        foreach(string file in all_images)
        {
            TableRow tr = new TableRow();
            string name = Path.GetFileNameWithoutExtension(file);
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = name.Split('_')[3];
                lb.CssClass = "control";
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = name.Split('_')[2] + "/" + name.Split('_')[1] + "/" + name.Split('_')[0];
                lb.CssClass = "control";
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = name.Split('_')[4];
                lb.CssClass = "control";
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                ImageButton img = new ImageButton();
                img.ImageUrl = "files/pictures/" + (string)Session["tmuna_group_name"] + "/" + Path.GetFileName(file);
                img.ToolTip = name.Split('_')[4];
                img.Width = image_little_width;
                img.Click += img_little_Click;
                td.Controls.Add(img);
                tr.Cells.Add(td);
            }
            main_table.Rows.Add(tr);
        }
    }

    private void addHeaders()
    {
        TableRow tr = new TableRow();
        string[] headers = { "מספר", "תאריך הוספה", "כותרת", "תמונה" };
        foreach (string header in headers)
        {
            TableHeaderCell th = new TableHeaderCell();
            Label lb = new Label();
            lb.Text = header;
            th.Controls.Add(lb);
            tr.Cells.Add(th);
        }
        main_table.Rows.Add(tr);
    }

    void img_little_Click(object sender, ImageClickEventArgs e)
    {
        panel_table.Visible = false;
        panel_image.Visible = true;
        ImageButton Sender = (ImageButton)sender;
        Image_big.ImageUrl = Sender.ImageUrl;
        Image_big.ToolTip = Sender.ToolTip;
    }
    protected void bt_back_Click(object sender, EventArgs e)
    {
        panel_table.Visible = true;
        panel_image.Visible = false;
        setTable();
    }
}