using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace HRIS.WPF
{
    class Consultation
    {
        #region Properties
        public Staff staff { get; set; }

        public Day day { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
        #endregion
        public override string ToString()
        {

            return staff + " " + day + " " + StartTime + " " + EndTime;
        }
    }
}
