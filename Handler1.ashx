<%@ WebHandler Language="C#" Class="Handler1" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class Handler1 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string displayimgid = context.Request.QueryString["id_Image"].ToString();
        string tableName = context.Request.QueryString["table_name"].ToString();
        string columnName = context.Request.QueryString["column_name"].ToString();
        string condition = context.Request.QueryString["condition"].ToString();
        SqlConnection con;
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ImageDBConnection"].ToString();
        con = new SqlConnection(constr);
        try { con.Open(); }
        catch { }
        SqlCommand cmd = new SqlCommand("select " + columnName + " from " + tableName + condition +"'" + displayimgid + "'", con);
       
        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        context.Response.BinaryWrite((Byte[])dr[0]);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}