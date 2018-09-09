

/* 
 Author: Ferdous Hossain
 Opearation:Submitted  Aplication are shown  using this page . 
 create date:   01.02.2015
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

public partial class LoanAplicationINformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
        if (!IsPostBack)
        {
            LoadBranch(1, "");
            GridLoad();
            trrHideMe1.Visible = false;
            trrHideMe.Visible = false;
        }
    }


    public void GridLoad()
    {
        string BrName;
        //string usertype;

        ReturnVal oRtnValue = new ReturnVal();
        string usertype = oRtnValue.ReturnValue("tblUserInfo", "userid", "'" + Session["userID"] + "'", "usertype");
        
        
        
        if (drpbranch.SelectedItem.Text=="--ALL--")
        {
            BrName = "%";
        }
        else
        {
            BrName = drpbranch.SelectedItem.Text;
        }

        string LoanNature;

        if (DropLoanNature.SelectedItem.Text == "--ALL--")
        {
            LoanNature = "%";
        }
        else
        {
            LoanNature = DropLoanNature.SelectedItem.Text;
        }

        
      
        SqlConnection conn = dbconnection.connection();

        if (usertype == "Admin")
        {

            SqlCommand objcmd = new SqlCommand("select [AplicationNo],[CreateBy],[Designation],[UserType],[BranchName],[Create/LastModified] from  View_LoanAolication where BranchName like '" + BrName + "'   ORDER BY CONVERT(DATETIME, [Create/LastModified], 103) Desc  ", conn);
            GridView1.DataSource = objcmd.ExecuteReader();
        
        }
        else
        {

            SqlCommand objcmd = new SqlCommand("select [AplicationNo],[CreateBy],[Designation],[UserType],[BranchName],[Create/LastModified] from  View_LoanAolicationAllUserWise  where Athuntication_USERID= '" + Session["userID"] + "' and  BranchName like '" + BrName + "'    ORDER BY CONVERT(DATETIME, [Create/LastModified], 103) Desc  ", conn);
            GridView1.DataSource = objcmd.ExecuteReader();
        
        }
            
            
            
        
        GridView1.DataBind();
        GridView1.EditIndex = -1;


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

       string quiry = "select BranchName,BrCode  from BranchInfo where BrCode<200  order by  BranchName";
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = Convert.ToInt32(GridView1.Rows[int.Parse(e.RowIndex.ToString())].RowIndex);
        string Asad = GridView1.Rows[row].Cells[1].Text;

        //SqlConnection conn = dbconnection.connection();
        //SqlCommand objcmd = new SqlCommand("delete from LoanDocumentChecklist  where ChecklistID= '" + adsd + "'", conn);
        //objcmd.ExecuteNonQuery();
        //conn.Close();
        Session["Aplication"] = Asad;
        Server.Transfer("LoanComments.aspx");
    
         

        //GridView1.EditIndex = -1;
        
        //GridLoad();
    }



    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        //int row = Convert.ToInt32(GridView1.Rows[int.Parse(e.NewEditIndex.ToString())].RowIndex);
        //label1.Text = GridView1.Rows[row].Cells[2].Text;
        //txtLstart.Text = GridView1.Rows[row].Cells[3].Text;
        //txtLEnd.Text = GridView1.Rows[row].Cells[4].Text;

        //txtHeading.Text = GridView1.Rows[row].Cells[5].Text;
        //txtRemarks.Text = GridView1.Rows[row].Cells[6].Text;

        //btnSave.Text = "Update";

    }


}