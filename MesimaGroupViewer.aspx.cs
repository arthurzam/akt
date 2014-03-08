using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <remarks>
/// needs some sessions:
///     Mesima_search - the serach format of the mesima [- string in engish]
///     Mesima_folder - the folder format of the mesima [- string in engish]
/// </remarks>
/// <version>16.12.2012</version>
public partial class MesimaGroupViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setAll();
    }

    private void setAll()
    {
        string folder = Server.MapPath("~/data/" + (string)Session["Mesima_folder"] + "/");
        string[] files = Directory.GetFiles(folder, "*_" + (string)Session["Mesima_search"] + "_*");
        for (int i = 0; i < files.Length; i++)
        {
            TableRow tr = new TableRow();
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.Text = Path.GetFileName(files[i]).Split('_')[0];
                lb.CssClass = "control";
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Button bt = new Button();
                bt.Text = Path.GetFileNameWithoutExtension(files[i]).Split('_')[5];
                bt.CssClass = "control";
                bt.Click += this.bt_mesima_Click;
                bt.ID = Path.GetFileName(files[i]);
                td.Controls.Add(bt);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.CssClass = "control";
                lb.Text = Path.GetFileName(files[i]).Split('_')[4] + "/" + Path.GetFileName(files[i]).Split('_')[3] + "/" + Path.GetFileName(files[i]).Split('_')[2];
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            {
                TableCell td = new TableCell();
                Label lb = new Label();
                lb.CssClass = "control";
                lb.Text = (Path.GetFileName(files[i]).Split('_')[1] == "1" ? "טופל" : "לא טופל");
                td.Controls.Add(lb);
                tr.Cells.Add(td);
            }
            Table_main.Rows.Add(tr);
        }
    }


    protected void bt_mesima_Click(object sender, EventArgs e)
    {
        string id = ((Button)sender).ID;
        //string folder = Server.MapPath("~/data/" + (string)Session["Mesima_folder"] + "/");

        Session["view_open_mesima"] = (string)Session["Mesima_folder"] + "/" + id;
        
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "popupwindow('MesimaCreator.aspx', 'mywindow', 480, 600)", true);
        Response.Redirect("MesimaCreator.aspx", false);
    }
}