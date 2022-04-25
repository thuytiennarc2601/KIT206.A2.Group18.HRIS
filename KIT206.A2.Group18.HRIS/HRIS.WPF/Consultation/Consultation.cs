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

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
        #endregion
        public override string ToString()
        {

            return day + " | " + StartTime + " - " + EndTime;
        }

        #region Return the Consultation of A Staff Member
        public static List<Consultation> GetConsultationByStaffID(int StaffID)
        {
            List<Consultation> conList = Agency.LoadAllConsultations();
            var getConsultation = from Consultation c in conList
                                  where c.staff.ID == StaffID
                                  select c;
            List<Consultation> resultConsultation = new List<Consultation>(getConsultation);

            return resultConsultation;
        }
        #endregion
    }
}
