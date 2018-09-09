using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

public  class ReturnVal
{
    public string ReturnValue(string tbl, string fld1, string val, string fld2)
    {
        string getValue = "";
        string query;
        try
        {



            SqlConnection conn = dbconnection.connection();
         
            //con.Open();
            if (val == "" || fld2 == "")
            {
                query = "select " + fld2 + " from " + tbl + "";
            }
            else
            {
                query = "select " + fld2 + " from " + tbl + " where " + fld1 + "=" + val;
            }
            SqlCommand com = new SqlCommand(query, conn);
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr[0] != System.DBNull.Value)
                {
                    getValue = (rdr[0].ToString());
                }
            }

            return getValue;
        }
        catch (Exception)
        {
            throw ;
        }

    }
}