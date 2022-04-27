﻿using System;
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

        public override string ToString()
        {
            return type.ToString() + " | " + day + " | " + StartTime + " - " + EndTime + " | " + Room + " | " + campus.ToString();
        }

        #region Get A List Of Classes Of A Unit
        public static List<Class> GetClassesByUnitCode(string UnitCode)
        {
            List<Class> classList = Agency.LoadAllClasses();
            var getClass = from Class c in classList
                           where c.unit.UnitCode == UnitCode
                           select c;

            List<Class> result = new List<Class>(getClass);

            return result;
        }
        #endregion

        #region Get A Specific Class Based On Its Unitcode, Day, Campus, StartTime
        public static Class GetClassByPrimaryKeys(string code, string day, string campus, TimeOnly start)
        {
            Class thisClass = new Class();

            Campus enumCampus = Agency.ParseEnum<Campus>(campus);
            Day enumDay = Agency.ParseEnum<Day>(day);


            List<Class> classList = Agency.LoadAllClasses();
            var getClass = from Class c in classList
                           where c.unit.UnitCode == code && c.day == enumDay && c.campus == enumCampus && c.StartTime == start
                           select c;
            List<Class> result = new List<Class>(getClass);
            if(result.Count > 0)
            {
                thisClass = result[0];
            } else { thisClass.unit.UnitCode = ""; }

            return thisClass;   
        }
        #endregion
    }
}
