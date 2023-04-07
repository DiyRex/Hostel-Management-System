using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Hostel_Management_System;
using MySql.Data.MySqlClient;

namespace Hostel_Management_System
{
    internal class SQLiteConn
    {
        private SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\Projects\\C#\\Visual Studio\\Databases\\users.db; Version = 3; New = True; Compress = True; ");
        public SQLiteConnection getConnection
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
