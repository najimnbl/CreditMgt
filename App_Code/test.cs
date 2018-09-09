using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for test
/// </summary>
public class test
{
    //public test()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    ConnectionDatabase oConnectionDatabase = new ConnectionDatabase();
    SqlConnection con;
        SqlCommand cmd;
        public DataTable LoadGridView()
        {
            con =oConnectionDatabase.DatabaseConnection();
            cmd = new SqlCommand("select * from tblCountry", con);
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

}