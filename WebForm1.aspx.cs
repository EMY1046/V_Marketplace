using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

namespace Web_Vindeed
{
    public partial class WebForm1 : System.Web.UI.Page
    {
      //  private Login form1;
       // string use, nam;

        // public WebForm1(Login form1)
        //{
        //   this.form1 = form1;

        //  this.InitializeComponent();
        //     }

            

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Login logDetails= new Login();


            if ((logDetails.User_Email != null) && (logDetails.User_Password != null))
            {
                // will need to load the existing posted job
                SqlConnection con = new SqlConnection();
                SqlCommand sqlCmd;
                SqlDataAdapter sqlAdapter;
                
                /*
                 string constr = ConfigurationManager.ConnectionStrings["Database"].ToString(); // connection string
                SqlConnection con = new SqlConnection(constr);
                SqlCommand com = new SqlCommand("select * from login", con); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset
                 */
                con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
                string commandString = "select * from login";



               sqlCmd = new SqlCommand(commandString, con);
                sqlAdapter = new SqlDataAdapter(commandString, con);
                DataSet ds = new DataSet();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sqlAdapter.Fill(ds, "Jobs");
                con.Close();
                grdViewJobs.DataSource = ds;
                grdViewJobs.DataMember = "Jobs";
                grdViewJobs.DataBind();

            }
        }
    }
}