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
       Login logDetails= new Login();
       SqlConnection con = new SqlConnection();
       SqlCommand sqlCmd;
       SqlDataAdapter sqlAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
            
            try
            {
                if ((logDetails.User_Email != null) && (logDetails.User_Password != null) && (logDetails.User_Role== "Volunteer"))
                {
                   
                    //con.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=V_indeed;Integrated Security=True";
                    string commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date, Reference_Number from OrganizationJobPosted ";

                    

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
                else
                {
                    grdViewJobs.AutoGenerateSelectButton = false;
                    
					//string  commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date \
					//                         from JobPosted where ZipCode='" + txtLocation.Text + "'";

                    string commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date, \
											Reference_Number from OrganizationJobPosted";
                    
					sqlCmd     = new SqlCommand(commandString, con);
                    sqlAdapter = new SqlDataAdapter(commandString, con);
                    DataSet ds = new DataSet();
                    
					if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    sqlAdapter.Fill(ds, "Jobs");
                    
					con.Close();
                    
                    //grdViewJobs.Columns[1].Visible = false;
                    grdViewJobs.DataSource          = ds;
                    grdViewJobs.DataMember          = "Jobs";
                    grdViewJobs.DataBind            ();
                    grdViewJobs.Columns[0].Visible  = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
              //  con.Close();
            }

            /*
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapt = new SqlDataAdapter("select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date from JobPosted", con);
                        con.Open();
                        adapt.Fill(dt);
                        con.Close();
                        if (dt.Rows.Count > 0)
                        {
                            grdViewJobs.DataSource = dt;
                            grdViewJobs.DataBind();
                        }*/

        
        }

        protected void grdViewJobs_SelectedrowChanged(object sender, EventArgs e)
        {
        }
            protected void grdViewJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string commandStringjob = null;
          //  Login logDetails = new Login();
            string moi = grdViewJobs.SelectedRow.Cells[3].Text;
            //GridViewRow row = grdViewJobs.;

            // Display the first name from the selected row.
            // In this example, the third column (index 2) contains
            // the first name.
            grdViewJobs.AutoGenerateSelectButton = false;


            logDetails.Type_            = grdViewJobs.SelectedRow.Cells[2].Text;
            logDetails.Position_        = grdViewJobs.SelectedRow.Cells[3].Text;
            logDetails.Zip_Code         = grdViewJobs.SelectedRow.Cells[4].Text;
            logDetails.City_            = grdViewJobs.SelectedRow.Cells[5].Text;
            logDetails.Job_Description  = grdViewJobs.SelectedRow.Cells[6].Text;
            logDetails.Start_Date       = grdViewJobs.SelectedRow.Cells[7].Text;
            logDetails.End_Date         = grdViewJobs.SelectedRow.Cells[8].Text;
            logDetails.REference_Number = grdViewJobs.SelectedRow.Cells[9].Text;
            
			Response.Redirect("Job_Application_Form.aspx");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string          columns       = null;
            string          commandString = null;
            SqlDataAdapter  sqlAdapter2;
            
			grdViewJobs.AutoGenerateSelectButton = false;

            if((rdbtnLocation.SelectedIndex != -1) && (txtLocation.Text==""))
            {
                grdViewJobs.Visible = false;
                lblMessage.Text = "Please specify the location";
                lblMessage.ForeColor = System.Drawing.Color.DarkOrange;
                return;
            }


            if (((rdbtnLocation.SelectedIndex == -1) || (rdbtnLocation.SelectedIndex == 2)) && 
				(ddlJobtype.SelectedIndex == 0))
            {
                commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date,\
								 Reference_Number from OrganizationJobPosted";
            }
            if (((rdbtnLocation.SelectedIndex == -1) || (rdbtnLocation.SelectedIndex == 2)) && 
				(ddlJobtype.SelectedIndex != 0))
            {
                commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date,\
								 Reference_Number from OrganizationJobPosted where Type ='" + ddlJobtype.SelectedValue.ToString() + "'";
            }

            if ((rdbtnLocation.SelectedIndex == 0) && (ddlJobtype.SelectedIndex == 0))
            {

                //columns = "ZipCode";
               // commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date \
			   //                  from JobPosted where " + columns + "='" + txtLocation.Text + "'";
                
				commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date,\
								 Reference_Number from OrganizationJobPosted where ZipCode='" + txtLocation.Text + "'";

            }
            else if ((rdbtnLocation.SelectedIndex == 1) && (ddlJobtype.SelectedIndex == 0))
            {
                columns = "City";
                commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date,\
								 Reference_Number from OrganizationJobPosted where " + columns + "='" + txtLocation.Text + "'";

            }

            if ((rdbtnLocation.SelectedIndex == 0) && (ddlJobtype.SelectedIndex != 0))
            {
                commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date, \
								 Reference_Number from OrganizationJobPosted where Type ='" + 
								 ddlJobtype.SelectedValue.ToString() + "'and ZipCode='" + txtLocation.Text + "'";
            }
            if ((rdbtnLocation.SelectedIndex == 1) && (ddlJobtype.SelectedIndex != 0))
            {
                commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date, \
								 Reference_Number from OrganizationJobPosted where Type ='" + 
								 ddlJobtype.SelectedValue.ToString() + "'and City='" + txtLocation.Text + "'";
            }



            //commandString = "select Type,Position,ZipCode,City,Job_Description,Start_Date,End_Date \
			//                 from JobPosted where" + columns + "='" + txtLocation.Text+"'";
            sqlCmd       = new SqlCommand(commandString, con);
            sqlAdapter2  = new SqlDataAdapter(commandString, con);
            DataSet ds   = new DataSet();
            DataTable dt = new DataTable();
            
			if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            // commandselect.Parameters.AddWithValue("@User_Activated", '1');
            SqlDataReader rdr = sqlCmd.ExecuteReader();

           // while ((!rdr.IsClosed) && rdr.Read())
           // {

                if (rdr.Read())
                {
                    if (((rdr[2].ToString() == txtLocation.Text) || (rdr[3].ToString() == txtLocation.Text)) && 
						((txtLocation.Text != "") || (txtLocation.Text != null)))
                    {/*
                    grdViewJobs.DataSource = ds;
                    grdViewJobs.DataMember = "Jobs";
                    grdViewJobs.DataBind();
                    lblMessage.Text = "";
                    */
                        rdr.Close();
                        /* sqlAdapter2.Fill(ds, "Jobs1");
                         con.Close();
                         grdViewJobs.DataSource = ds;
                         grdViewJobs.DataMember = "Jobs1";
                         grdViewJobs.DataBind();
                         */

                        sqlCmd      = new SqlCommand    (commandString, con);
                        sqlAdapter  = new SqlDataAdapter(commandString, con);
                        DataSet ds1 = new DataSet       ();
                        
						if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        sqlAdapter.Fill(ds1, "Jobs1");
                        con.Close();
                        grdViewJobs.DataSource = ds1;
                        grdViewJobs.DataMember = "Jobs1";
                        grdViewJobs.DataBind();
                    }
                    else
                    {
                        grdViewJobs.Visible  = false;
                        lblMessage.Text      = "No job at that location";
                        lblMessage.ForeColor = System.Drawing.Color.DarkOrange;
                    }
                }
                /*
                else
                {
                    lblMessage.Text = "No job at that location";
                }
                */
                //sqlAdapter.Fill(ds, "Jobs");


                //  sqlAdapter.Fill(dt);
                //  grdViewJobs.DataSource = dt;
                // grdViewJobs.DataBind();

               // con.Close();

                //check if dt is null
                /*  if ((dt?.Rows?.Count ?? 1) > 0)
                  {
                      grdViewJobs.DataSource = ds;
                      grdViewJobs.DataMember = "Jobs";
                      grdViewJobs.DataBind();
                      lblMessage.Text = "";
                  }
                  else
                  {
                      lblMessage.Text = "No job at that location";
                  }
                  */
            //}
            con.Close();
        }
    }
}


               