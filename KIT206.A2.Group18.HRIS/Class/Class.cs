using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    enum Type { Lecture, Tutorial, Practical, Workshop, Undefined}

    enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}

    class Class
    {
        public Unit unit { get; set; }

        public Staff staff { get; set; }

        public Campus campus { get; set; }

        public Day day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public Type type { get; set; }

        public string Room { get; set; }

        private static MySqlConnection conn;

        #region Get All Classes
        //Retrieve all classes from database
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

                    if(Convert.IsDBNull(rdr[3]) || rdr.GetString(3) =="")
                    {
                        classResult.type = Type.Undefined;
                    }
                    else
                    {
                        classResult.type = (Type)Enum.Parse(typeof(Type), rdr.GetString(3));
                    }

                    
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

        #region Get a Class list with full unit details (code, title, staffID
        public static List<Class> getClassWithUnitDetails ()
        {
            List<Class> classList = Class.LoadAllClasses();

            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            for(int i = 0; i<classList.Count; i++)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select title from unit where code=@code", conn);
                    cmd.Parameters.AddWithValue("@code", classList[i].unit.UnitCode);
                    rdr = cmd.ExecuteReader();
                    {
                        while(rdr.Read())
                        {
                            classList[i].unit.UnitName = rdr.GetString(0);
                        }
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
            }
            return classList;
        }

        #endregion

        #region Get class list with unit details and staff details (title, name)
        public static List<Class> LoadFullClassList()
        {
            List<Class> classList = Class.getClassWithUnitDetails();
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            for(int i=0; i<classList.Count;i++)
            {
                if (classList[i].staff.ID != 0)
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("select title, given_name, family_name, campus from staff where id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", classList[i].staff.ID);
                        rdr = cmd.ExecuteReader();
                        while(rdr.Read())
                        {
                            classList[i].staff.GivenName = rdr.GetString(1);
                            classList[i].staff.FamilyName = rdr.GetString(2);
                            if(Convert.IsDBNull(rdr[0]) || rdr.GetString(0) == "")
                            {
                                classList[i].staff.Title = "Unknown";
                            }
                            else
                            {
                                classList[i].staff.Title = rdr.GetString(0);
                            }

                            if (Convert.IsDBNull(rdr[3]) || rdr.GetString(3) == "")
                            {
                                classList[i].staff.campus = Campus.Notlocated;
                            }
                            else
                            {
                                classList[i].staff.campus = (Campus)Enum.Parse(typeof(Campus), rdr.GetString(3));
                            }
                        }
                    }
                    finally
                    {
                        if (rdr != null)
                        {
                            rdr.Close();
                        }
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            return classList;
        }
        #endregion
    }
}
