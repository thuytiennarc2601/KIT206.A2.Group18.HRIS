using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace HRIS.WPF
{
    public class Unit
    {
        #region Unit Properties
        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public Staff Coordinator { get; set; }
        #endregion
        public override string ToString()
        {

            return UnitName; //+ " by " + Coordinator.GivenName + " " + Coordinator.FamilyName;
        }
    }
}
