/* 
 Author: Ferdous Hossain
 Opearation: File Save Object recive here. 
 create date: 0.09.2015
 Version:01
  */


using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ASPNetFileUpDownLoad.Utilities;

//namespace ASPNetFileUpDownLoad
//{
    public partial class GetFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the file id from the query string
            int id = Convert.ToInt16(Request.QueryString["ID"]);

            // Get the file from the database
            DataTable file = FileUtilities.GetAFile(id);
            DataRow row = file.Rows[0];

            string name = (string)row["Name"];
            string contentType = (string)row["ContentType"];
            Byte[] data = (Byte[])row["Data"];

            // Send the file to the browser
            Response.AddHeader("Content-type", contentType);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
            Response.BinaryWrite(data);
            Response.Flush();
            Response.End();
        }
    }
//}