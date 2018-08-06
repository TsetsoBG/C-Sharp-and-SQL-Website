using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    // The code below sets the session variable to null if the user is already logged in. This way the page can be used as a log out page as well.
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((string)Session["username"] == "")
        {

        }
        else
        {
            Session["username"] = "";
            Session["member"] = "";
        }
    }
    // The below declared variables are used to connect to the local database with name: hrsdata.mdf.
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\hrscdata.mdf;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader dr;
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    // Simple login button. It takes the information from the fields and uses them to search for a username and password that are the same. If the login exists session variables are created and the user is logged in.
    // It also uses validation such as checking if any information is shown and returning error, as well as returning error if the entered information is wrong.
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            String Username = TextBox1.Text;
            String Password = TextBox2.Text;

            if (string.IsNullOrEmpty(Username))
            {
                Label4.Text = "Missing Information";
            }
            else if (string.IsNullOrEmpty(Password))
            {
                Label4.Text = "Missing Information";
            }

            else
            {
                cmd = new SqlCommand("SELECT Password FROM[User] WHERE User_Name = '" + Username + "';", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    String returnedPass = dr[0].ToString();
                    dr.Close();
                    if (Password == returnedPass)
                    {
                        membertype();
                        Session["username"] = Username;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Label4.Text = "Worng Password Or Username";
                    }
                }
                else
                {
                    Label4.Text = "Worng Password Or Username";
                }
            }



        }
        finally {
            con.Close();
        }

    }

    // The below class is executed in the Information class. It finds the user restriction level and adds it to a session varible.
    protected void membertype()
    {
        cmd = new SqlCommand("SELECT User_Type FROM[User] WHERE User_Name = '" + TextBox1.Text + "';", con);
        dr = cmd.ExecuteReader();
        dr.Read();
        String membertype = dr[0].ToString();
        Session["member"] = membertype;
        dr.Close();
    }
}