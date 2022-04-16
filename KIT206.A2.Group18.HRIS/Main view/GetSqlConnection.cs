using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    //for getting connection from database
    class GetSqlConnection
    {
        //return MySql connection
        private static MySqlConnection conn;

        private const string server = "alacritas.cis.utas.edu.au";
        private const string db = "hris";
        private const string user = "kit206g12a";
        private const string pwd = "group12a";

        public static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};" +
                    "User Id={2}; Password={3}", db, server, user, pwd);

                conn = new MySqlConnection(connectionString);
            }

            return conn;
        }
    }
}
