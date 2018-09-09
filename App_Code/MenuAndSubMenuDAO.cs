using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MenuAndSubMenuDAO
/// </summary>
public class MenuAndSubMenuDAO
{
	public MenuAndSubMenuDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;


   
    #region Munu
    public int InsertMenu(MenuEntity oMenuEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();
        
        ////try { con.Open(); }
        ////catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblMenuItem (MenuNo,MenuName,CreateBy,LastModifiedBy) VALUES(@MenuNo,@MenuName,@CreateBy,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@MenuNo", SqlDbType.VarChar).Value = oMenuEntity.MenuNo;
        cmd.Parameters.AddWithValue("@MenuName", SqlDbType.Image).Value = oMenuEntity.MenuName;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.VarChar).Value = oMenuEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.Image).Value = oMenuEntity.LastModifiedBy;
       
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
        catch { }
        con.Close();
        return i;
    }
    public DataTable GetMenu(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        //try { con.Open(); }
        //catch { }
        cmd = new SqlCommand("SELECT  * FROM  tblMenuItem" + condition, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
        }
        catch { }
        con.Close();
        return dt;
    }
    public int UpdateMenu(MenuEntity oMenuEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblMenuItem SET MenuName=@MenuName,LastModifiedBy=@LastModifiedBy where MenuNo=@MenuNo", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@MenuNo", SqlDbType.VarChar).Value = oMenuEntity.MenuNo;
        cmd.Parameters.AddWithValue("@MenuName", SqlDbType.Image).Value = oMenuEntity.MenuName;
     
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.Image).Value = oMenuEntity.LastModifiedBy;
        
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
        catch { }
        con.Close();
        return i;
    }
    public int DeleteMenu(MenuEntity oMenuEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblMenuItem WHERE MenuNo=" + oMenuEntity.MenuNo, con);
        //cmd = new SqlCommand("DELETE FROM tblMenuItem", con);
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
        catch { }
        con.Close();
        return i;
    }
    
    #endregion
    #region SubMunu
    public int InsertSubMenu(SubMenuEntity oMenuEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();

        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblSubMenuItem (SubMenuNo,SubMenuName,MenuNo,CreateBy,LastModifiedBy) VALUES(@SubMenuNo,@SubMenuName,@MenuNo,@CreateBy,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@SubMenuNo", SqlDbType.VarChar).Value = oMenuEntity.SubMenuNo;
        cmd.Parameters.AddWithValue("@SubMenuName", SqlDbType.Image).Value = oMenuEntity.SubMenuName;
        cmd.Parameters.AddWithValue("@MenuNo", SqlDbType.VarChar).Value = oMenuEntity.MenuNo;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.VarChar).Value = oMenuEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.Image).Value = oMenuEntity.LastModifiedBy;

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
        catch { }
        con.Close();
        return i;
    }
    public DataTable GetSubMenu(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("SELECT  * FROM  tblSubMenuItem" + condition, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
        }
        catch { }
        con.Close();
        return dt;
    }
    public int UpdateSubMenu(SubMenuEntity oMenuEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblSubMenuItem SET SubMenuName=@SubMenuName,LastModifiedBy=@LastModifiedBy where MenuNo=@MenuNo and SubMenuNo=@SubMenuNo", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@SubMenuNo", SqlDbType.VarChar).Value = oMenuEntity.SubMenuNo;
        cmd.Parameters.AddWithValue("@SubMenuName", SqlDbType.Image).Value = oMenuEntity.SubMenuName;
        cmd.Parameters.AddWithValue("@MenuNo", SqlDbType.VarChar).Value = oMenuEntity.MenuNo;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.Image).Value = oMenuEntity.LastModifiedBy;

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
        catch { }
        con.Close();
        return i;
    }
    public int DeleteSubMenu(SubMenuEntity oMenuEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblSubMenuItem WHERE SubMenuNo='" + oMenuEntity.SubMenuNo+"' and MenuNo='"+oMenuEntity.MenuNo+"'", con);
        //cmd = new SqlCommand("DELETE FROM tblSubMenuItem", con);
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
        catch { }
        con.Close();
        return i;
    }

    #endregion
}