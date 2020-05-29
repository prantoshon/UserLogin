using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Login
{
    public partial class Defualt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HM3JBK0\\SQLEXPRESS;Initial Catalog=PPL;Integrated Security=True");
        protected void btnSingIn_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeID = txtEmloyeeID.Text;
                string phoneNumber = txtMobileNumber.Text;
                con.Open();
                string qry = "select * from  hrd.Employee where PIN='" + employeeID + "' and Mobile_No='" + phoneNumber + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    //string myStringVariable = "Success";
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                    LblMessage.Text = "Login Success......!!";
                }
                else
                {
                    //string myStringVariable = "Wrong Pin or Phone number";
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);;
                    LblMessage.Text = "Login Fail......!!";

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    
}