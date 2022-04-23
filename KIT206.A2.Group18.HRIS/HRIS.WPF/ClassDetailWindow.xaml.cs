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
    /// Interaction logic for ClassDetailWindow.xaml
    /// </summary>
    public partial class ClassDetailWindow : Window
    {
        private Controller controller;
        private const string CLASS_LIST_KEY = "classList";
        private string unitCode;
        private Campus campus;
        private Day day;
        private TimeOnly start;
        private TimeOnly end;
        private Type type;
        private string room;
        private int staffID;
        public ClassDetailWindow(Class classdetail)
        {
            InitializeComponent();
            controller = (Controller)(Application.Current.FindResource(CLASS_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            unitInfo.Content = classdetail.unit.UnitCode + " | " + classdetail.unit;
            classInfo.Content = classdetail.type + " | " + classdetail.staff;
            classLocation.Content = "Room " + classdetail.Room + " | " +classdetail.campus + " campus";
            classTime.Content = classdetail.day + " | " + classdetail.StartTime + " - " + classdetail.EndTime;
            unitCode = classdetail.unit.UnitCode;
            campus = classdetail.campus;
            day = classdetail.day;
            start = classdetail.StartTime; 
            end = classdetail.EndTime;
            type = classdetail.type;
            room = classdetail.Room;
            staffID = classdetail.staff.ID;
        }

        private void editClassBtn_Click(object sender, RoutedEventArgs e)
        {
            controller.EditClassDetail(newCampus.Text, newDay.Text, newStartTime.Text, newEndTime.Text, newType.Text, newRoom.Text, newStaffID.Text, unitCode, campus.ToString(), 
                day.ToString(), start.ToString("HH:mm:ss"), end.ToString("HH:mm:ss"), type.ToString(), room, staffID);
            MessageBox.Show("Class Detail Edited");
        }
    }
}
