using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ChartOfAccountDAO
/// </summary>
public class ChartOfAccountDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
	public ChartOfAccountDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region UserAssignRight
    public int InsertChartOfAccount(ChartOfAccountEntity oChartOfAccountEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();

        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblChartOfAccount (CoAccNo,CoAccName,OpenDate,GrpAccSL,AccGrpSLR,AccTypeSL,SGrpAccSL,Posted,OpenDayBalance,ClossingBalance,AvailableBalance,CurrentBalance,CreateBy,LastModifiedBy) VALUES(@CoAccNo,@CoAccName,@OpenDate,@GrpAccSL,@AccGrpSLR,@AccTypeSL,@SGrpAccSL,@Posted,@OpenDayBalance,@ClossingBalance,@AvailableBalance,@CurrentBalance,@CreateBy,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@CoAccNo", SqlDbType.VarChar).Value = oChartOfAccountEntity.CoAccNo;
        cmd.Parameters.AddWithValue("@CoAccName", SqlDbType.VarChar).Value = oChartOfAccountEntity.CoAccName;
        cmd.Parameters.AddWithValue("@OpenDate", SqlDbType.VarChar).Value = oChartOfAccountEntity.OpenDate;
        cmd.Parameters.AddWithValue("@GrpAccSL", SqlDbType.VarChar).Value = oChartOfAccountEntity.GrpAccSL;
        cmd.Parameters.AddWithValue("@AccGrpSLR", SqlDbType.VarChar).Value = oChartOfAccountEntity.AccGrpSLR;
        cmd.Parameters.AddWithValue("@AccTypeSL", SqlDbType.VarChar).Value = oChartOfAccountEntity.AccTypeSL;
        cmd.Parameters.AddWithValue("@SGrpAccSL", SqlDbType.VarChar).Value = oChartOfAccountEntity.SGrpAccSL;
        cmd.Parameters.AddWithValue("@Posted", SqlDbType.VarChar).Value = oChartOfAccountEntity.Posted;
        cmd.Parameters.AddWithValue("@OpenDayBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.OpenDayBalance;
        cmd.Parameters.AddWithValue("@ClossingBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.ClossingBalance;
        cmd.Parameters.AddWithValue("@AvailableBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.AvailableBalance;
        cmd.Parameters.AddWithValue("@CurrentBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.CurrentBalance;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.VarChar).Value = oChartOfAccountEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oChartOfAccountEntity.LastModifiedBy;
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
    public DataTable GetChartOfAccount(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("SELECT  tblChartOfAccount.CoAccSL, tblChartOfAccount.CoAccNo, tblChartOfAccount.CoAccName, tblChartOfAccount.OpenDate, tblChartOfAccount.GrpAccSL,"
                      +"tblChartOfAccount.AccGrpSLR, tblChartOfAccount.AccTypeSL, tblChartOfAccount.SGrpAccSL, tblChartOfAccount.Posted, tblChartOfAccount.OpenDayBalance," 
                      +"tblChartOfAccount.ClossingBalance, tblChartOfAccount.AvailableBalance, tblChartOfAccount.CurrentBalance, tblChartOfAccount.CreateBy," 
                      +"tblChartOfAccount.LastModifiedBy, tblGroupAccount.GrpAccName, tblSubGroupAccount.SGrpAccName, tblAccountType.AccTypeName"
                       +" FROM  tblChartOfAccount INNER JOIN  tblAccountType ON tblChartOfAccount.AccTypeSL = tblAccountType.AccTypeSL INNER JOIN "
                      +"tblGroupAccount ON tblChartOfAccount.GrpAccSL = tblGroupAccount.GrpAccSL INNER JOIN tblSubGroupAccount ON tblChartOfAccount.SGrpAccSL = tblSubGroupAccount.SGrpAccSL" + condition, con);
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
    public int UpdateChartOfAccount(ChartOfAccountEntity oChartOfAccountEntity)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblChartOfAccount SET CoAccName=@CoAccName,GrpAccSL=@GrpAccSL,AccGrpSLR=@AccGrpSLR,AccTypeSL=@AccTypeSL,SGrpAccSL=@SGrpAccSL,LastModifiedBy=@LastModifiedBy WHERE CoAccNo=@CoAccNo", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@CoAccNo", SqlDbType.VarChar).Value = oChartOfAccountEntity.CoAccNo;
        cmd.Parameters.AddWithValue("@CoAccName", SqlDbType.VarChar).Value = oChartOfAccountEntity.CoAccName;
        cmd.Parameters.AddWithValue("@OpenDate", SqlDbType.VarChar).Value = oChartOfAccountEntity.OpenDate;
        cmd.Parameters.AddWithValue("@GrpAccSL", SqlDbType.VarChar).Value = oChartOfAccountEntity.GrpAccSL;
        cmd.Parameters.AddWithValue("@AccGrpSLR", SqlDbType.VarChar).Value = oChartOfAccountEntity.AccGrpSLR;
        cmd.Parameters.AddWithValue("@AccTypeSL", SqlDbType.VarChar).Value = oChartOfAccountEntity.AccTypeSL;
        cmd.Parameters.AddWithValue("@SGrpAccSL", SqlDbType.VarChar).Value = oChartOfAccountEntity.SGrpAccSL;
        cmd.Parameters.AddWithValue("@Posted", SqlDbType.VarChar).Value = oChartOfAccountEntity.Posted;
        cmd.Parameters.AddWithValue("@OpenDayBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.OpenDayBalance;
        cmd.Parameters.AddWithValue("@ClossingBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.ClossingBalance;
        cmd.Parameters.AddWithValue("@AvailableBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.AvailableBalance;
        cmd.Parameters.AddWithValue("@CurrentBalance", SqlDbType.VarChar).Value = oChartOfAccountEntity.CurrentBalance;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.VarChar).Value = oChartOfAccountEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oChartOfAccountEntity.LastModifiedBy;

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
    public int DeleteChartOfAccount(ChartOfAccountEntity oChartOfAccountEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblChartOfAccount WHERE  CoAccSL=" + oChartOfAccountEntity.CoAccSL, con);
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
    public DataTable GetChartOfAccountForDropDown(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        if(condition=="coa")
        cmd = new SqlCommand("SELECT CoAccNo+'|'+ CoAccName AS AccInfo,* FROM tblChartOfAccount", con);
        else
            cmd = new SqlCommand("SELECT     (tblClient.ClientID+' | '+tblCustomer.CustomerName) as AccInfo, tblClient.ClientID as CoAccNo FROM  tblCustomer INNER JOIN tblClient ON tblCustomer.CustomerCleintID = tblClient.ClientID", con);
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
    public int UpdateAmount(decimal amount, string columnName, string CoAccNo, SqlConnection con, SqlTransaction oSqlTransaction)
    {


        //con = oConnectionDatabase.DatabaseConnection();
        //try { con.Open(); }
        //catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblChartOfAccount SET " + columnName + "=@columnName WHERE CoAccNo=@CoAccNo", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        cmd.Transaction = oSqlTransaction;
        cmd.Parameters.AddWithValue("@CoAccNo", SqlDbType.VarChar).Value = CoAccNo;
        cmd.Parameters.AddWithValue("@columnName", SqlDbType.Decimal).Value = amount;


        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
        catch { }
        //con.Close();
        return i;
    }

    public string CreateCOACode(int AccGTSL)
    {
        string code = "";
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select tblChartOfAccount.CoAccNo from tblChartOfAccount,tblGroupAccount where tblChartOfAccount.GrpAccSL = tblGroupAccount.GrpAccSL and tblGroupAccount.AccGTSL in (SELECT  tblGroupAccount.AccGTSL"+
               " FROM  tblChartOfAccount INNER JOIN   tblGroupAccount ON tblChartOfAccount.GrpAccSL = tblGroupAccount.GrpAccSL"+
                   "   where tblGroupAccount.GrpAccSL='" + AccGTSL + "')  order by CoAccNo desc", con);
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
            code = (Convert.ToInt64(dt.Rows[0]["CoAccNo"].ToString()) + 1).ToString();

        }
        else
        {
            cmd = new SqlCommand("SELECT  AccGTSL, GrpAccSL FROM  tblGroupAccount where GrpAccSL='"+AccGTSL+"'", con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch { }


            code = int.Parse(dt.Rows[0]["AccGTSL"].ToString()) + "0001";


        }
        con.Close();



        return code;
    }
    #endregion

}