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
        private string _unitCode;
        private string _unitDetails;
        private int _staffID;
        private string _classType;
        private string _classTime;
        private string _classLocation;

        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; }
        }

        public string UnitDetails
        {
            get { return _unitDetails; }
            set { _unitDetails = value; this.unitInfo.Content = value; }
        }

        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
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
    }
}
