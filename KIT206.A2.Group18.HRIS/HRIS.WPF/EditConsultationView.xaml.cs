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

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for EditConsultationView.xaml
    /// </summary>
    public partial class EditConsultationView : Window
    {
        public EditConsultationView()
        {
            InitializeComponent();
        }

        private int _id;
        private string _day;
        private string _start;
        private string _end;
        

        public int StaffID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public string ConsultationStart
        {
            get { return _start; }
            set { _start = value; }
        }

        public string ConsultationEnd
        {
            get { return _start; }
            set { _start = value; }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            string day = (string)this.DayList.SelectedItem;
            string startHour = this.StartHour.Text;
            string endHour = this.EndHour.Text;
            string startMinute = this.StartMinute.Text;
            string endMinute = this.EndMinute.Text;


            if (Validation.TimeValidation(startHour, startHour, endHour, true)
               && Validation.TimeValidation(endHour, startHour, endHour, true)
               && Validation.TimeValidation(startMinute, startMinute, endMinute, false)
               && Validation.TimeValidation(endMinute, startHour, endHour, false))
            {
                string start = startHour + ":" + startMinute + ":00";
                string end = endHour + ":" + endMinute + ":00";

                if (Validation.EditConsultationValidation(StaffID, day, start, end))
                {
                    //Consultation.EditConsultation(this._id, _day, _start, day, start, end);
                    this.Close();
                }
            }

        }
    }
}
