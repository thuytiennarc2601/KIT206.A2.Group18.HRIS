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
        #region Unit Properties
        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public Staff Coordinator { get; set; }
        #endregion

        private static MySqlConnection conn;

        #region Load all units at level 0
        //Load all units from database without staff details
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

        #region Load a unit list at level 1
        //get all units with staff details
        public static List<Unit> LoadFullUnitList()
        {
            List<Unit> unitList = Unit.LoadAllUnit();
            List<Staff> staffList = Staff.LoadAllStaffList();

            for(int i = 0; i<unitList.Count; i++)
            {
                var result = from Staff s in staffList
                             where s.ID == unitList[i].Coordinator.ID
                             select s; //LINQ

                List<Staff> resultList = new List<Staff>(result);

                unitList[i].Coordinator.GivenName = resultList[0].GivenName;
                unitList[i].Coordinator.FamilyName = resultList[0].FamilyName;
                unitList[i].Coordinator.Title = resultList[0].Title;

            }
            return unitList;
        }
        #endregion
    }
}
