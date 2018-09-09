/* 
 Author: Ferdous Hossain
 Opearation:Submitted  Aplication modified histry are shown  using this page . 
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

public partial class LoanAplicationModifiedHistory : System.Web.UI.Page
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
       SqlCommand objcmd = new SqlCommand("select * from  View_LoanAplicationHistory where AplicationNo = '" + txtAplication.Text + "'  ORDER BY [Create/Update] Desc  ", conn);
        GridView1.DataSource = objcmd.ExecuteReader();
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

      
        Session["Aplication"] = Asad;
        Server.Transfer("LoanAplication.aspx");



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