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

public partial class AplicationFinancialInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridLoad();

        }
    }

   
    public void GridLoad()
    {
        


        SqlConnection conn = dbconnection.connection();

        string sub_Sl1;
        if (txtPlSL.Text=="")
        {
            sub_Sl1 = "%";
        }
        else
        {
            sub_Sl1 = txtPlSL.Text;

        }


        if (CheckBox1.Checked==true)
        {
            SqlCommand objcmd = new SqlCommand("select * from  LoanAplicationFinancialHis where AcountNo = '" + txtAplication.Text + "' and sub_Sl like'" + sub_Sl1 + "'  ORDER BY Cdate Desc  ", conn);
        GridView1.DataSource = objcmd.ExecuteReader();
        }
        else
        {
            SqlCommand objcmd = new SqlCommand("select * from  LoanAplicationFinancial where AcountNo = '" + txtAplication.Text + "' and sub_Sl like'" + sub_Sl1 + "'  ORDER BY Cdate Desc  ", conn);
          GridView1.DataSource = objcmd.ExecuteReader();
        }
       
        GridView1.DataBind();
        GridView1.EditIndex = -1;
       


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridLoad();
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int row = Convert.ToInt32(GridView1.Rows[int.Parse(e.RowIndex.ToString())].RowIndex);
        string Asad = GridView1.Rows[row].Cells[1].Text;
        //Session["Aplication"] = Asad;
        //Server.Transfer("LoanAplication.aspx");
    }



    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
     

    }
}