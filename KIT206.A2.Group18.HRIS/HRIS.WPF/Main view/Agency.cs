using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace KIT206.A2.Group18.HRIS
{
    //establishes connection with database, contains all functions relating to database
    class Agency
    {
        private static bool reportingErrors = false;

        //return MySql connection
        private static MySqlConnection conn;

        private const string server = "alacritas.cis.utas.edu.au";
        private const string db = "hris";
        private const string user = "kit206g12a";
        private const string pwd = "group12a";
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

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        #region Load All Classes
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
                        StartTime = TimeOnly.ParseExact(rdr.GetString(4), "HH:mm:ss"),
                        EndTime = TimeOnly.ParseExact(rdr.GetString(5), "HH:mm:ss"), 
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


        #region Load All Units
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
        #region Load All Consultations
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
                        StartTime = TimeOnly.ParseExact(rdr.GetString(2), "HH:mm:ss"),
                        EndTime = TimeOnly.ParseExact(rdr.GetString(3), "HH:mm:ss"),
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
        #region Load All Staff from HRIS database
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
                    Staff result = new Staff();
                    result.ID = rdr.GetInt32(0);
                    result.GivenName = rdr.GetString(1);
                    result.FamilyName = rdr.GetString (2);

                    if (Convert.IsDBNull(rdr[3]) || rdr.GetString(3) == "")
                    {
                        result.Title = "Unknown";
                    }
                    else { result.Title = rdr.GetString(3); }

                    if(Convert.IsDBNull(rdr[4]) || rdr.GetString(4) == "")
                    {
                        result.campus = Campus.Unknown;
                    }
                    else { result.campus = ParseEnum<Campus>(rdr.GetString(4)); }

                    if(Convert.IsDBNull(rdr[5]) || rdr.GetString(5) == "")
                    {
                        result.Phone = "No contact added";
                    }
                    else { result.Phone = rdr.GetString(5); }

                    if(Convert.IsDBNull(rdr[6]) || rdr.GetString(6) == "")
                    {
                        result.Room = "Unknown";
                    }
                    else { result.Room = rdr.GetString(6); }

                    if(Convert.IsDBNull(rdr[7]) || rdr.GetString(7) == "")
                    {
                        result.Email = "No email added";
                    }
                    else { result.Email = rdr.GetString(7); }

                    if(!Convert.IsDBNull(rdr[8]))
                    {
                        result.Photo = (byte[])rdr[8];
                    }

                    if(Convert.IsDBNull(rdr[9]) || rdr.GetString(9) == "")
                    {
                        result.category = Category.uncategorised;
                    }
                    else { result.category = ParseEnum<Category>(rdr.GetString(9)); }

                    staffList.Add(result);
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
                        StartTime = TimeOnly.ParseExact(rdr.GetString(2), "HH:mm:ss"),
                        EndTime = TimeOnly.ParseExact(rdr.GetString(3), "HH:mm:ss"),
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
                        StartTime = TimeOnly.ParseExact(rdr.GetString(4), "HH:mm:ss"),
                        EndTime = TimeOnly.ParseExact(rdr.GetString(5), "HH:mm:ss"),
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
        #region
        public static void DeleteConsultation(int id, Day day, TimeOnly Start, TimeOnly End)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("delete " +
                                                    "from class" +
                                                    "where (staff_id=?id) and (day=?day) and (start=?Start) and (end=?End)", conn);

                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("day", day);
                cmd.Parameters.AddWithValue("start", Start);
                cmd.Parameters.AddWithValue("end", End);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportError("deleting consultation selected", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        public static void AddClass(string code, Campus campus, Day day, TimeOnly start, TimeOnly end, Type type, string room, string staff)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO researcher (code, campus, day, start, end, type, room, staff)" +
                                                    "VALUE (@code, @campus, @day, @start, @end, @type, @room, @staff", conn);
                cmd.ExecuteNonQuery();
                cmd.AddWithValue("@code", code);


            }
            catch (MySqlException e)
            {
                ReportError("Adding staff", e);
            }
            finally
            {
                conn.Close();
            }


        }
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
