using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

/// <summary>
/// Summary description for TransactionAccountDAO
/// </summary>
public class TransactionAccountDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
	public TransactionAccountDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Transaction
    public int InsertTransaction(TransactionEntity oTransactionEntity, List<TransactionAccEntity> oTransactionAccEntityList)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        SqlTransaction oSqlTransaction;
        oSqlTransaction = con.BeginTransaction("s");
        
        cmd = new SqlCommand("INSERT INTO tblTransaction (VoucherNo,VoucherDate,BrSL,TranTypeSL,PartiCulars,Posted,Approved,BillSL,RevTranSL,CreateBy,LastModifiedBy) VALUES(@VoucherNo,@VoucherDate,@BrSL,@TranTypeSL,@PartiCulars,@Posted,@Approved,@BillSL,@RevTranSL,@CreateBy,@LastModifiedBy)", con);
        cmd.Transaction = oSqlTransaction;
        cmd.Parameters.AddWithValue("@VoucherNo", SqlDbType.VarChar).Value = oTransactionEntity.VoucherNo;
        cmd.Parameters.AddWithValue("@VoucherDate", SqlDbType.DateTime).Value = oTransactionEntity.VoucherDate;
        cmd.Parameters.AddWithValue("@BrSL", SqlDbType.VarChar).Value = oTransactionEntity.BrSL;
        cmd.Parameters.AddWithValue("@TranTypeSL", SqlDbType.VarChar).Value = oTransactionEntity.TranTypeSL;
        cmd.Parameters.AddWithValue("@PartiCulars", SqlDbType.Image).Value = oTransactionEntity.PartiCulars;
        cmd.Parameters.AddWithValue("@Posted", SqlDbType.VarChar).Value = oTransactionEntity.Posted;
        cmd.Parameters.AddWithValue("@Approved", SqlDbType.VarChar).Value = oTransactionEntity.Approved;
        cmd.Parameters.AddWithValue("@BillSL", SqlDbType.Image).Value = oTransactionEntity.BillSL;
        cmd.Parameters.AddWithValue("@RevTranSL", SqlDbType.VarChar).Value = oTransactionEntity.RevTranSL;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.Image).Value = oTransactionEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oTransactionEntity.LastModifiedBy;
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
            int m = 0;
            for (int l = 0; l < oTransactionAccEntityList.Count; l++)
            {
                TransactionAccEntity oTransactionAccEntity = oTransactionAccEntityList[l];
              m+=  InsertTransactionAcc(oTransactionAccEntity, oSqlTransaction,con);
            }

            if (m == oTransactionAccEntityList.Count)
            {
                oSqlTransaction.Commit();
            }
        }
        catch { oSqlTransaction.Rollback(); }
        con.Close();
        return i;
    }
    public int InsertTransactionAcc(TransactionAccEntity oTransactionAccEntity, SqlTransaction oSqlTransaction,SqlConnection con)
    {
        //con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
       
        cmd = new SqlCommand("INSERT INTO tblTransactionAcc (VoucherNo,CoAccNo,IsClient,TMode,BankName,BranchName,ChequeNo,ChequeDate,Tref,BQty,SQty,Debit,Credit,Balance,Matured,CreateBy,LastModifiedBy,BankAccNo) VALUES(@VoucherNo,@CoAccNo,@IsClient,@TMode,@BankName,@BranchName,@ChequeNo,@ChequeDate,@Tref,@BQty,@SQty,@Debit,@Credit,@Balance,@Matured,@CreateBy,@LastModifiedBy,@BankAccNo)", con);
        cmd.Transaction = oSqlTransaction;
        cmd.Parameters.AddWithValue("@VoucherNo", SqlDbType.VarChar).Value = oTransactionAccEntity.VoucherNo;
        cmd.Parameters.AddWithValue("@CoAccNo", SqlDbType.VarChar).Value = oTransactionAccEntity.CoAccNo;
        cmd.Parameters.AddWithValue("@IsClient", SqlDbType.Bit).Value = oTransactionAccEntity.IsClient;
        cmd.Parameters.AddWithValue("@TMode", SqlDbType.VarChar).Value = oTransactionAccEntity.TMode;
        cmd.Parameters.AddWithValue("@BankName", SqlDbType.VarChar).Value = oTransactionAccEntity.BankName;
        cmd.Parameters.AddWithValue("@BranchName", SqlDbType.VarChar).Value = oTransactionAccEntity.BranchName;
        cmd.Parameters.AddWithValue("@ChequeNo", SqlDbType.VarChar).Value = oTransactionAccEntity.ChequeNo;
        cmd.Parameters.AddWithValue("@ChequeDate", SqlDbType.DateTime).Value = oTransactionAccEntity.ChequeDate;
        cmd.Parameters.AddWithValue("@Tref", SqlDbType.VarChar).Value = oTransactionAccEntity.Tref;
        cmd.Parameters.AddWithValue("@BQty", SqlDbType.Decimal).Value = oTransactionAccEntity.BQty;
        cmd.Parameters.AddWithValue("@SQty", SqlDbType.Decimal).Value = oTransactionAccEntity.SQty;
        cmd.Parameters.AddWithValue("@Debit", SqlDbType.Decimal).Value = oTransactionAccEntity.Debit;
        cmd.Parameters.AddWithValue("@Credit", SqlDbType.Decimal).Value = oTransactionAccEntity.Credit;
        cmd.Parameters.AddWithValue("@Balance", SqlDbType.Decimal).Value = oTransactionAccEntity.Balance;
        cmd.Parameters.AddWithValue("@Matured", SqlDbType.Bit).Value = oTransactionAccEntity.Matured;
        cmd.Parameters.AddWithValue("@CreateBy", SqlDbType.VarChar).Value = oTransactionAccEntity.CreateBy;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = oTransactionAccEntity.LastModifiedBy;
        cmd.Parameters.AddWithValue("@BankAccNo", SqlDbType.VarChar).Value = oTransactionAccEntity.BankAccNo;
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
            //oSqlTransaction.Commit();
        }
        catch { 
        //    oSqlTransaction.Rollback(); 
        }
        //con.Close();
        return i;
    }
    public int UpdateTransactionAccDetails(TransactionAccEntity oTransactionAccEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblTransactionAcc SET Debit='" + oTransactionAccEntity.Debit + "',Credit='" + oTransactionAccEntity.Credit + "' WHERE VoucherNo='" +oTransactionAccEntity.VoucherNo+"' and CoAccNo='"+oTransactionAccEntity.CoAccNo+"'" , con);
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
    public string CreateNewVoucher(DateTime voucherDate,string entryType)
    {
        string s = "01";
        string voucherNo = "";
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select VoucherNo from tblTransaction where VoucherDate='" + voucherDate.ToString("yyyy-MM-dd") + "' order by TranSL desc", con);
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
            s = dt.Rows[0]["VoucherNo"].ToString().Substring(7, 2);
            s = (Convert.ToInt16(s) + 1).ToString();
            if (s.Length==1)
            {
                s = "0" + s;
            }
           
        }
        voucherNo = entryType + (voucherDate.Day.ToString().Length == 1 ? "0" + voucherDate.Day.ToString() : voucherDate.Day.ToString()) + (voucherDate.Month.ToString().Length == 1 ? "0" + voucherDate.Month.ToString() : voucherDate.Month.ToString()) + DateTime.Now.Year.ToString().Substring(voucherDate.Year.ToString().Length - 2) + s;
        con.Close();
        return voucherNo;
    }
    public int DeleteTransactionAccDetails(TransactionAccEntity oTransactionAccEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblTransactionAcc WHERE VoucherNo='" +oTransactionAccEntity.VoucherNo+"' and CoAccNo='"+oTransactionAccEntity.CoAccNo+"'", con);
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
    public DataTable GetVoucherDetails(string condition)
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("SELECT  tblTransaction.PartiCulars,   tblTransactionAcc.*,(CASE WHEN tblTransactionAcc.IsClient='false' then (select CoAccNo+'|'+CoAccName from tblChartOfAccount where CoAccNo=tblTransactionAcc.CoAccNo) else CoAccNo end) as AccountNo FROM tblTransactionAcc INNER JOIN  tblTransaction ON tblTransactionAcc.VoucherNo = tblTransaction.VoucherNo" + condition, con);
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

    #region TransactionApprove
    public DataTable GetUnApprovedVoucher()
    {


        con = oConnectionDatabase.DatabaseConnection();
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("SELECT * from tblTransaction where Approved='false'", con);
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
    public int UpdateTransactionApprove(Boolean status, string columnName, string voucherNo, SqlConnection con, SqlTransaction oSqlTransaction)
    {


        //con = oConnectionDatabase.DatabaseConnection();
        //try { con.Open(); }
        //catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblTransaction SET " + columnName + "=@columnName WHERE VoucherNo=@VoucherNo", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        cmd.Transaction = oSqlTransaction;
        cmd.Parameters.AddWithValue("@VoucherNo", SqlDbType.VarChar).Value = voucherNo;
        cmd.Parameters.AddWithValue("@columnName", SqlDbType.Bit).Value = status;


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

    public int UpdateTransactionAccChequeMatured(Boolean status,string voucherNo)
    {


        con = oConnectionDatabase.DatabaseConnection();
        //try { con.Open(); }
        //catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblTransactionAcc SET Matured=@Matured WHERE VoucherNo=@VoucherNo", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        //cmd.Transaction = oSqlTransaction;
        cmd.Parameters.AddWithValue("@VoucherNo", SqlDbType.VarChar).Value = voucherNo;
        cmd.Parameters.AddWithValue("@Matured", SqlDbType.Bit).Value = status;


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

    public int UpdateClientBalance(decimal amount, string ClientNo)
    {


        con = oConnectionDatabase.DatabaseConnection();
        //try { con.Open(); }
        //catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblClient SET clientBal=@clientBal WHERE ClientID=@ClientID", con);
        //cmd = new SqlCommand("INSERT INTO tblUserInfo (UserID,UserType,Password,ConfirmPassword,Active,LastModifiedBy) VALUES(@UserID,@UserType,@Password,@ConfirmPassword,@Active,@LastModifiedBy)", con);
        //cmd.Transaction = oSqlTransaction;
        cmd.Parameters.AddWithValue("@ClientID", SqlDbType.VarChar).Value = ClientNo;
        cmd.Parameters.AddWithValue("@clientBal", SqlDbType.Decimal).Value = amount;


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

    public int DeleteTransaction(string voucheNo)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        SqlTransaction oSqlTransaction=con.BeginTransaction("s");
      
        cmd = new SqlCommand("DELETE FROM tblTransactionAcc WHERE VoucherNo='" + voucheNo + "'", con);
        cmd.Transaction = oSqlTransaction;
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            i = 1;
        }
       
        catch { }

        if (i == 1)
        {
            cmd = new SqlCommand("DELETE FROM tblTransaction WHERE VoucherNo='" + voucheNo + "'", con);
            cmd.Transaction = oSqlTransaction;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                i = 1;
                oSqlTransaction.Commit();
            }
            catch { oSqlTransaction.Rollback(); }
        }
        con.Close();
        return i;
    }
    #endregion
}