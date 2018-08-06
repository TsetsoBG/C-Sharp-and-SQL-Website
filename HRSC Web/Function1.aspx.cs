using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Function1 : System.Web.UI.Page
{
    // Page load function redirects the used to the login page if they are not logged in.
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["username"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {

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


    // Information class uses if statements to validate if any information was entered and take the selected value from the dropdown box. Based on the selection it executes the appropriate query and displays the data in a table.
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
                string selection = DropDownList1.SelectedValue;
                con.Open();
                if (selection == "cName")
                {
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT c.Custno AS 'Customer Number',c.Name, c.Address, c.Credit_Limit AS 'Credit Limit',c.Depot_No AS 'Depot Number', d.Location AS 'Depot Location', d.Address AS ' Depot Address' FROM Customer c , Depot d WHERE c.Name = '" + TextBox1.Text + "' AND c.Depot_No = d.Depot_No", con);
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
                else
                {
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT c.Custno AS 'Customer Number',c.Name, c.Address, c.Credit_Limit AS 'Credit Limit',c.Depot_No AS 'Depot Number', d.Location AS 'Depot Location', d.Address AS ' Depot Address' FROM Customer c , Depot d WHERE c.Custno = '" + TextBox1.Text + "' AND c.Depot_No = d.Depot_No", con);                  
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
        }
        finally
        {
            con.Close();
        }

    }




}