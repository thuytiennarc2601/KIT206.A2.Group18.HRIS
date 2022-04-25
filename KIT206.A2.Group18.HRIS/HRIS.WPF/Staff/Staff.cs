using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206.A2.Group18.HRIS
{
    public enum Campus { Hobart, Launceston, Unknown }

    public enum Category { academic, technical, admin, casual, uncategorised }

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
        public List<Consultation> Consultations { get; set; }
        public List<Class> Classes { get; set; }
        #endregion


        public override string ToString()
        {
            return Title + ". " +  GivenName + " " + FamilyName;
        }

        //Return a staff by its ID
        #region Return A Staff By Its ID
        public static Staff GetStaffByID(int StaffID)
        {
            Staff staff = new Staff();
            List<Staff> staffList = Agency.LoadAllStaffs();

            var getStaff = from Staff s in staffList
                           where s.ID == StaffID
                           select s;
            List<Staff> resultStaff = new List<Staff>(getStaff);
            staff = resultStaff[0];

            return staff;
        }
        #endregion

    }
}
