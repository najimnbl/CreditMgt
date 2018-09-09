/* 
 Author: Ferdous Hossain
 Opearation:  Aplication aspecific conted are seach here . 
 create date:   14.02.2015 to 16.02.2015 
 Version:01
  */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class SearchContant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridLoad();
    }

    public void GridLoad()
    {
        //string BrName;
        //if (drpbranch.SelectedItem.Text == "--ALL--")
        //{
        //    BrName = "%";
        //}
        //else
        //{
        //    BrName = drpbranch.SelectedItem.Text;
        //}
        //string status;
        //if (Rstaus.SelectedItem.Text == "--ALL--")
        //{
        //    status = "%";
        //}
        //else
        //{
        //    status = Rstaus.SelectedItem.Text;
        //}


        SqlConnection conn = dbconnection.connection();


        SqlCommand objcmd = new SqlCommand("select AcountNo,BranchName,EmployeeName,Designation,CreationDate from  View_AdvanchSearch where HTML like '%" + txtAccount.Text + "%'   ORDER BY AcountNo Desc  ", conn);

        GridView1.DataSource = objcmd.ExecuteReader();

        GridView1.DataBind();
        GridView1.EditIndex = -1;


    }
}