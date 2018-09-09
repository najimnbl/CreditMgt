
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GroupAccountDAO
/// </summary>
public class AccountGroupReportDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;

    public AccountGroupReportDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region AccountGroupReport

    public int InsertAccountGroupReport(AccountGroupReportEntity oAccountGroupReportEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblAccountGroupReport (AccGrpCodeR,AccGrpNameR) VALUES('" + oAccountGroupReportEntity.AccGrpCodeR + "','" + oAccountGroupReportEntity.AccGrpNameR + "')", con);
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

    public DataTable GetAccountGroupReport(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblAccountGroupReport " + condition, con);
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

    public int DeleteAccountGroupReport(AccountGroupReportEntity oAccountGroupReportEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblAccountGroupReport WHERE AccGrpSLR=" + oAccountGroupReportEntity.AccGrpSLR, con);
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

    public DataTable GetAccountGroupReportView(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select AccGrpSLR, AccGrpCodeR,AccGrpNameR from tblAccountGroupReport " + condition, con);
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

    public int UpdateAccountGroupReport(AccountGroupReportEntity oAccountGroupReportEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblAccountGroupReport SET AccGrpCodeR='" + oAccountGroupReportEntity.AccGrpCodeR + "',AccGrpNameR='" + oAccountGroupReportEntity.AccGrpNameR + "' WHERE AccGrpSLR=" + oAccountGroupReportEntity.AccGrpSLR, con);
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