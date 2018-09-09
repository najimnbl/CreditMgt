using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for CustomerDAO
/// </summary>
public class CustomerDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;
	public CustomerDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Customer
    public int InsertCustomer(CustomerEntity oCustomerEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblCustomer (CustomerID,CustomerName,CustomerFatherName,CustomerMotherName,CustomerSex,"
        +"CustomerDOB,CustomerReligion,CountryID,CustomerNID,CustomerTIN,CustomerPassportNO,CustomerMeritalStatus,CustomerEmail,CustomerPermanentAddress,"
        + "CustomerPermanentContact,CustomerPresentAddress,CustomerPresentContact,CustomerMailingAddress,CustomerMailingContact,CustomerNo,Bankid,BranchID,CustomerBankAccount,"
        + "CustommerCreateBY,CustomerApprovedby,CustomerLastModified,CustomerCleintID,CustomerIsCompany,CustomerMobileNo)"
        +"VALUES('" + oCustomerEntity.CustomerID + "','" + oCustomerEntity.CustomerName + "','" + oCustomerEntity.CustomerFatherName + "',"
        +"'" + oCustomerEntity.CustomerMotherName + "','" + oCustomerEntity.CustomerSex + "','" + oCustomerEntity.CustomerDOB + "','" + oCustomerEntity.CustomerReligion + "',"
        + "'" + oCustomerEntity.CountryID + "','" + oCustomerEntity.CustomerNID + "','" + oCustomerEntity.CustomerTIN + "','" + oCustomerEntity.CustomerPassportNO + "','" + oCustomerEntity.CustomerMeritalStatus + "',"
        + "'" + oCustomerEntity.CustomerEmail + "','" + oCustomerEntity.CustomerPermanentAddress + "','" + oCustomerEntity.CustomerPermanentContact + "',"
        + "'" + oCustomerEntity.CustomerPresentAddress + "','" + oCustomerEntity.CustomerPresentContact + "','" + oCustomerEntity.CustomerMailingAddress + "','" + oCustomerEntity.CustomerMailingContact + "',"
        + "'" + oCustomerEntity.CustomerNo + "','" + oCustomerEntity.Bankid + "','" + oCustomerEntity.BranchID + "','" + oCustomerEntity.CustomerBankAccount + "',"
        + "'" + oCustomerEntity.CustommerCreateBY + "','" + oCustomerEntity.CustomerApprovedby + "','" + oCustomerEntity.CustomerLastModified + "','" + oCustomerEntity.CustomerCleintID + "',"
        + "'" + oCustomerEntity.CustomerIsCompany + "','" + oCustomerEntity.CustomerMobileNo + "')", con);
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
    public int UpdateCustomer(CustomerEntity oCustomerEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblCustomer SET CustomerName='" + oCustomerEntity.CustomerName + "',CustomerFatherName='" + oCustomerEntity.CustomerFatherName + "',"
        + "CustomerMotherName='" + oCustomerEntity.CustomerMotherName + "',CustomerSex='" + oCustomerEntity.CustomerSex + "',CustomerDOB='" + oCustomerEntity.CustomerDOB + "',CustomerReligion='" + oCustomerEntity.CustomerReligion + "',"
        + "CountryID='" + oCustomerEntity.CountryID + "',CustomerNID='" + oCustomerEntity.CustomerNID + "',CustomerTIN='" + oCustomerEntity.CustomerTIN + "',CustomerPassportNO='" + oCustomerEntity.CustomerPassportNO + "',"
        + "CustomerMeritalStatus='" + oCustomerEntity.CustomerMeritalStatus + "',CustomerEmail='" + oCustomerEntity.CustomerEmail + "',CustomerPermanentAddress='" + oCustomerEntity.CustomerPermanentAddress + "',CustomerPermanentContact='" + oCustomerEntity.CustomerPermanentContact + "',"
        + "CustomerPresentAddress='" + oCustomerEntity.CustomerPresentAddress + "',CustomerPresentContact='" + oCustomerEntity.CustomerPresentContact + "',CustomerMailingAddress='" + oCustomerEntity.CustomerMailingAddress + "',CustomerMailingContact='" + oCustomerEntity.CustomerMailingContact + "',"
        + "CustomerNo='" + oCustomerEntity.CustomerNo + "',Bankid='" + oCustomerEntity.Bankid + "',BranchID='" + oCustomerEntity.BranchID + "',CustomerBankAccount='" + oCustomerEntity.CustomerBankAccount + "',"
        + "CustommerCreateBY='" + oCustomerEntity.CustommerCreateBY + "',CustomerApprovedby='" + oCustomerEntity.CustomerApprovedby + "',CustomerLastModified='" + oCustomerEntity.CustomerLastModified + "',CustomerCleintID='" + oCustomerEntity.CustomerCleintID + "',"
        + "CustomerIsCompany='" + oCustomerEntity.CustomerIsCompany + "',CustomerMobileNo='" + oCustomerEntity.CustomerMobileNo + "' WHERE CuSL=" + oCustomerEntity.CuSL, con);
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
    public DataTable GetCustomer(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblCustomer " + condition, con);
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
    public int DeleteCustomer(CustomerEntity oCustomerEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblCustomer WHERE CuSL=" + oCustomerEntity.CuSL, con);
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
    public DataTable GetClientWiseCustomer(string clientId)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("Exec GetClientInformation '"+clientId+"'", con);
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