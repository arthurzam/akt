using System;
using System.IO;
using System.Web.UI;

public partial class FileViewer : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]))
        {
            string path = (string)Session["view_path"];
            Response.Clear();
            Response.AddHeader("Content-Disposition", "inline;filename=" + Path.GetFileName(path));
            Response.ContentType = "application/" + Path.GetExtension(path);
            Response.WriteFile(path);
            Response.End();
        }
        else
        {
            Response.Redirect("default.aspx", true);
        }
    }
}