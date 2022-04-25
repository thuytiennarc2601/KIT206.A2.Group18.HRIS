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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KIT206.A2.Group18.HRIS;
using Type = KIT206.A2.Group18.HRIS.Type;

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for addClassWindow.xaml
    /// </summary>
    public partial class addClassWindow : Window
    {
        public addClassWindow()
        {
            InitializeComponent();
        }

        private void addStaff_Click(object sender, RoutedEventArgs e)
        {
            string staff = textBox_staff.Text;
            string code = textBox_code.Text;
            string room = textBox_room.Text;
            Campus campus = (Campus)comboBox_campus.SelectedItem;
            Day day = (Day)comboBox_day.SelectedItem;
            Type type = (Type)comboBox_type.SelectedItem;
            var start = new TimeOnly(11, 0);
            var end = new TimeOnly(13, 0);

            Agency.AddClass(code, campus, day, start, end, type, room, staff);
            MessageBox.Show("Updated successully!");
        }

    }

}
