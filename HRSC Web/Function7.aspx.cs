using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function7 : System.Web.UI.Page
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

    // The Information class find information about suppliers, depots etc. If results are found they are shown in the table.
    protected void Information()
    {
        try
        {
                DataTable results = new DataTable();
                con.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT s.Name AS 'Supplier Name', d.Depot_No AS 'Depot Number', d.Location AS 'Depot Location',p.Product_No AS 'Product Number', p.Description AS 'Product Description', st.Quantity FROM Supplier s, Depot d, Product p, Stock st WHERE s.Supplier_No = p.Supplier_No AND p.Supply_Depot_No = d.Depot_No AND d.Depot_No = st.Depot_No AND p.Product_No = st.Product_No ORDER BY s.Name, d.Depot_No", con);
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