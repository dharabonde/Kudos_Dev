using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
            Response.Redirect("Login.aspx");

        form2.Visible = false;
        lblUserDetails.Text = "Welcome " + GetEmployeeame();
        if (!IsPostBack)
        {
            Populate_Dept();
        }
    }

    public void Populate_Dept()
    {
        DataTable dt = new DataTable();
        SqlConnection sqlConn = new SqlConnection(@"Data Source=D-784TVR1\SQLEXPRESS;Initial Catalog=Kudos;Integrated Security=True;");
        sqlConn.Open();

        string SQLstring = "Select  Id, DeptName from tblDepartment ";
        SqlCommand cmd = new SqlCommand(SQLstring, sqlConn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        drpDepartment.DataSource = dt;
        drpDepartment.DataTextField = "DeptName";
        drpDepartment.DataValueField = "Id";
        drpDepartment.DataBind();
        drpDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
        sqlConn.Close();
    }

    public void Populate_Emp()
    {
        DataTable dt = new DataTable();
        SqlConnection sqlConn = new SqlConnection(@"Data Source=D-784TVR1\SQLEXPRESS;Initial Catalog=Kudos;Integrated Security=True;");
        sqlConn.Open();
        int deptID=Convert.ToInt32(drpDepartment.SelectedValue);
        string SQLstring = "Select  * from tblEmployee where deptId="+ deptID;
        SqlCommand cmd = new SqlCommand(SQLstring, sqlConn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        drpEmployee.DataSource = dt;
        drpEmployee.DataTextField = "EmpName";
        drpEmployee.DataValueField = "Id";
        drpEmployee.DataBind();
        drpEmployee.Items.Insert(0, new ListItem("--Select--", "0"));
        sqlConn.Close();
    }

    private string GetEmployeeame()
    {
        string empName = "";
        using (SqlConnection sqlConn = new SqlConnection(@"Data Source=D-784TVR1\SQLEXPRESS;Initial Catalog=Kudos;Integrated Security=True;"))
        {
            sqlConn.Open();
            string query = "Select EMPNAME from TBLEMPLOYEE E inner join tblUsers U on E.ID = u.empid where u.username=@username";
            SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
            sqlCmd.Parameters.AddWithValue("@username", Session["username"]);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                empName = reader["EMPNAME"].ToString();
            }
        }
        return empName;
    }

    protected void btnLogout_Click1(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }

    protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate_Emp();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        form2.Visible = true;
    }
}