
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
//using ASPNetFileUpDownLoad.Utilities;
using System.Data.SqlClient;
using System.Configuration;

public partial class AplicationDocumentUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            DataTable fileList = GetFileList(Session["user"].ToString());
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
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

                string[] a = name.Split('.');

                string Aplication = a[0].ToString();

                ReturnVal oRtnValue = new ReturnVal();
                string ApplicationHave = oRtnValue.ReturnValue("LoanAplication", "AcountNo", "'" + Aplication + "'", "AcountNo");

                if (ApplicationHave == "")
                {

                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "MessageBox", "alert('Submit Aplication First and Make file Name same as Aplication No')", true);

                    return;
                }


                string filecount = oRtnValue.ReturnValue("Files", "AcountNo", "'" + Aplication + "'", "count(*)");

                string NameWithVersion = a[0].ToString() +"."+ "" +filecount+"."+ a[1].ToString();



                using (SqlConnection connection = new SqlConnection())
                {
                    OpenConnection(connection);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    //string user = Session["userID"].tostring();

                    string commandText = "INSERT INTO Files (Name,ContentType,Size,Data,Cdate,userid,brCode,AcountNo) VALUES(@Name, @ContentType, ";
                    commandText = commandText + "@Size, @Data,@Cdate,@userid,@brCode,@AcountNo)";

                   
                    cmd.CommandText = commandText;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@size", SqlDbType.Int);
                    cmd.Parameters.Add("@Data", SqlDbType.VarBinary);

                    cmd.Parameters.Add("@Cdate", SqlDbType.Date);
                    cmd.Parameters.Add("@userid", SqlDbType.NVarChar, 25);
                    cmd.Parameters.Add("@brCode", SqlDbType.NVarChar, 3);
                    cmd.Parameters.Add("@AcountNo", SqlDbType.NVarChar, 25);

                    //string[] a = name.Split(',');AcountNo

                    cmd.Parameters["@Name"].Value = NameWithVersion;
                    cmd.Parameters["@ContentType"].Value = contentType;
                    cmd.Parameters["@size"].Value = size;
                    cmd.Parameters["@Data"].Value = fileData;

                    cmd.Parameters["@Cdate"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cmd.Parameters["@userid"].Value = userid;
                    cmd.Parameters["@brCode"].Value = name.Substring(3,3);
                    cmd.Parameters["@AcountNo"].Value = Aplication;

                    cmd.ExecuteNonQuery();

                    connection.Close();


                }

            }
        }

        DataTable fileList = GetFileList(Session["user"].ToString());
        gvFiles.DataSource = fileList;
        gvFiles.DataBind();

    }

  
    private static void OpenConnection(SqlConnection connection)
    {
        connection.ConnectionString = GetConnectionString();
        connection.Open();
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.AppSettings["DBConnectionString"];
    }


    public static DataTable GetFileList(string userid)
    {
        DataTable fileList = new DataTable();
        using (SqlConnection connection = new SqlConnection())
        {
            OpenConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;


            ReturnVal oRtnValue = new ReturnVal();
            string usertype = oRtnValue.ReturnValue("tblUserInfo", "userid", "'" + userid + "'", "usertype");


            if (usertype == "Admin")
            {
                cmd.CommandText = "Select ID,FileName,Uploaded_Date,BranchName,Uploaded_By,UserType from dbo.View_Loan_info_For_admin";
            }
            else
            {
                cmd.CommandText = "Select  ID,FileName,Uploaded_Date,BranchName,Uploaded_By,UserType from dbo.View_Fileinfo_Details where HaveAccessUser='" + userid + "'";
            }
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;
            adapter.Fill(fileList);

            connection.Close();
        }

        return fileList;
    }



}