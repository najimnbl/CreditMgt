using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GuardianDAO
/// </summary>
public class UserInfoDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;


    public UserInfoDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region UserInfo
    public int InsertUserInfo(UserInfoEntity oUserInfoEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();
        
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,EmployeeID,CreateBy,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@EmployeeID,@CreateBy,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@UserID", SqlDbType.VarChar).Value =oUserInfoEntity.UserID;
        cmd.Parameters.AddWithValue("@UserType", SqlDbType.Image).Value = oUserInfoEntity.UserType;
        cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = oUserInfoEntity.Password;
        cmd.Parameters.AddWithValue("@ConfirmPassword", SqlDbType.Image).Value = oUserInfoEntity.ConfirmPassword;
        cmd.Parameters.AddWithValue("@Active", SqlDbType.VarChar).Value = oUserInfoEntity.Active;
        cmd.Parameters.AddWithValue("@EmployeeID", SqlDbType.VarChar).Value = oUserInfoEntity.EmployeeID;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.Image).Value = oUserInfoEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oUserInfoEntity.LastModifiedBy;
   

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
    public DataTable GetUserInfo(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("SELECT   tblUserInfo.*,(tblEmployeeInfo.EmployeeName+'('+tblEmployeeInfo.EmployeeID+')') as EmployeeName FROM  tblUserInfo INNER JOIN  tblEmployeeInfo ON tblUserInfo.EmployeeID = tblEmployeeInfo.EmployeeID" + condition, con);
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
    public int UpdateUserInfo(UserInfoEntity oUserInfoEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblUserInfo SET UserType=@UserType,Password=@Password,ConfirmPassword=@ConfirmPassword,Active=@Active,LastModifiedBy=@LastModifiedBy WHERE ID=@ID", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = oUserInfoEntity.ID;
        cmd.Parameters.AddWithValue("@UserType", SqlDbType.Image).Value = oUserInfoEntity.UserType;
        cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = oUserInfoEntity.Password;
        cmd.Parameters.AddWithValue("@ConfirmPassword", SqlDbType.Image).Value = oUserInfoEntity.ConfirmPassword;
        cmd.Parameters.AddWithValue("@Active", SqlDbType.VarChar).Value = oUserInfoEntity.Active;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oUserInfoEntity.LastModifiedBy;
        
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
    public int DeleteUserInfo(UserInfoEntity oUserInfoEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblUserInfo WHERE ID=" + oUserInfoEntity.ID, con);
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
    #region Employee
    public DataTable GetEmployeeInfo(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("SELECT  (EmployeeName+'('+EmployeeID+')') as EnameWithID,tblEmployeeInfo.* from tblEmployeeInfo" + condition, con);
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
    #endregion
}