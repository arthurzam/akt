using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <remarks>
/// uses Sesion:
///     image_upload_gizra - the gizra
/// </remarks>
/// <version>17.12.2012</version>
public partial class TmunaUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lb_number.Text = GetImageNumber();
        switch (((string)Session["image_upload_gizra"]))
        {
            case "menashe": lb_gizra.Text = "מנשה"; break;
            case "efraim": lb_gizra.Text = "אפרים"; break;
            case "binyamin": lb_gizra.Text = "בנימין"; break;
            case "jerusalem": lb_gizra.Text = "עוטף ירושלים"; break;
            case "yehuda": lb_gizra.Text = "עציון ויהודה"; break;
            default: lb_gizra.Text = "~"; break;
        }
    }

    protected void bt_ok_Click(object sender, EventArgs e)
    {
        if (val_FileUpload_picture.IsValid && val_tb_title.IsValid && FileUpload_picture.HasFile)
        {
            string folder = Server.MapPath("~/files/pictures/" + ddp_type.SelectedValue + "/" + (string)Session["image_upload_gizra"] + "/");
            string file_name = DateTime.Today.Year + "_" + DateTime.Today.Month + "_" + DateTime.Today.Day + "_" +
                lb_number.Text + "_" + tb_title.Value + Path.GetExtension(FileUpload_picture.FileName);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            FileUpload_picture.SaveAs(folder + file_name);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
    }

    private string GetImageNumber()
    {
        if (!Directory.Exists(Server.MapPath("~/files/pictures/" + ddp_type.SelectedValue + "/" + (string)Session["image_upload_gizra"] + "/")))
            return "0";
        int number = Directory.GetFiles(Server.MapPath("~/files/pictures/" + ddp_type.SelectedValue + "/" + (string)Session["image_upload_gizra"] + "/")).Length;
        return number + "";
    }
}