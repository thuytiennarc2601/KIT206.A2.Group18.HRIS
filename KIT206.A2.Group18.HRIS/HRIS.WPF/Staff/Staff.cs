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
            return ID.ToString() + " | " + Title + ". " +  GivenName + " " + FamilyName;
        }

        //Return a staff list by a search text (using only ID and Name)
        #region Search for a Staff Member
        public static List<Staff> GetStaffListBySearchText(string SearchText)
        {
            SearchText = SearchText.ToLower();
            List<Staff> staffList = Agency.LoadAllStaffs();
            var getStaff = from Staff s in staffList
                           where (s.ID).ToString().Contains(SearchText) || s.GivenName.ToLower().Contains(SearchText) || s.FamilyName.ToLower().Contains(SearchText)
                           select s;

            List<Staff> result = new List<Staff>(getStaff);

            return result;
        }
        #endregion
    }
}
