using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
            Response.Redirect("Login.aspx");
        
        lblUserDetails.Text = "Welcome " + GetEmployeeame(); 
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text != Session["username"].ToString())
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please enter a valid user name";
            txtUserName.Text = "";
            return;
        }
        
        using (SqlConnection sqlConn = new SqlConnection(@"Data Source=D-784TVR1\SQLEXPRESS;Initial Catalog=Kudos;Integrated Security=True;"))
        {
            SqlCommand sqlCmd = new SqlCommand("spResetPassword", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            
            SqlParameter paramUserName = new SqlParameter("@UserName", Session["username"]);
            sqlCmd.Parameters.Add(paramUserName);

            sqlConn.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToBoolean(reader["ReturnCode"]))
                {
                    SendPasswordResetEmail(reader["Email"].ToString(), Session["username"].ToString(), reader["UniqueId"].ToString());
                    lblMsg.ForeColor = System.Drawing.Color.Blue;
                    lblMsg.Text = "An email with instructions to reset your password is sent to your registered email";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "UserName not found or !"; 
                }
            }
        }
    }

    private string GetEmployeeame()
    {
        string empName="";
        using (SqlConnection sqlConn = new SqlConnection(@"Data Source=D-784TVR1\SQLEXPRESS;Initial Catalog=Kudos;Integrated Security=True;"))
        {
            sqlConn.Open();
            string query = "Select EMPNAME from TBLEMPLOYEE E inner join tblUsers U on E.ID = u.empid where u.username=@username";
            SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
            sqlCmd.Parameters.AddWithValue("@username", Session["username"]);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if(reader.Read())
            {
                empName = reader["EMPNAME"].ToString();
            }              
        }
        return empName;
    }
    private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
    {
        // MailMessage class is present is System.Net.Mail namespace
        MailMessage mailMessage = new MailMessage("meatlaunchcode@gmail.com", ToEmail);


        // StringBuilder class is present in System.Text namespace
        StringBuilder sbEmailBody = new StringBuilder();
        sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
        sbEmailBody.Append("Please click on the following link to reset your password");
        sbEmailBody.Append("<br/>"); sbEmailBody.Append("https://localhost/WebApplication1/Registration/ChangePassword.aspx?uid=" + UniqueId);
        sbEmailBody.Append("<br/><br/>");
        sbEmailBody.Append("<b>Dhara@LaunchCode</b>");

        mailMessage.IsBodyHtml = true;

        mailMessage.Body = sbEmailBody.ToString();
        mailMessage.Subject = "Reset Your Password";
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        smtpClient.Credentials = new System.Net.NetworkCredential()
        {
            UserName = "meatlaunchcode@gmail.com",
            Password = "strong%@10pass"
        };

        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}