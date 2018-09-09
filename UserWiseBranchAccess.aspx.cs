/* 
 Author: Ferdous Hossain
 Opearation:  User wise Branch access assin here. 
 create date:   24.02.2015 to 28.02.2015 
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

public partial class UserWiseBranchAccess : System.Web.UI.Page
{

    UserInfoEntity oUserInfoEntity = new UserInfoEntity();
    UserInfoDAO oUserInfoDAO = new UserInfoDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDropDownList();
            //LoadBranch(1, "");
            BtnLoad_Click(sender, e);
        }
    }
   protected void BtnRight_Click(object sender, EventArgs e)
{
    MoveItems(lstLeft,lstRight,false);
}
 
protected void BtnLeft_Click(object sender, EventArgs e)
{
    MoveItems(lstRight, lstLeft,false);
}
 
protected void BtnRightAll_Click(object sender, EventArgs e)
{
    MoveItems(lstLeft, lstRight, true);
}
 
protected void BtnLeftAll_Click(object sender, EventArgs e)
{
    MoveItems(lstRight, lstLeft, true);
}
 
private void MoveItems(ListBox leftListBox, ListBox RightListBox,bool bAll)
{
    ListItemCollection oCollection = new ListItemCollection();
    foreach (ListItem oItem in leftListBox.Items)
        //if (oItem.Selected || bAll)

        if (oItem.Selected || bAll)
       
        
        {
            RightListBox.Items.Add(oItem);
            oCollection.Add(oItem);
        }
    foreach (ListItem oItem in oCollection)
        leftListBox.Items.Remove(oItem);
}


protected void btnSubmit_Click(object sender, EventArgs e)
{
    //Label1.Text = "Left ListBox Items:<br/>";
    //foreach (ListItem oItem in lstLeft.Items)
    //    Label1.Text = Label1.Text + oItem.Text + "<br/>";

    //Label2.Text = "Right ListBox Items:<br/>";


    SqlConnection conn = dbconnection.connection();
    SqlCommand objcmd1 = new SqlCommand("Delete  from  UserWiseBranchAccess  where userid = '" + userDropDownList.Text + "'", conn);

    objcmd1.ExecuteNonQuery();
    //conn.Close();

    foreach (ListItem oItem in lstRight.Items)
    {
        //Label2.Text = Label2.Text + oItem.Value + "<br/>";

        string brcode = oItem.Value;
        //SqlConnection conn = dbconnection.connection();


        SqlCommand objcmd = new SqlCommand("insert into UserWiseBranchAccess (UserID,brCode) values ('" + userDropDownList.Text + "','" + brcode + "')", conn);

        objcmd.ExecuteNonQuery();
    }
    conn.Close();


}


public void LoadBranch(int a, string code)
{
    DataSet ds = new DataSet();
    SqlConnection conn = dbconnection.connection();
    //string quiry = "select code from program where Code <>'" + code + "'  order by code";

    string quiry = "Select BrCode,BranchName from BranchInfo where BrCode<190 order by BranchName";



    SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
    dt.Fill(ds);
    lstLeft.DataSource = ds;
    lstLeft.DataTextField = "BranchName";
    lstLeft.DataValueField = "BrCode";
    lstLeft.DataBind();

    //if (a == 1)
    //{
    //    drpBranch.Items.Insert(0, "--Select--");

    //}

}

protected void BtnLoad_Click(object sender, EventArgs e)
{


    DataSet ds = new DataSet();
    SqlConnection conn = dbconnection.connection();
    //string quiry = "select code from program where Code <>'" + code + "'  order by code";

    string quiry = "Select UserWiseBranchAccess.BrCode, (Select BranchName from BranchInfo where BranchInfo.BrCode=UserWiseBranchAccess.BrCode) as BranchName from UserWiseBranchAccess where  UserWiseBranchAccess.userid = '" + userDropDownList.Text + "' order by BranchName ";
    SqlDataAdapter dt = new SqlDataAdapter(quiry, conn);
    dt.Fill(ds);
    lstRight.DataSource = ds;
    lstRight.DataTextField = "BranchName";
    lstRight.DataValueField = "BrCode";
    lstRight.DataBind();




    DataSet ds1 = new DataSet();
    //SqlConnection conn = dbconnection.connection();
    //string quiry = "select code from program where Code <>'" + code + "'  order by code";

    string quiry1 = "Select BrCode,BranchName from BranchInfo where BrCode not in ( Select BrCode from   UserWiseBranchAccess where userid  = '" + userDropDownList.Text + "' ) and BrCode <190 order by BranchName";



    SqlDataAdapter dt1 = new SqlDataAdapter(quiry1, conn);
    dt1.Fill(ds1);
    lstLeft.DataSource = ds1;
    lstLeft.DataTextField = "BranchName";
    lstLeft.DataValueField = "BrCode";
    lstLeft.DataBind();



}

private void loadDropDownList()
{
    string condition = " where tblUserInfo.UserType<>'Admin' and tblUserInfo.Active='true'";
    DataTable dt = oUserInfoDAO.GetUserInfo(condition);
    if (dt.Rows.Count > 0)
    {
        userDropDownList.DataSource = dt;
        userDropDownList.DataTextField = "UserID";
        userDropDownList.DataValueField = "UserID";
        userDropDownList.DataBind();
    }
}




protected void userDropDownList_SelectedIndexChanged(object sender, EventArgs e)
{
    BtnLoad_Click(sender,e);
}


protected void userDropDownList_TextChanged(object sender, EventArgs e)
{

}
}