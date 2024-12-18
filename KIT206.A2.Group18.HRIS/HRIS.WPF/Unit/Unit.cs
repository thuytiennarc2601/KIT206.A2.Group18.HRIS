﻿using System;
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

        #region Check If A Unit Exist Or Not
        public static Unit CheckUnitExist(string code)
        {
            Unit unit = new Unit();
            List<Unit> unitList = new List<Unit>();
            var getUnit = from Unit u in unitList
                          where u.UnitCode == code
                          select u;
            List<Unit> result = new List<Unit>(getUnit);
            if(result.Count > 0)
            {
                unit = result[0];
            }else { unit.UnitCode = ""; }
            return unit;
        }
        #endregion

        #region Return A Unit List By Its Staff's ID
        public static List<Unit> GetUnitsByStaffID(int StaffID)
        {
            List<Unit> unitList = Unit.LoadAllUnits();
            var getUnit = from Unit u in unitList
                          where u.Coordinator.ID == StaffID
                          select u;
            List<Unit> resultUnit = new List<Unit>(getUnit);

            return resultUnit;
        }
        #endregion

        #region Load All Units
        public static List<Unit> LoadAllUnits()
        {
            List<Unit> unitList = Agency.LoadAllUnits();
            return unitList;
        }
        #endregion

        #region Get A Unit By Unit Code
        public static Unit GetUnitByCode(string code)
        {
            Unit unit = Agency.GetUnitByUnitCode(code);
            return unit;
        }
        #endregion

        #region Update Unit Coordinator
        public static void UpdateUnitCoordinator(string code, int id)
        {
            Agency.UpdateUnitCoordinator(code, id);
        }
        #endregion

        #region Add A New Unit
        public static void AddUnit(string code, string title, int id)
        {
            Agency.AddNewUnit(code, title, id);
        }
        #endregion
    }
}
