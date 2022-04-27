using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206.A2.Group18.HRIS;
using System.Windows;

namespace HRIS.WPF
{
    class Validation
    {
        #region Validate Adding Unit Operation
        public static bool AddUnitValidation(string UnitCode, string UnitName, int StaffID)
        {
            bool valid = true;
            Unit UnitByCode = Unit.GetUnitByCode(UnitCode); 
            Unit UnitByName = Unit.GetUnitByTitle(UnitName);
            if (UnitCode == "") //unitcode provided cannot be empty
            {
                valid = false;
                MessageBox.Show("Unit code required");
            }
            else if(UnitName == "") //unitname provided cannot be empty
            {
                valid = false;
                MessageBox.Show("Unit name required");
            }
            else if(UnitByCode.UnitCode != "")  //unitcode cannot exist beforehand
            {
                valid = false;
                MessageBox.Show("This unit code already exist");                
            }
            else if(UnitByName.UnitName != "") //unitname cannot exist beforehand
            {
                valid = false;
                MessageBox.Show("This unit name already exist");
            }
            else if (StaffID == -1) //staff cannot be empty
            {
                valid = false;
                MessageBox.Show("A coordinator required");
            }
            return valid;
        }
        #endregion

        #region Validate Adding/Editing Class Operation
        public static bool AddingEditClassValidation(string UnitDetails, string StaffDetails, int StaffID, string StartHour, string EndHour, string Room, string Campus, string Day)
        {
            //type and staff details can be empty
            bool valid = true;

            Staff staff = Staff.GetStaffByID(StaffID);
            if(UnitDetails == "") //a unit must be choosen
            {
                valid = false;
                MessageBox.Show("A unit required"); 
            }
            else if(StaffDetails != null || staff.ID == -1) //if staff details(textbox) is provided, staff id must exist
            {
                valid = false;
                MessageBox.Show("This staff does not exist");
            }
            else if(StartHour == "") //Start hour cannot be empty
            {
                valid = false;
                MessageBox.Show("Start time required");
            }
            else if(EndHour == "") //End hour cannot be empty
            {
                valid = false;
                MessageBox.Show("End time required");
            }
            else if(Campus == "Select..") //campus cannot be empty
            {
                valid = false;
                MessageBox.Show("Campus required");
            }
            else if(Day == "Select..") //day cannot be empty
            {
                valid = false;
                MessageBox.Show("Day required");
            }
            else if(Room == "") //room cannot be empty
            {
                valid = false;
                MessageBox.Show("Room required");
            }

            return valid;
        }
        #endregion
    }
}
