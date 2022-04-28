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
    /// Interaction logic for AddConsultationView.xaml
    /// </summary>
    public partial class AddConsultationView : Window
    {
        public AddConsultationView()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int staff;
            Staff selectedStaff = (Staff)this.StaffList.SelectedItem;
            string day = (string)this.DayList.SelectedItem;
            string startHour = this.StartHour.Text;
            string endHour = this.EndHour.Text;
            string startMinute = this.StartMinute.Text;
            string endMinute = this.EndMinute.Text;

            if(selectedStaff != null)
            {
                staff = selectedStaff.ID;
            } else { staff = -1; }

            if(Validation.TimeValidation(startHour, startHour, endHour, true)
               && Validation.TimeValidation(endHour, startHour, endHour, true)
               && Validation.TimeValidation(startMinute, startMinute, endMinute, false)
               && Validation.TimeValidation(endMinute, startHour, endHour, false))
            {
                string start = startHour + ":" + startMinute + ":00";
                string end = endHour + ":" + endMinute + ":00";

                if(Validation.AddingConsultationValidation(staff, day, start))
                {
                    Agency.AddConsultation(day, start, end, staff);
                    this.Close();
                }
            }
           
        }
    }
}
