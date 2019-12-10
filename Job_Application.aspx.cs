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
    public partial class Job_Application : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand sqlCmd;
        SqlDataAdapter sqlAdapter;
        Login logDetails = new Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {


            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(logDetails.User_Email.ToString());
            mm.To.Add(logDetails.User_Email.ToString());
            mm.Subject = "Job Application";
            mm.Body = txtWorkHistory.Text;
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
    }
}