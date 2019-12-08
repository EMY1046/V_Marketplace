using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Web_Vindeed
{
    public partial class Job_Application_Form : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand sqlCmd;
        SqlDataAdapter sqlAdapter;
        Login logDetails = new Login();
        string OrganizationEmail = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
            string QuantcommandString = "select Posted_by from OrganizationJobPosted where Reference_Number = '" + logDetails.REference_Number.ToString() + "'";
            SqlCommand commandselect = new SqlCommand(QuantcommandString, con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader rdr = commandselect.ExecuteReader();
            if (rdr.Read())
            {
                OrganizationEmail = rdr["Posted_by"].ToString();
            }
           
            rdr.Close();
            con.Close();

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {


            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(logDetails.User_Email.ToString());
            mm.To.Add(OrganizationEmail.ToString());
            mm.Subject = "Job Application";
            mm.Body = txtFirstName.Text + "  "+ txtLastName.Text+"   "+txtPhone.Text+"   "+txtAddress.Text+  "   " + txtWorkHistory.Text;
            if (FileUploadCV.HasFile)
            {
                mm.Attachments.Add(new Attachment(FileUploadCV.PostedFile.InputStream, FileUploadCV.FileName));
            }
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "noreplyschoolprojecttest@gmail.com";
            NetworkCred.Password = "Don'treply";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            Response.Redirect("WebForm1.aspx");
            try
            {
                smtp.Send(mm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //lblmessage.ForeColor = System.Drawing.Color.ForestGreen;
            //           lblmessage.Text = "Please go to your email to access your activation code.";
            //           lblmessage.ForeColor = System.Drawing.Color.ForestGreen;


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}