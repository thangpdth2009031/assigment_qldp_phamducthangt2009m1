using System.Data;
using MySql.Data.MySqlClient;

namespace QuanLyDuongPho.helper
{
    public class ConnectionHelper
    {
        private static string server = "localhost";
        private static string database = "t2009031_duongpho";
        private static string uid = "root";
        private static string password = "";
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
                                   database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "convert zero datetime=True" + ";";

                connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            else
            {
                return connection;
            }
        }
    }
}