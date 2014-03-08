using System;
using System.IO;
using System.Web.UI;

public partial class Upload : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Login"] != null && ((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0])))
        {
            Session.Add("upload_path", null);
            Session.Timeout = 1;
        }
        else
        {
            Response.Redirect("default.aspx", true);
        }
    }

    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            Image_loading.Visible = true;
            string path = Server.MapPath("~/files/" + (string)Session["upload_file_name"] + Path.GetExtension(FileUpload1.FileName));
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            FileUpload1.SaveAs(path);
            if (Session["Upload_file_path"] == null) Session.Add("Upload_file_path", path);
            else Session["Upload_file_path"] = path;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
    }
}