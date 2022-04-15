using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    class Consultation
    {
        public Staff staff { get; set; }

        public Day day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        private static MySqlConnection conn;

        #region Get All Consultations
        //Get all consultations in database
        public static List<Consultation> GetAllConsultation()
        {
            List<Consultation> conList = new List<Consultation>();

            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select staff_id, day, start, end from consultation", conn);
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Consultation result = new Consultation();
                    result.staff = new Staff();

                    result.staff.ID = rdr.GetInt32(0);
                    result.day = (Day)Enum.Parse(typeof(Day), rdr.GetString(1));
                    result.StartTime = (TimeSpan)rdr[2];
                    result.EndTime = (TimeSpan)rdr[3];

                    conList.Add(result);
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

            return conList;
        }
        #endregion

        #region Get Consultation with staff details (title, given name, family name)
        public static List<Consultation> LoadFullConsultationList()
        {
            List<Consultation> conList = Consultation.GetAllConsultation();
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            for(int i = 0; i<conList.Count; i++)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select title, given_name, family_name from staff where id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", conList[i].staff.ID);
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        conList[i].staff.GivenName = rdr.GetString(1);
                        conList[i].staff.FamilyName = rdr.GetString(2);
                        if(Convert.IsDBNull(rdr[0]) || rdr.GetString(0) == "")
                        {
                            conList[i].staff.Title = "Unknown";
                        }
                        else
                        {
                            conList[i].staff.Title = rdr.GetString(0);
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
            return conList;
        }
        #endregion
    }
}
