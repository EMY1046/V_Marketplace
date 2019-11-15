using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Web_Vindeed
{
    public partial class About : Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand sqlCmd;
        SqlDataAdapter sqlAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPasswordConfirm.Text = "";
            txtUserName.Text = "";
            ddlRole.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //*******************************************************

            /*string to = txtUserName.Text; //To address    
            string from = "noreplyschoolprojecttes@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("noreplyschoolprojecttest@gmail.com", "Don'treply");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            */
            /*

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("noreplyschoolprojecttest@gmail.com");
            mm.To.Add(txtUserName.Text);
            mm.Subject = "Activation code";
            mm.Body = "here be go";
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
            */
            //**********************************************************************

            if (EmailValidation.IsValidEmail(txtUserName.Text))
            {
                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    lblmessage.Text = "The password is not correctly confirm";
                    return;
                }
                else
                {
                    con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
                  

                    // check first if the user does not exist before adding
                    string QuantcommandString = "select * from login where User_Email = '" + txtUserName.Text + "'";
                    SqlCommand commandQuant = new SqlCommand(QuantcommandString, con);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = commandQuant.ExecuteReader();
                    if (rdr.Read())
                    {
                        lblmessage.Text = "User already exist, please go to login, reset password or use another email to continue";
                    }
                    else
                    {
                         //********************************************************************************************
                        SqlCommand cmd = new SqlCommand("insert into Login (User_Email,User_Password,User_Role) values (@User_Email,@User_Password,@User_Role)", con);
                        cmd.Parameters.AddWithValue("User_Email", txtUserName.Text);
                        cmd.Parameters.AddWithValue("User_Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("User_Role", ddlRole.SelectedItem.Value);
                        //con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i != 0)
                        {

                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("noreplyschoolprojecttest@gmail.com");
                            mail.To.Add(txtUserName.Text);
                            mail.Subject = "Activation Mail";
                            mail.Body = "Please use this xxxx to activate your Vindeed account";

                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("noreplyschoolprojecttest@gmail.com", "Don'treply");
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);

                            lblmessage.ForeColor = System.Drawing.Color.ForestGreen;
                            lblmessage.Text = "Please go to your email to access your activation code.";
                            lblmessage.ForeColor = System.Drawing.Color.ForestGreen;
                        }
                        lblmessage.Text = "Login incorrect or not yet registered";
                    }
                    rdr.Close();
                    con.Close();

                }
            }
            else
            {
                lblmessage.Text = "Please use a valid email address";
                return;

            }
        }
    }
}