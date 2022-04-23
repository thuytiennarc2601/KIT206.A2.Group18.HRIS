using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;


namespace HRIS.WPF
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

        #region Retrieve All Classes
        public static List<Class> LoadAllClasses()
        {
            List<Class> classList = new List<Class>();

            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select c.unit_code, c.campus, c.day, c.type, c.start, c.end, c.room, c.staff, " +
                    "s.given_name, s.family_name, s.title, s.campus, s.phone, s.room, s.email, s.photo, s.category,  u.title, u.coordinator  " +
                    "from class as c join staff as s on c.staff = s.id join unit as u on u.code = c.unit_code", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    classList.Add(new Class { 
                        unit = new Unit { UnitCode = rdr.GetString(0), UnitName = rdr.GetString(17) }, 
                        campus = ParseEnum<Campus>(rdr.GetString(1)), 
                        day = ParseEnum<Day>(rdr.GetString(2)), 
                        type = ParseEnum<Type>(rdr.GetString(3)), 
                        StartTime = TimeOnly.ParseExact(rdr.GetString(4), "HH:mm:ss"),
                        EndTime = TimeOnly.ParseExact(rdr.GetString(5), "HH:mm:ss"), 
                        Room = rdr.GetString(6), 
                        staff = new Staff { ID = rdr.GetInt32(7),
                            GivenName = rdr.GetString(8),
                            FamilyName = rdr.GetString(9),
                            Title = rdr.GetString(10),
                            campus = ParseEnum<Campus>(rdr.GetString(11)),
                            Phone = rdr.GetString(12),
                            Room = rdr.GetString(13),
                            Email = rdr.GetString(14),
                            //Photo = rdr.Get
                            category = ParseEnum<Category>(rdr.GetString(16))
                        } 
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
        #region Retrive all units from database
        public static List<Unit> LoadAllUnits()
        {
            List<Unit> unitList = new List<Unit>();

            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select u.code, u.title, u.coordinator, " +
                    "s.given_name, s.family_name, s.title, s.campus, s.phone, s.room, s.email, s.photo, s.category " +
                    "from unit as u inner join staff as s on u.coordinator = s.id", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    unitList.Add(new Unit
                    {
                        UnitCode = rdr.GetString(0),
                        UnitName = rdr.GetString(1),
                        Coordinator = new Staff { ID = rdr.GetInt32(2),
                            GivenName = rdr.GetString(3),
                            FamilyName = rdr.GetString(4),
                            Title = rdr.GetString(5),
                            campus = ParseEnum<Campus>(rdr.GetString(6)),
                            Phone = rdr.GetString(7),
                            Room = rdr.GetString(8),
                            Email = rdr.GetString(9),
                            //Photo = rdr.Get
                            category = ParseEnum<Category>(rdr.GetString(11))
                        },
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
        #region Retrieve all consultations from database
        public static List<Consultation> LoadAllConsultations()
        {
            List<Consultation> consultationList = new List<Consultation>();
            List<Staff> staffList = new List<Staff>();

            MySqlDataReader rdr = null;
            conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select con.staff_id, con.day, con.start, con.end, s.given_name, s.family_name, s.title, s.campus, s.phone, s.room, s.email, s.photo, s.category" +
                    " from consultation as con inner join staff as s on con.staff_id = s.id", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    consultationList.Add(new Consultation
                    {
                        staff = new Staff { ID = rdr.GetInt32(0), 
                            GivenName = rdr.GetString(4), 
                            FamilyName = rdr.GetString(5), 
                            Title = rdr.GetString(6),
                            campus = ParseEnum<Campus>(rdr.GetString(7)),
                            Phone = rdr.GetString(8),
                            Room = rdr.GetString(9),
                            Email = rdr.GetString(10),
                            //Photo = rdr.Get
                            category = ParseEnum<Category>(rdr.GetString(12))
                        },
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
        #region Retrieve all staffs from database
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
        #region Retrieve consultations of selected staff
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
        #region Retrieve classes of selected staff
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
        #region Delete a consultation
        public static void DeleteConsultation(int id, string day, string Start, string End)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE " +
                                                    "FROM consultation " +
                                                    "WHERE staff_id =" + id + " AND day='" + day + "'" + " AND start='" + Start + "'" + " AND end='" + End + "'", conn);

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
        #endregion Delete consultation from database
        #region Add a consultation time for a staff
        public static void AddConsultation(int id, string day, string Start, string End)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO consultation (staff_id, day, start, end) VALUES ('" + id + "', '" + day + "', '" + Start + "', '" + End + "')", conn);
                cmd.ExecuteNonQuery();



            }
            catch (MySqlException e)
            {
                ReportError("Adding consultation", e);
            }
            finally
            {
                conn.Close();

            }


        }
        #endregion
        #region Edit details of a class
        public static void EditClassDetail(string new_campus, string new_day, string new_start, string new_end, string new_type, string new_room, string new_staffID, string unitCode, string campus, string day, string start, string end, string type, string room, int staffID)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE class" +
                                                    " SET unit_code='" + unitCode + "',campus='" + new_campus + "',day='" + new_day + "',start='" + new_start + 
                                                    "',end='" + new_end + "',type='" + new_type + "',room='" + new_room + "',staff='" + new_staffID + "'" +
                                                    " WHERE unit_code ='" + unitCode + "' AND campus='" + campus + "'" + " AND day='" + day + "'" 
                                                    + " AND start='" + start + "'" + " AND end='" + end + "'"
                                                    + " AND type='" + type + "'" + " AND room='" + room + "'"
                                                    + " AND staff='" + staffID + "'", conn);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportError("Editing class details", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion Edit details of a class
        //Report error
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
