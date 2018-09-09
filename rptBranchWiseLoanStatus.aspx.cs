/* 
 Author: Ferdous Hossain
 Opearation:rptBranchWiseLoanStatus reprt  are shown  using this page . 
 create date:   12.07.2015
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
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using LoanProcessingDataTableAdapters;

public partial class rptBranchWiseLoanStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadBranch(1, "");

            if (Session["UserType"].ToString() != "Admin")
            {
                ReturnVal oRtnValue = new ReturnVal();
                drpBranch.SelectedValue = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "BranchCode");

                drpBranch.Enabled = false;
            }
     

        }
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
        drpBranch.DataSource = ds;
        drpBranch.DataTextField = "BranchName";
        drpBranch.DataValueField = "BrCode";
        drpBranch.DataBind();

        if (a == 1)
        {
            drpBranch.Items.Insert(0, "--ALL--");

        }

    }
    protected void ShowReport_Click(object sender, EventArgs e)
    {

        string branch = string.Empty;
        if (drpBranch.SelectedItem.Text == "--ALL--")
        {
            branch = "%";
        }
        else
        {
            branch = drpBranch.SelectedValue;
        }

        string Nature = string.Empty;
        if (DropNature.SelectedItem.Text == "--ALL--")
        {
            Nature = "%";
        }
        else
        {
            Nature = DropNature.SelectedValue;
        }


        string Type = string.Empty;

        if (DrpType.SelectedItem.Text == "--ALL--")
        {
            Type = "%";
        }
        else
        {
            Type = DrpType.SelectedValue;
        }

        
        
        
        
        string FromDate ;
        string ToDate;

        if (YrChkBox.Checked == true)
        {
            //FromDate = DateTime.ParseExact(txtProposedDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true).ToString("MM/dd/yyyy"));

            FromDate=(DateTime.ParseExact("01/01/1982", "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("yyyy-MM-dd");
            ToDate = (DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("yyyy-MM-dd");

           

        }
        else
        {
            FromDate = (DateTime.ParseExact(txtFromDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("yyyy-MM-dd");
            ToDate = (DateTime.ParseExact(txtToDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("yyyy-MM-dd");

            //txtvalidityDate.Text.Trim()

        }




        LoanProcessingData oLoanProcessingData = new LoanProcessingData();

        BranchWiseLoanStatusTableAdapter oBranchWiseLoanStatusTableAdapter = new BranchWiseLoanStatusTableAdapter();
        oBranchWiseLoanStatusTableAdapter.Fill(oLoanProcessingData.BranchWiseLoanStatus, branch, Nature, Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), Type);
        //return oHeadOfficeGLPLSource;
        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("~/Report/rptBranchWiseLoanStatus.rpt"));
        myReportDocument.SetDataSource(oLoanProcessingData);
        myReportDocument.SetParameterValue("BrName", drpBranch.SelectedItem.Text);
        myReportDocument.SetParameterValue("Type", DrpType.SelectedItem.Text);

        MemoryStream oStream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename='Branch Wise Loan Status.pdf'");
        Response.BinaryWrite(oStream.ToArray());
        Response.End();



    }
    protected void YrChkBox_CheckedChanged(object sender, EventArgs e)
    {
        if (YrChkBox.Checked==true)
        {
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
        }
        else
        {
            txtFromDate.Enabled = true;
            txtToDate.Enabled = true;
        }
    }
}