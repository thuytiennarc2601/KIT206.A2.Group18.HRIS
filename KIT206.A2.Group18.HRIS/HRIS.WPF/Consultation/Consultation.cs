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
        #region Properties
        public Staff staff { get; set; }

        public Day day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        #endregion

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
            List<Staff> staffList = Staff.LoadAllStaffList();

            for(int i = 0; i<conList.Count; i++)
            {
                var result = from Staff s in staffList
                             where conList[i].staff.ID == s.ID
                             select s; //LINQ

                List<Staff> resultList = new List<Staff>(result);

                conList[i].staff.GivenName = resultList[0].GivenName;
                conList[i].staff.FamilyName = resultList[0].FamilyName;
                conList[i].staff.Title = resultList[0].Title;
            }
            return conList;
        }
        #endregion
    }
}
