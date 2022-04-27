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
        public override string ToString()
        {
            return UnitCode.ToUpper() + " | " + UnitName;
        }

        #region Return A Unit List By Its Staff's ID
        public static List<Unit> GetUnitsByStaffID(int StaffID)
        {
            List<Unit> unitList = Agency.LoadAllUnits();
            var getUnit = from Unit u in unitList
                          where u.Coordinator.ID == StaffID
                          select u;
            List<Unit> resultUnit = new List<Unit>(getUnit);

            return resultUnit;
        }
        #endregion

        #region Get A Unit By Its UnitCode
        public static Unit GetUnitByCode(string UnitCode)
        {
            List<Unit> unitList = Agency.LoadAllUnits();
            Unit unit = new Unit();
            var getUnit = from Unit u in unitList
                          where u.UnitCode.ToLower() == UnitCode.ToLower()
                          select u;

            List<Unit> result = new List<Unit>(getUnit);

            if (result.Count > 0)
            {
                unit = result[0];
            } else { unit.UnitCode = ""; }
            return unit;
        }
        #endregion

        #region Get A Unit By Its Title
        public static Unit GetUnitByTitle(string UnitName)
        {
            List<Unit> unitList = Agency.LoadAllUnits();
            Unit unit = new Unit();
            var getUnit = from Unit u in unitList
                          where u.UnitName.ToLower() == UnitName.ToLower()
                          select u;

            List<Unit> result = new List<Unit>(getUnit);
            if (result.Count > 0)
            {
                unit = result[0];
            } else { unit.UnitName = ""; }

            return unit;
        }
        #endregion

        #region Get A Unit By Search Text
        public static List<Unit> GetUnitsBySearchText(string searchText)
        {
            List<Unit> unitList = Agency.LoadAllUnits();

            var getUnit = from Unit u in unitList
                          where u.UnitCode.ToLower().Contains(searchText.ToLower()) || u.UnitName.ToLower().Contains(searchText.ToLower())
                          select u;

            List<Unit> result = new List<Unit>(getUnit);

            return result;
        }

        #endregion
    }
}
