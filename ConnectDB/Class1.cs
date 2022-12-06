using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ConnectDB
{
    public class Class1
    {
        public class Connect
        {
            string connStr;
            MySqlConnection conn;

            public MySqlConnection Conn()
            {
                conn = new MySqlConnection(connStr);
                return conn;
            }
            public string RConn()
            {
                return connStr;
            }
            public Connect(string conn)
            {
                connStr = conn;
            }
        }
    }
}
