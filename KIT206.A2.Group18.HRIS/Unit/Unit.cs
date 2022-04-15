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
        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public Staff Coordinator { get; set; }

        private static MySqlConnection conn;

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
                    unit.Coordinator = new Staff();
                    
                    unit.UnitCode = rdr.GetString(0);
                    unit.UnitName = rdr.GetString(1);
                    unit.Coordinator.ID = rdr.GetInt32(2);

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

        #region Load a unit list with staff details (title, name)
        public static List<Unit> LoadFullUnitList()
        {
            List<Unit> unitList = Unit.LoadAllUnit();
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            for(int i = 0; i<unitList.Count; i++)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select title, given_name, family_name from staff where id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", unitList[i].Coordinator.ID);
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        unitList[i].Coordinator.GivenName = rdr.GetString(1);
                        unitList[i].Coordinator.FamilyName = rdr.GetString(2);

                        if(Convert.IsDBNull(rdr[0]) || rdr.GetString(0) == "")
                        {
                            unitList[i].Coordinator.Title = "Unknown";
                        }
                        else
                        {
                            unitList[i].Coordinator.Title = rdr.GetString(0);
                        }
                    }
                }
                finally
                {
                    if(rdr!=null)
                    {
                        rdr.Close();
                    }
                    if(conn!=null)
                    {
                        conn.Close();
                    }
                }
            }

            return unitList;
        }
        #endregion
    }
}
