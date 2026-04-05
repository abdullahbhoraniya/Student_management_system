using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    internal class DBConnection
    {

        public string GetConnectionString()
        {
            //read connection string from web.config

            string connectionString =  ConfigurationManager.AppSettings["connection_string"];

            return connectionString;
        }

        public SqlConnection GetConnection()
        {

            SqlConnection connection = null;    

            connection = new SqlConnection();
            connection.ConnectionString = GetConnectionString();
            
            return connection;  
        }

    }
}
