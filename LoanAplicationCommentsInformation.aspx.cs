
/* 
 Author: Ferdous Hossain
 Opearation: Aplication Comment are shown  using this page . 
 create date:  29.1.2015
 Version:01
  */


using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Data.SqlTypes;

public partial class LoanAplicationCommentsInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBranch(1, "");
            //GridLoad();

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridLoad();
    }

    public void LoadBranch(int a, string code)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = dbconnection.connection();
        //string quiry = "select code from program where Code <>'" + code + "'  order by code";

        string quiry = "select BranchName,BrCode  from BranchInfo where BrCode<190  order by  BranchName";
        ////string quiry = "select BranchName,BrCode  from BranchInfo  order by  BranchName";



        SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
        dt.Fill(ds);
        drpbranch.DataSource = ds;
        drpbranch.DataTextField = "BranchName";
        drpbranch.DataValueField = "BrCode";
        drpbranch.DataBind();

        if (a == 1)
        {
            drpbranch.Items.Insert(0, "--ALL--");

        }

    }
    public void GridLoad()
    {


        ReturnVal oRtnValue = new ReturnVal();
        string usertype = oRtnValue.ReturnValue("tblUserInfo", "userid", "'" + Session["userID"] + "'", "usertype");
        
        string BrName;
        if (drpbranch.SelectedItem.Text == "--ALL--")
        {
            BrName = "%";
        }
        else
        {
            BrName = drpbranch.SelectedItem.Text;
        }
        string status;
        if (Rstaus.SelectedItem.Text=="--ALL--")
            
        {
            status = "%";
        }
        else
        {
            status = Rstaus.SelectedItem.Text;
        }


        SqlConnection conn = dbconnection.connection();

        if (usertype == "Admin")
        {

                if ((txtAccount.Text == "--ALL--") || (txtAccount.Text == ""))
                {
                    SqlCommand objcmd = new SqlCommand("select [AcountNo],[Status],[Comments],[EmployeeName] ,[UserType] ,[Designation],[BranchName],[Date] from  View_LoanAplicationComments where BranchName like '" + BrName + "' and  Status like '" + status + "'  ORDER BY CONVERT(DATETIME, [Date], 103)  Desc  ", conn);


                    GridView1.DataSource = objcmd.ExecuteReader();
                }
                else
                {
                    SqlCommand objcmd = new SqlCommand("select [AcountNo],[Status],[Comments],[EmployeeName] ,[UserType] ,[Designation],[BranchName],[Date] from  View_LoanAplicationComments where AcountNo = '" + txtAccount.Text + "'   ORDER BY CONVERT(DATETIME, [Date], 103)  Desc  ", conn);

                    GridView1.DataSource = objcmd.ExecuteReader();
                }
        }

        else

        {

                if ((txtAccount.Text == "--ALL--") || (txtAccount.Text == ""))
                {
                    SqlCommand objcmd = new SqlCommand("select [AcountNo],[Status],[Comments],[EmployeeName] ,[UserType] ,[Designation],[BranchName],[Date] from  View_LoanAplicationCommentsAll where Autherised_UserID= '" + Session["userID"] + "'  and BranchName like '" + BrName + "' and  Status like '" + status + "'  ORDER BY AcountNo Desc  ", conn);


                    GridView1.DataSource = objcmd.ExecuteReader();
                }
                else
                {
                    SqlCommand objcmd = new SqlCommand("select [AcountNo],[Status],[Comments],[EmployeeName] ,[UserType] ,[Designation],[BranchName],[Date] from  View_LoanAplicationCommentsAll where  Autherised_UserID= '" + Session["userID"] + "'  and  AcountNo = '" + txtAccount.Text + "'   ORDER BY AcountNo Desc  ", conn);

                    GridView1.DataSource = objcmd.ExecuteReader();
                }



        
        
        }


      
        GridView1.DataBind();
        GridView1.EditIndex = -1;


    }

}