/* 
 Author: Ferdous Hossain
 Opearation: Details Doucument sava as file or folder in data base as binary file. 
 create date: 0.01.2015
 Version:01
  */




using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ASPNetFileUpDownLoad.Utilities;
using System.Data.SqlClient;
using System.Configuration;



    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["user"] == null)
            {

                Server.Transfer("WebLogin.aspx");

            }
            
            
            //if (! IsPostBack)
            //{
            //    DataTable fileList = FileUtilities.GetFileList();
            //    gvFiles.DataSource = fileList;
            //    gvFiles.DataBind();
            //    Server.Transfer("WebLogin.aspx");
            //}
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Although I put only one http file control on the aspx page,
            // the following code can handle multiple file controls in a single aspx page.
            HttpFileCollection files = Request.Files;
            foreach (string fileTagName in files)
            {
                HttpPostedFile file = Request.Files[fileTagName];
                if (file.ContentLength > 0)
                {
                    // Due to the limit of the max for a int type, the largest file can be
                    // uploaded is 2147483647, which is very large anyway.
                    int size = file.ContentLength;
                     string userid = Session["user"].ToString();
                     //string name = file.FileName + "," + userid;
                     string name = file.FileName;

                    int position = name.LastIndexOf("\\");
                    name = name.Substring(position + 1);
                    string contentType = file.ContentType;
                    byte[] fileData = new byte[size];
                    file.InputStream.Read(fileData, 0, size);
                   

                   //FileUtilities.SaveFile(name, contentType, size, fileData);


                    using (SqlConnection connection = new SqlConnection())
                    {
                        OpenConnection(connection);

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandTimeout = 0;
                        //string user = Session["userID"].tostring();

                        string commandText = "INSERT INTO Files VALUES(@Name, @ContentType,@Size, @Data, ";
                        commandText = commandText + "@Size, @Data)";

                        //commandText = commandText + "@Size, @Data,@Cdate,@userid)";

                        //string commandText = "INSERT INTO Files(Name,ContentType,Size,Data,Cdate,userid) VALUES(, @ContentType,@Size, @Data,@Cdate,@userid) ";



                        cmd.CommandText = commandText;
                        cmd.CommandType = CommandType.Text;




                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@size", SqlDbType.Int);
                        cmd.Parameters.Add("@Data", SqlDbType.VarBinary);


                        //cmd.Parameters.Add("@Cdate", SqlDbType.Date);
                        //cmd.Parameters.Add("@userid", SqlDbType.NVarChar, 25);

                        string[] a = name.Split(',');

                        cmd.Parameters["@Name"].Value = name;
                        cmd.Parameters["@ContentType"].Value = contentType;
                        cmd.Parameters["@size"].Value = size;
                        cmd.Parameters["@Data"].Value = fileData;


                        //cmd.Parameters["@Cdate"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                        //cmd.Parameters["@userid"].Value = a[1];






                        cmd.ExecuteNonQuery();

                        connection.Close();
                   }







                }                
            }

            DataTable fileList = FileUtilities.GetFileList();
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();
        }


        private static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["DBConnectionString"];
        }

        private static void OpenConnection(SqlConnection connection)
        {
            connection.ConnectionString = GetConnectionString();
            connection.Open();
        }

    }
