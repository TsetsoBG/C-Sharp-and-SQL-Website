using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function9 : System.Web.UI.Page
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

    //The button executes two classes. Delete1 and Delete2. Both of them delete information from a different table.
    protected void Button1_Click(object sender, EventArgs e)
    {
        Delete1();
        Delete2();
    }

    // The below classes delete the records of old orders from two different tables.
    protected void Delete1()
    {
        try
        {
            con.Open();
            string querystr = "DELETE FROM Oline WHERE Corder_No IN (SELECT o.Corder_No FROM Oline o, Corder c WHERE c.Date_Placed < DATEADD(DAY, -365, GETDATE()) AND o.Corder_No = c.Corder_NO AND c.Date_Delivered IS NULL)";
            SqlCommand cmd = new SqlCommand(querystr, con);
            cmd.ExecuteNonQuery();
        }
        finally
        {
            con.Close();
        }
    }
    protected void Delete2()
    {
        try
        {
            con.Open();
            string querystr= "DELETE FROM Corder WHERE Corder_No IN (SELECT Corder_No FROM Corder WHERE Date_Placed < DATEADD(DAY, -365, GETDATE()) AND Date_Delivered IS NULL )";
            SqlCommand cmd = new SqlCommand(querystr, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("Function9.aspx");
        }


        finally
        {
            con.Close();
        }
    }

    // Information class uses a query to find all old orders and their details and shows the results in a table.
    protected void Information()
    {
        try
        {
                DataTable results = new DataTable();
                con.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT p.Product_No AS 'Product Number', p.Description AS 'Product Description', o.Corder_No AS 'Order Number', CONVERT(varchar, c.Date_Placed, 103) AS 'Date Placed' FROM Product p, Oline o, Corder c WHERE c.Date_Placed < DATEADD(DAY, -365, GETDATE()) AND p.Product_No = o.Product_No AND o.Corder_No = c.Corder_NO AND c.Date_Delivered IS NULL ORDER BY c.Date_Placed ", con);
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