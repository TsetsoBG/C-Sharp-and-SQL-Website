using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function2 : System.Web.UI.Page
{

    // Page load function redirects the used to the login page if they are not logged in. Also if the logged in user doesnt have Manager or Administrator previlegies they are redirected to login again.
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["username"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else if ((string)Session["member"] == "Manager" || (string)Session["member"] == "Administrator")
        {
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    // The below declared variables are used to connect to the local database with name: hrsdata.mdf.
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\hrscdata.mdf;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader dr;


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    // Button executes Information Class.
    protected void Button1_Click(object sender, EventArgs e) {
        Information();
    }

    // Information class uses if statements to validate if any information was entered and executes a query with the entered information. If there are results they are shown in the table if not an error is returned.
    protected void Information()
    {
        try
        {
            if (TextBox1.Text == "")
            {
                Label1.Text = "Enter Information";
            }
            else
            {
                DataTable results = new DataTable();
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT cu.Custno, cu.Name,cu.Address, p.Product_No, p.Description, o.Corder_No, CONVERT(varchar, c.Date_Placed, 103) AS'Date Placed 'FROM Product p, Oline o, Corder c, Customer cu WHERE c.Date_Placed > DATEADD(DAY, -30, GETDATE()) AND p.Product_No = o.Product_No AND o.Corder_No = c.Corder_NO AND c.Customer_No = cu.Custno AND p.Description = '" + TextBox1.Text +"'", con);
                cmd.Fill(results);
                if (results.Rows.Count > 0)
                    {
                        GridView1.DataSource = results;
                        GridView1.DataBind();
                    }
                else
                    {
                        Label1.Text = "There are no records based on that search. Enter Different Data";
                    }
                
            }
        }
        finally
        {
            con.Close();
        }

    }




}