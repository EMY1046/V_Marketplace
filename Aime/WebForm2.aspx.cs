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
           
            /*
            SqlCommand sqlCmd;
            SqlDataAdapter sqlAdapter;
            SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
           
    */
         //   con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (EmailValidation.IsValidEmail(txtUserName.Text))
            {
                con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
                string QuantcommandString = "select * from login where User_Email = '" + txtUserName.Text + "'and User_Password='" + txtPassword.Text + "'";
                SqlCommand commandQuant = new SqlCommand(QuantcommandString, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader rdr = commandQuant.ExecuteReader();
                if (rdr.Read())
                {
                    //WebForm1 form2 = new WebForm1(tempSoldier);


                    lblmessage.Text = "User found";
                    Login logInfo = new Login();
                    logInfo.User_Email = txtUserName.Text;
                    logInfo.User_Password = txtPassword.Text;
                    Response.Redirect("WebForm1.aspx");

                }
                else
                {
                    lblmessage.Text = "Login incorrect or not yet registered";
                }
                rdr.Close();
                con.Close();
            }
            else {
                lblmessage.Text = "incorrect login information";
            }
        }
    }
}