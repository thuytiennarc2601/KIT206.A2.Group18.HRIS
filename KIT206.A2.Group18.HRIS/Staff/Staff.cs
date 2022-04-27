using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace KIT206.A2.Group18.HRIS
{

    public enum Campus { Hobart, Launceston }

    public enum Category { Academic, Technical, Admin, Casual }

    class Staff
    {
        #region Staff Properties
        public int ID { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Title { get; set; }

        public Campus campus { get; set; }

        public string Phone { get; set; }

        public string Room { get; set; }

        public string Email { get; set; }

        public Category category { get; set; }

        public byte[] Photo { get; set; }

        private static MySqlConnection conn;
        #endregion

        #region Get all staff with full details from database
        //retrieves all STAFF from staff database
        public static List<Staff> LoadAllStaffList()
        {
            List<Staff> staffList = new List<Staff>();
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, campus, email, phone, room, photo, category from staff", conn);

                rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Staff result = new Staff();

                    result.ID = rdr.GetInt32(0); //get id

                    //get name
                    result.GivenName = rdr.GetString(1); 
                    result.FamilyName = rdr.GetString(2); 

                    /*
                    //get Title
                    if (Convert.IsDBNull(rdr[3]) || rdr.GetString(3) == "")
                    {
                        result.Title = "Unknown";
                    }
                    else
                    {
                    */
                        result.Title = rdr.GetString(3);
                    //}

                    /*
                    //get Campus
                    if (rdr.GetString(4) == "" || Convert.IsDBNull(rdr[4]))
                    {
                        result.campus = Campus.Notlocated;
                    }
                    else
                    {
                    */
                        result.campus = (Campus)Enum.Parse(typeof(Campus), rdr.GetString(4));
                    //}

                    /*
                    //get Email
                    if (rdr.GetString(5) == "" || Convert.IsDBNull(rdr[5]))
                    {
                        result.Email = "No email added";
                    }
                    else
                    {
                    */
                        result.Email = rdr.GetString(5);
                    //}
                    /*
                    //get Phone
                    if( rdr.GetString(6) == "" || Convert.IsDBNull(rdr[6]))
                    {
                        result.Phone = "No number added";
                    }
                    else
                    {
                    */
                        result.Phone = rdr.GetString(6);
                    //}

                    /*
                    //get ROOM
                    if (rdr.GetString(7) == "" || Convert.IsDBNull(rdr[7]))
                    {
                        result.Room = "No room assigned";
                    }
                    else
                    {
                    */
                        result.Room = rdr.GetString(7);
                    //}

                    /*
                    //get PHOTO
                    if (!Convert.IsDBNull(rdr[8]))
                    {
                    */
                        result.Photo = (byte[])rdr[8];
                    //}

                    /*
                    //get CATEGORY
                    if (rdr.GetString(9) == "" || Convert.IsDBNull(rdr[9]))
                    {
                        result.category = Category.unknown;
                    }
                    else
                    {
                    */
                        result.category = (Category)Enum.Parse(typeof(Category), rdr.GetString(9));
                    //}

                    staffList.Add(result);
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

            return staffList;
        }
        #endregion

        #region Get Staff Name
        //Get name of staff using their ID
        public static string GetStaffName(int staffID)
        {
            string name = "";

            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title from staff where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", staffID);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string givenName = rdr.GetString(0);
                    string familyName = rdr.GetString(1);

                    string title = "";
                    if (Convert.IsDBNull(rdr[2]) || rdr.GetString(2) == "")
                    {
                        title = "Unknown";
                    }
                    else
                    {
                        title = rdr.GetString(2);
                    }

                    name = title + ". " + givenName + " " + familyName;
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
            return name;
        }
        #endregion

        #region Get Staff Location
        //Get room and campus of a staff member
        public static string GetStaffLocation(int staffID)
        {
            string staffLocation = "";

            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select campus, room from staff where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", staffID);

                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    string room = "";
                    string campus = "";

                    /*
                    //get Campus
                    if (rdr.GetString(0) == "" || Convert.IsDBNull(rdr[0]))
                    {
                        campus = Campus.Notlocated.ToString();
                    }
                    else
                    {
                    */
                        campus = rdr.GetString(0);
                    //}

                    //get ROOM
                    if (rdr.GetString(1) == "" || Convert.IsDBNull(rdr[1]))
                    {
                        room = "No room assigned";
                    }
                    else
                    {
                        room = rdr.GetString(1);
                    }
                    staffLocation = "Room: " + room + " | " + campus + " campus";
                }
            }
            finally
            {
                if(rdr!=null)
                {
                    rdr.Close();
                }
                if(conn!=null)
                {
                    conn.Close();
                }
            }

            return staffLocation;
        }
        #endregion
    }
}
