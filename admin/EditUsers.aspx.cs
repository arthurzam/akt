using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

public partial class admin_EditUsers : System.Web.UI.Page
{
    private string file;

    protected void Page_Load(object sender, EventArgs e)
    {
        bool isLogged = Session["Login"] != null;
        isLogged = isLogged && (((string)Session["Login"]).Split('$')[1] == Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]));
        isLogged = isLogged && (Hash.CalculateSHA1(((string)Session["Login"]).Split('$')[0]) == Hash.adminHash);
        if (isLogged)
        {
            file = Server.MapPath("~/admin/users.dat");
            //Hash.DecryptFile(file);
            SetPanel();
            //Hash.EcryptFile(file);
        }
        else
            Response.Redirect("../default.aspx", true);
    }

    private void SetPanel()
    {
        table.Rows.Clear();
        string[] lines = File.ReadAllLines(file, System.Text.Encoding.ASCII);
        for (int count = 0; count < lines.Length; count++)
        {
            string line = lines[count];

            TableRow tr = new TableRow();

            {
                TableCell td = new TableCell();
                td.Controls.Add(GetCheckBox("cb_" + count));
                tr.Cells.Add(td);
            }

            {
                TableCell td = new TableCell();
                td.Controls.Add(GetTextBox("tb_username_" + count, line.Split('$')[0]));
                tr.Cells.Add(td);
            }

            {
                TableCell td = new TableCell();
                td.Controls.Add(GetTextBox("tb_password_" + count, line.Split('$')[1]));
                tr.Cells.Add(td);
            }

            {
                TableCell td = new TableCell();
                WebControl[] list = GetPermissionCell("cb_" + count, line.Split('$')[2]);
                foreach (WebControl c in list)
                    td.Controls.Add(c);
                tr.Cells.Add(td);
            }

            table.Rows.Add(tr);
        }
        AddToTable();
    }

    private CheckBox GetCheckBox(string id, bool isChecked = false, string text=null)
    {
        CheckBox cb = new CheckBox();
        cb.ID = id;
        cb.Checked = isChecked;
        if (text != null)
            cb.Text = text;
        return cb;
    }

    private TextBox GetTextBox(string id, string defaultText = "")
    {
        TextBox tb = new TextBox();
        tb.ID = id;
        tb.Text = defaultText;
        return tb;
    }

    private Label GetLabel(string text)
    {
        Label lb = new Label();
        lb.Text = text;
        return lb;
    }

    private WebControl[] GetPermissionCell(string id, string permission = "00000000")
    {
        Permissions permisions = new Permissions(permission);
        WebControl[] list = {GetCheckBox(id + "_menashe",permisions.canEditMenashe, "מנשה"),
                             GetCheckBox(id + "_efraim",permisions.canEditEfraim,"אפרים"),
                             GetCheckBox(id + "_binyamin",permisions.canEditBinyamin,"בנימין"),
                             GetCheckBox(id + "_jerusalem",permisions.canEditJerusalem,"עוטף ירושלים"),
                             GetCheckBox(id + "_yehuda",permisions.canEditYehuda,"עציון ויהודה")};
        return list;
    }

    private void AddToTable()
    {
        TableRow tr = new TableRow();
        {
            TableCell td = new TableCell();
            Button bt = new Button();
            bt.Click += bt_add_Click;
            bt.ID = "bt_add_" + table.Rows.Count;
            bt.Text = "הוסף";
            td.Controls.Add(bt);
            tr.Cells.Add(td);
        }
        {
            TableCell td = new TableCell();
            td.Controls.Add(GetTextBox("tb_add_username"));
            tr.Cells.Add(td);
        }
        {
            TableCell td = new TableCell();
            td.Controls.Add(GetTextBox("tb_add_password"));
            tr.Cells.Add(td);
        }
        {
            TableCell td = new TableCell();
            WebControl[] list = GetPermissionCell("cb_add");
            foreach (WebControl c in list)
                td.Controls.Add(c);
            tr.Cells.Add(td);
        }
        table.Rows.Add(tr);
    }

    protected void bt_delete_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < table.Rows.Count - 1; i++)
        {
            if (!((CheckBox)table.Rows[i].Cells[0].Controls[0]).Checked)
            {
                User user = new User();
                user.username = ((TextBox)table.Rows[i].Cells[1].Controls[0]).Text;
                user.password = ((TextBox)table.Rows[i].Cells[2].Controls[0]).Text;
                {
                    bool[] abilities = {((CheckBox)table.Rows[i].Cells[3].Controls[0]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[1]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[2]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[3]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[4]).Checked};
                    user.abilities = new Permissions(abilities);
                }
                
                list.Add(user.ToString());
            }
        }
        File.Delete(file);
        File.WriteAllLines(file, list.ToArray());
        list = null;
        SetPanel();
        //Hash.EcryptFile(file);
    }

    protected void bt_add_Click(object sender, EventArgs e)
    {
        int row = int.Parse(((Button)sender).ID.Split('_')[2]);
        string newUsername = ((TextBox)table.Rows[row].Cells[1].Controls[0]).Text,
               newPassword = ((TextBox)table.Rows[row].Cells[2].Controls[0]).Text;
        if (newPassword == "" || newPassword == "")
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert(\"אנה מלא את כל השדות\")", true);
            return;
        }
        List<string> list = new List<string>();
        {
            User user = new User();
            user.username = newUsername;
            user.password = newPassword;

            {
                bool[] abilities = {((CheckBox)table.Rows[row].Cells[3].Controls[0]).Checked,
                                        ((CheckBox)table.Rows[row].Cells[3].Controls[1]).Checked,
                                        ((CheckBox)table.Rows[row].Cells[3].Controls[2]).Checked,
                                        ((CheckBox)table.Rows[row].Cells[3].Controls[3]).Checked,
                                        ((CheckBox)table.Rows[row].Cells[3].Controls[4]).Checked};
                user.abilities = new Permissions(abilities);
            }
            list.Add(user.ToString());
        }
        for (int i = 0; i < table.Rows.Count - 1; i++)
        {
            User user = new User();
            user.username = ((TextBox)table.Rows[i].Cells[1].Controls[0]).Text;
            user.password = ((TextBox)table.Rows[i].Cells[2].Controls[0]).Text;

            {
                bool[] abilities = {((CheckBox)table.Rows[i].Cells[3].Controls[0]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[1]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[2]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[3]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[4]).Checked};
                user.abilities = new Permissions(abilities);
            }
            list.Add(user.ToString());
        }

        File.Delete(file);
        File.WriteAllLines(file, list.ToArray());
        list = null;
        SetPanel();
        //Hash.EcryptFile(file);
    }

    protected void bt_save_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < table.Rows.Count - 1; i++)
        {
            User user = new User();
            user.username = ((TextBox)table.Rows[i].Cells[1].Controls[0]).Text;
            user.password = ((TextBox)table.Rows[i].Cells[2].Controls[0]).Text;

            {
                bool[] abilities = {((CheckBox)table.Rows[i].Cells[3].Controls[0]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[1]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[2]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[3]).Checked,
                                        ((CheckBox)table.Rows[i].Cells[3].Controls[4]).Checked};
                user.abilities = new Permissions(abilities);
            }
            list.Add(user.ToString());
        }

        File.Delete(file);
        File.WriteAllLines(file, list.ToArray());
        list = null;
        SetPanel();
        //Hash.EcryptFile(file);
    }

    private new struct User
    {
        public string username, password;
        public Permissions abilities;

        public User(Permissions abilities)
        {
            this.abilities = abilities;
            username = password = "";
        }

        /// <summary>
        /// format: [username]$[password]$[Permissions]
        /// </summary>
        public override string ToString()
        {
            return username + '$' + password + '$' + (abilities == null ? "0" : abilities.ToString());
        }
    }
    
}