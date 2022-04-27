using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KIT206.A2.Group18.HRIS;

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for EditClassDetails.xaml
    /// </summary>
    public partial class EditClassDetails : Window
    {
        public EditClassDetails()
        {
            InitializeComponent();
        }

        private string _code;
        private string _campus;
        private string _day;
        private TimeOnly _start;
        private int _id = -1;

        public int StaffID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string UnitCode
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Campus
        {
            get { return _campus; }
            set { _campus = value; }
        }

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public TimeOnly ClassStart
        {
            get { return _start; }
            set { _start = value; }
        }

        #region Show Search Result
        //Show unit search result
        //private void AddUnitToSearchResult()
        //{
        //    if (this.UnitDetailsTB.Text != "")
        //    {
        //        List<Unit> result = Unit.GetUnitsBySearchText(this.UnitDetailsTB.Text);
        //        if (result.Count > 0)
        //        {
        //            this.UnitList.Visibility = Visibility.Visible;
        //            this.UnitList.ItemsSource = result;
        //        }
        //        else
        //        {
        //            this.UnitList.Visibility = Visibility.Hidden;
        //        }
        //    }
        //}

        //Show staff search result
        private void AddStaffToSearchResult()
        {
            if(this.StaffDetailsTB.Text != "")
            {
                List<Staff> result = Staff.GetStaffListBySearchText(this.StaffDetailsTB.Text);
                if(result.Count > 0)
                {
                    this.StaffList.Visibility = Visibility.Visible;
                    this.StaffList.ItemsSource = result;
                }
                else
                {
                    this.StaffList.Visibility= Visibility.Hidden;
                }
            }
        }

        #endregion

        private void StaffDetailsTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                AddStaffToSearchResult();
            }
        }

        private void SearchStaffButton_Click(object sender, RoutedEventArgs e)
        {
            AddStaffToSearchResult();
        }

        private void StaffList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (this.StaffList.SelectedItem != null)
            {
                Staff selectedStaff = (Staff)StaffList.SelectedItem;
                this.StaffID = selectedStaff.ID;
                this.StaffDetailsTB.Text = selectedStaff.ID.ToString() + " | " + selectedStaff.ToString();
                this.StaffList.Visibility = Visibility.Hidden;
                MessageBox.Show(StaffID.ToString());
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string code = this.UnitCode;
            string campus = this.Campus;
            string day = this.Day;
            string start = this.ClassStart.ToString("HH:mm:ss");
            string startHour = this.StartHourTB.Text;
            string startMinute = this.StartMinute.Text;
            string endHour = this.EndHourTB.Text;
            string endMinute = this.EndMinuteTB.Text;
            string new_type = (string)this.TypeList.SelectedItem;
            string new_day = (string)this.DayList.SelectedItem;
            string room = this.RoomTB.Text;
            int staff = this.StaffID;

            if (Validation.TimeValidation(this.StartHourTB.Text, this.StartHourTB.Text, this.EndHourTB.Text, true)
                && Validation.TimeValidation(this.EndHourTB.Text, this.StartHourTB.Text, this.EndHourTB.Text, true)
                && Validation.TimeValidation(this.StartMinute.Text, this.StartHourTB.Text, this.EndHourTB.Text, false)
                && Validation.TimeValidation(this.EndMinuteTB.Text, this.StartHourTB.Text, this.EndHourTB.Text, false))
            {
                string new_start = TimeDoubleDigitConverter(startHour) + ":" + TimeDoubleDigitConverter(startMinute) + ":00";
                string new_end = TimeDoubleDigitConverter(endHour) + ":" + TimeDoubleDigitConverter(endMinute) + ":00";

                if(Validation.AddingEditClassValidation(this.StaffDetailsTB.Text, staff, new_start, new_end, room, campus, day))
                {
                    Agency.EditClassDetail(code, day, campus, start, new_day, new_start, new_end, new_type, room, staff);
                    this.Close();
                }
            }
        }

        private string TimeDoubleDigitConverter(string time)
        {
            if(time.Length < 2)
            {
                time = "0" + time;
            }
            return time;
        }
    }
}
