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
    }
}
