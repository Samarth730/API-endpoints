using System.Data;
using System.Data.SqlClient;


namespace TalukMasterInformation.DataBaseLAyer
{
    public class DBTalukLayer
    {
        public String conn = string.Empty;

        public DBTalukLayer() 
        {
            var connstring = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["dbcs"];
            conn = Convert.ToString(connstring);
        }
        public DataTable GetDataTable(String query)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();


            sqlCommand.CommandText = query;
            sqlConnection.ConnectionString = conn;
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;






        }
        public int ExecuteOnlyQuery(string query)
        {
            SqlConnection sqlConn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = query;
            sqlConn.ConnectionString = conn;
            sqlConn.Open();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.Text;
            int count = cmd.ExecuteNonQuery();
            sqlConn.Close();
            return count;
        }


    }
}
