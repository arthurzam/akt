using System;
using System.IO;
using System.Web.UI;

public partial class admin_BrowseServer : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isLogged = Session["Login"] != null;
        isLogged = isLogged && (((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]));
        isLogged = isLogged && (Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]) == Hash.adminHash);
        if (isLogged)
        {
            //command_read_Click(tb_command, null);
            tb_command.Focus();
        }
        else
            Response.Redirect("../default.aspx", true);
    }

    private void SetAll()
    {
    }
    protected void command_read_Click(object sender, EventArgs e)
    {
        string temp = "";
        div_text.InnerHtml = "";
        switch (tb_command.Text.Split(' ')[0])
        {
            case "help":
                Help();
                break;
            case "cd":
                if (tb_command.Text.Split(' ').Length > 1)
                {
                    temp = tb_command.Text.Split(' ')[1].Replace("\"", "");
                    if (temp == "../")
                        hidden_location.Value = hidden_location.Value.Substring(0, hidden_location.Value.LastIndexOf('/'));
                    else if (temp == "\\")
                        hidden_location.Value = "";
                    else
                        hidden_location.Value += "/" + temp;
                }
                break;
            case "dir":
                temp = Server.MapPath("~" + hidden_location.Value) + "";
                if (Directory.Exists(temp))
                {
                    string[] files = Directory.GetFiles(temp);
                    div_text.InnerHtml = "<b>files:</b><br />";
                    foreach (string file in files)
                        div_text.InnerHtml += Path.GetFileName(file) + "<br />";
                    div_text.InnerHtml += "<b>directories:</b><br />";
                    files = Directory.GetDirectories(temp);
                    foreach (string file in files)
                        div_text.InnerHtml += Path.GetFileName(file) + "<br />";
                    
                }
                else
                    div_text.InnerHtml = "Directory not found";
                break;
            case "del":
                if (tb_command.Text.Split(' ').Length > 1)
                {
                    string folder = Server.MapPath("~" + hidden_location.Value) + "/";
                    temp = tb_command.Text.Split(' ')[1].Replace("\"", "");
                    if (File.Exists(folder + temp))
                        File.Delete(folder + temp);
                    else
                        div_text.InnerHtml = "File not found";
                }
                break;
            case "shdir":
                div_text.InnerHtml = hidden_location.Value + "/";
                break;
        }
    }

    private void Help()
    {
        div_text.InnerHtml = "Help" + "<br />";
        div_text.InnerHtml += "cd [dir] - move to the [dir] in the location" + "<br />";
        div_text.InnerHtml += "cd ../ - move one direcory before" + "<br />";
        div_text.InnerHtml += "cd \\ - return to root" + "<br />";
        div_text.InnerHtml += "dir - show all files & directories in the current folder" + "<br />";
        div_text.InnerHtml += "del [file] - delete file" + "<br />";
        div_text.InnerHtml += "shdir - show location" + "<br />";
    }
}