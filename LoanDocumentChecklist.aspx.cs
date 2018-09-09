/* 
 Author: Ferdous Hossain
 Opearation:  Aplication suported checklist create and modified here  using this page . 
 create date:   03.02.2015 to 10.02.2015 
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


public partial class LoanDocumentChecklist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDocName.Visible = false;
        
        if (!IsPostBack)
        {

            
            if (Session["Aplicationid"] != null)
            {

                txtAccount.Text = Session["Aplicationid"].ToString();
                txtDocName.Visible = false;
                GridLoad();
                btnSearch_Click(sender, e);
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Application Saved successfully, Receive document for final  the submission')", true);
               

            }

            else
            {
                GridLoad();
                txtDocName.Visible = false;
            
            }


        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        //ReturnVal oRtnValue = new ReturnVal();
        //string Cont = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAccount.Text + "'", "HTML");


       
        //if (elm1.Value == "")
        //{
        //    btnCommentSave.Enabled = false;
        //    elm1.Visible = false;
        //}
        //else
        //{
        //    btnCommentSave.Enabled = true;
        //    elm1.Visible = true;
           

        //}
        GridLoad();

        Session["Aplicationid"] = null;

    }
    protected void btnDocSavee_Click(object sender, EventArgs e)

    {

        ReturnVal oRtnValue = new ReturnVal();
        string Cont = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAccount.Text + "'", "AcountNo");

        //string Doc = oRtnValue.ReturnValue("LoanDocumentChecklist", "AcountNo", "'" + txtAccount.Text + "'and DocName='" + drpLoanDocument.Text + "' ", "DocName");
        string Doc = null;
        if (drpLoanDocument.Text != "Others")
        {
             Doc = oRtnValue.ReturnValue("LoanDocumentChecklist", "AcountNo", "'" + txtAccount.Text + "'and DocName='" + drpLoanDocument.Text + "' ", "DocName");

        }
        else
        {
             Doc = oRtnValue.ReturnValue("LoanDocumentChecklist", "AcountNo", "'" + txtAccount.Text + "'and DocName='" + txtDocName.Text + "' ", "DocName");

        }
       
        
        
        if (Cont == "")
        {

            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please Enter Valid Aplication No.')", true);
        
        
        }
        else
        {
             //string Doc = oRtnValue.ReturnValue("LoanDocumentChecklist", "AcountNo", "'" + txtAccount.Text + "'and DocName='" + drpLoanDocument.Text + "' ", "DocName");

            if ((drpLoanDocument.Text == "--Select--") || (Doc == drpLoanDocument.Text) || (drpLoanDocument.Text == "Others" && Doc == txtDocName.Text) || (drpLoanDocument.Text == "Others" && txtDocName.Equals("")))

            {

                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please Select Valid Document Which Yet Not Recived')", true);
        
            }
            else
            
            {

                if (drpLoanDocument.Text!="Others")
                {

                    SqlConnection conn = dbconnection.connection();
                    //SqlCommand objcmd = new SqlCommand("insert into LoanDocumentChecklist (AcountNo,DocName,UserID,Cdate) values ('" + txtAccount.Text + "','" + drpLoanDocument.Text + "','" + Session["userID"] + "','" + DateTime.Now + "')", conn);
                    SqlCommand objcmd = new SqlCommand("insert into LoanDocumentChecklist (AcountNo,DocName,UserID,Cdate) values ('" + txtAccount.Text + "','" + drpLoanDocument.Text + "','" + Session["userID"] + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:MM") + "')", conn);
                     objcmd.ExecuteNonQuery();
                     conn.Close();
                
                }
                else
                {
                 SqlConnection conn = dbconnection.connection();
                    //SqlCommand objcmd = new SqlCommand("insert into LoanDocumentChecklist (AcountNo,DocName,UserID,Cdate) values ('" + txtAccount.Text + "','" + drpLoanDocument.Text + "','" + Session["userID"] + "','" + DateTime.Now + "')", conn);
                    SqlCommand objcmd = new SqlCommand("insert into LoanDocumentChecklist (AcountNo,DocName,UserID,Cdate) values ('" + txtAccount.Text + "','" + txtDocName.Text + "','" + Session["userID"] + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:MM") + "')", conn);

                 objcmd.ExecuteNonQuery();
                  conn.Close();
                
                }


         
                
            
            GridLoad();
            GridView1.EditIndex = -1;
            }
        }
        
       
        //string message = "Data Save Successfully. ";
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
       

    }

 

    public void GridLoad()
    {
        SqlConnection conn = dbconnection.connection();
        SqlCommand objcmd = new SqlCommand("Select ChecklistID,Aplication_NO,Document,Recived_BY from View_LoanDocCheckList where Aplication_NO='" + txtAccount.Text + "' ", conn);
        GridView1.DataSource = objcmd.ExecuteReader();
        GridView1.DataBind();
        GridView1.EditIndex = -1;
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = Convert.ToInt32(GridView1.Rows[int.Parse(e.RowIndex.ToString())].RowIndex);
        string adsd = GridView1.Rows[row].Cells[1].Text;

        SqlConnection conn = dbconnection.connection();
        SqlCommand objcmd = new SqlCommand("delete from LoanDocumentChecklist  where ChecklistID= '" + adsd + "'", conn);
        objcmd.ExecuteNonQuery();
        conn.Close();

        GridView1.EditIndex = -1;
        //string message = "Data Delete Successfully. ";
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        GridLoad();
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


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView1.EditIndex = -1;
        GridLoad();


    }
    protected void drpLoanDocument_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpLoanDocument.SelectedItem.Text == "Others")
        {

            txtDocName.Visible = true;

        }
        else
        {
            txtDocName.Visible = false;
        }
    }
}