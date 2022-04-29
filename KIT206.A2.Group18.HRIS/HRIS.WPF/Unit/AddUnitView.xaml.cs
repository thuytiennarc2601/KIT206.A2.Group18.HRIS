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
    /// Interaction logic for AddUnitView.xaml
    /// </summary>
    public partial class AddUnitView : Window
    {
        public AddUnitView()
        {
            InitializeComponent();
        }

        private int StaffID = -1;

        #region Add The Staff List From Search Result To Staff List (Box)
        private void AddStaffResultToStaffList()
        {
            if (this.CoordinatorTB.Text != "")
            {
                List<Staff> SearchResult = Staff.GetStaffListBySearchText(this.CoordinatorTB.Text);
                if (SearchResult.Count > 0)
                {
                    this.StaffList.Visibility = Visibility.Visible;
                    this.StaffList.ItemsSource = SearchResult;
                }
            }
            else
            {
                this.StaffList.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            AddStaffResultToStaffList();
        }

        private void CoordinatorTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddStaffResultToStaffList();
            }
        }

        private void StaffList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.StaffList.SelectedItem != null)
            {
                Staff selectedStaff = (Staff)this.StaffList.SelectedItem;
                this.CoordinatorTB.Text = selectedStaff.ToString();
                StaffID = selectedStaff.ID;

                this.StaffList.Visibility = Visibility.Hidden;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool valid = Validation.AddUnitValidation(this.UnitCodeTB.Text, this.UnitNameTB.Text, StaffID);
            if(valid)
            {
                Unit.AddUnit(this.UnitCodeTB.Text, this.UnitNameTB.Text, StaffID);
                this.Close();
            }
        }
    }
}
