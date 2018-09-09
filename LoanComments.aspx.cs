/* 
 Author: Ferdous Hossain
 Opearation:Comment on  Aplication create here shown  using this page . 
 create date:   02.02.2015
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
//using System.Net.WebUtility.HtmlDecode;


public partial class LoanComments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //elm1.Value = "bn";
        if (!IsPostBack)
        {
            LoadBranch(1, "");
            bankBranchRow.Visible = false;
            elm1.Visible = false;
            btnCommentSave.Enabled = false;
            if (Session["Aplication"]!=null)
            {

                txtAccount.Text = Session["Aplication"].ToString();
                btnSearch_Click(sender, e);

            }
            
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        ReturnVal oRtnValue = new ReturnVal();
        string Cont = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAccount.Text + "'", "HTML");


        //string original = Server.HtmlDecode(Cont);
        
        
        
        elm1.Value = Cont;
        //elm1.InnerHtml = Cont;
        //elm1.Value = original;
        lblDisplay.Text = elm1.Value;
        if (elm1.Value=="")
        {
            btnCommentSave.Enabled = false;
            elm1.Visible = false;

        }
        else
        {
            btnCommentSave.Enabled = true;
            elm1.Visible = true;
            //elm1.disabled = true;
            //elm1.disabled
                

        }

        //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "ChangeMode()", true);
        //elm1.EnableViewState = false;
        //elm1.EnableTheming = false;
        //Session["TempPage"] = Cont;
        //Server.Transfer("ShowTempPage.aspx");

        //string url = "http://localhost/NBLCredit/tinymce/jscripts/tiny_mce/plugins/preview/preview.html";
        //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
        //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        Session["Aplication"] = null;

    }
    protected void Rstaus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rstaus.SelectedItem.Text == "Approved")
        {

            bankBranchRow.Visible = true;
            //SnactionAmount.Visible = true;
            Mdate.Visible = true;
            MNo.Visible = true;

        }
        else
        {
            bankBranchRow.Visible = false;
            //SnactionAmount.Visible = false;
            Mdate.Visible = false;
            MNo.Visible = false;
        }
    }


    public void LoadBranch(int a, string code)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = dbconnection.connection();
        //string quiry = "select code from program where Code <>'" + code + "'  order by code";

        string quiry = "select BranchName,BrCode  from BranchInfo where BrCode<900  order by  BranchName";


     
        SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
        dt.Fill(ds);
        drpbranch.DataSource = ds;
        drpbranch.DataTextField = "BranchName";
        drpbranch.DataValueField = "BrCode";
        drpbranch.DataBind();

        if (a == 1)
        {
            drpbranch.Items.Insert(0, "--Select--");

        }

    }

    protected void btnCommentSave_Click(object sender, EventArgs e)
    {


        if (Rstaus.Text == "Select")
        {

            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please select Valid  Recommended Status')", true);

        }

        else
        {

            string brcode;
            if (drpbranch.Text == "--Select--")
            {
                brcode = "nul";
            }
            else
            {
                brcode = drpbranch.SelectedValue;
            }

            String MettingNo;
            if (txtMettingNo.Text == "")
            {
                MettingNo = null;
            }
            else
            {
                MettingNo = txtMettingNo.Text;
            }

            String MDate;
            if (MettingDate.Text == "")
            {
                MDate = null;
            }
            else
            {
                MDate = MettingDate.Text;
            }

            SqlConnection conn = dbconnection.connection();

            if (MettingDate.Text == "")
            {
                SqlCommand objcmd = new SqlCommand("insert into LoanAplicationComments (AcountNo,Comments,Status,Userid,Commentdate,DisbusmentBrCode,MettingNo) values ('" + txtAccount.Text + "','" + txtComments.Text + "','" + Rstaus.Text + "','" + Session["userID"] + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:MM") + "','" + brcode + "','" + MettingNo + "')", conn);

                objcmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                SqlCommand objcmd = new SqlCommand("insert into LoanAplicationComments (AcountNo,Comments,Status,Userid,Commentdate,DisbusmentBrCode,MettingNo,MettingDate) values ('" + txtAccount.Text + "','" + txtComments.Text + "','" + Rstaus.Text + "','" + Session["userID"] + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:MM") + "','" + brcode + "','" + MettingNo + "','" + DateTime.Parse(MDate).ToString("MM/dd/yyyy") + "')", conn);

                objcmd.ExecuteNonQuery();
                conn.Close();
            }

            btnCommentSave.Enabled = false;
            elm1.Value = "";
            txtComments.Text = "";
            txtAccount.Text = "";
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Comment Posted Successfully')", true);
        }
    }

}