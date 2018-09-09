using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
/* 
 Author: Ferdous Hossain
 Opearation:  Log in page  . 
 create date:   03.03.2015 to 05.03.2015 
 Version:02
  */


using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//public partial class webLogin : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {

//    }
//}
public partial class webLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AddHeader("Cache-control", "no-store, must-revalidate, private,no-cache");
        Response.AddHeader("Pragma", "no-cache");
        Response.AddHeader("Expires", "0");


        lblInfo.Text = "";
    }


    protected void Btn_LogIn_Click(object sender, EventArgs e)
    {

        Session["userID"] = txtUser.Text.Trim();
        
        if (!Page.IsValid)
        {
            return;
        }
        DbHandler dbh = new DbHandler();
        DataTable dt = dbh.GetDataTable("EXEC getLogInInfo '" + txtUser.Text.Trim() + "'");

        if (dt.Rows.Count < 1)
        {
            lblInfo.Text = "Invalid User Id & Password.";
        }
        else
        {
            if (dt.Rows[0]["Password"].ToString().Trim() != txtPass.Text.Trim())
            {
                lblInfo.Text = "Invalid User Id & Password.";
            }
            else
            {

                if (dbh.ExecuteQuery("EXEC LogInUser '" + txtUser.Text.Trim() + "'"))
                {
                    Session.Add("user", txtUser.Text.Trim());
                    Session.Add("EmployeeID", dt.Rows[0]["EmployeeID"].ToString());
                    Session.Add("UserType", dt.Rows[0]["UserType"].ToString());
                    
                    //Session.Add("EmpName", dt.Rows[0]["USER_NM"].ToString());
                    //Session.Add("BrCode", dt.Rows[0]["BrCode"].ToString());
                    //Session.Add("BranchName", dt.Rows[0]["BranchName"].ToString());
                    //Session.Add("REG_NO", "");
                   
                    
                    //Response.Redirect("Default.aspx");
                    Server.Transfer("Home.aspx");

                    Session["userID"] = txtUser.Text.Trim();
                }
                else
                {
                    lblInfo.Text = "Error in query.";
                }

            }
        }
    }



}