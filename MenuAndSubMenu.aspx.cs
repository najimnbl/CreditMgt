/* 
 Author: Ferdous Hossain
 Opearation:  Menu Submenu Control here
 create date:   11.02.2015 to 14.02.2015 
 Version:01
  */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MenuAndSubMenu : System.Web.UI.Page
{
    List<SubMenuEntity> oSubMenuList = new List<SubMenuEntity>();
    int k = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDropDownList();
            gridViewBind();
        }

    }

    private void loadDropDownList()
    {
        Menu NavigationMenu = (Menu)this.Master.FindControl("NavigationMenu");
        int count = NavigationMenu.Items.Count;

        List<MenuEntity> oMenuList = new List<MenuEntity>();
        MenuEntity oMenu = new MenuEntity();
        for (int i = 0; i < count; i++)
        {
            oMenu = new MenuEntity();
            oMenu.MenuNo = (i).ToString();
            oMenu.MenuName = NavigationMenu.Items[i].Text;
            oMenuList.Add(oMenu);
        }
        menuItemDropDownList.DataSource = oMenuList;
        menuItemDropDownList.DataTextField = "MenuName";
        menuItemDropDownList.DataValueField = "MenuNo";
        menuItemDropDownList.DataBind();
    }
    protected void menuItemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        gridViewBind();
    }

    private void gridViewBind()
    {
       Menu NavigationMenu = (Menu)this.Master.FindControl("NavigationMenu");
       MenuItem NavigationMenu1 = NavigationMenu.Items[Convert.ToInt16(menuItemDropDownList.SelectedValue)];
        //(MenuItem)NavigationMenu.Items[Convert.ToInt16(menuItemDropDownList.SelectedValue)].ChildItems;
        //List<SubMenuEntity> oSubMenuList = new List<SubMenuEntity>();
        SubMenuEntity oMenu = new SubMenuEntity();
        foreach (MenuItem item in NavigationMenu1.ChildItems)
        {

            // Display the menu items.
            DisplayChildMenuText(item);

        }
        //for (int i = 0; i < count; i++)
        //{
        //    oMenu = new SubMenuEntity();
        //    oMenu.MenuNo = menuItemDropDownList.SelectedValue;
        //    oMenu.SubMenuNo = i.ToString();
        //    oMenu.SubMenuName = NavigationMenu.Items[Convert.ToInt16(menuItemDropDownList.SelectedValue)].ChildItems[i].Text;
        //    oMenuList.Add(oMenu);
        //}
        GridView1.DataSource = oSubMenuList;
        GridView1.DataBind();
    }
    void DisplayChildMenuText(MenuItem item)
    {
        
        
        SubMenuEntity oMenu = new SubMenuEntity();
        oMenu.SubMenuName = item.Text;
        oMenu.SubMenuNo = (k++).ToString();
        oMenu.MenuNo = menuItemDropDownList.SelectedValue;
        oSubMenuList.Add(oMenu);
        foreach (MenuItem childItem in item.ChildItems)
        {
                    
            DisplayChildMenuText(childItem);

        }

    }
    protected void addButton_Click(object sender, EventArgs e)
    {
        MenuAndSubMenuDAO oMenuAndSubMenuDAO = new MenuAndSubMenuDAO();

        for (int i = 0; i < menuItemDropDownList.Items.Count; i++)
        {
            MenuEntity oMenuEntity = new MenuEntity();
            string condition = " where MenuNo='" + menuItemDropDownList.Items[i].Value + "'";
            DataTable dt = oMenuAndSubMenuDAO.GetMenu(condition);
            oMenuEntity.MenuNo = menuItemDropDownList.Items[i].Value;
            oMenuEntity.MenuName = menuItemDropDownList.Items[i].Text;
            oMenuEntity.CreateBy = DateTime.Now.ToShortDateString();
            oMenuEntity.LastModifiedBy = DateTime.Now.ToShortDateString();
         
            if (dt.Rows.Count > 0)
            {
                int j = oMenuAndSubMenuDAO.DeleteMenu(oMenuEntity);
            }
            else
            {
                int j = oMenuAndSubMenuDAO.InsertMenu(oMenuEntity);
            }

        }
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            SubMenuEntity oSubMenuEntity = new SubMenuEntity();
            //oSubMenuEntity.ID =Convert.ToInt16(((Label)GridView1.Rows[i].FindControl("idLabel")).Text);
            oSubMenuEntity.SubMenuNo = ((Label)GridView1.Rows[i].FindControl("SubMenuNoLabel")).Text;
            oSubMenuEntity.SubMenuName = ((Label)GridView1.Rows[i].FindControl("SubMenuNameLabel")).Text;
            oSubMenuEntity.MenuNo = ((Label)GridView1.Rows[i].FindControl("MenuNoLabel")).Text;
            oSubMenuEntity.CreateBy = DateTime.Now.ToShortDateString();
            oSubMenuEntity.LastModifiedBy = DateTime.Now.ToShortDateString();
            string condition = " where SubMenuNo='" + oSubMenuEntity.SubMenuNo + "' and MenuNo='" + oSubMenuEntity.MenuNo + "'";
            DataTable dt = oMenuAndSubMenuDAO.GetSubMenu(condition);
          
            if (dt.Rows.Count > 0)
            {
                int j = oMenuAndSubMenuDAO.DeleteSubMenu(oSubMenuEntity);
            }
            else
            {
                int j = oMenuAndSubMenuDAO.InsertSubMenu(oSubMenuEntity);
            }

        }
    }
}