/* 
 Author: Ferdous Hossain
 Opearation:rpGroupWiseLoanStatus reprt  are shown  using this page . 
 create date:   17.08.2015
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
public partial class rptGroupwiseLoanStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGroup(1, "");
            LoadBranch(1, "");
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

            if (Session["UserType"].ToString() != "Admin")
            {
                ReturnVal oRtnValue = new ReturnVal();
                drpBranch.SelectedValue = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "BranchCode");

             
            }


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

 
        string subgroup = string.Empty;


        if (DropSubGroup.SelectedItem.Text == "--ALL--")
        {
            subgroup = "%";
        }
        else
        {
            subgroup = DropSubGroup.SelectedValue;
        }



        LoanProcessingData oLoanProcessingData = new LoanProcessingData();

        GroupWiseLoanStatusAprovedTableAdapter oGroupWiseLoanStatusAprovedTableAdapter = new GroupWiseLoanStatusAprovedTableAdapter();
        oGroupWiseLoanStatusAprovedTableAdapter.Fill(oLoanProcessingData.GroupWiseLoanStatusAproved, branch, drpGroup.SelectedValue, subgroup);
        //return oHeadOfficeGLPLSource;
        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("~/Report/rptGroupWiseLoanStatus.rpt"));
        myReportDocument.SetDataSource(oLoanProcessingData);
        myReportDocument.SetParameterValue("BrName", drpBranch.SelectedItem.Text);
        myReportDocument.SetParameterValue("GroupName", drpGroup.SelectedItem.Text);
       

        MemoryStream oStream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename='Group Wise Approved Loan Status.pdf'");
        Response.BinaryWrite(oStream.ToArray());
        Response.End();



    }

    public void LoadGroup(int a, string code)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = dbconnection.connection();
        //string quiry = "select code from program where Code <>'" + code + "'  order by code";

        string quiry = "SELECT GroupSL, GroupName FROM (SELECT TOP (200) GroupSL,GroupName FROM GroupInfo ORDER BY (GroupName)) AS GroupInfo  ";



        SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
        dt.Fill(ds);
        drpGroup.DataSource = ds;
        drpGroup.DataTextField = "GroupName";
        drpGroup.DataValueField = "GroupSL";
        //drpGroup.Items.Insert(0, "--Other--");
        drpGroup.DataBind();

        if (a == 1)
        {
            drpGroup.Items.Insert(0, "--Select--");
        }

    }
    public void LoadSubGroup(int a, string code)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = dbconnection.connection();
        //string quiry = "select code from program where Code <>'" + code + "'  order by code";

        string quiry = "Select SubGroupSL,SubGroupName from  (Select top(100) SubGroupSL,SubGroupName  from SubGroupInfo where GroupSL='" + code + "' order by (SubGroupName)) as SubGroupInfo   ";

        SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
        dt.Fill(ds);
        DropSubGroup.DataSource = ds;
        DropSubGroup.DataTextField = "SubGroupName";
        DropSubGroup.DataValueField = "SubGroupSL";
        DropSubGroup.DataBind();

        if (a == 1)
        {
            DropSubGroup.Items.Insert(0, "--ALL--");
        }
    }
    protected void drpGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

      
            if (drpGroup.SelectedValue != "--Select--")
                {


                    LoadSubGroup(1, drpGroup.SelectedValue);
                }
                else
                {
                    DropSubGroup.ClearSelection();
                }
        }
        
    
    protected void DropSubGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }



}