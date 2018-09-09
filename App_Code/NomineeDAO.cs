using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for NomineeDAO
/// </summary>
public class NomineeDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;



	public NomineeDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Nominee
    public int InsertNominee(NomineeEntity oNomineeEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblNominee (NomineeID,NomineeRightPercentage,NomineeName,NomineeFatherName,NomineeRelationWithC,"
        + "NomineeSex,NomineeDOB,NomineeReligion,NomineeCountryID,NomineeNID,NomineeTIN,NomineePermanentAddress,NomineePermanentContact,NomineePresentAddress,"
        + "NomineePresentContact,ClientID,NomineeIsMature,NomineeCreateBy,NomineeLastModified)"
        + "VALUES('" + oNomineeEntity.NomineeID + "','" + oNomineeEntity.NomineeRightPercentage + "','" + oNomineeEntity.NomineeName + "',"
        + "'" + oNomineeEntity.NomineeFatherName + "','" + oNomineeEntity.NomineeRelationWithC + "','" + oNomineeEntity.NomineeSex + "','" + oNomineeEntity.NomineeDOB + "',"
        + "'" + oNomineeEntity.NomineeReligion + "','" + oNomineeEntity.NomineeCountryID + "','" + oNomineeEntity.NomineeNID + "','" + oNomineeEntity.NomineeTIN + "','" + oNomineeEntity.NomineePermanentAddress + "',"
        + "'" + oNomineeEntity.NomineePermanentContact + "','" + oNomineeEntity.NomineePresentAddress + "','" + oNomineeEntity.NomineePresentContact + "',"
        + "'" + oNomineeEntity.ClientID + "','" + oNomineeEntity.NomineeIsMature + "','" + oNomineeEntity.NomineeCreateBy + "','" + oNomineeEntity.NomineeLastModified + "')", con);
       
        
        
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
    public int UpdateNominee(NomineeEntity oNomineeEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;

        cmd = new SqlCommand("UPDATE  tblNominee SET NomineeRightPercentage='" + oNomineeEntity.NomineeRightPercentage + "',NomineeName='" + oNomineeEntity.NomineeName + "',"
        + "NomineeFatherName='" + oNomineeEntity.NomineeFatherName + "',NomineeRelationWithC='" + oNomineeEntity.NomineeRelationWithC + "',NomineeSex='" + oNomineeEntity.NomineeSex + "',NomineeDOB='" + oNomineeEntity.NomineeDOB + "',"
        + "NomineeReligion='" + oNomineeEntity.NomineeReligion + "',NomineeCountryID='" + oNomineeEntity.NomineeCountryID + "',NomineeNID='" + oNomineeEntity.NomineeNID + "',NomineeTIN='" + oNomineeEntity.NomineeTIN + "',"
        + "NomineePermanentAddress='" + oNomineeEntity.NomineePermanentAddress + "',NomineePermanentContact='" + oNomineeEntity.NomineePermanentContact + "',NomineePresentAddress='" + oNomineeEntity.NomineePresentAddress + "',NomineePresentContact='" + oNomineeEntity.NomineePresentContact + "',"
        + "ClientID='" + oNomineeEntity.ClientID + "',NomineeIsMature='" + oNomineeEntity.NomineeIsMature + "',NomineeLastModified='" + oNomineeEntity.NomineeLastModified + "' WHERE NomSl=" + oNomineeEntity.NomSL, con);
       
        
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
    public DataTable GetNominee(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblNominee " + condition, con);
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

    public int DeleteNominee(NomineeEntity oNomineeEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblNominee WHERE NomSL=" + oNomineeEntity.NomSL, con);
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

    #endregion

    #region Country
    public DataTable GetCountry(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblCountry " + condition, con);
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