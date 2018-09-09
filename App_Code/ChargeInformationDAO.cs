using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ChargeInformationDAO
/// </summary>
public class ChargeInformationDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
	public ChargeInformationDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region ChargeItem
    public int InsertChargeItem(ChargeItemEntity oChargeItemEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblChargeItem (ChargeCode,ChargeDetails,ChargeAmount,CApplyLowerLimit,CApplyHigherLimit,ChargePercentage,ChargeItemType,ChargeRemarks,ChargeCreatedBy,ChargeLastModifiedBy) VALUES('" + oChargeItemEntity.ChargeCode + "','" + oChargeItemEntity.ChargeDetails + "','" + oChargeItemEntity.ChargeAmount + "','" + oChargeItemEntity.CApplyLowerLimit + "','" + oChargeItemEntity.CApplyHigherLimit + "','" + oChargeItemEntity.ChargePercentage + "','" + oChargeItemEntity.ChargeItemType + "','" + oChargeItemEntity.ChargeRemarks + "','" + oChargeItemEntity.ChargeCreatedBy + "','" + oChargeItemEntity.ChargeLastModifiedBy + "')", con);
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
    public int UpdateChargeItem(ChargeItemEntity oChargeItemEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblChargeItem SET ChargeDetails='" + oChargeItemEntity.ChargeDetails + "',ChargeAmount='" + oChargeItemEntity.ChargeAmount + "',CApplyLowerLimit='" + oChargeItemEntity.CApplyLowerLimit + "',CApplyHigherLimit='" + oChargeItemEntity.CApplyHigherLimit + "',ChargePercentage='" + oChargeItemEntity.ChargePercentage + "',ChargeItemType='" + oChargeItemEntity.ChargeItemType + "',ChargeRemarks='" + oChargeItemEntity.ChargeRemarks + "',ChargeLastModifiedBy='" + oChargeItemEntity.ChargeLastModifiedBy + "' WHERE ChargeID=" + oChargeItemEntity.ChargeID, con);
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
    public DataTable GetChargeItem(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblChargeItem " + condition, con);
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
    public int DeleteChargeItem(ChargeItemEntity oChargeItemEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblChargeItem WHERE ChargeID=" + oChargeItemEntity.ChargeID, con);
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
    #region ChargeCategory
    public int InsertChargeCategory(ChargeCategoryEntity oChargeCategoryEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tbleChargeCategory (ChargeCategoryCode,ChargeCategoryName,ChargeCategoryRemarks,ChargeCategoryCreatedBy,ChargeCategoryLastModifiedBy) VALUES('" + oChargeCategoryEntity.ChargeCategoryCode + "','" + oChargeCategoryEntity.ChargeCategoryName + "','" + oChargeCategoryEntity.ChargeCategoryRemarks + "','" + oChargeCategoryEntity.ChargeCategoryCreatedBy + "','" + oChargeCategoryEntity.ChargeCategoryLastModifiedBy + "')", con);
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
    public int UpdateChargeCategory(ChargeCategoryEntity oChargeCategoryEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tbleChargeCategory SET ChargeCategoryName='" + oChargeCategoryEntity.ChargeCategoryName + "',ChargeCategoryRemarks='" + oChargeCategoryEntity.ChargeCategoryRemarks + "',ChargeCategoryLastModifiedBy='" + oChargeCategoryEntity.ChargeCategoryLastModifiedBy + "' WHERE ChargeCategoryID=" + oChargeCategoryEntity.ChargeCategoryID, con);
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
    public DataTable GetChargeCategory(string condition)
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
    public int DeleteChargeCategory(ChargeCategoryEntity oChargeCategoryEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tbleChargeCategory WHERE ChargeCategoryID=" + oChargeCategoryEntity.ChargeCategoryID, con);
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
    #region ChargeConfiguration
    public int InsertChargeConfiguration(ChargeConfigurationEntity oChargeConfigurationEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblChargeConfiguration (ChargeCategoryCode,ChargeConfigurationDetails,ChargeCode,ChargeCRemarks,ChargeCCreatedBy,ChargeCLastModifiedBy) VALUES('" + oChargeConfigurationEntity.ChargeCategoryCode + "','" + oChargeConfigurationEntity.ChargeConfigurationDetails + "','" + oChargeConfigurationEntity.ChargeCode + "','" + oChargeConfigurationEntity.ChargeCRemarks + "','" + oChargeConfigurationEntity.ChargeCCreatedBy + "','" + oChargeConfigurationEntity.ChargeCLastModifiedBy + "')", con);
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
    public int UpdateChargeConfiguration(ChargeConfigurationEntity oChargeConfigurationEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblChargeConfiguration SET ChargeConfigurationDetails='" + oChargeConfigurationEntity.ChargeConfigurationDetails + "',ChargeCategoryCode='" + oChargeConfigurationEntity.ChargeCategoryCode + "',ChargeCRemarks='" + oChargeConfigurationEntity.ChargeCRemarks + "',ChargeCode='" + oChargeConfigurationEntity.ChargeCode + "',ChargeCLastModifiedBy='" + oChargeConfigurationEntity.ChargeCLastModifiedBy + "' WHERE ChargeConfigurationID=" + oChargeConfigurationEntity.ChargeConfigurationID, con);
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
    public DataTable GetChargeConfiguration(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("SELECT  tblChargeItem.ChargeDetails, tbleChargeCategory.ChargeCategoryName, tblChargeConfiguration.* FROM  tblChargeItem INNER JOIN  tblChargeConfiguration ON tblChargeItem.ChargeCode = tblChargeConfiguration.ChargeCode INNER JOIN tbleChargeCategory ON tblChargeConfiguration.ChargeCategoryCode = tbleChargeCategory.ChargeCategoryCode " + condition, con);
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
    public int DeleteChargeConfiguration(ChargeConfigurationEntity oChargeConfigurationEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblChargeConfiguration WHERE  ChargeConfigurationID=" + oChargeConfigurationEntity.ChargeConfigurationID, con);
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