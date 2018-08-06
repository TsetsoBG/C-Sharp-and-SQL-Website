using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function3User : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\hrscdata.mdf;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader dr;

    // Page load function redirects the used to the login page if they are not logged in. Also if the logged in user have Manager previlegies they are redirected to Manager Side of this Page.
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((string)Session["username"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else if ((string)Session["member"] == "Manager")
        {
            Response.Redirect("Function3Manager.aspx");
        }
        else
        {
            con.Open();
            cmd = new SqlCommand("SELECT Password FROM[User] WHERE User_Name = '" + (string)Session["username"] + "';", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String returnedPass = dr[0].ToString();
            f3ULabel2.Text = returnedPass;
            con.Close();

        }

    }














    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    // Button executes Information Class.
    protected void Button1_Click(object sender, EventArgs e) {
        Information();
    }

    // The below class is used to allow the user to update their password. It takes the information that was entered and it uses a query to update it.
    protected void Information()
    {
        try
        {
            string Username = (string)Session["username"];
            con.Open();
            string querystr = "UPDATE [USER] SET PASSWORD = '" + TextBox1.Text + "' WHERE User_Name = '" + Username + "'; ";
            SqlCommand cmd = new SqlCommand(querystr, con);
            cmd.ExecuteNonQuery();
            Label2.Text = "Password Updated to : "  + TextBox1.Text;
            f3ULabel2.Text = TextBox1.Text;
            TextBox1.Text = "";

        }
        finally
        {
            con.Close();
        }

    }




}