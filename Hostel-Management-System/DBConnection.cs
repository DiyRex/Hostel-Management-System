using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hostel_Management_System
{
    internal class DBConnection
    {
        // The connection
        private MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=users");

        // create a function to get the connection
        public MySqlConnection getConnection
        {
            get
            {
                return conn;
            }
        }

        // create a function to open the connection
        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        // create a function to close the connection
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }

}
