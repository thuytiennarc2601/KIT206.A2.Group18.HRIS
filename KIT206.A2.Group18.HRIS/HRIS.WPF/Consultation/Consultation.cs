using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    class Consultation
    {
        #region Properties
        public Staff staff { get; set; }

        public Day day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        #endregion
        public override string ToString()
        {

            return staff + " " + day + " " + StartTime + " " + EndTime;
        }
    }
}
