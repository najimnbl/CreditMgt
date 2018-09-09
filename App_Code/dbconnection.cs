using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for dbconnection
/// </summary>
public class dbconnection
{
    public static SqlConnection connection()
    {
        string conn = "";
        conn = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlConnection objsqlconn = new SqlConnection(conn);
        objsqlconn.Open();
        return objsqlconn;
    }
}