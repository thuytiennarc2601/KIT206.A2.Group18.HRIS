using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace KIT206.A2.Group18.HRIS
{

    public enum Campus { Hobart, Launceston, Notlocated }

    public enum Category { admin, technical, casual, academic, unknown }

    class Staff
    {
        private static MySqlConnection conn;

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

                    //get Title
                    if (rdr.GetString(3) == "")
                    {
                        result.Title = "Unk";
                    }
                    else
                    {
                        result.Title = rdr.GetString(3);
                    }

                    //get Campus
                    if (rdr.GetString(4) == "")
                    {
                        result.campus = Campus.Notlocated;
                    }
                    else
                    {
                        result.campus = (Campus)Enum.Parse(typeof(Campus), rdr.GetString(4));
                    }

                    //get Email
                    if (rdr.GetString(5) == "")
                    {
                        result.Email = "No email added";
                    }
                    else
                    {
                        result.Email = rdr.GetString(5);
                    }

                    //get Phone
                    if( rdr.GetString(6) == "")
                    {
                        result.Phone = "No number added";
                    }
                    else
                    {
                        result.Phone = rdr.GetString(6);
                    }

                    //get ROOM
                    if (rdr.GetString(7) == "")
                    {
                        result.Room = "No room assigned";
                    }
                    else
                    {
                        result.Room = rdr.GetString(7);
                    }

                    //get PHOTO
                    if (!Convert.IsDBNull(rdr[8]))
                    {
                        result.Photo = (byte[])rdr[8];
                    }

                    //get CATEGORY
                    if (rdr.GetString(9) == "")
                    {
                        result.category = Category.unknown;
                    }
                    else
                    {
                        result.category = (Category)Enum.Parse(typeof(Category), rdr.GetString(9));
                    }

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
    }
}
