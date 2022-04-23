using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HRIS.WPF
{
    public enum Type { Lecture, Tutorial, Practical, Workshop }

    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}

    public class Class
    {
        #region Class Properties
        public Unit unit { get; set; }

        public Staff staff { get; set; }

        public Campus campus { get; set; }

        public Day day { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public Type type { get; set; }

        public string Room { get; set; }
        #endregion

        public override string ToString()
        {
            return unit + " " + day + " " + StartTime + " " + EndTime;
        }
    }
}
