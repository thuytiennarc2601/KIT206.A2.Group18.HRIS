using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    enum Type { Lecture, Tutorial, Practical, Workshop}

    enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, NA}

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

        public override string ToString()
        {
            return type.ToString() + " | " + day + " | " + StartTime + " - " + EndTime + " | " + Room + " | " + campus.ToString();
        }

        #region Get A List Of Classes Of A Unit
        public static List<Class> GetClassesByUnitCode(string UnitCode)
        {
            List<Class> classList = Class.LoadAllClasses();
            var getClass = from Class c in classList
                           where c.unit.UnitCode == UnitCode
                           select c;

            List<Class> result = new List<Class>(getClass);

            return result;
        }
        #endregion

        #region Load All Classes
        public static List<Class> LoadAllClasses()
        {
            List<Class> classList = Agency.LoadAllClasses();
            return classList;
        }
        #endregion

        #region Edit Class Details
        public static void EditClassDetails(string code, string day, string campus, string start, string new_day, string new_start, string end, string type, string room, int staff)
        {
            Class.EditClassDetails(code, day, campus, start, new_day, new_start, end, type, room, staff);
        }
        #endregion

        #region Add A New Class
        public static void AddClass(string code, string campus, string day, string start, string end, string type, string room, int staff)
        {
            Agency.AddClass(code, campus, day, start, end, type, room, staff);
        }
        #endregion

        #region Check If A Class Room Is Available Or Not
        public static bool CheckClass(string campus, string day, string start, string end, string room, int staff)
        {
            bool valid = Agency.checkValidateClass(campus, day, start, end, room, staff);
            return valid;
        }
        #endregion

        #region Check If A Staff Is Available Or Not
        public static bool CheckClassClash(string day, string start, string end, int staff)
        {
            bool valid = Agency.checkClassClash(day, start, end, staff);
            return valid;
        }
        #endregion
    }
}
