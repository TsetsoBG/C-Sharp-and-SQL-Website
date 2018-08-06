using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function12 : System.Web.UI.Page
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

    //  The Information Class executes the query and populates the table in the website with its result. It will give an error message in no such data is found.
    protected void Information()
    {
        try
        {
                DataTable results = new DataTable();
                con.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT d.Location AS 'Depot', SUM(s.Quantity * p.Price) AS 'Total Value' FROM Depot d, Product p, Stock s WHERE d.Depot_No = s.Depot_No AND s.Product_No = p.Product_No GROUP BY d.Location", con);
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