using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClientDAO
/// </summary>
public class ClientDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;

	public ClientDAO()
	{
		
	}
    #region Client
    public int InsertClient(ClientEntity oClientEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;

  



        cmd = new SqlCommand("INSERT INTO tblClient (ClientID,ClientBIO,MBHouseCode,ClientIntroducer,RoleCode,ClientTypeCode,"
        + "ChargeCategoryCode,ClientPowerAtonyDetais,ClientSpecialComissionRate,ClientTransactionAccount,AccountType,ClientCreateBy,ClientLastModified,acccountOpeningDate)"
        + "VALUES('" + oClientEntity.ClientID + "','" + oClientEntity.ClientBIO + "','" + oClientEntity.MBHouseCode + "','" + oClientEntity.ClientIntroducer  + "',"
        + "'" + oClientEntity.RoleCode + "','" + oClientEntity.ClientTypeCode + "','" + oClientEntity.ChargeCategoryCode + "','" + oClientEntity.ClientPowerAtonyDetais  + "',"
        + "'" + oClientEntity.ClientSpecialComissionRate + "','" + oClientEntity.ClientTransactionAccount + "','" + oClientEntity.AccountType + "','" + oClientEntity.ClientCreateBy + "',"
        + "'" + oClientEntity.ClientLastModified + "','" + oClientEntity.AcccountOpeningDate + "')", con);
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
    public int UpdateClient(ClientEntity oClientEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;

   

        cmd = new SqlCommand("UPDATE  tblClient SET ClientBIO='" + oClientEntity.ClientBIO + "',MBHouseCode='" + oClientEntity.MBHouseCode + "',ClientIntroducer='" + oClientEntity.ClientIntroducer + "',"
        + "RoleCode='" + oClientEntity.RoleCode + "',ClientTypeCode='" + oClientEntity.ClientTypeCode + "',ChargeCategoryCode='" + oClientEntity.ChargeCategoryCode + "',ClientSpecialComissionRate='" + oClientEntity.ClientSpecialComissionRate + "',"
        + "ClientTransactionAccount='" + oClientEntity.ClientTransactionAccount + "',AccountType='" + oClientEntity.AccountType + "',ClientLastModified='" + oClientEntity.ClientLastModified + "' WHERE ClSL=" + oClientEntity.ClSL, con);
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
    public int DeleteClient(ClientEntity oClientEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblClient WHERE ClSL=" + oClientEntity.ClSL, con);
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
    public DataTable GetClient(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblClient " + condition, con);
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
    public DataTable GetClientIntroducer(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblClient " + condition, con);
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
    public DataTable GetClientRole(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblrole " + condition, con);
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
    public DataTable GetClientChargeCategory(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tbleChargeCategory " + condition, con);
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
    public DataTable GetClientView(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("SELECT ClSL,ClientID,ClientBIO,MBHouseCode,ClientIntroducer,RoleCode,ClientTypeCode,ChargeCategoryCode,ClientPowerAtonyDetais,ClientSpecialComissionRate,ClientTransactionAccount,AccountType from tblClient " + condition, con);

        
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