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
            List<Staff> staffList = Staff.LoadAllStaff();
            var getStaff = from Staff s in staffList
                           where (s.ID).ToString().Contains(SearchText) || s.GivenName.ToLower().Contains(SearchText) || s.FamilyName.ToLower().Contains(SearchText)
                           select s;

            List<Staff> result = new List<Staff>(getStaff);

            return result;
        }
        #endregion

        //Load All Staff
        #region Load All Staff Members From Database
        public static List<Staff> LoadAllStaff()
        {
            List<Staff> staffList = Agency.LoadAllStaffs();
            return staffList;
        }
        #endregion

        //Add/Update A Specific Staff Member Information
        #region Add/Update Staff Details
        public static void UpdateStaffDetails(int StaffID, string Title, string Category, string Phone, string Room, string Email, string Campus, byte[] Photo)
        {
            Agency.UpdateStaffInfo(StaffID, Title, Category, Phone, Room, Email, Campus, Photo);
        }
        #endregion

        //Get Staff By ID
        #region Get Staff By ID
        public static Staff GetStaffByID(int id)
        {
            Staff staff = Agency.GetStaffByID(id);
            return staff;
        }
        #endregion

        //Get A Staff With Just ID, Title, Name
        #region Get A Staff List With ID, Title, Name
        public static List<Staff> GetStaffsWithIDName()
        {
            List<Staff> staffList = Agency.LoadAllStaffWithIDNAME();
            return staffList;
        }
        #endregion

        //Get A Staff With All Details
        public static Staff GetStaffWithAllDetails(int id)
        {
            Staff staff = Agency.GetStaffWithAllDetails(id);
            return staff;
        }
    }
}
