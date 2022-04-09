using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    public enum Title { Prof, Dr, Mr, Mrs, Ms, Miss, Unk }

    public enum Campus { Hobart, Launceston, NonLocated }

    class Staff
    {
        private static MySqlConnection conn;

        public int ID { get; set; }

        public string Name { get; set; }

        public Title title { get; set; }

        public Campus campus { get; set; }

        public int Phone { get; set; }

        public string Room { get; set; }

        public string Email { get; set; }

        public string Category { get; set; }

        public string Photo { get; set; }

        public static List<Staff> LoadAllStaffList()
        {
            List<Staff> staffList = new List<Staff>();
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, campus, email from staff", conn);

                rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Staff result = new Staff();

                    result.ID = rdr.GetInt32(0);
                    result.Name = rdr.GetString(1) + " " + rdr.GetString(2);

                    if (rdr.GetString(3) == "")
                    {
                        result.title = Title.Unk;
                    }
                    else
                    {
                        result.title = (Title)Enum.Parse(typeof(Title), rdr.GetString(3));
                    }

                    if (rdr.GetString(4) == "")
                    {
                        result.campus = Campus.NonLocated;
                    }
                    else
                    {
                        result.campus = (Campus)Enum.Parse(typeof(Campus), rdr.GetString(4));
                    }

                    result.Email = rdr.GetString(5);

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
