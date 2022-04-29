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
    /// Interaction logic for AddClassView.xaml
    /// </summary>
    public partial class AddClassView : Window
    {
        public AddClassView()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Unit selectedUnit = (Unit)this.UnitList.SelectedItem;
            Staff selectStaff = (Staff)this.StaffList.SelectedItem;

            string unitCode;
            int staffID;
            if (selectedUnit == null)
            {
                unitCode = "empty";
            }
            else { unitCode = selectedUnit.UnitCode; }

            if(selectStaff == null)
            {
                staffID = -1;
            } else { staffID = selectStaff.ID; }
            
            string campus = (string)this.CampusList.SelectedItem;
            string day = (string)this.DayList.SelectedItem;
            string type = (string)this.TypeList.SelectedItem;
            string room = this.RoomTB.Text;
            string startHour = this.StartHour.Text;
            string endHour = this.EndHour.Text; 
            string startMinute = this.StartMinute.Text;
            string endMinute = this.EndMinute.Text;

            if(Validation.TimeValidation(startHour, startHour, endHour, true)
            && Validation.TimeValidation(startMinute, startHour, endHour, false)
            && Validation.TimeValidation(endHour, startHour, endHour, true)
            && Validation.TimeValidation(endMinute, startHour, endHour, false))
            {
                string start = this.StartHour.Text + ":" + this.StartMinute.Text + ":00";
                string end = this.EndHour.Text + ":" + this.EndMinute.Text + ":00";

                if(Validation.AddingClassValidation(unitCode, campus, day, start, end, room, staffID) 
                    && Validation.AddingEditClassValidation(staffID, start, end, room, campus, day, type))
                {
                    Agency.AddClass(unitCode, campus, day, start, end, type, room, staffID);
                    this.Close();
                }
            }
        }
    }
}
