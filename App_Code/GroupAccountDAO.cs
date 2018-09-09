using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GroupAccountDAO
/// </summary>
public class GroupAccountDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
    
    public GroupAccountDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region GroupAccount

    public int InsertGroupAccount(GroupAccountEntity oGroupAccountEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblGroupAccount (GrpAccNo,AccGTSL,GrpAccName,Remarks,CrateBy,LastModifiedBy) VALUES('" + oGroupAccountEntity.GrpAccNo + "','" + oGroupAccountEntity.AccGTSL + "','" + oGroupAccountEntity.GrpAccName + "','" + oGroupAccountEntity.Remarks + "','" + oGroupAccountEntity.CrateBy + "','" + oGroupAccountEntity.LastModifiedBy + "')", con);
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

    public DataTable GetGroupAccount(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblAccountGroupType " + condition, con);
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

    public int DeleteGroupAccount(GroupAccountEntity oGroupAccountEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblGroupAccount WHERE GrpAccSL=" + oGroupAccountEntity.GrpAccSL, con);
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

    public DataTable GetGroupAccountView(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select GrpAccSL,GrpAccNo,AccGTSL,GrpAccName,Remarks from tblGroupAccount " + condition, con);
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

    public int UpdateGroupAccount(GroupAccountEntity oGroupAccountEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblGroupAccount SET GrpAccNo='" + oGroupAccountEntity.GrpAccNo + "',AccGTSL='" + oGroupAccountEntity.AccGTSL + "',GrpAccName='" + oGroupAccountEntity.GrpAccName + "',Remarks='" + oGroupAccountEntity.Remarks + "', LastModifiedBy ='" + oGroupAccountEntity.LastModifiedBy + "' WHERE GrpAccSL=" + oGroupAccountEntity.GrpAccSL, con);
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

    public string CreateGroupCode(int accTypeSL)
    {
        string code = accTypeSL + "01";
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblGroupAccount  where AccGTSL='" + accTypeSL + "' order by GrpAccSL desc", con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
        }
        catch { }
        con.Close();
        if (dt.Rows.Count > 0)
        {
            int lastDigit =int.Parse(dt.Rows[0]["GrpAccNo"].ToString().Substring(1, 2));
            lastDigit++;
            code = (accTypeSL).ToString() + lastDigit.ToString();
            if (lastDigit < 10)
            {
                code = accTypeSL + "0" + lastDigit;
            }
            
        }


        return code;
    }

    #endregion


}