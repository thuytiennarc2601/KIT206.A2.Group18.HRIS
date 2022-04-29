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
                    Day dayRead;
                    if (rdr.GetString(1) == "") { dayRead = Day.NA; }
                    else { dayRead = ParseEnum<Day>(rdr.GetString(1)); }
                    consultations.Add(new Consultation
                    {
                        staff = new Staff { ID = rdr.GetInt32(0) },
                        day = dayRead,
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
                    Day dayRead;
                    if (rdr.GetString(1) == "") { dayRead = Day.NA; }
                    else { dayRead = ParseEnum<Day>(rdr.GetString(2)); }
                    classes.Add(new Class
                    {
                        unit = new Unit { UnitCode = rdr.GetString(0) },
                        campus = ParseEnum<Campus>(rdr.GetString(1)),
                        day = dayRead,
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

        //STAFF OPERATIONS
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
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, category, photo from staff", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Staff result = new Staff();
                    result.ID = rdr.GetInt32(0);
                    result.GivenName = rdr.GetString(1);
                    result.FamilyName = rdr.GetString(2);

                    if (Convert.IsDBNull(rdr[3]) || rdr.GetString(3) == "")
                    {
                        result.Title = "Unknown";
                    }
                    else { result.Title = rdr.GetString(3); }

                    if (Convert.IsDBNull(rdr[4]) || rdr.GetString(4) == "")
                    {
                        result.category = Category.uncategorised;
                    }
                    else { result.category = ParseEnum<Category>(rdr.GetString(4)); }
                    
                    if (!Convert.IsDBNull(rdr[5]))
                    {
                        result.Photo = (byte[])rdr[5];
                    }

                    staffList.Add(result);
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading all staff", e);
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

        #region Add/Update A Staff Member's information
        public static void UpdateStaffInfo(int StaffID, string Title, string Category, string Phone, string Room, string Email, string Campus, byte[] Photo)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                AddStaffInfoHelper("Unknown", "title", StaffID, Title, conn);
                AddStaffInfoHelper("Select..", "category", StaffID, Category, conn);
                AddStaffInfoHelper("No contact added", "phone", StaffID, Phone, conn);
                AddStaffInfoHelper("Unknown", "room", StaffID, Room, conn);
                AddStaffInfoHelper("No email added", "email", StaffID, Email, conn);
                AddStaffInfoHelper("Select..", "campus", StaffID, Campus, conn);

                if (Photo.Length > 0)
                {
                    MySqlCommand cmdPhoto = new MySqlCommand("update staff set photo=@photo where id=@id", conn);
                    cmdPhoto.Parameters.AddWithValue("@photo", Photo);
                    cmdPhoto.Parameters.AddWithValue("@id", StaffID);
                    cmdPhoto.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                ReportError("update staff information", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            MessageBox.Show("Updated successfully");
        }

        private static void AddStaffInfoHelper(string condition, string field, int StaffID, string value, MySqlConnection conn)
        {
            if (value != condition)
            {
                MySqlCommand cmd = new MySqlCommand("update staff set " + field + "=@field where id=@id", conn);
                cmd.Parameters.AddWithValue("@field", value);
                cmd.Parameters.AddWithValue("@id", StaffID);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Get A Staff Member By ID (ID, Title, Name)
        public static Staff GetStaffByID(int id)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            Staff result = new Staff();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title from staff where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.ID = rdr.GetInt32(0);
                    result.GivenName = rdr.GetString(1);
                    result.FamilyName = rdr.GetString(2);

                    if (Convert.IsDBNull(rdr[3]) || rdr.GetString(3) == "")
                    {
                        result.Title = "Unknown";
                    }
                    else { result.Title = rdr.GetString(3); }

                }
            }
            catch (MySqlException e)
            {
                ReportError("loading staff", e);
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

            return result;
        }
        #endregion

        #region Get Staff Member In Depth (All details)
        public static Staff GetStaffWithAllDetails(int id)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            Staff result = new Staff();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, campus, phone, room, email, photo, category from staff where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.ID = rdr.GetInt32(0);
                    result.GivenName = rdr.GetString(1);
                    result.FamilyName = rdr.GetString(2);

                    if (Convert.IsDBNull(rdr[3]) || rdr.GetString(3) == "")
                    {
                        result.Title = "Unknown";
                    }
                    else { result.Title = rdr.GetString(3); }

                    if (Convert.IsDBNull(rdr[4]) || rdr.GetString(4) == "")
                    {
                        result.campus = Campus.Unknown;
                    }
                    else { result.campus = ParseEnum<Campus>(rdr.GetString(4)); }

                    if (Convert.IsDBNull(rdr[5]) || rdr.GetString(5) == "")
                    {
                        result.Phone = "No contact added";
                    }
                    else { result.Phone = rdr.GetString(5); }

                    if (Convert.IsDBNull(rdr[6]) || rdr.GetString(6) == "")
                    {
                        result.Room = "Unknown";
                    }
                    else { result.Room = rdr.GetString(6); }

                    if (Convert.IsDBNull(rdr[7]) || rdr.GetString(7) == "")
                    {
                        result.Email = "No email added";
                    }
                    else { result.Email = rdr.GetString(7); }

                    if (!Convert.IsDBNull(rdr[8]))
                    {
                        result.Photo = (byte[])rdr[8];
                    }

                    if (Convert.IsDBNull(rdr[9]) || rdr.GetString(9) == "")
                    {
                        result.category = Category.uncategorised;
                    }
                    else { result.category = ParseEnum<Category>(rdr.GetString(9)); }

                }
            }
            catch (MySqlException e)
            {
                ReportError("loading staff", e);
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

            return result;
        }
        #endregion

        #region Load All Staff With Name And ID
        public static List<Staff> LoadAllStaffWithIDNAME()
        {
            List<Staff> staffList = new List<Staff>();


            MySqlDataReader rdr = null;
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT id, title, given_name, family_name FROM staff order by id ASC", conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    staffList.Add(new Staff { ID = rdr.GetInt32(0), Title = rdr.GetString(1), GivenName = rdr.GetString(2), FamilyName = rdr.GetString(3) });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading id", e);
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

        //UNIT OPERATIONS
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

        #region Get A Unit By Unit Code
        public static Unit GetUnitByUnitCode(string code)
        {
            MySqlConnection conn = GetConnection();

            MySqlDataReader rdr = null;

            Unit unit = new Unit();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select code, title, coordinator from unit where code=@code", conn);
                cmd.Parameters.AddWithValue("@code", code);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unit.UnitCode = code;
                    unit.UnitName = rdr.GetString(1);
                    unit.Coordinator = new Staff { ID = rdr.GetInt32(2) };
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading unit", e);
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
            return unit;
        }
        #endregion

        #region Update Unit Coordinator
        public static void UpdateUnitCoordinator(string UnitCode, int StaffID)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update unit set coordinator=@coordinator where code=@code", conn);
                cmd.Parameters.AddWithValue("@coordinator", StaffID);
                cmd.Parameters.AddWithValue("@code", UnitCode);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportError("Updating unit coordinator", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            MessageBox.Show("Coordinator updated successfully");
        }
        #endregion

        #region Add A New Unit
        public static void AddNewUnit(string UnitCode, string UnitName, int StaffID)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into unit(code, title, coordinator) values(@code, @title, @coordinator)", conn);
                cmd.Parameters.AddWithValue("@code", UnitCode.ToUpper());
                cmd.Parameters.AddWithValue("@title", UnitName);
                cmd.Parameters.AddWithValue("@coordinator", StaffID);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportError("Adding unit", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            MessageBox.Show("Unit added successfully");
        }
        #endregion

        //CLASS OPERATION
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
                    Class result = new Class();
                    Day dayRead;

                    if (rdr.GetString(2) == "") { dayRead = Day.NA; }
                    else { dayRead = ParseEnum<Day>(rdr.GetString(2)); }

                    result.unit = new Unit { UnitCode = rdr.GetString(0) };
                    result.campus = ParseEnum<Campus>(rdr.GetString(1));
                    result.day = dayRead;
                    result.type = ParseEnum<Type>(rdr.GetString(3));
                    result.StartTime = TimeOnly.ParseExact(rdr.GetString(4), "HH:mm:ss");
                    result.EndTime = TimeOnly.ParseExact(rdr.GetString(5), "HH:mm:ss");
                    result.Room = rdr.GetString(6);
                    result.staff = new Staff { ID = rdr.GetInt32(7) };

                    classList.Add(result);
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

        #region Edit Details Of A Class
        public static void EditClassDetail(string code, string day, string campus, string start, string new_day, string new_start, string end, string type, string room, int staff)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE class" +
                                                    " SET day=@new_day, room=@new_room, end=@new_end, start=@new_start, type=@new_type, staff=@id " +
                                                    " WHERE unit_code=@code AND day=@day AND campus=@campus AND start=@start", conn);
                cmd.Parameters.AddWithValue("@new_day", new_day);
                cmd.Parameters.AddWithValue("@new_start", new_start);
                cmd.Parameters.AddWithValue("@new_end", end);
                cmd.Parameters.AddWithValue("@new_room", room);
                cmd.Parameters.AddWithValue("@new_type", type);
                cmd.Parameters.AddWithValue("@id", staff);

                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@day", day);
                cmd.Parameters.AddWithValue("@campus", campus);
                cmd.Parameters.AddWithValue("@start", start);
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
            MessageBox.Show("Update Class Details successfully");
        }
        #endregion Edit details of a class

        #region Add A New Class
        public static void AddClass(string code, string campus, string day, string start, string end, string type, string room, int staff)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO class (unit_code, campus, day, start, end, type, room, staff) " +
                    " VALUES (@code, @campus, @day, @start, @end, @type, @room, @staff)", conn);

                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@campus", campus);
                cmd.Parameters.AddWithValue("@day", day);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@room", room);
                cmd.Parameters.AddWithValue("@staff", staff);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportError("Adding Class selected", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            MessageBox.Show("A class added successfully");
        }
        #endregion

        #region Check If Room Is Available At A Specific Time Or Not
        //Check if a room is available or not
        public static Boolean checkValidateClass(string campus, string day, string start, string end, string room, int staff)
        {
            List<string> campusList = new List<string>();
            List<string> dayList = new List<string>();
            List<string> startList = new List<string>();
            List<string> endList = new List<string>();
            Boolean check = true;

            MySqlDataReader rdr = null;
            MySqlConnection conn = GetConnection();
            if (checkClassClash(day, start, end, staff))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT campus, day, start, end " +
                                                        "FROM class " +
                                                        "WHERE room=@room ", conn);

                    cmd.Parameters.AddWithValue("@room", room);

                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        campusList.Add(rdr.GetString(0));
                        dayList.Add(rdr.GetString(1));
                        startList.Add(rdr.GetString(2));
                        endList.Add(rdr.GetString(3));
                    }
                }
                catch (MySqlException e)
                {
                    ReportError("validating...", e);
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

                int count = 0;

                foreach (string s in campusList)
                {
                    if ((s == campus) && (dayList[count] == day) && (startList[count] == start))
                    {
                        check = false;
                        MessageBox.Show("Room clashed at period");
                    }
                    else if ((s == campus) && (dayList[count] == day) && (startList[count] != start))
                    {
                        string a = start.Replace(":", string.Empty);
                        int start_add = Int32.Parse(a);
                        string b = startList[count].Replace(":", string.Empty);
                        int start_class = Int32.Parse(b);
                        string c = end.Replace(":", string.Empty);
                        int end_add = Int32.Parse(c);
                        string d = endList[count].Replace(":", string.Empty);
                        int end_class = Int32.Parse(d);

                        if (((start_class < start_add) && (start_add < end_class)) || ((start_class < end_add) && (end_add <= end_class)) || ((start_add < start_class) && (end_add > end_class)) || ((start_add > start_class) && (end_add < end_class)))
                        {
                            check = false;
                            MessageBox.Show("Room clashed at period");
                        }
                    }
                    count++;
                }
            }
            else
            {  
                check = false;
                MessageBox.Show("This staff has class at this time.");
            }
            return check;
        }
        #endregion

        //CONSULTATION OPERATIONS
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
                    Day dayRead;
                    if (rdr.GetString(1) == "") { dayRead = Day.NA; }
                    else { dayRead = ParseEnum<Day>(rdr.GetString(1)); }

                    consultationList.Add(new Consultation
                    {
                        staff = new Staff { ID = rdr.GetInt32(0) },
                        day = dayRead,
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

        #region Add A New Consultation
        public static void AddConsultation(string day, string start, string end, int staff)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO consultation (staff_id, day, start, end) " +
                    " VALUES (@staff, @day, @start, @end)", conn);

                cmd.Parameters.AddWithValue("@day", day);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@staff", staff);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportError("Adding a consultation", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            MessageBox.Show("A new consultation added");
        }
        #endregion

        #region Delete Consultation
        public static void DeleteConsultation(int id, string day, string Start, string End)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE " +
                                                    "FROM consultation " +
                                                    "WHERE staff_id =@id AND day=@day AND start=@start AND end=@end", conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@day", day);
                cmd.Parameters.AddWithValue("@start", Start);
                cmd.Parameters.AddWithValue("@end", End);
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
            MessageBox.Show("Consultation cancelled");
        }
        #endregion
        #region Edit Consultation
        public static void EditConsultation(int id, string day, string start, string new_day, string new_start, string new_end)
        {

            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE consultation" +
                                                    " SET day=@new_day, end=@new_end, start=@new_start" +
                                                    " WHERE staff_id=@id AND day=@day AND start=@start", conn);
                cmd.Parameters.AddWithValue("@new_day", new_day);
                cmd.Parameters.AddWithValue("@new_start", new_start);
                cmd.Parameters.AddWithValue("@new_end", new_end);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@day", day);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportError("Editing consultation details", e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            MessageBox.Show("Update Consultation Details successfully");
        }
        #endregion Edit details of a consultation
        #region Check If A Consultation Time Of Specific Staff Is Not Clashing With Other Consultation
        public static Boolean checkValidateConsul(string day, string start, string end, int staff)
        {
            List<string> dayList = new List<string>();
            List<string> startList = new List<string>();
            List<string> endList = new List<string>();
            Boolean check = true;

            MySqlDataReader rdr = null;
            MySqlConnection conn = GetConnection();

            if (checkClassClash(day, start, end, staff))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT day, start, end " +
                                                        "FROM consultation " +
                                                        "WHERE staff_id=@staff ", conn);

                    cmd.Parameters.AddWithValue("@staff", staff);

                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        dayList.Add(rdr.GetString(0));
                        startList.Add(rdr.GetString(1));
                        endList.Add(rdr.GetString(2));
                    }
                }
                catch (MySqlException e)
                {
                    ReportError("validating...", e);
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

                int count = 0;

                foreach (string s in dayList)
                {
                    if ((s == day) && (startList[count] == start))
                    {
                        check = false;
                        MessageBox.Show("This staff has consultation at this time.");
                    }
                    else if ((s == day) && (startList[count] != start))
                    {
                        string a = start.Replace(":", string.Empty);
                        int start_add = Int32.Parse(a);
                        string b = startList[count].Replace(":", string.Empty);
                        int start_class = Int32.Parse(b);
                        string c = end.Replace(":", string.Empty);
                        int end_add = Int32.Parse(c);
                        string d = endList[count].Replace(":", string.Empty);
                        int end_class = Int32.Parse(d);

                        if (((start_class < start_add) && (start_add < end_class)) || ((start_class < end_add) && (end_add <= end_class)) || ((start_add < start_class) && (end_add > end_class)) || ((start_add > start_class) && (end_add < end_class)))
                        {
                            check = false;
                            MessageBox.Show("This staff has consultation at this time.");
                        }
                    }
                    count++;
                }
            }
            else
            {
                check = false;
                MessageBox.Show("This staff has class at this time.");
            }
            return check;
        }
        #endregion

        //OTHER FUNCTION
        #region Check If Staff Is Available Or Not
        public static Boolean checkClassClash(string day, string start, string end, int staff)
        {
            List<string> dayList = new List<string>();
            List<string> startList = new List<string>();
            List<string> endList = new List<string>();
            Boolean check = true;

            MySqlDataReader rdr = null;
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT day, start, end FROM class WHERE staff=@staff ", conn);

                cmd.Parameters.AddWithValue("@staff", staff);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dayList.Add(rdr.GetString(0));
                    startList.Add(rdr.GetString(1));
                    endList.Add(rdr.GetString(2));
                }
            }
            catch (MySqlException e)
            {
                ReportError("validating...", e);
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

            int count = 0;

            foreach (string s in dayList)
            {
                if ((s == day) && (startList[count] == start))
                {
                    check = false;
                }
                else if ((s == day) && (startList[count] != start))
                {
                    string a = start.Replace(":", string.Empty);
                    int start_add = Int32.Parse(a);
                    string b = startList[count].Replace(":", string.Empty);
                    int start_class = Int32.Parse(b);
                    string c = end.Replace(":", string.Empty);
                    int end_add = Int32.Parse(c);
                    string d = endList[count].Replace(":", string.Empty);
                    int end_class = Int32.Parse(d);

                    if (((start_class < start_add) && (start_add < end_class)) || ((start_class < end_add) && (end_add <= end_class)) || ((start_add < start_class) && (end_add > end_class)) || ((start_add > start_class) && (end_add < end_class)))
                    {
                        check = false;
                    }
                }
                count++;
            }

            return check;
        }
        #endregion

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
