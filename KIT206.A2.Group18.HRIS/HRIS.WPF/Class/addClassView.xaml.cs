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

        /*private int _staff;
        private string fileImageName = "";
        public int StaffID
        {
            get { return _id; }
            set { _id = value; }
        }*/
        private void staff_Click(object sender, EventArgs e)
        {
            Agency.staffDrop
        }

        private void addClass_Click(object sender, RoutedEventArgs e)
        {
            //int staff = this.textBox_staff;
            string code = this.textBox_code.Text;
            string room = this.textBox_room.Text;
            string campus = this.comboBox_campus.SelectedItem.ToString();
            string day = this.comboBox_day.SelectedItem.ToString();
            string type = this.comboBox_type.SelectedItem.ToString();
            TimeOnly start = new TimeOnly(11, 0, 0);
            TimeOnly end = new TimeOnly(13, 0, 0);

            Agency.AddClass(code, campus, day, start, end, type, room, staff);
            MessageBox.Show("Updated successully!");
        }
    }
}
