using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    enum Type { Lecture, Tutorial, Practical, Workshop }

    enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}

    class Class
    {
        #region Class Properties
        public Unit unit { get; set; }

        public Staff staff { get; set; }

        public Campus campus { get; set; }

        public Day day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public Type type { get; set; }

        public string Room { get; set; }
        #endregion

        private static MySqlConnection conn;

        #region Get All Classes at level 0
        //Retrieve all classes from database without staff or unit details
        public static List<Class> LoadAllClasses()
        {
            List<Class> classList = new List<Class>();

            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select unit_code, campus, day, type, start, end, room, staff from class", conn);
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Class classResult = new Class();
                    classResult.unit = new Unit();
                    classResult.staff = new Staff();

                    classResult.unit.UnitCode = rdr.GetString(0);
                    classResult.campus = (Campus)Enum.Parse(typeof(Campus), rdr.GetString(1));
                    classResult.day = (Day)Enum.Parse(typeof(Day), rdr.GetString(2));
                    /*
                    if(Convert.IsDBNull(rdr[3]) || rdr.GetString(3) =="")
                    {
                        classResult.type = Type.Undefined;
                    }
                    else
                    {
                    */
                        classResult.type = (Type)Enum.Parse(typeof(Type), rdr.GetString(3));
                    //}
                    
                    
                    classResult.StartTime = (TimeSpan)rdr[4];
                    classResult.EndTime = (TimeSpan)rdr[5];
                    classResult.Room = rdr.GetString(6);

                    if(Convert.IsDBNull(rdr[7]))
                    {
                        classResult.staff.ID = 0;
                    }
                    else
                    {
                        classResult.staff.ID = rdr.GetInt32(7);
                    }
                    classList.Add(classResult);
                }
            }
            finally
            {
                if(rdr != null)
                {
                    rdr.Close();
                }
                if(conn != null)
                {
                    conn.Close();
                }
            }

            return classList;
        }
        #endregion

        #region Get a Class list at level 1
        //get class list plus unit details 
        public static List<Class> getClassWithUnitDetails ()
        {
            List<Class> classList = Class.LoadAllClasses();
            List<Unit> unitList = Unit.LoadAllUnit();
            for (int i = 0; i < classList.Count; i++)
            {
                var result = from Unit u in unitList
                             where u.UnitCode == classList[i].unit.UnitCode
                             select u;
                List<Unit> resultList = new List<Unit>(result);

                classList[i].unit.UnitName = resultList[0].UnitName;
            }
            return classList;
        }

        #endregion

        #region Get class list at level 2
        //Get class list plus staff details and unit details
        public static List<Class> LoadFullClassList()
        {
            List<Class> classList = Class.getClassWithUnitDetails();
            List<Staff> staffList = Staff.LoadAllStaffList();

            for(int i = 0; i<classList.Count; i++)
            {
                var result = from Staff s in staffList
                             where s.ID == classList[i].staff.ID
                             select s;

                List<Staff> resultList = new List<Staff>(result);

                classList[i].staff.GivenName = resultList[0].GivenName;
                classList[i].staff.FamilyName = resultList[0].FamilyName;
                classList[i].staff.Title = resultList[0].Title;
                classList[i].staff.campus = resultList[0].campus;
            }
            return classList;
        }
        #endregion
    }
}
