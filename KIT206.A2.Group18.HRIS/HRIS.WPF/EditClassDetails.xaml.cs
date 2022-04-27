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
    /// Interaction logic for EditClassDetails.xaml
    /// </summary>
    public partial class EditClassDetails : Window
    {
        public EditClassDetails()
        {
            InitializeComponent();
        }

        private string _code;
        private string _campus;
        private string _day;
        private TimeOnly _start;
        private int _id = -1;

        public int StaffID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string UnitCode
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Campus
        {
            get { return _campus; }
            set { _campus = value; }
        }

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public TimeOnly ClassStart
        {
            get { return _start; }
            set { _start = value; }
        }

        #region Show Search Result
        //Show unit search result
        private void AddUnitToSearchResult()
        {
            if (this.UnitDetailsTB.Text != "")
            {
                List<Unit> result = Unit.GetUnitsBySearchText(this.UnitDetailsTB.Text);
                if (result.Count > 0)
                {
                    this.UnitList.Visibility = Visibility.Visible;
                    this.UnitList.ItemsSource = result;
                }
                else
                {
                    this.UnitList.Visibility = Visibility.Hidden;
                }
            }
        }

        //Show staff search result
        private void AddStaffToSearchResult()
        {
            if(this.StaffDetailsTB.Text != "")
            {
                List<Staff> result = Staff.GetStaffListBySearchText(this.StaffDetailsTB.Text);
                if(result.Count > 0)
                {
                    this.StaffList.Visibility = Visibility.Visible;
                    this.StaffList.ItemsSource = result;
                }
                else
                {
                    this.StaffList.Visibility= Visibility.Hidden;
                }
            }
        }

        #endregion

        private void UnitDetailsTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddUnitToSearchResult();
            }
        }

        private void StaffDetailsTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                AddStaffToSearchResult();
            }
        }

        private void SearchUnitButton_Click(object sender, RoutedEventArgs e)
        {
            AddUnitToSearchResult();
        }

        private void SearchStaffButton_Click(object sender, RoutedEventArgs e)
        {
            AddStaffToSearchResult();
        }

        private void UnitList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit selectedUnit = (Unit)UnitList.SelectedItem;
            this.UnitCode = selectedUnit.UnitCode;
            this.UnitDetailsTB.Text = selectedUnit.ToString();
        }

        private void StaffList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Staff selectedStaff = (Staff)StaffList.SelectedItem;
            this.StaffID = selectedStaff.ID;
            this.StaffDetailsTB.Text = selectedStaff.ID.ToString() + selectedStaff.ToString();
        }
    }
}
