using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206.A2.Group18.HRIS;
using System.Windows;
using System.Text.RegularExpressions;

namespace HRIS.WPF
{
    class Validation
    {
        private const int MIN_TIME_HOUR = 9; 
        private const int MAX_TIME_HOUR = 17;
        private const int MAX_TIME_MINUTE = 60;

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

        #region Time Validation
        //time: is the actual time to check
        //starthour and endhour: use for check if the ending time is larger than starting time or not
        //hour: twitch between hour and minute
        public static bool TimeValidation(string time, string startHour, string endHour, bool hour)
        {
            bool valid = true;
            var regex = @"[0-9][0-9]";
            int timeNumber = Int32.Parse(time);
            int startTimeInt = Int32.Parse(startHour);
            int endTimeInt = Int32.Parse(endHour);
            if (time != "")
            {
                if (!Regex.IsMatch(time, regex))
                {
                    valid = false;
                    MessageBox.Show("Time requires non-negative numbers");
                }
                else if (hour && timeNumber < MIN_TIME_HOUR)
                {
                    valid = false;
                    MessageBox.Show("Start working at 9:00AM");
                }
                else if (hour && timeNumber > MAX_TIME_HOUR)
                {
                    valid = false;
                    MessageBox.Show("End working at 17:00PM");
                }
                else if (!hour && timeNumber > 60)
                {
                    valid = false;
                    MessageBox.Show("Minute out of range");
                }
                else if(hour && endTimeInt < startTimeInt)
                {
                    valid = false;
                    MessageBox.Show("Ending time must be larger than starting time");
                }
            }
            return valid;
        }
        #endregion

        #region Validate Adding/Editing Class Operation
        public static bool AddingEditClassValidation(string StaffDetails, int StaffID, string Start, string End, string Room, string Campus, string Day)
        {
            //type and staff details can be empty
            bool valid = true;

            Staff staff = Staff.GetStaffByID(StaffID);
            if(StaffDetails != null && staff.ID == -1) //if staff details(textbox) is provided, staff id must exist
            {
                valid = false;
                MessageBox.Show("This staff does not exist");
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
