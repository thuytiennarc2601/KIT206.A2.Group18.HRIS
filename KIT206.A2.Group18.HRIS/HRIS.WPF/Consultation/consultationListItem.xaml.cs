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

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for consultationListItem.xaml
    /// </summary>
    public partial class consultationListItem : UserControl
    {
        public consultationListItem()
        {
            InitializeComponent();
        }

        #region Consultation Properties
        private int _staffID;
        private string _staffName;
        private string _conTime;

        private string _day;
        private string _start;
        private TimeOnly _start1;
        private TimeOnly _end1;
        private string _end;

        //Properties for Displaying data
        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; this.staffDetails.Content = value; }
        }

        public string ConTime
        {
            get { return _conTime; }
            set { _conTime = value; this.consultationTime.Content = value; }
        }

        //Properties for functionality
        public string Start
        {
            get { return _start; }
            set { _start = value; }

        }
        public string End
        {
            get { return _end; }
            set { _end = value; }
        }


        public TimeOnly Start1
        {
            get { return _start1; }
            set { _start1 = value; }

        }
        public TimeOnly End1
        {
            get { return _end1; }
            set { _end1 = value; }
        }

        public string ConsultationDay
        {
            get { return _day; }   
            set { _day = value; }
        }
        #endregion

        private void conUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            //Agency.UpdateConsultation(StaffID, ConsultationDay, Start, End)
            UpdateConsultationView view = Controller.ShowStaffDetails(StaffID, ConsultationDay, Start1, End1);
            view.ShowDialog();
        }

        private void conCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Agency.DeleteConsultation(StaffID, ConsultationDay, Start, End);
        }
    }
}
