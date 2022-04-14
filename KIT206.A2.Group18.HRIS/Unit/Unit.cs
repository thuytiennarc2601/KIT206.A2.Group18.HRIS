using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    class Unit
    {
        private static MySqlConnection conn;

        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public int Coordinator { get; set; }

        #region Load all units
        //Load all units from database
        public static List<Unit> LoadAllUnit()
        {
            List<Unit> unitList = new List<Unit>();
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select code, title, coordinator from unit", conn);
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Unit unit = new Unit();
                    
                    unit.UnitCode = rdr.GetString(0);
                    unit.UnitName = rdr.GetString(1);
                    unit.Coordinator = rdr.GetInt32(2);

                    unitList.Add(unit);
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }

            return unitList;
        }
        #endregion

        #region Get coordinator name
        //get the unit coordinator details from database
        public static string getCoordinatorName (int staffID)
        {
            string name = "";
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title from staff where id='" + staffID + "'", conn);

                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    string givenName = rdr.GetString(0);
                    string familyName = rdr.GetString(1);

                    string title = "";
                    if (rdr.GetString(2) == "")
                    {
                        title = "Unknown";
                    }
                    else
                    {
                        title = rdr.GetString(2);
                    }

                    name = title + ". " + givenName + " " + familyName;
                }
            }
            finally
            {
                if(rdr != null)
                {
                    rdr.Close();
                }
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return name;
        }
        #endregion
    }
}
