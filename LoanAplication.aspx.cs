
/* 
 Author: Ferdous Hossain
 Opearation: Aplication Save and update using this page . 
 create date: 25.1.2015 to  28.1.2015
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
using System.Globalization;

public partial class LoanAplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        txtADRTarget.Attributes.Add("readonly", "readonly");
        txtADRAchievemen.Attributes.Add("readonly", "readonly");



        if (!IsPostBack)
        {
            Button1.Enabled = false;

            if (Session["Aplication"] != null)
            {

                //txtAccount.Text = Session["Aplication"].ToString();
                btnSearch_Click(sender, e);
                txtAccount.Enabled = false;
                drpLoanType.Enabled = false;
                btnSearch.Enabled = false;
                btnNewLoan.Enabled = false;
                Button1.Enabled = false;
                Session["Aplication"] = null;

            }
        }
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        string key = txtAccount.Text;
        string content = elm1.Value;
        ////string content = Server.HtmlEncode(elm1.Value);
        float DTarget = 0;
        float DAchievement = 0;
        float ATarget = 0;
        float AAchievement = 0;
        float clasification = 0;


        if (txtDepositTarget.Text != "")
        {
            DTarget = (float)Convert.ToDouble(txtDepositTarget.Text);

        }

        if (txtDepositAchievemen.Text != "")
        {
            DAchievement = (float)Convert.ToDouble(txtDepositAchievemen.Text);

        }
        if (txtAdvanchTarget.Text != "")
        {
            ATarget = (float)Convert.ToDouble(txtAdvanchTarget.Text);

        }
        if (txtAdvanchAchievemen.Text != "")
        {
            AAchievement = (float)Convert.ToDouble(txtAdvanchAchievemen.Text);

        }


        if (txtClasification.Text!= "")
        {
            clasification = (float)Convert.ToDouble(txtClasification.Text);

        }





        if (content == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please Create or Upload Loan Application')", true);
            Button1.Enabled = true;
            return;
        }



        ReturnVal oRtnValue = new ReturnVal();
        string BrCode = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "BranchCode");

        string oldAccount = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAccount.Text + "'", "AcountNo");


        SqlConnection conn = dbconnection.connection();
        using (SqlCommand cmd = new SqlCommand("SPInsertGLPLBalance", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoanContent";
            cmd.Parameters.AddWithValue("@AcountNo", key);
            cmd.Parameters.AddWithValue("@HTML", content);
            cmd.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd.Parameters.AddWithValue("@BrCode", BrCode);
            cmd.Parameters.AddWithValue("@creation", DateTime.Now);

            //cmd.Parameters.AddWithValue("@creation", DateTime.Now.ToString("MM/dd/yyyy HH:MM"));




            cmd.Parameters.AddWithValue("@DTarget", DTarget);
            cmd.Parameters.AddWithValue("@DAchievement", DAchievement);

            cmd.Parameters.AddWithValue("@ATarget", ATarget);
            cmd.Parameters.AddWithValue("@AAchievement", AAchievement);

            cmd.Parameters.AddWithValue("@ADRTarget", txtADRTarget.Text);
            cmd.Parameters.AddWithValue("@ADRAchievement", txtADRAchievemen.Text);


            cmd.Parameters.AddWithValue("@LoanSubject", txtSubject.Text);


            cmd.Parameters.AddWithValue("@Clasification", clasification);

            cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);


            if (!string.IsNullOrEmpty(AsOnDate.Text))
            {

                //cmd.Parameters.AddWithValue("@AsonDate", DateTime.Parse(AsOnDate.Text).ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@AsonDate", (DateTime.ParseExact(AsOnDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("MM/dd/yyyy"));
            }
            else
            {
                cmd.Parameters.Add("@AsonDate", SqlDbType.Date).Value = SqlDecimal.Null;

            }
            //cmd.ExecuteNonQuery();

            try
            {
                //cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                i = 1;
            }
            catch { }
            conn.Close();

            if (i == 1)
            {

                if (oldAccount == "")
                {

                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Application Saved successfully, Receive document for final  the submission')", true);

                    Session["Aplicationid"] = txtAccount.Text;
                    txtAccount.Enabled = true;
                    txtAccount.Text = "";
                    drpLoanType.Enabled = true;
                    btnSearch.Enabled = true;
                    btnNewLoan.Enabled = true;
                    Button1.Enabled = true;
                    elm1.Value = "";
                    Button1.Enabled = false;


                    //Server.Transfer("LoanDocumentChecklist.aspx");
                    Response.Redirect("LoanDocumentChecklist.aspx");



                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Aplication updated Successfully')", true);
                    txtAccount.Enabled = true;
                    txtAccount.Text = "";
                    drpLoanType.Enabled = true;
                    btnSearch.Enabled = true;
                    btnNewLoan.Enabled = true;
                    Button1.Enabled = true;
                    elm1.Value = "";
                    Button1.Enabled = false;




                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Data Can not Save')", true);
                Button1.Enabled = true;
            }

        }



    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string Cont = null;
        ReturnVal oRtnValue = new ReturnVal();

        if (Session["Aplication"] != null)
        {
            Cont = oRtnValue.ReturnValue("LoanAplicationHistory", "SL", "'" + Session["Aplication"] + "'", "HTML");

            elm1.Value = Cont;
            if (Cont != "")
            {
                txtAccount.Enabled = false;
                drpLoanType.Enabled = false;
                btnSearch.Enabled = false;
                btnNewLoan.Enabled = false;
                Button1.Enabled = true;

            }
            else
            {

                Button1.Enabled = false;
            }

        }
        else
        {

            string userid = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAccount.Text + "'", "userID");

            if (Session["userID"].ToString().ToUpper() == userid.ToUpper())
            {

                Cont = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAccount.Text + "'", "HTML");
                elm1.Value = Cont;
                if (Cont != "")
                {
                    txtAccount.Enabled = false;
                    drpLoanType.Enabled = false;
                    btnSearch.Enabled = false;
                    btnNewLoan.Enabled = false;
                    Button1.Enabled = true;

                }
                else
                {

                    Button1.Enabled = false;
                }

            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Only initiator are eligible to change the proposal')", true);
                Button1.Enabled = false;
            }



        }

        //elm1.Value = Cont;
        //if (Cont != "")
        //{
        //    txtAccount.Enabled = false;
        //    drpLoanType.Enabled = false;
        //    btnSearch.Enabled = false;
        //    btnNewLoan.Enabled = false;
        //    Button1.Enabled = true;

        //}
        //else
        //{

        //    Button1.Enabled = false;
        //}

    }

    protected void btnNewLoan_Click(object sender, EventArgs e)
    {
        // entryType + (voucherDate.Day.ToString().Length == 1 ? "0" + voucherDate.Day.ToString() : voucherDate.Day.ToString()) + (voucherDate.Month.ToString().Length == 1 ? "0" + voucherDate.Month.ToString() : voucherDate.Month.ToString()) + DateTime.Now.Year.ToString().Substring(voucherDate.Year.ToString().Length - 2) + s;
        //string.Concat("NBL" + "'" + BrCode + "'" + "'" + drpLoanType.SelectedItem.Text + "'");

        if (drpLoanType.SelectedItem.Text == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please Select Valid Loan Type')", true);
            Button1.Enabled = false;
            return;

        }
        else
        {

            ReturnVal oRtnValue = new ReturnVal();
            string BrCode = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "BranchCode");
            string maxloanSL = oRtnValue.ReturnValue("LoanAplication", "brCode", "'" + BrCode + "'", "Count(*)+1");
            txtAccount.Text = "NBL" + "" + BrCode + "" + "" + drpLoanType.SelectedItem.Text + "" + "" + (DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) + (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + DateTime.Now.Year.ToString().Substring(DateTime.Now.Year.ToString().Length - 2) + "" + "" + maxloanSL + "";

            txtAccount.Enabled = false;
            drpLoanType.Enabled = false;
            btnSearch.Enabled = false;
            btnNewLoan.Enabled = false;
            Button1.Enabled = true;

        }

        //txtAccount.Text = "NBL" + "" + BrCode + "" + "" + drpLoanType.SelectedItem.Text + "" + "" + (DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) + (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + DateTime.Now.Year.ToString().Substring(DateTime.Now.Year.ToString().Length - 2) + "" + "" + maxloanSL + "";

    }

    protected void txtDepositTarget_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtZoom_Click(object sender, EventArgs e)
    {
        Session["subject"] = txtSubject.Text;
        //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('"+ txtSubject.Text+"')", true);
    }
}