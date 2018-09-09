using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ASPNetFileUpDownLoad.Utilities
{
    public class FileUtilities
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["DBConnectionString"];
        }

        private static void OpenConnection(SqlConnection connection)
        {
            connection.ConnectionString = GetConnectionString();
            connection.Open();
        }

        // Get the list of the files in the database
        public static DataTable GetFileList()
        {
            DataTable fileList = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                cmd.CommandText = "SELECT ID, Name, ContentType, Size FROM Files";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = cmd;
                adapter.Fill(fileList);

                connection.Close();
            }

            return fileList;
        }

        // Save a file into the database
        public static void SaveFile(string name, string contentType,int size, byte[] data,string userid)
        {
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
                cmd.Parameters["@Data"].Value = data;


                //cmd.Parameters["@Cdate"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                //cmd.Parameters["@userid"].Value = a[1];


                    



                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        // Get a file from the database by ID
        public static DataTable GetAFile(int id)
        {
            DataTable file = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                cmd.CommandText = "SELECT ID, Name, ContentType, Size, Data FROM Files "
                    + "WHERE ID=@ID";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = id;

                adapter.SelectCommand = cmd;
                adapter.Fill(file);

                connection.Close();
            }

            return file;
        }
    }
}