using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GuardianDAO
/// </summary>
public class GuardianDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;


	public GuardianDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Guardian
    public int InsertGuardian(GuadianEntity oGuardianEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblGuardian (GuardianID,GuardianRightPercentage,GuardianName,GuardianFatherName,GuardianRelationWithN,"
        + "GuardianSex,GuardianDOB,GuardianReligion,GuardianCountryID,GuardianNID,GuardianTIN,GuardianPermanentAddress,GuardianPermanentContact,GuardianPresentAddress,"
        + "GuardianPresentContact,NomineeID,GuardianCreateBy,GuardianLastModified)"
        + "VALUES('" + oGuardianEntity.GuardianID + "','" + oGuardianEntity.GuardianRightPercentage + "','" + oGuardianEntity.GuardianName + "',"
        + "'" + oGuardianEntity.GuardianFatherName + "','" + oGuardianEntity.GuardianRelationWithN + "','" + oGuardianEntity.GuardianSex + "','" + oGuardianEntity.GuardianDOB + "',"
        + "'" + oGuardianEntity.GuardianReligion + "','" + oGuardianEntity.GuardianCountryID + "','" + oGuardianEntity.GuardianNID + "','" + oGuardianEntity.GuardianTIN + "','" + oGuardianEntity.GuardianPermanentAddress + "',"
        + "'" + oGuardianEntity.GuardianPermanentContact + "','" + oGuardianEntity.GuardianPresentAddress + "','" + oGuardianEntity.GuardianPresentContact + "',"
        + "'" + oGuardianEntity.NomineeID + "','" + oGuardianEntity.GuardianCreateBy + "','" + oGuardianEntity.GuardianLastModified + "')", con);



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
    public int UpdateGuardian(GuadianEntity oGuardianEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;

        cmd = new SqlCommand("UPDATE  tblGuardian SET GuardianRightPercentage='" + oGuardianEntity.GuardianRightPercentage + "',GuardianName='" + oGuardianEntity.GuardianName + "',"
        + "GuardianFatherName='" + oGuardianEntity.GuardianFatherName + "',GuardianRelationWithN='" + oGuardianEntity.GuardianRelationWithN + "',GuardianSex='" + oGuardianEntity.GuardianSex + "',GuardianDOB='" + oGuardianEntity.GuardianDOB + "',"
        + "GuardianReligion='" + oGuardianEntity.GuardianReligion + "',GuardianCountryID='" + oGuardianEntity.GuardianCountryID + "',GuardianNID='" + oGuardianEntity.GuardianNID + "',GuardianTIN='" + oGuardianEntity.GuardianTIN + "',"
        + "GuardianPermanentAddress='" + oGuardianEntity.GuardianPermanentAddress + "',GuardianPermanentContact='" + oGuardianEntity.GuardianPermanentContact + "',GuardianPresentAddress='" + oGuardianEntity.GuardianPresentAddress + "',GuardianPresentContact='" + oGuardianEntity.GuardianPresentContact + "',"
        + "NomineeID='" + oGuardianEntity.NomineeID + "',GuardianLastModified='" + oGuardianEntity.GuardianLastModified + "' WHERE GurSL=" + oGuardianEntity.GurSL, con);


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
    public DataTable GetGuardian(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblGuardian " + condition, con);
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

    public int DeleteGuardian(GuadianEntity oGuardianEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblGuardian WHERE GurSL=" + oGuardianEntity.GurSL, con);
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