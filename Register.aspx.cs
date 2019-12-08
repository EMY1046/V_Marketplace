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
            lblActivation.Text = "The below part can be used only if you registered successfully and the activation code was provided to you.";
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
            

           
            
            //**********************************************************************

            if (EmailValidation.IsValidEmail(txtUserName.Text))
            {
                if ((txtPassword.Text != txtPasswordConfirm.Text) || (txtPassword.Text=="") || (txtPasswordConfirm.Text==""))
                {
                    lblmessage.Text = "The password is not confirm";
                    return;
                }
                else
                {
                    con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
                  

                    // check first if the user does not exist before adding
                    string QuantcommandString = "select * from VLogin where User_Email = '" + txtUserName.Text + "'";
                    SqlCommand commandQuant = new SqlCommand(QuantcommandString, con);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = commandQuant.ExecuteReader();
                    if (rdr.Read())
                    {
                        lblmessage.Text = "User already exist, please go either to login, reset password or use another email to continue";
                    }
                    else
                    {
                        //********************************************************************************************
                        // con.Close();
                        rdr.Close();

                        Random randm = new Random();
                        int rand_Numb = randm.Next(0, 10000000);
                        string activationCode = txtUserName.Text.Substring(0, 1);
                        activationCode = activationCode + rand_Numb;

                        SqlCommand cmd = new SqlCommand("insert into VLogin (User_Email,User_Password,User_Role,Activation_code) values (@User_Email,@User_Password,@User_Role,@Activation_code)", con);
                        cmd.Parameters.AddWithValue("User_Email", txtUserName.Text);
                        cmd.Parameters.AddWithValue("User_Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("User_Role", ddlRole.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("Activation_code", activationCode.ToString());
                        
                       // con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();

                        

                        //send a mail if successful registration is done
                        if (i != 0)
                        {

                            MailMessage mm = new MailMessage();
                            mm.From = new MailAddress("noreplyschoolprojecttest@gmail.com");
                            mm.To.Add(txtUserName.Text);
                            mm.Subject = "Activation code";
                            mm.Body = "here your activation code, take it back to the registration page to activate your account: "+ activationCode;
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

                            lblmessage.ForeColor = System.Drawing.Color.ForestGreen;
                            lblmessage.Text = "Please go to your email to access your activation code.";
                            lblmessage.ForeColor = System.Drawing.Color.ForestGreen;
                        }
                        
                        //lblmessage.Text = "The registration was successful";
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
       
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
            try
            {
                // 1. Create Command
                // Sql Update Statement
                string updateSql = "UPDATE VLogin " + "SET User_Activated = @User_Activated " + "WHERE User_Email = @User_Email and Activation_code=@Activation_code";

                //where country = '" + country + "' AND idcurrency = '" + idcurrency + "'";
                SqlCommand UpdateCmd = new SqlCommand(updateSql, con);
                con.Open();


                UpdateCmd.Parameters.AddWithValue("@User_Activated", '1');
                UpdateCmd.Parameters.AddWithValue("@User_Email", txtNameActivation.Text.ToString());
                UpdateCmd.Parameters.AddWithValue("@Activation_code", txtCode.Text.ToString());
                int rowsUpdated = UpdateCmd.ExecuteNonQuery();
                con.Close();
                if (rowsUpdated > 0)
                {
                    lblMessageAct.Text = "You have been activated, you can now use your login.";
                    lblmessage.Text = "";
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                
            }
        }
    }
}