using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for UserAssignRightDAO
/// </summary>
public class UserAssignRightDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
	public UserAssignRightDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region UserAssignRight
    public int InsertUserAssignRight(UserAssignRightEntity oUserAssignRightEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();

        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblUserAssignRights (UserID,MenuNo,MenuRights,SubMenuNo,SubMenuRights,CreateBy,LastModifiedBy) VALUES(@UserID,@MenuNo,@MenuRights,@SubMenuNo,@SubMenuRights,@CreateBy,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = oUserAssignRightEntity.UserID;
        cmd.Parameters.AddWithValue("@MenuNo", SqlDbType.Image).Value = oUserAssignRightEntity.MenuNo;
        cmd.Parameters.AddWithValue("@SubMenuNo", SqlDbType.VarChar).Value = oUserAssignRightEntity.SubMenuNo;
        cmd.Parameters.AddWithValue("@MenuRights", SqlDbType.Image).Value = oUserAssignRightEntity.MenuRights;
        cmd.Parameters.AddWithValue("@SubMenuRights", SqlDbType.VarChar).Value = oUserAssignRightEntity.SubMenuRights;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.Image).Value = oUserAssignRightEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oUserAssignRightEntity.LastModifiedBy;


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
    public DataTable GetUserAssignRight(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("SELECT  tblMenuItem.MenuName, tblSubMenuItem.SubMenuName, tblUserAssignRights.* FROM tblMenuItem INNER JOIN  tblSubMenuItem ON tblMenuItem.MenuNo = tblSubMenuItem.MenuNo INNER JOIN tblUserAssignRights ON tblMenuItem.MenuNo = tblUserAssignRights.MenuNo AND tblSubMenuItem.SubMenuNo = tblUserAssignRights.SubMenuNo" + condition, con);
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
    public int UpdateUserAssignRight(UserAssignRightEntity oUserAssignRightEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblUserAssignRights SET MenuRights=@MenuRights,SubMenuRights=@SubMenuRights,LastModifiedBy=@LastModifiedBy WHERE UserID=@UserID and MenuNo=@MenuNo and SubMenuNo=@SubMenuNo", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value = oUserAssignRightEntity.UserID;
        cmd.Parameters.AddWithValue("@MenuNo", SqlDbType.Image).Value = oUserAssignRightEntity.MenuNo;
        cmd.Parameters.AddWithValue("@SubMenuNo", SqlDbType.VarChar).Value = oUserAssignRightEntity.SubMenuNo;
        cmd.Parameters.AddWithValue("@MenuRights", SqlDbType.Image).Value = oUserAssignRightEntity.MenuRights;
        cmd.Parameters.AddWithValue("@SubMenuRights", SqlDbType.VarChar).Value = oUserAssignRightEntity.SubMenuRights;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oUserAssignRightEntity.LastModifiedBy;

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
    public int DeleteUserAssignRight(UserAssignRightEntity oUserAssignRightEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblUserAssignRights WHERE ID=" + oUserAssignRightEntity.ID, con);
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