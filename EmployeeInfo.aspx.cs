/* 
 Author: Ferdous Hossain
 Opearation: Employee Information Save and update Here. 
 create date: 0.06.2015
 Version:01
  */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EmployeeInfo : System.Web.UI.Page
{
    EmployeeInfoDAO oEmployeeInfoDAO = new EmployeeInfoDAO();
    EmployeeInfoEntity oEmployeeInfoEntity = new EmployeeInfoEntity();
    ReturnVal oRtnValue = new ReturnVal();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
           LoadBranch(1, "");
      
            
            gridViewBind();


            string EmployeeID = oRtnValue.ReturnValue("tblEmployeeInfo", "", "", "isnull(MAX(EmployeeID ),0000000)+1");
            int value;
            int.TryParse(EmployeeID, out value);
            txtEmployeeID.Text = value.ToString("D7");
            


        }

    }

    protected void btnBSave_Click1(object sender, EventArgs e)
    {

        oEmployeeInfoEntity = new EmployeeInfoEntity();


        oEmployeeInfoEntity.EmployeeID = txtEmployeeID.Text;
        oEmployeeInfoEntity.EmployeeName = txtEmployeeName.Text;
        oEmployeeInfoEntity.Designation = txtDesignation.Text;
        oEmployeeInfoEntity.RegistrationNo = txtRegistrationNo.Text;
        oEmployeeInfoEntity.BranchCode = txtBranchCode.SelectedItem.Value;
        oEmployeeInfoEntity.MobileNo = txtMobileNo.Text;
        oEmployeeInfoEntity.CreateBy  = DateTime.Now.ToShortDateString();
        oEmployeeInfoEntity.LastModifiedBy  = DateTime.Now.ToShortDateString();





        string condition = " where EmployeeID='" + oEmployeeInfoEntity.EmployeeID + "'";
        DataTable dt = oEmployeeInfoDAO.GetEmployeeInfo(condition);
        string message = "";
        if (dt.Rows.Count == 0)
        {
            int i = oEmployeeInfoDAO.InsertEmployeeInfo(oEmployeeInfoEntity);
            if (i == 1)
            {
                message = "Data Inserted Successfully";
                Clear();
            }
            else
                message = "Data Not  Inserted";

        }
        else
        {
            message = "Data Alreay in DataBase";
        }
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('" + message + "')", true);
        gridViewBind();
        Clear();
    }

    public void Clear()
    {


       //txtEmployeeID.Text="";
       txtEmployeeName.Text = "";
       txtDesignation.Text = "";
       txtRegistrationNo.Text = "";
       //txtBranchCode.Text = "";
       txtMobileNo.Text = "";

       string EmployeeID = oRtnValue.ReturnValue("tblEmployeeInfo", "", "", "isnull(MAX(EmployeeID ),0000000)+1");
       int value;
       int.TryParse(EmployeeID, out value);
       txtEmployeeID.Text = value.ToString("D7");
        

    }

    private void gridViewBind()
    {

        ClientTypeDAO oClientTypeDAO = new ClientTypeDAO();

        string condition = " order by EmployeeID ASC";
        DataTable dt = oEmployeeInfoDAO.GetEmployeeInfoView(condition);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        gridViewBind();
        //GridView1.DataSource = oCollectionAccount.GetCustomer(Session["brCode"].ToString(), "");
        //GridView1.DataBind();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView1.EditIndex = -1;
        gridViewBind();


    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

       
        
        TextBox txtGrEmployeeID = (TextBox)GridView1.Rows[e.RowIndex].FindControl("GrEmployeeID");
        TextBox txtGrEmployeeName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("GrEmployeeName");
        TextBox txtGrDesignation = (TextBox)GridView1.Rows[e.RowIndex].FindControl("GrDesignation");
        TextBox txtGrRegistrationNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("GrRegistrationNo");
        TextBox txtGrBranchCode = (TextBox)GridView1.Rows[e.RowIndex].FindControl("GrBranchCode");
        TextBox txtGrMobileNo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("GrMobileNo");
        //TextBox txtGrLastModifiedBy = DateTime.Now.ToString();

        EmployeeInfoEntity oEmployeeInfoEntity = new EmployeeInfoEntity();




        oEmployeeInfoEntity.EmployeeID = txtGrEmployeeID.Text;
        oEmployeeInfoEntity.EmployeeName = txtGrEmployeeName.Text;
        oEmployeeInfoEntity.Designation = txtGrDesignation.Text;
        oEmployeeInfoEntity.RegistrationNo = txtGrRegistrationNo.Text;
        oEmployeeInfoEntity.BranchCode = txtGrBranchCode.Text;
        oEmployeeInfoEntity.MobileNo = txtGrMobileNo.Text;
        oEmployeeInfoEntity.LastModifiedBy = DateTime.Now.ToShortDateString();




        oEmployeeInfoEntity.ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        int i = oEmployeeInfoDAO.UpdateEmployeeInfo(oEmployeeInfoEntity);
        string message = "";
        GridView1.EditIndex = -1;


        if (i == 1)
            message = "Data Updated Successfully";
        else
            message = "Data Not Updated!";

        gridViewBind();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('" + message + "')", true);
        Clear();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {





        oEmployeeInfoEntity.ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

        int i = oEmployeeInfoDAO.DeleteEmployeeInfo(oEmployeeInfoEntity);

        GridView1.EditIndex = -1;


        string message = "";
        if (i == 1)
            message = "Data Deleted Successfully";
        else
            message = "Data Not Deleted!";

        gridViewBind();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('" + message + "')", true);

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView1.EditIndex = e.NewEditIndex;
        gridViewBind();

        // gvbind();

    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
         
        }

    }
    protected void txtNew_Click1(object sender, EventArgs e)
    {
        Clear();
    }

    public void LoadBranch(int a, string code)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = dbconnection.connection();
        //string quiry = "select code from program where Code <>'" + code + "'  order by code";

        string quiry = "select BranchName + ' ('+ BrCode +')' as BranchName ,BrCode  from BranchInfo   order by  BranchName";
        ////string quiry = "select BranchName,BrCode  from BranchInfo where BrCode<190  order by  BranchName";



        SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
        dt.Fill(ds);
        txtBranchCode.DataSource = ds;
        txtBranchCode.DataTextField = "BranchName";
        txtBranchCode.DataValueField = "BrCode";
        txtBranchCode.DataBind();

        if (a == 1)
        {
            txtBranchCode.Items.Insert(0, "--Select--");

        }

    }


}