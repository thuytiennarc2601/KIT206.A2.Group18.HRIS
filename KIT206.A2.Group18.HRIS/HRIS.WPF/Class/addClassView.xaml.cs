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

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
                // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = list;

                // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void addClass_Click(object sender, RoutedEventArgs e)
        {
            int staff = (int)comboBox_staff.SelectedItem;
            string code = this.textBox_code.Text;
            string room = this.textBox_room.Text;
            Campus campus = (Campus)comboBox_campus.SelectedItem;
            Day day = (Day)comboBox_day.SelectedItem;
            Type type = (Type)comboBox_type.SelectedItem;
            TimeOnly start = new TimeOnly(11, 0, 0);
            TimeOnly end = new TimeOnly(13, 0, 0);

            Agency.AddClass(code, campus, day, start, end, type, room, staff);
            MessageBox.Show("Updated successully!");
        }
    }
}
