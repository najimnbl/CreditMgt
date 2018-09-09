using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ClientTypeDAO
/// </summary>
public class ClientTypeDAO

{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
    
    
    public ClientTypeDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region ClientType

    public int InsertClientType(ClientTypeEntity oClientTypeEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblClientType (ClientTypeCode,ClientTypeDetais,ClientTypeRemarks,ClientTypeChargePercentage,ClientTypeCreateBy,ClientTypeLastModifiedBy) VALUES('" + oClientTypeEntity.ClientTypeCode + "','" + oClientTypeEntity.ClientTypeDetais + "','" + oClientTypeEntity.ClientTypeRemarks + "','" + oClientTypeEntity.ClientTypeChargePercentage + "','" + oClientTypeEntity.ClientTypeCreateBy + "','" + oClientTypeEntity.ClientTypeLastModifiedBy + "')", con);
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

    public DataTable GetClientType(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblClientType " + condition, con);
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


  

    public int DeleteClientType(ClientTypeEntity oClientTypeEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblClientType WHERE ClientTypeID=" + oClientTypeEntity.ClientTypeID, con);
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

    public DataTable GetClientTypeView(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select ClientTypeID,ClientTypeCode,ClientTypeDetais,ClientTypeChargePercentage,ClientTypeRemarks from tblClientType " + condition, con);
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

    public int UpdateClientType(ClientTypeEntity oClientTypeEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblclientType SET ClientTypeCode='" + oClientTypeEntity.ClientTypeCode + "',ClientTypeDetais='" + oClientTypeEntity.ClientTypeDetais + "',ClientTypeChargePercentage='" + oClientTypeEntity.ClientTypeChargePercentage + "',ClientTypeRemarks='" + oClientTypeEntity.ClientTypeRemarks + "', ClientTypeLastModifiedBy ='" + oClientTypeEntity.ClientTypeLastModifiedBy + "' WHERE ClientTypeID=" + oClientTypeEntity.ClientTypeID, con);
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