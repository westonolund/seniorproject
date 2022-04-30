using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace DataAccessLayer
{
    public class DBConnection
    {
        private string connectionString;
        public MySqlConnection connection;
        string server = "baseballdatabase.cpz0as23ed7o.us-east-2.rds.amazonaws.com";
        string database = "BaseballDatabase";
        string userid = "admin";
        string password = "password";

        public DBConnection()
        {
        connectionString = "server=" + server + ";database=" + database + ";uid=" + userid + ";pwd=" + password + ";";
        connection = new MySqlConnection(connectionString);
        }

        
        public void connectToDatabase()
		{
            try
			{
                connection.Open();
			}
            catch(MySqlException ex)
			{
                throw new Exception(ex.Message);
			}
		}

        public void closeDatabase()
		{
            connection.Close();
		}
    }
}
