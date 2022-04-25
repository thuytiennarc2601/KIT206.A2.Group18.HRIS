using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    enum Type { Lecture, Tutorial, Practical, Workshop, Undefined }

    enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}

    class Class
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

        public void AddClass(string code, Campus campus, Day day, TimeOnly start, TimeOnly end, Type type, string room, string staff)
        {
            Agency.AddClass(code, campus, day, start, end, type, room, staff);
        }
        public override string ToString()
        {
            return unit + " " + day + " " + StartTime + " " + EndTime;
        }
    }
}
