/* 
 Author: Ferdous Hossain
 Opearation:  User wise menu submenu access . 
 create date:   18.02.2015 to 20.02.2015 
 Version:01
  */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserAssignRights : System.Web.UI.Page
{
    UserInfoDAO oUserInfoDAO = new UserInfoDAO();
    MenuAndSubMenuDAO oMenuAndSubMenuDAO = new MenuAndSubMenuDAO();
    UserAssignRightDAO oUserAssignRightDAO = new UserAssignRightDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDropDownList();
            gridViewBind();
        }
    }

    private void gridViewBind()
    {
        string condition = " where tblUserAssignRights.MenuNo='" + menuItemDropDownList.SelectedValue + "' and UserID='" + userDropDownList.SelectedValue + "'";
        DataTable dt = oUserAssignRightDAO.GetUserAssignRight(condition);
        GridView1.DataSource = dt;
        GridView1.DataBind();
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
        condition = " where MenuName<>'Admin'";
        dt = new DataTable();
        dt = oMenuAndSubMenuDAO.GetMenu(condition);
        if (dt.Rows.Count > 0)
        {
            menuItemDropDownList.DataSource = dt;
            menuItemDropDownList.DataTextField = "MenuName";
            menuItemDropDownList.DataValueField = "MenuNo";
            menuItemDropDownList.DataBind();
        }

    }
    protected void assignRightButton_Click(object sender, EventArgs e)
    {
        if (userDropDownList.SelectedValue == "" || userDropDownList.SelectedValue == null)
            return;
        if (menuItemDropDownList.SelectedValue == "" || menuItemDropDownList.SelectedValue == null)
            return;
        for (int k = 0; k <GridView1.Rows.Count; k++)
        {
            UserAssignRightEntity oUserAssignRightEntity = new UserAssignRightEntity();
            oUserAssignRightEntity.UserID =userDropDownList.SelectedValue;
            oUserAssignRightEntity.MenuNo = menuItemDropDownList.SelectedValue;
            oUserAssignRightEntity.SubMenuNo = ((Label)GridView1.Rows[k].FindControl("SubMenuNoLabel")).Text;
            oUserAssignRightEntity.MenuRights =true;
            if (allCheckBox.Checked == true)
            {
                oUserAssignRightEntity.SubMenuRights = true;
            }
            else
            {
                if (((CheckBox)GridView1.Rows[k].FindControl("CheckBox1")).Checked)
                {
                    oUserAssignRightEntity.SubMenuRights = true;
                }
                else
                {
                    oUserAssignRightEntity.SubMenuRights =false;
                }
            }
            oUserAssignRightEntity.CreateBy = DateTime.Now.ToShortDateString();
            oUserAssignRightEntity.LastModifiedBy = DateTime.Now.ToShortDateString();
            int n = oUserAssignRightDAO.UpdateUserAssignRight(oUserAssignRightEntity);
        }
        gridViewBind();

    }
    protected void menuItemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridViewBind();
    }
    protected void userDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridViewBind();
    }
}