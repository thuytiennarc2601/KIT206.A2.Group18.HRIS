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
        private string _id;
        private string _staffName;
        private string _conTime;

        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; this.staffID.Content = value; }
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
        #endregion
    }
}
