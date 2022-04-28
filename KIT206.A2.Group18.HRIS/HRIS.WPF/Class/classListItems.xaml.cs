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

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for classListItems.xaml
    /// </summary>
    public partial class classListItems : UserControl
    {
        public classListItems()
        {
            InitializeComponent();
        }

        #region Class Properties
        //Class 'class' properties
        private string _unitCode;
        private int _staffID;
        private string _day;
        private string _campus;
        private TimeOnly _start;
        private TimeOnly _end;
        private string _room;
        private string _type;
        
        //Properties for classlistitem
        private string _unitDetails;
        private string _classType;
        private string _classTime;
        private string _classLocation;

        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; }
        }
        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public string Campus
        {
            get { return _campus; }
            set { _campus = value; }
        }

        public TimeOnly StartTime
        {
            get { return _start; }
            set { _start = value; }
        }

        public TimeOnly EndTime
        {
            get { return _end; }
            set { _end = value; }
        }

        public string Room
        {
            get { return _room; }
            set { _room = value; }
        }

        public string thisClassType
        {
            get { return _type; }
            set { _type = value; }
        }

        //Classlistitem properties
        public string UnitDetails
        {
            get { return _unitDetails; }
            set { _unitDetails = value; this.unitInfo.Content = value; }
        }
        
        public string ClassType
        {
            get { return _classType; }
            set { _classType = value; this.classInfo.Content = value; }
        }

        public string ClassTime
        {
            get { return _classTime; }
            set { _classTime = value; this.classTime.Content = value; }
        }

        public string ClassLocation
        {
            get { return _classLocation; }
            set { _classLocation = value; this.classLocation.Content = value; }
        }
        #endregion

        private void editClassBtn_Click(object sender, RoutedEventArgs e)
        {
            EditClassDetails view = Controller.LoadClassDetails(StaffID, UnitCode, Day, Campus, StartTime, EndTime, Room, thisClassType);
            view.UnitCode = UnitCode;
            view.Day = Day;
            view.Campus = Campus;
            view.ClassStart = StartTime;
            view.ShowDialog();
        }
    }
}
