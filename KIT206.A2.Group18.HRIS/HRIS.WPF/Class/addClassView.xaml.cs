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
using Type = KIT206.A2.Group18.HRIS.Type;

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for addClassView.xaml
    /// </summary>
    public partial class addClassView : Window
    {
        public addClassView()
        {
            InitializeComponent();
        }


        private void staff_Loaded(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            list = Agency.LoadID();

            // ... Assign the ItemsSource to the List.
            comboBox_staff.ItemsSource = list;

                // ... Make the first item selected.
            comboBox_staff.SelectedIndex = 0;
        }

        private void unit_Loaded(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list = Agency.LoadCode();

            comboBox_code.ItemsSource = list;
            // ... Make the first item selected.

            comboBox_code.SelectedItem = null;
        }

        private string TimeDoubleDigitConverter(string time)
        {
            if (time.Length < 2)
            {
                time = "0" + time;
            }
            return time;
        }

        private void addClass_Click(object sender, RoutedEventArgs e)
        {
            int staff = (int)comboBox_staff.SelectedItem;
            string code = (string)comboBox_code.SelectedItem;
            string room = this.textBox_room.Text;
            string campus = (string)comboBox_campus.SelectedItem;
            string day = (string)comboBox_day.SelectedItem;
            string type = (string)comboBox_type.SelectedItem;
            string startHour = this.start_hour.Text;
            string startMinute = this.start_minute.Text;
            string endHour = this.end_hour.Text;
            string endMinute = this.end_minute.Text;

            if (Validation.TimeValidation(this.start_hour.Text, this.start_hour.Text, this.end_hour.Text, true)
                && Validation.TimeValidation(this.end_hour.Text, this.start_hour.Text, this.end_hour.Text, true)
                && Validation.TimeValidation(this.start_minute.Text, this.start_hour.Text, this.end_hour.Text, false)
                && Validation.TimeValidation(this.end_minute.Text, this.start_hour.Text, this.end_hour.Text, false))
            { 
                string start = TimeDoubleDigitConverter(startHour) + ":" + TimeDoubleDigitConverter(startMinute) + ":00";
                string end = TimeDoubleDigitConverter(endHour) + ":" + TimeDoubleDigitConverter(endMinute) + ":00";

                if (Validation.AddClassValidation(code, campus, day, start, end, room))
                {
                    if (Agency.checkValidateClass(code, campus, day, start, end, room, staff))
                    {
                        Agency.AddClass(code, campus, day, start, end, type, room, staff);
                        MessageBox.Show("Updated successully!");
                    }
                    else
                    {
                        MessageBox.Show("This room has been booked");
                    }
                }
            }
        }
    }
}
