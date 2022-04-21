using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace KIT206.A2.Group18.HRIS
{
    //for getting connection from database
    class Agency
    {
        private static bool reportingErrors = false;

        //return MySql connection
        private static MySqlConnection conn;

        private const string server = "alacritas.cis.utas.edu.au";
        private const string db = "hris";
        private const string user = "kit206g12a";
        private const string pwd = "group12a";

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        public static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};" +
                    "User Id={2}; Password={3}", db, server, user, pwd);

                conn = new MySqlConnection(connectionString);
            }

            return conn;
        }

        #region Get All Classes at level 0
        //Retrieve all classes from database without staff or unit details
        public static List<Class> LoadAllClasses()
        {
            List<Class> classList = new List<Class>();

            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select unit_code, campus, day, type, start, end, room, staff from class", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    classList.Add(new Class { 
                        unit = new Unit { UnitCode = rdr.GetString(0) }, 
                        campus = ParseEnum<Campus>(rdr.GetString(1)), 
                        day = ParseEnum<Day>(rdr.GetString(2)), 
                        type = ParseEnum<Type>(rdr.GetString(3)), 
                        StartTime = rdr.GetTimeSpan(4), 
                        EndTime = rdr.GetTimeSpan(5), 
                        Room = rdr.GetString(6), 
                        staff = new Staff { ID = rdr.GetInt32(7) } 
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading classes", e);
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

            return classList;
        }
        #endregion
       
        /*
        #region Get a Class list at level 1
        //get class list plus unit details 
        public static List<Class> getClassWithUnitDetails()
        {
            List<Class> classList = LoadAllClasses();
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
        */
        #region
        //Retrieve all units from database
        public static List<Unit> LoadAllUnits()
        {
            List<Unit> unitList = new List<Unit>();

            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select code, title, coordinator from unit", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    unitList.Add(new Unit
                    {
                        UnitCode = rdr.GetString(0),
                        UnitName = rdr.GetString(1),
                        Coordinator = new Staff { ID = rdr.GetInt32(2) },
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading units", e);
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

            return unitList;
        }
        #endregion
        #region
        //Retrieve all consultations from database
        public static List<Consultation> LoadAllConsultations()
        {
            List<Consultation> consultationList = new List<Consultation>();

            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select staff_id, day, start, end from consultation", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    consultationList.Add(new Consultation
                    {
                        staff = new Staff { ID = rdr.GetInt32(0) },
                        day = ParseEnum<Day>(rdr.GetString(1)),
                        StartTime = rdr.GetTimeSpan(2),
                        EndTime = rdr.GetTimeSpan(3)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading consultations", e);
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

            return consultationList;
        }
        #endregion
        #region
        //Retrieve all staffs from database
        public static List<Staff> LoadAllStaffs()
        {
            List<Staff> staffList = new List<Staff>();

            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, campus, phone, room, email, photo, category from staff", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    staffList.Add(new Staff
                    {
                        ID = rdr.GetInt32(0),
                        GivenName = rdr.GetString(1),
                        FamilyName = rdr.GetString(2),
                        Title = rdr.GetString(3),
                        campus = ParseEnum<Campus>(rdr.GetString(4)),
                        Phone = rdr.GetString(5),
                        Room = rdr.GetString(6),
                        Email = rdr.GetString(7),
                        //Photo = (byte[]) rdr[8],
                        category = ParseEnum<Category>(rdr.GetString(9))
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading staffs", e);
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

            return staffList;
        }
        #endregion
        #region
        public static List<Consultation> LoadConsultations(int id)
        {
            List<Consultation> consultations = new List<Consultation>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select staff_id, day, start, end" +
                                                    "from consultation" +
                                                    "where staff_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    consultations.Add(new Consultation
                    {
                        staff = new Staff { ID = rdr.GetInt32(0) },
                        day = ParseEnum<Day>(rdr.GetString(1)),
                        StartTime = rdr.GetTimeSpan(2),
                        EndTime = rdr.GetTimeSpan(3)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading consultations for staff selected", e);
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

            return consultations;
        }
        #endregion
        #region
        public static List<Class> LoadClasses(int id)
        {
            List<Class> classes = new List<Class>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select unit_code, campus, day, start, end, type, room, staff" +
                                                    "from class" +
                                                    "where staff=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    classes.Add(new Class
                    {
                        unit = new Unit { UnitCode = rdr.GetString(0) },
                        campus = ParseEnum<Campus>(rdr.GetString(1)),
                        day = ParseEnum<Day>(rdr.GetString(2)),
                        type = ParseEnum<Type>(rdr.GetString(3)),
                        StartTime = rdr.GetTimeSpan(4),
                        EndTime = rdr.GetTimeSpan(5),
                        Room = rdr.GetString(6),
                        staff = new Staff { ID = rdr.GetInt32(7) }
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading classes for staff selected", e);
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

            return classes;
        }
        #endregion
        /*
        #region Get class list at level 2
        //Get class list plus staff details and unit details
        public static List<Class> LoadFullClassList()
        {
            List<Class> classList = Class.getClassWithUnitDetails();
            List<Staff> staffList = Staff.LoadAllStaffList();

            for (int i = 0; i < classList.Count; i++)
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
        */
        private static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
