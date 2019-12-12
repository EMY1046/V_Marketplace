using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Web_Vindeed
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;database=V_indeed;integrated security=SSPI");


       // SqlCommand sqlCmd;
       // SqlDataAdapter sqlAdapter;
        SqlConnection con = new SqlConnection();
        //con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
        // con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
       // private Login tempSoldier = new Login();

        public Login Soldier { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            Login logInfo = new Login();
            if (logInfo.User_Email != null)
            {
                logInfo.User_Email = "";
                logInfo.User_Password = "";
                logInfo.User_Role = "";
                lblmessage.Text = "You have been logout, please login again if need to.";
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if ((EmailValidation.IsValidEmail(txtUserName.Text)) && txtPassword.Text !="")
            {
                con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
                string QuantcommandString = "select * from VLogin where User_Email = '" + txtUserName.Text + "'and User_Password='" + txtPassword.Text + "'and User_Activated =1";
                SqlCommand commandselect = new SqlCommand(QuantcommandString, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               // commandselect.Parameters.AddWithValue("@User_Activated", '1');
                SqlDataReader rdr = commandselect.ExecuteReader();
                if (rdr.Read())
                {
                    //WebForm1 form2 = new WebForm1(tempSoldier);

                    Login logInfo = new Login();
                    logInfo.User_Email = txtUserName.Text;
                    logInfo.User_Password = txtPassword.Text;
                    logInfo.User_Role = rdr["User_Role"].ToString();
                    Session["user"] = rdr["User_Role"].ToString();
                    if (rdr["User_Role"].ToString() == "Organization")
                    {
                        Response.Redirect("JobPost.aspx");
                    }
                    else
                    {
                        Response.Redirect("WebForm1.aspx");
                    }


                    Response.Redirect("WebForm1.aspx");

                }
                else
                {
                    lblmessage.Text = " incorrect login or not yet registered or activated";
                }
                rdr.Close();
                con.Close();
            }
            else {
                lblmessage.Text = "incorrect login information";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //   Response.Redirect("JobPost.aspx");
            lblmessage.Text = "";
            txtUserName.Text="";
            txtPassword.Text="";
            txtUserName.Focus();
        }
    }
