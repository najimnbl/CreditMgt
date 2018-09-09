using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ClientTypeDAO
/// </summary>
public class EmployeeInfoDAO
{
    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
    SqlCommand cmd;


    public EmployeeInfoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region EmployeeInfo

    public int InsertEmployeeInfo(EmployeeInfoEntity oEmployeeInfoEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("INSERT INTO tblEmployeeInfo (EmployeeID,EmployeeName,Designation,RegistrationNo,BranchCode,MobileNo,CreateBy,LastModifiedBy) VALUES('" + oEmployeeInfoEntity.EmployeeID + "','" + oEmployeeInfoEntity.EmployeeName + "','" + oEmployeeInfoEntity.Designation + "','" + oEmployeeInfoEntity.RegistrationNo + "','" + oEmployeeInfoEntity.BranchCode + "','" + oEmployeeInfoEntity.MobileNo + "','" + oEmployeeInfoEntity.CreateBy + "','" + oEmployeeInfoEntity.LastModifiedBy  + "')", con);
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

    public DataTable GetEmployeeInfo(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select * from tblEmployeeInfo " + condition, con);
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




    public int DeleteEmployeeInfo(EmployeeInfoEntity oEmployeeInfoEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("DELETE FROM tblEmployeeInfo WHERE ID=" + oEmployeeInfoEntity.ID , con);
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

    public DataTable GetEmployeeInfoView(string condition)
    {
        con = oConnectionDatabase.DatabaseConnection();
        cmd = new SqlCommand("select ID, EmployeeID,EmployeeName,Designation,RegistrationNo,BranchCode,MobileNo from tblEmployeeInfo " + condition, con);
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

    public int UpdateEmployeeInfo(EmployeeInfoEntity oEmployeeInfoEntity)
    {
        con = oConnectionDatabase.DatabaseConnection();
        int i = 0;
        cmd = new SqlCommand("UPDATE  tblEmployeeInfo SET EmployeeID='" + oEmployeeInfoEntity.EmployeeID + "',EmployeeName='" + oEmployeeInfoEntity.EmployeeName + "',Designation='" + oEmployeeInfoEntity.Designation + "',RegistrationNo='" + oEmployeeInfoEntity.RegistrationNo + "', BranchCode ='" + oEmployeeInfoEntity.BranchCode + "', MobileNo ='" + oEmployeeInfoEntity.MobileNo + "', LastModifiedBy ='" + oEmployeeInfoEntity.LastModifiedBy + "' WHERE ID=" + oEmployeeInfoEntity.ID , con);
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