using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function3Manager : System.Web.UI.Page
{
    // The below declared variables are used to connect to the local database with name: hrsdata.mdf.
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\hrscdata.mdf;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader dr;

    // Page load function redirects the used to the login page if they are not logged in. Also if the logged in user doesnt have Manager  previlegies they are redirected to the User side of this page. This page changes depending on the previlegies of the user.
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["member"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else if ((string)Session["member"] == "Manager")
        {

        }
        else
        {
            Response.Redirect("Function3User.aspx");
        }

    }



}