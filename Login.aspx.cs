using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMsg.Visible = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlConn = new SqlConnection(@"Data Source=D-784TVR1\SQLEXPRESS;Initial Catalog=Kudos;Integrated Security=True;"))
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                sqlConn.Open();
                string query = "Select count(1) from tblUsers where username=@username and password_=@password";// parameterized query to avoid sql injection.
                SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
                sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());// Trim() to remove white spaces from the both ends of the string.
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count == 1)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Incorrect User Credentials";
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Please enter Username and Password both!";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        } 
    }

    protected void btnForgotPassword_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text != "")
        {
            Session["username"] = txtUserName.Text.Trim();
            Response.Redirect("ForgotPassword.aspx");
        }
        else
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = "Please enter Username!";
            lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }    
}