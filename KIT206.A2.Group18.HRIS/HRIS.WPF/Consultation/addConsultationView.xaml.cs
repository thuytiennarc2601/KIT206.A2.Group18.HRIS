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
    /// Interaction logic for addConsultationView.xaml
    /// </summary>
    public partial class addConsultationView : Window
    {
        public addConsultationView()
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
        private void addConsultation_Click(object sender, RoutedEventArgs e)
        {
            int staff = (int)comboBox_staff.SelectedItem;
            Day day = (Day)comboBox_day.SelectedItem;

            //string start = this.start_hour.Text + this.start_minute.Text;
            TimeOnly start = new TimeOnly(9, 0);
            TimeOnly end = new TimeOnly(13, 0);
            //string end = (string)lstBox_start.SelectedItem;

            if (Agency.checkValidateConsul(day.ToString(), start.ToString("HH:mm:ss"), staff))
            {
                Agency.AddConsultation(day.ToString(), start.ToString("HH:mm:ss"), end.ToString("HH:mm:ss"), staff);
                MessageBox.Show("Updated successully!");
            }
            else
            {
                MessageBox.Show("This staff already has a consultation on " + day + " at " + start);
            }
        }
    }
}
