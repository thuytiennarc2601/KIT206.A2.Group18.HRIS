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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

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

        private void unit_Loaded(object sender, RoutedEventArgs e)
        {

            List<string> list = new List<string>();
            list = Agency.LoadCode();

            
            // ... Assign the ItemsSource to the List.
            comboBox_code.ItemsSource = list;

            // ... Make the first item selected.
            comboBox_code.SelectedIndex = 0;
        }

        private void addClass_Click(object sender, RoutedEventArgs e)
        {
            int staff = (int)comboBox_staff.SelectedItem;
            string code = (string)comboBox_code.SelectedItem;
            string room = this.textBox_room.Text;
            Campus campus = (Campus)comboBox_campus.SelectedItem;
            Day day = (Day)comboBox_day.SelectedItem;
            Type type = (Type)comboBox_type.SelectedItem;
            TimeOnly start = new TimeOnly(11,0);
            TimeOnly end = new TimeOnly(13,0);
           
            

            Agency.AddClass(code, campus.ToString(), day.ToString(), start.ToString("HH:mm:ss"), end.ToString("HH:mm:ss"), type.ToString(), room, staff);
            MessageBox.Show("Updated successully!");
        }
    }
}
