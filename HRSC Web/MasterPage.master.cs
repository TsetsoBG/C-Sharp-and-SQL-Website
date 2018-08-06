using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if ((string)Session["username"] == "")
        {
            logL.Text = "<a href=Login.aspx>Login</a>";
        }
        else
        {
            logL.Text = "Welcome " + (string)Session["member"] + " " + (string)Session["username"] + "    " + "  <a href=Login.aspx>LogOut</a>";
        }
    }
}