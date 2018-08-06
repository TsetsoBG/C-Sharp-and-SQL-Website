using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function10 : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                LoadSubjects();
            }
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


    // The below code loads the results from a query to the dropdown list. 
    private void LoadSubjects()
    {

        DataTable subjects = new DataTable();

        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\hrscdata.mdf;Integrated Security=True"))
        {

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Name AS 'Rep Name' FROM Salesrep", con);
                adapter.Fill(subjects);
                ddlSubject.DataSource = subjects;
                ddlSubject.DataTextField = "Rep Name";
                ddlSubject.DataBind();
            }
            catch (Exception ex)
            {
                // Handle the error
            }

        }


    }


    // The Information Class fills the table in the website based on the selected value of the dropbown box.
    protected void Information()
    {
        try
        {
            DataTable results = new DataTable();
            string selection = ddlSubject.SelectedValue;
            con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT p.Description, c.Name, CONVERT(varchar, co.Date_Placed, 103) AS 'Date Placed', (p.Price * o.Quantity) AS 'Value' FROM Salesrep sr, Product p, Customer c, Corder co, Oline o WHERE sr.Name = '" + ddlSubject.SelectedItem.Value +"' AND sr.Rep_No = p.Supply_Depot_No AND p.Product_No = o.Product_No AND o.Corder_No = co.Corder_No AND co.Customer_No = c.Custno AND co.Customer_No IN ( SELECT co.Customer_No FROM Corder co WHERE co.Date_Placed > DATEADD(DAY, -365, GETDATE())) ORDER BY p.Description", con);
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
        finally
        {
            con.Close();
        }

    }




    // The code below is the same as the Information class but its executed everytime a new dropdown value is selected.
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable results = new DataTable();
            string selection = ddlSubject.SelectedValue;
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT p.Description, c.Name, CONVERT(varchar, co.Date_Placed, 103) AS 'Date Placed', (p.Price * o.Quantity) AS 'Value' FROM Salesrep sr, Product p, Customer c, Corder co, Oline o WHERE sr.Name = '" + ddlSubject.SelectedItem.Value + "' AND sr.Rep_No = p.Supply_Depot_No AND p.Product_No = o.Product_No AND o.Corder_No = co.Corder_No AND co.Customer_No = c.Custno AND co.Customer_No IN ( SELECT co.Customer_No FROM Corder co WHERE co.Date_Placed > DATEADD(DAY, -365, GETDATE())) ORDER BY p.Description", con);
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
        finally
        {
            con.Close();
        }
    }
}