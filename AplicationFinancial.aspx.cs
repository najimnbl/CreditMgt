/* 
 Author: Ferdous Hossain
 Opearation: Financial Aplication Data Save and update using this page . 
 create date: 25.6.2015 to  28.7.2015
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

public partial class AplicationFinancial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtGroupName.Visible = false;
        btnGroup.Visible = false;
        txtSubGroupName.Visible = false;
        btnSubGroup.Visible = false;
        
        
        if (!IsPostBack)
        {
            LoadGroup(1, "");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ReturnVal oRtnValue = new ReturnVal();
        int i = 0;
        if ((oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAplication.Text + "'", "AcountNo")=="")||(txtAplication.Text == ""))
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Please provide valid  Loan Application NO.')", true);
            //txtAplication.ForeColor=
            return;
        }



        //ReturnVal oRtnValue = new ReturnVal();
        //string BrCode = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "BranchCode");

        string oldAccount = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + txtAplication.Text + "'", "AcountNo");


        SqlConnection conn = dbconnection.connection();
        using (SqlCommand cmd = new SqlCommand("SP_LoanAplicationFinancial", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@AcountNo",txtAplication.Text );



            if (!string.IsNullOrEmpty(txtPlSL.Text))
                                    {
                                        cmd.Parameters.Add("@sub_Sl", SqlDbType.Int).Value = txtPlSL.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@sub_Sl", SqlDbType.Int).Value = null;
                                    }


                cmd.Parameters.AddWithValue("@Type",DrpType.Text );
                cmd.Parameters.AddWithValue("@Nature",DropNature.Text );


                if (drpGroup.SelectedValue != "--Select--" && drpGroup.SelectedValue != "9999")
                {
                    cmd.Parameters.Add("@GroupSL", SqlDbType.Int).Value = drpGroup.SelectedValue;

                }
                else
                {
                    cmd.Parameters.Add("@GroupSL", SqlDbType.Int).Value = null;
                }


                if (DropSubGroup.SelectedValue != "--Select--" && DropSubGroup.SelectedValue != "9999" && DropSubGroup.SelectedValue != "")
                {
                    cmd.Parameters.Add("@SubGroupSL", SqlDbType.Int).Value = DropSubGroup.SelectedValue;

                }
                else
                {
                    cmd.Parameters.Add("@SubGroupSL", SqlDbType.Int).Value = null;
                }
            







            if (!string.IsNullOrEmpty(txtExistingLimmit.Text))
                                    {
                                        cmd.Parameters.Add("@ExistingLimitAmount", SqlDbType.Decimal).Value = txtExistingLimmit.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@ExistingLimitAmount", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }


             if (!string.IsNullOrEmpty(txtProposedLimit.Text))
                                    {
                                        cmd.Parameters.Add("@ProposedLimit", SqlDbType.Decimal).Value = txtProposedLimit.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@ProposedLimit", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }

             if (!string.IsNullOrEmpty(txtRevisedLimit.Text))
                                    {
                                        cmd.Parameters.Add("@RevisedLimit", SqlDbType.Decimal).Value = txtRevisedLimit.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@RevisedLimit", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }



            if (!string.IsNullOrEmpty(txtOutStanding.Text))
                                    {
                                        cmd.Parameters.Add("@Outstanding", SqlDbType.Decimal).Value = txtOutStanding.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@Outstanding", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }


            if (!string.IsNullOrEmpty(txtOverDeu.Text))
                                    {
                                        cmd.Parameters.Add("@OverDue", SqlDbType.Decimal).Value = txtOverDeu.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@OverDue", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }

            if (!string.IsNullOrEmpty(txtEOL.Text))
                                    {
                                        cmd.Parameters.Add("@EOL", SqlDbType.Decimal).Value = txtEOL.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@EOL", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }



            if (!string.IsNullOrEmpty(txtExistingSanction.Text))
                                    {
                                        cmd.Parameters.Add("@ExistingSanction", SqlDbType.Decimal).Value = txtExistingSanction.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@ExistingSanction", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }

            if (!string.IsNullOrEmpty(txtSanctionAmount.Text))
                                    {
                                        cmd.Parameters.Add("@ProposedSanction", SqlDbType.Decimal).Value = txtSanctionAmount.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@ProposedSanction", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }

            if (!string.IsNullOrEmpty(txtRevisedSanction.Text))
                                    {
                                        cmd.Parameters.Add("@RevisedSanction", SqlDbType.Decimal).Value = txtRevisedSanction.Text;
                                            
                                          

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@RevisedSanction", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }
            if (!string.IsNullOrEmpty(txtexixtingTenor.Text))
                                    {
                                        cmd.Parameters.Add("@ExistingTenor", SqlDbType.Decimal).Value = txtexixtingTenor.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@ExistingTenor", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }


            if (!string.IsNullOrEmpty(txtProposedTenor.Text))
            {
                cmd.Parameters.Add("@ProposedTenor", SqlDbType.Decimal).Value = txtProposedTenor.Text;

            }
            else
            {
                cmd.Parameters.Add("@ProposedTenor", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtTenorRevised.Text))
            {
                cmd.Parameters.Add("@RevisedTenor", SqlDbType.Decimal).Value = txtTenorRevised.Text;

            }
            else
            {
                cmd.Parameters.Add("@RevisedTenor", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtExixtingInstallmentAmount.Text))
            {
                cmd.Parameters.Add("@ExistingInstallmentAmount", SqlDbType.Decimal).Value = txtExixtingInstallmentAmount.Text;

            }
            else
            {
                cmd.Parameters.Add("@ExistingInstallmentAmount", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtProposedInstallment.Text))
            {
                cmd.Parameters.Add("@ProposedInstallmentAmount", SqlDbType.Decimal).Value = txtProposedInstallment.Text;

            }
            else
            {
                cmd.Parameters.Add("@ProposedInstallmentAmount", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtRevisedInstallment.Text))
            {
                cmd.Parameters.Add("@RevisedInstallmentAmount", SqlDbType.Decimal).Value = txtRevisedInstallment.Text;

            }
            else
            {
                cmd.Parameters.Add("@RevisedInstallmentAmount", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtExistingLCComission.Text))
            {
                cmd.Parameters.Add("@ExistingLC_Comission", SqlDbType.Decimal).Value = txtExistingLCComission.Text;

            }
            else
            {
                cmd.Parameters.Add("@ExistingLC_Comission", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtProposedLCComission.Text))
            {
                cmd.Parameters.Add("@ProposedLC_Comission", SqlDbType.Decimal).Value = txtProposedLCComission.Text;

            }
            else
            {
                cmd.Parameters.Add("@ProposedLC_Comission", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtRevisedLCComission.Text))
            {
                cmd.Parameters.Add("@RevisedLC_Comission", SqlDbType.Decimal).Value = txtRevisedLCComission.Text;

            }
            else
            {
                cmd.Parameters.Add("@RevisedLC_Comission", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }


            if (!string.IsNullOrEmpty(txtExistingAcceptedComission.Text))
            {
                cmd.Parameters.Add("@ExistingAcceptedComision", SqlDbType.Decimal).Value = txtExistingAcceptedComission.Text;

            }
            else
            {
                cmd.Parameters.Add("@ExistingAcceptedComision", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtAcceptedCommisionProposed.Text))
            {
                cmd.Parameters.Add("@proposedAcceptedComision", SqlDbType.Decimal).Value = txtAcceptedCommisionProposed.Text;

            }
            else
            {
                cmd.Parameters.Add("@proposedAcceptedComision", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtAcceptedComissionRevised.Text))
            {
                cmd.Parameters.Add("@RevisedAcceptedComision", SqlDbType.Decimal).Value = txtAcceptedComissionRevised.Text;

            }
            else
            {
                cmd.Parameters.Add("@RevisedAcceptedComision", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }

            if (!string.IsNullOrEmpty(txtProposedDate.Text))
            {
                //cmd.Parameters.Add("@@SanctionDate", SqlDbType.Decimal).Value = txtAcceptedComission2.Text;
                //cmd.Parameters.AddWithValue("@SanctionDate", DateTime.Now.ToString("MM/dd/yyyy"));
                //cmd.Parameters.AddWithValue("@ProposedDate", DateTime.Parse(txtProposedDate.Text).ToString("dd/MM/yyyy"));
                //string s = (DateTime.ParseExact(txtProposedDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("MM/dd/yyyy");

                   cmd.Parameters.AddWithValue("@ProposedDate", (DateTime.ParseExact(txtProposedDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("MM/dd/yyyy"));

                //(DateTime.ParseExact(txtBoxLCA_DATE.Text.Trim(), "dd-MM-yyyy", new CultureInfo("fr-FR", true))).ToString("MM/dd/yyyy")



            }
            else
            {
                //cmd.Parameters.Add("@AcceptedComision2", SqlDbType.Decimal).Value = SqlDecimal.Null;
                //cmd.Parameters.AddWithValue("@SanctionDate", DateTime.Now.ToString("MM/dd/yyyy"));
                cmd.Parameters.Add("@ProposedDate", SqlDbType.Date).Value = SqlDateTime.Null;

            }
            




            if (!string.IsNullOrEmpty(txtSanctionDate.Text))
                                    {
                                        //cmd.Parameters.Add("@@SanctionDate", SqlDbType.Decimal).Value = txtAcceptedComission2.Text;
                            //cmd.Parameters.AddWithValue("@SanctionDate", DateTime.Now.ToString("MM/dd/yyyy"));
                                        //cmd.Parameters.AddWithValue("@SanctionDate", DateTime.Parse(txtSanctionDate.Text).ToString("dd/MM/yyyy"));

                                        cmd.Parameters.AddWithValue("@SanctionDate", (DateTime.ParseExact(txtProposedDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("MM/dd/yyyy"));

                

                                    }
                                    else
                                    {
                                        //cmd.Parameters.Add("@AcceptedComision2", SqlDbType.Decimal).Value = SqlDecimal.Null;
                                  //cmd.Parameters.AddWithValue("@SanctionDate", DateTime.Now.ToString("MM/dd/yyyy"));
                                        cmd.Parameters.Add("@SanctionDate", SqlDbType.Date).Value = SqlDateTime.Null;

                                    }


            if (!string.IsNullOrEmpty(txtExistingInterestRate.Text))
                                    {
                                        cmd.Parameters.Add("@ExistingInttRate", SqlDbType.Decimal).Value = txtExistingInterestRate.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@ExistingInttRate", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }



            if (!string.IsNullOrEmpty(txtProposedInttRate.Text))
                                    {
                                        cmd.Parameters.Add("@ProposedInttRate", SqlDbType.Decimal).Value = txtProposedInttRate.Text;

                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@ProposedInttRate", SqlDbType.Decimal).Value = SqlDecimal.Null;


                                    }


            if (!string.IsNullOrEmpty(txtRevisedInttRate.Text))
            {
                cmd.Parameters.Add("@RevisedInttRate", SqlDbType.Decimal).Value = txtRevisedInttRate.Text;

            }
            else
            {
                cmd.Parameters.Add("@RevisedInttRate", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }


            if (!string.IsNullOrEmpty(txtExistingGracePriod.Text))
            {
                cmd.Parameters.Add("@ExixtingGrascePriod", SqlDbType.Decimal).Value = txtExistingGracePriod.Text;

            }
            else
            {
                cmd.Parameters.Add("@ExixtingGrascePriod", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }


            if (!string.IsNullOrEmpty(txtProposedGracePreiod.Text))
            {
                cmd.Parameters.Add("@ProposedGrascePriod", SqlDbType.Decimal).Value = txtProposedGracePreiod.Text;

            }
            else
            {
                cmd.Parameters.Add("@ProposedGrascePriod", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }


            if (!string.IsNullOrEmpty(txtRevisedGracePreiod.Text))
            {
                cmd.Parameters.Add("@RevisedGrascePriod", SqlDbType.Decimal).Value = txtRevisedGracePreiod.Text;

            }
            else
            {
                cmd.Parameters.Add("@RevisedGrascePriod", SqlDbType.Decimal).Value = SqlDecimal.Null;


            }






            cmd.Parameters.AddWithValue("@Margin", txtMargin.Text);
            cmd.Parameters.AddWithValue("@Status", DropStatus.Text);
            cmd.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd.Parameters.AddWithValue("@Cdate", DateTime.Now.ToString("yyyy-MM-dd"));



            if (!string.IsNullOrEmpty(txtSanctionDate.Text))
            {
                cmd.Parameters.AddWithValue("@ValidityDate", (DateTime.ParseExact(txtvalidityDate.Text.Trim(), "dd/MM/yyyy", new CultureInfo("fr-FR", true))).ToString("MM/dd/yyyy"));
            }
            else
            {
                cmd.Parameters.Add("@ValidityDate", SqlDbType.Date).Value = SqlDateTime.Null;

            }

            
            
            
            
            
            
            
            
            ////////////

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

                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Data Saved successfully, Receive document for final  the submission')", true);

                  



                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Data updated Successfully')", true);
                    //txtAccount.Enabled = true;
                    //txtAccount.Text = "";
                    //drpLoanType.Enabled = true;
                    //btnSearch.Enabled = true;
                    //btnNewLoan.Enabled = true;
                    //Button1.Enabled = true;
                    //elm1.Value = "";
                    //Button1.Enabled = false;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Data Can not Save')", true);
                //Button1.Enabled = true;
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {


        ReturnVal oRtnValue = new ReturnVal();
        //string BrCode = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "BranchCode");

        if (oRtnValue.ReturnValue("LoanAplicationFinancial", "AcountNo", "'" + txtAplication.Text + "' and sub_Sl ='" + txtPlSL.Text + "'", "AcountNo") != "")
        {

            ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
            SqlConnection con;
            SqlCommand cmd;
            string condition = "Where AcountNo='" + txtAplication.Text + "' and sub_Sl ='"+txtPlSL.Text+"'";
            con = oConnectionDatabase.DatabaseConnection();
            cmd = new SqlCommand("SELECT *  from LoanAplicationFinancial  " + condition, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch { }
            con.Close();


            DrpType.Text = dt.Rows[0]["Type"].ToString();
            DropNature.Text = dt.Rows[0]["Nature"].ToString();
            txtExistingLimmit.Text = dt.Rows[0]["ExistingLimitAmount"].ToString();

            txtProposedLimit.Text = dt.Rows[0]["ProposedLimit"].ToString();

            txtRevisedLimit.Text = dt.Rows[0]["RevisedLimit"].ToString();


            txtOutStanding.Text = dt.Rows[0]["Outstanding"].ToString();

            txtOverDeu.Text = dt.Rows[0]["OverDue"].ToString();

            txtEOL.Text = dt.Rows[0]["EOL"].ToString();
            txtExistingSanction.Text = dt.Rows[0]["ExistingSanction"].ToString();

            txtSanctionAmount.Text = dt.Rows[0]["ProposedSanction"].ToString();

            txtRevisedSanction.Text = dt.Rows[0]["RevisedSanction"].ToString();

            txtexixtingTenor.Text = dt.Rows[0]["ExistingTenor"].ToString();

            txtProposedTenor.Text = dt.Rows[0]["ProposedTenor"].ToString();

            txtTenorRevised.Text = dt.Rows[0]["RevisedTenor"].ToString();

            txtExixtingInstallmentAmount.Text = dt.Rows[0]["ExistingInstallmentAmount"].ToString();

            txtProposedInstallment.Text = dt.Rows[0]["ProposedInstallmentAmount"].ToString();

            txtRevisedInstallment.Text = dt.Rows[0]["RevisedInstallmentAmount"].ToString();

            txtExistingLCComission.Text = dt.Rows[0]["ExistingLC_Comission"].ToString();

            txtProposedLCComission.Text = dt.Rows[0]["ProposedLC_Comission"].ToString();

            txtRevisedLCComission.Text = dt.Rows[0]["RevisedLC_Comission"].ToString();

            txtExistingAcceptedComission.Text = dt.Rows[0]["ExistingAcceptedComision"].ToString();

            txtAcceptedCommisionProposed.Text = dt.Rows[0]["proposedAcceptedComision"].ToString();

            txtAcceptedComissionRevised.Text = dt.Rows[0]["RevisedAcceptedComision"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["SanctionDate"].ToString()))
            {

                txtSanctionDate.Text = DateTime.Parse(dt.Rows[0]["SanctionDate"].ToString()).ToString("dd/MM/yyyy");
            }

            if (!string.IsNullOrEmpty(dt.Rows[0]["ProposedDate"].ToString()))
            {

                txtProposedDate.Text = DateTime.Parse(dt.Rows[0]["SanctionDate"].ToString()).ToString("dd/MM/yyyy");
            }




            txtExistingInterestRate.Text = dt.Rows[0]["ExistingInttRate"].ToString();

            txtProposedInttRate.Text = dt.Rows[0]["ProposedInttRate"].ToString();

            txtRevisedInttRate.Text = dt.Rows[0]["RevisedInttRate"].ToString();

            txtExistingGracePriod.Text = dt.Rows[0]["ExixtingGrascePriod"].ToString();
            txtProposedGracePreiod.Text = dt.Rows[0]["ProposedGrascePriod"].ToString();
            txtRevisedGracePreiod.Text = dt.Rows[0]["RevisedGrascePriod"].ToString();

            DropStatus.Text = dt.Rows[0]["Status"].ToString();
            txtMargin.Text = dt.Rows[0]["Margin"].ToString();

            if (!string.IsNullOrEmpty(dt.Rows[0]["ValidityDate"].ToString()))
            {
                txtvalidityDate.Text = DateTime.Parse(dt.Rows[0]["ValidityDate"].ToString()).ToString("dd/MM/yyyy");
            }


            if (!string.IsNullOrEmpty(dt.Rows[0]["GroupSL"].ToString()))
            {

                YrChkBox.Checked = true;
                Group.Visible = true;
                SubGroup.Visible = true;


                drpGroup.SelectedValue = dt.Rows[0]["GroupSL"].ToString();
                LoadSubGroup(1, drpGroup.SelectedValue);
              
                if (!string.IsNullOrEmpty(dt.Rows[0]["SubGroupSL"].ToString()))
                {
                    DropSubGroup.SelectedValue = dt.Rows[0]["SubGroupSL"].ToString();
                   
                    //ReturnVal oRtnValue1 = new ReturnVal();
                    //DropSubGroup.Text = oRtnValue.ReturnValue("SubGroupInfo", "SubgroupSL", "'" + dt.Rows[0]["SubGroupSL"].ToString() + "'", "SubGroupName");
                }
            }
            else
            {
                YrChkBox.Checked = false;
                Group.Visible = false;
                SubGroup.Visible = false;
            }




        }
        else
        {

            //txtPlSL.Text = "";
            DrpType.Text = "";
            DropNature.Text = "";
            txtExistingLimmit.Text = "";
            txtProposedLimit.Text = "";
            txtRevisedLimit.Text = "";
            txtTenorRevised.Text = "";
            txtOutStanding.Text = "";
            txtOverDeu.Text = "";
            txtEOL.Text = "";
            txtExistingSanction.Text = "";
            txtSanctionAmount.Text = "";
            txtRevisedSanction.Text = "";
            txtexixtingTenor.Text = "";
            txtProposedTenor.Text = "";
            txtTenorRevised.Text = "";
            txtExixtingInstallmentAmount.Text="";
            txtProposedInstallment.Text = "";
            txtRevisedInstallment.Text = "";
            txtExistingLCComission.Text = "";
            txtProposedLCComission.Text = "";
            txtRevisedLCComission.Text = "";
            txtExistingAcceptedComission.Text = "";
            txtAcceptedCommisionProposed.Text = "";
            txtAcceptedComissionRevised.Text = "";

            txtSanctionDate.Text = "";
            txtProposedDate.Text = "";
            txtExistingInterestRate.Text = "";
            txtProposedInttRate.Text = "";
            txtRevisedInttRate.Text = "";
            txtExistingGracePriod.Text = "";
            txtProposedGracePreiod.Text = "";
            txtRevisedGracePreiod.Text="";
            DropStatus.Text = "";
            txtMargin.Text = "";
            txtvalidityDate.Text = "";

           
        
        }

    }
    protected void txtAplication_TextChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
  

    public void LoadGroup(int a, string code)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = dbconnection.connection();
        //string quiry = "select code from program where Code <>'" + code + "'  order by code";

        string quiry = "SELECT GroupSL, GroupName FROM (SELECT TOP (200) GroupSL,GroupName FROM GroupInfo ORDER BY (GroupName)) AS GroupInfo UNION ALL SELECT 9999 AS Exp1, 'Others' AS Exp2  ";



        SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
        dt.Fill(ds);
        drpGroup.DataSource = ds;
        drpGroup.DataTextField = "GroupName";
        drpGroup.DataValueField ="GroupSL";
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

        string quiry = "Select SubGroupSL,SubGroupName from  (Select top(100) SubGroupSL,SubGroupName  from SubGroupInfo where GroupSL='" + code + "' order by (SubGroupName)) as SubGroupInfo  union ALL  Select  9999 as exp1,'Others' as exp2 ";

        SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
        dt.Fill(ds);
        DropSubGroup.DataSource = ds;
        DropSubGroup.DataTextField = "SubGroupName";
        DropSubGroup.DataValueField = "SubGroupSL";
        DropSubGroup.DataBind();

        if (a == 1)
        {
            DropSubGroup.Items.Insert(0, "--Select--");
        }
    }
    protected void drpGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (drpGroup.SelectedValue=="9999")
        {
            txtGroupName.Visible = true;
            btnGroup.Visible = true;
            txtSubGroupName.Visible = true;
            btnSubGroup.Visible = true;

        }
        else
        {

            if (drpGroup.SelectedValue != "9999")
            {
                txtGroupName.Visible = false;
                btnGroup.Visible = false;
                txtSubGroupName.Visible = false;
                btnSubGroup.Visible = false;

                if (drpGroup.SelectedValue != "--Select--")
                {


                    LoadSubGroup(1, drpGroup.SelectedValue);
                }
                else
                {
                    DropSubGroup.ClearSelection();
                }
            }
        }
    }
    protected void DropSubGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropSubGroup.SelectedValue == "9999")
       
        {
           
            txtSubGroupName.Visible = true;
            btnSubGroup.Visible = true;
        }
    }
    protected void btnGroup_Click(object sender, EventArgs e)
    {
        SqlConnection conn = dbconnection.connection();
        SqlCommand objcmd = new SqlCommand("insert into GroupInfo (GroupName) values ('" + txtGroupName.Text + "')", conn);

        objcmd.ExecuteNonQuery();
        conn.Close();
        LoadGroup(1, "");
    }
    protected void btnSubGroup_Click(object sender, EventArgs e)
    {
        SqlConnection conn = dbconnection.connection();
        SqlCommand objcmd = new SqlCommand("insert into SubGroupInfo (GroupSL,subGroupName) values ('" + drpGroup.SelectedValue + "','" + txtSubGroupName.Text + "')", conn);

        objcmd.ExecuteNonQuery();
        conn.Close();

        LoadSubGroup(1, drpGroup.SelectedValue);
    }
  
    protected void YrChkBox_CheckedChanged(object sender, EventArgs e)
    {
        if (YrChkBox.Checked==true)
   {
        Group.Visible=true;
        SubGroup.Visible = true;
   }
        else
   {
       Group.Visible = false;
       SubGroup.Visible = false;
   
   }
    }
    protected void txtPlSL_TextChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
}