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

    protected void Button1_Click(object sender, EventArgs e) {
    }

    // The below code loads the results from a query to the dropdown list. 
    private void LoadSubjects()
    {

        DataTable subjects = new DataTable();

        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tsets\source\repos\HRSC Web\HRSC Web\App_Data\hrscdata.mdf;Integrated Security=True"))
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



    // The Infromation Class selects the value from the dropdown list and generates a query which takes information from the database and populates a table on the website.
    protected void Information()
    {
        try
        {
            DataTable results = new DataTable();
            string selection = ddlSubject.SelectedValue;
            con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT sr.Name AS 'Sales Rep Name', p.Description AS 'Product Description', s.Name AS 'Supplier Name', d.Location AS 'Depot Location' FROM Salesrep sr, Product p, Supplier s, Depot d WHERE sr.Name = '" + ddlSubject.SelectedItem.Value + "' AND sr.Rep_No = p.Marketing_Rep_No AND p.Supplier_No = s.Supplier_No AND p.Supply_Depot_No = d.Depot_No ORDER BY p.Description, s.Name", con);
                cmd.Fill(results);
                if (results.Rows.Count > 0)
                {
                    GridView1.DataSource = results;
                    GridView1.DataBind();
                }
                else
                {
                }

            
        }
        finally
        {
            con.Close();
        }

    }




    // The below class acts the same way as information but its executed everytime a change is made in the dropdown list.
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable results = new DataTable();
            string selection = ddlSubject.SelectedValue;
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT sr.Name AS 'Sales Rep Name', p.Description AS 'Product Description', s.Name AS 'Supplier Name', d.Location AS 'Depot Location' FROM Salesrep sr, Product p, Supplier s, Depot d WHERE sr.Name = '" + ddlSubject.SelectedItem.Value + "' AND sr.Rep_No = p.Marketing_Rep_No AND p.Supplier_No = s.Supplier_No AND p.Supply_Depot_No = d.Depot_No ORDER BY p.Description, s.Name", con);
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