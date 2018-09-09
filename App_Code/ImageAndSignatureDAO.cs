using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for ImageAndSignatureDAO
/// </summary>
public class ImageAndSignatureDAO
{
    SqlConnection con;
    SqlCommand cmd;
	public ImageAndSignatureDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region customerImage
    public int InsertCustomerImageAndSignature(byte[] image, byte[] signature, string customerId, string Creatby, string LastModifiedBy)
    {
      

        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES(@CustomerID,@CustomerImage,@CustomerSignature,@Creatby,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.VarChar).Value = customerId;
        cmd.Parameters.AddWithValue("@CustomerImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@CustomerSignature", SqlDbType.VarChar).Value = signature;
        cmd.Parameters.AddWithValue("@Creatby", SqlDbType.Image).Value = Creatby;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;

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
    public DataTable GetCustomerImageAndSignature(string condition)
    {

    
        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("select * from tblCustomerImage " + condition, con);
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
    public int UpdateCustomerImageAndSignature(byte[] image, byte[] signature, string customerId, string LastModifiedBy)
    {
       

        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblCustomerImage SET CustomerImage=@CustomerImage,CustomerSignature=@CustomerSignature,LastModifiedBy=@LastModifiedBy WHERE CustomerID=@CustomerID", con);
        cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.VarChar).Value = customerId;
        cmd.Parameters.AddWithValue("@CustomerImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@CustomerSignature", SqlDbType.VarChar).Value = signature;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;

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
    public int InsertCustomerImageAndSignatureHistory(byte[] image, byte[] signature, string customerId, string LastModifiedBy)
    {
       

        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblCustomerImageHistroy (CustomerID,CustomerImage,CustomerSignature,LastModifiedBy) VALUES(@CustomerID,@CustomerImage,@CustomerSignature,@LastModifiedBy)", con);
        cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.VarChar).Value = customerId;
        cmd.Parameters.AddWithValue("@CustomerImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@CustomerSignature", SqlDbType.VarChar).Value = signature;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;
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
    #region NomineeImage
    public int InsertNomineeImageAndSignature(byte[] image, byte[] signature, string nomineeID, string Creatby, string LastModifiedBy, string ClientID)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblNomineeImage (NomineeID,NomineeImage,NomineeSignature,Creatby,LastModifiedBy,ClientID) VALUES(@NomineeID,@NomineeImage,@NomineeSignature,@Creatby,@LastModifiedBy,@ClientID)", con);
        cmd.Parameters.AddWithValue("@NomineeID", SqlDbType.VarChar).Value = nomineeID;
        cmd.Parameters.AddWithValue("@NomineeImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@NomineeSignature", SqlDbType.VarChar).Value = signature;
        cmd.Parameters.AddWithValue("@Creatby", SqlDbType.Image).Value = Creatby;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;
        cmd.Parameters.AddWithValue("@ClientID", SqlDbType.VarChar).Value = ClientID;

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
    public DataTable GetNomineeImageAndSignature(string condition)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("select * from tblNomineeImage " + condition, con);
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
    public int UpdateNomineeImageAndSignature(byte[] image, byte[] signature, string nomineeID, string LastModifiedBy, string ClientID)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblNomineeImage SET NomineeImage=@NomineeImage,NomineeSignature=@NomineeSignature,LastModifiedBy=@LastModifiedBy WHERE nomineeID=@nomineeID and ClientID=@ClientID ", con);

        //cmd = new SqlCommand("INSERT INTO tblNomineeImageHistroy (NomineeImage,NomineeImage,NomineeSignature,Creatby,LastModifiedBy,ClientID) VALUES(@NomineeID,@NomineeImage,@NomineeSignature,@Creatby,@LastModifiedBy,@ClientID)", con);
        cmd.Parameters.AddWithValue("@NomineeID", SqlDbType.VarChar).Value = nomineeID;
        cmd.Parameters.AddWithValue("@NomineeImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@NomineeSignature", SqlDbType.VarChar).Value = signature;
      
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;
        cmd.Parameters.AddWithValue("@ClientID", SqlDbType.VarChar).Value = ClientID;

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
    public int InsertNomineeImageAndSignatureHistory(byte[] image, byte[] signature, string nomineeID, string LastModifiedBy, string ClientID)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblNomineeImageHistroy (NomineeID,NomineeImage,NomineeSignature,LastModifiedBy,ClientID) VALUES(@NomineeID,@NomineeImage,@NomineeSignature,@LastModifiedBy,@ClientID)", con);
        cmd.Parameters.AddWithValue("@NomineeID", SqlDbType.VarChar).Value = nomineeID;
        cmd.Parameters.AddWithValue("@NomineeImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@NomineeSignature", SqlDbType.VarChar).Value = signature;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;
        cmd.Parameters.AddWithValue("@ClientID", SqlDbType.VarChar).Value = ClientID;
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
    #region GurdianImage
    public int InsertGuardianImageAndSignature(byte[] image, byte[] signature, string guardianID, string Creatby, string LastModifiedBy, string nomineeID)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblGuardianImage (GuardianID,GuardianImage,GuardianSignature,Creatby,LastModifiedBy,NomineeID) VALUES(@GuardianID,@GuardianImage,@GuardianSignature,@Creatby,@LastModifiedBy,@NomineeID)", con);
        cmd.Parameters.AddWithValue("@GuardianID", SqlDbType.VarChar).Value = guardianID;
        cmd.Parameters.AddWithValue("@GuardianImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@GuardianSignature", SqlDbType.VarChar).Value = signature;
        cmd.Parameters.AddWithValue("@Creatby", SqlDbType.Image).Value = Creatby;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;
        cmd.Parameters.AddWithValue("@NomineeID", SqlDbType.VarChar).Value = nomineeID;

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
    public DataTable GetGuardianImageAndSignature(string condition)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        cmd = new SqlCommand("select * from tblGuardianImage " + condition, con);
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
    public int UpdateGuardianImageAndSignature(byte[] image, byte[] signature, string guardianID, string LastModifiedBy, string nomineeID)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("UPDATE tblGuardianImage SET GuardianImage=@GuardianImage,GuardianSignature=@GuardianSignature,LastModifiedBy=@LastModifiedBy WHERE NomineeID=@NomineeID and GuardianID=@GuardianID ", con);

        //cmd = new SqlCommand("INSERT INTO tblNomineeImageHistroy (NomineeImage,NomineeImage,NomineeSignature,Creatby,LastModifiedBy,ClientID) VALUES(@NomineeID,@NomineeImage,@NomineeSignature,@Creatby,@LastModifiedBy,@ClientID)", con);
        cmd.Parameters.AddWithValue("@GuardianID ", SqlDbType.VarChar).Value = guardianID;
        cmd.Parameters.AddWithValue("@GuardianImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@GuardianSignature", SqlDbType.VarChar).Value = signature;

        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;
        cmd.Parameters.AddWithValue("@NomineeID", SqlDbType.VarChar).Value = nomineeID;

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
    public int InsertGuardianImageAndSignatureHistory(byte[] image, byte[] signature, string guardianID, string LastModifiedBy, string nomineeID)
    {


        string constr = ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        int i = 0;
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        //cmd = new SqlCommand("INSERT INTO tblCustomerImage (CustomerID,CustomerImage,CustomerSignature,Creatby,LastModifiedBy) VALUES('" + customerId + "','" + image + "','" + signature + "','" + Creatby + "','" + LastModifiedBy + "')", con);
        cmd = new SqlCommand("INSERT INTO tblnomineeImageHistroy (GuardianeID,GuardianImage,GuardianSignature,LastModifiedBy,NomineeID) VALUES(@GuardianeID,@GuardianImage,@GuardianSignature,@LastModifiedBy,@NomineeID)", con);
        cmd.Parameters.AddWithValue("@GuardianeID", SqlDbType.VarChar).Value = guardianID;
        cmd.Parameters.AddWithValue("@GuardianImage", SqlDbType.Image).Value = image;
        cmd.Parameters.AddWithValue("@GuardianSignature", SqlDbType.VarChar).Value = signature;
        cmd.Parameters.AddWithValue("@LastModifiedBy", SqlDbType.VarChar).Value = LastModifiedBy;
        cmd.Parameters.AddWithValue("@NomineeID", SqlDbType.VarChar).Value = nomineeID;
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