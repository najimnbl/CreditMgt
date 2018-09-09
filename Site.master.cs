using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SiteMaster : System.Web.UI.MasterPage
{   UserAssignRightDAO oUserAssignRightDAO=new UserAssignRightDAO();
    UserInfoDAO oUserInfoDAO = new UserInfoDAO();
    protected void Page_Load(object sender, EventArgs e)
{



    if (Session["user"] != null)
    {

        ReturnVal oRtnValue = new ReturnVal();
        string BranchName = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "BranchName");
        string EmployeeName = oRtnValue.ReturnValue("View_BranchInfo", "userid", "'" + Session["userID"] + "'", "EmployeeName");





        Label1.Text = "Branch/Division: " + BranchName;
        //Label1.Text =  BranchName;
        Label2.Text = "User Name: " + EmployeeName;


        Label1.Font.Bold = true;
        Label1.Font.Italic = false;
        Label1.Font.Name = "verdana";
        Label1.Font.Overline = false;
        Label1.Font.Size = 10;
        Label1.Font.Strikeout = false;
        Label1.Font.Underline = false;


        Label2.Font.Name = "verdana";


       
    }
        
        
        
        
        
        
        
     if (Session["user"] == null)
    {

        Server.Transfer("WebLogin.aspx");
    
    }

    if (!IsPostBack)
    {
        string condition = " where userID='" + Session["user"].ToString() + "'";
        DataTable dt = oUserInfoDAO.GetUserInfo(condition);
        string userType = "";
        if (dt.Rows.Count > 0)
        {
            userType = dt.Rows[0]["UserType"].ToString();
            if (userType != "Admin") 
            {
                condition = " where userID='" + Session["user"].ToString() + "'";
                DataTable dt1 = oUserAssignRightDAO.GetUserAssignRight(condition);
                SubMenuEntity oMenu = new SubMenuEntity();
                for (int k = 0; k < NavigationMenu.Items.Count; k++)
                {
                    if (NavigationMenu.Items[k].Text == "Admin")
                    {
                        NavigationMenu.Items[k].Enabled = false;

                    }
                    foreach (MenuItem item in NavigationMenu.Items[k].ChildItems)
                    {
                        
                        // Display the menu items.
                        DisplayChildMenuText(item, dt1);

                    }
                }
            }
        }
       
        
    }
    }
    void DisplayChildMenuText(MenuItem item,DataTable dt)
    {

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (item.Text == dt.Rows[i]["SubMenuName"].ToString())
            {
                item.Enabled = Convert.ToBoolean(dt.Rows[i]["SubMenuRights"]);
            }
        }
            foreach (MenuItem childItem in item.ChildItems)
            {

                DisplayChildMenuText(childItem, dt);

            }

    }
}
