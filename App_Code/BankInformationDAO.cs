using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for BankInformationDAO
/// </summary>
public class BankInformationDAO
{  
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
	public BankInformationDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Bank
    public int InsertBank(BankInformationEntity oBankInformationEntity)
    {
            con = oConnectionDatabase.DatabaseConnection();
            int i=0;
            cmd = new SqlCommand("INSERT INTO tblBank (BankName,BankRemarks) VALUES('"+oBankInformationEntity.BankName+"','"+oBankInformationEntity.BankRemarks+"')", con);
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
    public int UpdateBank(BankInformationEntity oBankInformationEntity)
    {
            con = oConnectionDatabase.DatabaseConnection();
            int i=0;
            cmd = new SqlCommand("UPDATE  tblBank SET BankName='"+oBankInformationEntity.BankName+"',BankRemarks='"+oBankInformationEntity.BankRemarks+"' WHERE Bankid="+oBankInformationEntity.Bankid, con);
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
       public DataTable GetBank(string condition)
        {
            con = oConnectionDatabase.DatabaseConnection();
            cmd = new SqlCommand("select * from tblBank " + condition, con);
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
       public int DeleteBank(BankInformationEntity oBankInformationEntity)
       {
           con = oConnectionDatabase.DatabaseConnection();
           int i = 0;
           cmd = new SqlCommand("DELETE FROM tblBank WHERE Bankid=" + oBankInformationEntity.Bankid, con);
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
    #region BankBranch
       public int InsertBankBranch(BankInformationEntity oBankInformationEntity)
       {
           con = oConnectionDatabase.DatabaseConnection();
           int i = 0;
           cmd = new SqlCommand("INSERT INTO tblBankBranch (Bankid,BranchCode,BranchName,BranchAddress,BranchRoutingCode,BranchRemarks,BranchCreateBy,BranchLastModifieddBy) VALUES(" + oBankInformationEntity.Bankid + ",'" + oBankInformationEntity.BranchCode + "','" + oBankInformationEntity.BranchName + "','" + oBankInformationEntity.BranchAddress + "','" + oBankInformationEntity.BranchRoutingCode + "','" + oBankInformationEntity.BranchRemarks + "','" + oBankInformationEntity.BranchCreateBy + "','" + oBankInformationEntity.BranchLastModifieddBy + "')", con);
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
       public int UpdateBankBranch(BankInformationEntity oBankInformationEntity)
       {
           con = oConnectionDatabase.DatabaseConnection();
           int i = 0;
           cmd = new SqlCommand("UPDATE  tblBankBranch SET BranchCode='" + oBankInformationEntity.BranchCode + "',BranchName='" + oBankInformationEntity.BranchName + "',BranchAddress='" + oBankInformationEntity.BranchAddress + "',BranchRoutingCode='" + oBankInformationEntity.BranchRoutingCode + "',BranchRemarks='" + oBankInformationEntity.BranchRemarks + "',BranchLastModifieddBy='" + oBankInformationEntity.BranchLastModifieddBy + "' WHERE BranchID=" + oBankInformationEntity.BranchID, con);
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
       public DataTable GetBankBranch(string condition)
       {
           con = oConnectionDatabase.DatabaseConnection();
           cmd = new SqlCommand("SELECT   tblBank.BankName, tblBankBranch.* FROM  tblBank INNER JOIN  tblBankBranch ON tblBank.Bankid = tblBankBranch.Bankid  " + condition, con);
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
       public int DeleteBankBranch(BankInformationEntity oBankInformationEntity)
       {
           con = oConnectionDatabase.DatabaseConnection();
           int i = 0;
           cmd = new SqlCommand("DELETE FROM tblBankBranch WHERE BranchID=" + oBankInformationEntity.BranchID, con);
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