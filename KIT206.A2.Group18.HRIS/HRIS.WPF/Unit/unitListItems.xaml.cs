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
    /// Interaction logic for unitListItems.xaml
    /// </summary>
    public partial class unitListItems : UserControl
    {
        public unitListItems()
        {
            InitializeComponent();
        }

        #region Unit Properties
        private string _unitName;
        private string _unitCode;
        private int _staffID;
        private string _staffName;

        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; this.unitName.Content = value; }
        }

        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; this.unitCode.Content = value; }
        }

        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; this.unitCoordinator.Content = value; }
        }

        #endregion

        private void editCoorBtn_Click(object sender, RoutedEventArgs e)
        {
            EditUnitView view = Controller.ShowUnitDetails(UnitCode, UnitName, StaffID);
            view.Code = UnitCode;
            view.ShowDialog();
        }
    }
}
