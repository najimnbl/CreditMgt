/* 
 Author: Ferdous Hossain
 Opearation:  User Creation . 
 create date:   21.02.2015 to 23.02.2015 
 Version:01
  */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserInfo : System.Web.UI.Page
{
    UserInfoEntity oUserInfoEntity = new UserInfoEntity();
    UserInfoDAO oUserInfoDAO = new UserInfoDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            LoadDropDownList();
            gridViewBind();

        }
    }

    private void gridViewBind()
    {
        
        string condition = " order by ID desc";
        DataTable dt =oUserInfoDAO.GetUserInfo(condition);

        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit)
        {
            e.Row.Cells[0].Controls[0].Visible = false;
        }
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        GridView1.EditIndex = -1;
        gridViewBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView1.EditIndex = -1;
        gridViewBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //GridView1.EditIndex = -1;
        GridView1.EditIndex = e.NewEditIndex;
        gridViewBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    { oUserInfoEntity.ID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value.ToString());
     int i = oUserInfoDAO.DeleteUserInfo(oUserInfoEntity);

        GridView1.EditIndex = -1;


        string message = "";
        if (i == 1)
        {
            message = "Data Deleted Successfully";
        }
        else
            message = "Data Not Deleted!";

        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('" + message + "')", true);
        gridViewBind();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gridViewBind();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView1.EditIndex = -1;
        gridViewBind();


    }

    private void LoadDropDownList()
    {
        DataTable dt =oUserInfoDAO.GetEmployeeInfo("");
        if (dt.Rows.Count > 0)
        {
            userNameDropDownList.DataSource = dt;
            userNameDropDownList.DataTextField = "EnameWithID";
            userNameDropDownList.DataValueField = "EmployeeID";
            userNameDropDownList.DataBind();
        }


       
    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (userNameDropDownList.SelectedValue == "" || userNameDropDownList.SelectedValue == null)
            return;
        oUserInfoEntity.UserID = userIdTextBox.Text;
        oUserInfoEntity.UserType = userTypeDropDownList.SelectedValue;
        oUserInfoEntity.Password = passwordTextBox.Text;
        oUserInfoEntity.ConfirmPassword = confirmPasswordTextBox.Text;
        oUserInfoEntity.Active = activeCheckBox.Checked;
        oUserInfoEntity.EmployeeID = userNameDropDownList.SelectedValue;
        oUserInfoEntity.CreateBy = DateTime.Now.ToShortDateString();
        oUserInfoEntity.LastModifiedBy = DateTime.Now.ToShortDateString();
        

         string message = "";
         if (oUserInfoEntity.Password != oUserInfoEntity.ConfirmPassword) {
             message = "Password and confirmed password are not same";
             ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('" + message + "')", true); return; }

        if (saveButton.Text == "Update")
        {
            if (Session["ID"] != null)
            {
                oUserInfoEntity.ID = Convert.ToInt16(Session["ID"]);
                int i = oUserInfoDAO.UpdateUserInfo(oUserInfoEntity);

                if (i == 1)
                {
                    message = "User Updated Successfully";

                    Clear();
                }
                else
                    message = "User Not Updated!";
            }
        }
        else
        {
            string condition = " where userId='" + oUserInfoEntity.UserID + "'";
            DataTable dt = oUserInfoDAO.GetUserInfo(condition);
            if (dt.Rows.Count > 0)
            {
                message = "User Id already in Database";
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('" + message + "')", true); return;
            }
            int i = oUserInfoDAO.InsertUserInfo(oUserInfoEntity);

            if (i == 1)
            {  MenuAndSubMenuDAO oMenuAndSubMenuDAO=new MenuAndSubMenuDAO();
                dt = oMenuAndSubMenuDAO.GetSubMenu("");
                UserAssignRightDAO oUserAssignRightDAO=new UserAssignRightDAO();
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    UserAssignRightEntity oUserAssignRightEntity = new UserAssignRightEntity();
                    oUserAssignRightEntity.UserID = oUserInfoEntity.UserID;
                    oUserAssignRightEntity.MenuNo=dt.Rows[k]["MenuNo"].ToString();
                    oUserAssignRightEntity.SubMenuNo=dt.Rows[k]["SubMenuNo"].ToString();
                    oUserAssignRightEntity.MenuRights=false;
                    oUserAssignRightEntity.SubMenuRights = false;
                    oUserAssignRightEntity.CreateBy = DateTime.Now.ToShortDateString();
                    oUserAssignRightEntity.LastModifiedBy = DateTime.Now.ToShortDateString();
                    int n = oUserAssignRightDAO.InsertUserAssignRight(oUserAssignRightEntity);
                }
                    message = "User Created Successfully";

                Clear();
            }
            else
                message = "User Not Created!";
        }



        gridViewBind();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('" + message + "')", true);
    }

    private void Clear()
    {
        userIdTextBox.Text = "";
        passwordTextBox.Text = "";
        confirmPasswordTextBox.Text = "";
        saveButton.Text = "Save";
     


    }
    protected void newButton_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            int index = row.RowIndex; //gets the row index selected
            int id = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());
            //grab the values here
            //string myVariable = row.Cells[1].Text;
            string condition = " where tblUserInfo.ID='" + id + "'";
            //DataTable dt = oCustomerDAO.GetCustomer(condition);
            DataTable dt =oUserInfoDAO.GetUserInfo(condition);

            if (dt.Rows.Count > 0)
            {
                userIdTextBox.Text = dt.Rows[0]["UserID"].ToString(); ;
                passwordTextBox.Text = dt.Rows[0]["Password"].ToString(); ;
                confirmPasswordTextBox.Text = dt.Rows[0]["ConfirmPassword"].ToString(); 
                activeCheckBox.Checked = Convert.ToBoolean(dt.Rows[0]["Active"]);
                userNameDropDownList.SelectedValue = dt.Rows[0]["EmployeeID"].ToString();
                userTypeDropDownList.SelectedValue = dt.Rows[0]["UserType"].ToString(); 
             
                  


                Session["ID"] = id;

                saveButton.Text = "Update";
            }


        }
    }

    protected void userTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}