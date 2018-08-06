using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function8 : System.Web.UI.Page
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
        Information();
    }
    // The below declared variables are used to connect to the local database with name: hrsdata.mdf.
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\hrscdata.mdf;Integrated Security=True");
    SqlCommand cmd;
    SqlDataReader dr;


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    // The code below uses a query to find product information and if there are any results they are shown in a table. If not an error is displayed. 
    protected void Information()
    {
        try
        {
                DataTable results = new DataTable();
                con.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT p.Product_No AS 'Product Number', p.Description AS 'Product Description', o.Corder_No AS 'Order Number', CONVERT(varchar, c.Date_Placed, 103) AS 'Date Placed' FROM Product p, Oline o, Corder c WHERE c.Date_Placed < DATEADD(DAY, -10, GETDATE())  AND p.Product_No = o.Product_No  AND o.Corder_No = c.Corder_NO AND c.Date_Delivered IS NULL ORDER BY c.Date_Placed ", con);
                    cmd.Fill(results);
                    if (results.Rows.Count > 0)
                    {
                        GridView1.DataSource = results;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "There are no records based on that search.";
                    }
         }
            
        
        finally
        {
            con.Close();
        }

    }




}