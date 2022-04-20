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

        public DBConnection()
        {
        connectionString = "server=localhost;database=BaseballDatabase;uid=admin;pwd=password;";
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
