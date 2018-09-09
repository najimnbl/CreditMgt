using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for TransactionRoleDAO
/// </summary>
public class TransactionRoleDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;


    public TransactionRoleDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region TransactionRole

    public int InsertTransactionRole(TransactionRoleEntity oTransactionRoleEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblRole (RoleCode,RoleDetails,RoleRemarks,RoleCreateBy,RoleLastModifiedBy) VALUES('" + oTransactionRoleEntity.RoleCode + "','" + oTransactionRoleEntity.RoleDetails + "','" + oTransactionRoleEntity.RoleRemarks + "','" + oTransactionRoleEntity.RoleCreateBy + "','" + oTransactionRoleEntity.RoleLastModifiedBy + "')", con);
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

    public DataTable GetTransactionRole(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblRole " + condition, con);
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


    public DataTable GetTransactionRoleView(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("SELECT roleid,rolecode,roledetails,RoleRemarks from tblrole " + condition, con);
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

    public int DeleteTransactionRole(TransactionRoleEntity oTransactionRoleEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblrole WHERE roleid=" + oTransactionRoleEntity.RoleId , con);
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

    public int UpdateTransactionRole(TransactionRoleEntity oTransactionRoleEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblrole SET roleCode='" + oTransactionRoleEntity.RoleCode + "',RoleDetails='" + oTransactionRoleEntity.RoleDetails + "',RoleRemarks='" + oTransactionRoleEntity.RoleRemarks + "', RoleLastModifiedBy ='" + oTransactionRoleEntity.RoleLastModifiedBy + "' WHERE roleid=" + oTransactionRoleEntity.RoleId, con);
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

