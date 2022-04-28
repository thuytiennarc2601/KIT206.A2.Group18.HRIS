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
            Unit CheckUnit = Unit.CheckUnitExist(UnitCode);
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
            else if(CheckUnit.UnitCode != "")  //unitcode cannot exist beforehand
            {
                valid = false;
                MessageBox.Show("This unit code already exist");                
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
                    MessageBox.Show("Time requires 00:00 format");
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

        #region Validate Adding Class (expanded)
        public static bool AddingClassValidation(string code, string campus, string day, string start, string end, string room, int staff)
        {
            bool valid = true;
            if(code == "empty")
            {
                valid = false;
                MessageBox.Show("A unit required");
            }
            
            else if(!Agency.checkValidateClass(campus, day, start, end, room, staff))
            {
                valid = false;
            }

            return valid;
        }
        #endregion

        #region Validate Adding/Editing Class Operation
        public static bool AddingEditClassValidation(int StaffID, string Start, string End, string Room, string Campus, string Day, string Type)
        {
            bool valid = true;
            if(StaffID == -1) //staff id must be required
            {
                valid = false;
                MessageBox.Show("Staff required");
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
            else if(Type == "Select..")
            {
                valid = false;
                MessageBox.Show("Type required");
            }
            return valid;
        }
        #endregion

        #region Validate Adding Consultation
        public static bool AddingConsultationValidation(int staffId, string day, string start, string end)
        {
            bool valid = true;
            if(staffId == -1)
            {
                valid = false;
                MessageBox.Show("Staff required");
            }
            else if(day == "Select..")
            {
                valid = false;
                MessageBox.Show("Day required");
            }
            else if(!Agency.checkValidateConsul(day, start, end, staffId))
            {
                valid = false;
            }
            else if (!Agency.checkClassClash(day, start, end, staffId))
            {
                valid = false;
            }
            return valid;
        }
        #endregion
    }
}
