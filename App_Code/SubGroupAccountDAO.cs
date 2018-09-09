using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for SubGroupAccountDAO
/// </summary>
public class SubGroupAccountDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;

    
    public SubGroupAccountDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region SubGroupAccount
    public int InsertSubGroupAccount(SubGroupAccountEntity oSubGroupAccountEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblSubGroupAccount (SGrpAccNo,GrpAccSL,SGrpAccName,Remarks,"
        + "CrateBy,LastModifiedBy)"
        + "VALUES('" + oSubGroupAccountEntity.SGrpAccNo + "','" + oSubGroupAccountEntity.GrpAccSL + "','" + oSubGroupAccountEntity.SGrpAccName + "',"
        + "'" + oSubGroupAccountEntity.Remarks + "'," + "'" + oSubGroupAccountEntity.CrateBy + "'," + "'" + oSubGroupAccountEntity.LastModifiedBy  + "')", con);
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
    public int UpdateSubGroupAccount(SubGroupAccountEntity oSubGroupAccountEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;

        cmd = new SqlCommand("UPDATE  tblSubGroupAccount SET SGrpAccNo='" + oSubGroupAccountEntity.SGrpAccNo + "',GrpAccSL='" + oSubGroupAccountEntity.GrpAccSL + "',"
        + "SGrpAccName='" + oSubGroupAccountEntity.SGrpAccName + "',Remarks='" + oSubGroupAccountEntity.Remarks + "',LastModifiedBy='" + oSubGroupAccountEntity.LastModifiedBy + "' WHERE SGrpAccSL=" + oSubGroupAccountEntity.SGrpAccSL, con);
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
    public DataTable GetSubGroupAccount(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblSubGroupAccount " + condition, con);
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
    public DataTable GetGrpAccSL(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblGroupAccount " + condition, con);
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

    public int DeleteSubGroupAccount(SubGroupAccountEntity oSubGroupAccountEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblSubGroupAccount WHERE SGrpAccSL=" +  oSubGroupAccountEntity.SGrpAccSL, con);
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
    public string CreateSubGroupCode(int AccGTSL)
    {
        string code = "";
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select tblGroupAccount.GrpAccSL,AccGTSL,SGrpAccNo from tblGroupAccount,tblSubGroupAccount where tblSubGroupAccount.GrpAccSL=tblGroupAccount.GrpAccSL and  tblGroupAccount.AccGTSL in ( SELECT  tblGroupAccount.AccGTSL FROM  tblGroupAccount INNER JOIN  tblSubGroupAccount ON tblGroupAccount.GrpAccSL = tblSubGroupAccount.GrpAccSL"+
                      " where tblSubGroupAccount.GrpAccSL='" + AccGTSL + "')  order by SGrpAccNo desc", con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
        }
        catch { }
        if (dt.Rows.Count > 0)
        {
            int lastDigit = int.Parse(dt.Rows[0]["SGrpAccNo"].ToString().Substring(1, 2));
            lastDigit++;
            code =int.Parse(dt.Rows[0]["AccGTSL"].ToString())+ lastDigit.ToString();
            if (lastDigit < 10)
            {
                code = int.Parse(dt.Rows[0]["AccGTSL"].ToString()) + "0" + lastDigit;
            }

        }
        else
        {
            cmd = new SqlCommand("SELECT  AccGTSL, GrpAccSL FROM  tblGroupAccount where GrpAccSL='" + AccGTSL + "'", con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch { }

          
            code = int.Parse(dt.Rows[0]["AccGTSL"].ToString()) + "01";
           

        }
        con.Close();
      


        return code;
    }


    #endregion
}