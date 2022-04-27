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
        public static bool AddClassValidation(string code, string campus, string day, string start, string end, string room)
        {
            bool valid = true;

            if (code == null) //unitcode provided cannot be empty
            {
                valid = false;
                MessageBox.Show("Unit code required");
            }
            if (campus == null) //unitname provided cannot be empty
            {
                valid = false;
                MessageBox.Show("Campus required");
            }
            if (day == null)  //unitcode cannot exist beforehand
            {
                valid = false;
                MessageBox.Show("Day required");
            }
            if (start == "00:00:00") //unitname cannot exist beforehand
            {
                valid = false;
                MessageBox.Show("Start time required");
            }
            if (end == "00:00:00") //staff cannot be empty
            {
                valid = false;
                MessageBox.Show("End time required");
            }
            if (room == "-- Selected Room --")
            {
                valid = false;
                MessageBox.Show("Room required");
            }
            return valid;
        }
        #endregion

        public static bool AddConValidation(string day)
        {
            bool valid = true;

            if (day == null)
            { 
                valid = false;
                MessageBox.Show("Day required");
            }
            return valid;
        }

        #region Time Validation
        //time: is the actual time to check
        //starthour and endhour: use for check if the ending time is larger than starting time or not
        //hour: twitch between hour and minute
        public static bool TimeValidation(string time, string startHour, string endHour, bool hour)
        {
            bool valid = true;
            int timeNumber = Int32.Parse(time);
            int startTimeInt = Int32.Parse(startHour);
            int endTimeInt = Int32.Parse(endHour);
            if (time != "")
            {
                if (timeNumber < 0)
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
                else if (hour && endTimeInt < startTimeInt)
                {
                    valid = false;
                    MessageBox.Show("Ending time must be larger than starting time");
                }
            }
            return valid;
        }
        #endregion
    }
}
