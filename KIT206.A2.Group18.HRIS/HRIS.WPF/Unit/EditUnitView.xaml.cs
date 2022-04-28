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
    /// Interaction logic for EditUnitView.xaml
    /// </summary>
    public partial class EditUnitView : Window
    {
        public EditUnitView()
        {
            InitializeComponent();
        }

        private int StaffID = -1;
        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.CoordinatorTB.IsEnabled = true;
        }

        private void CoordinatorTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (this.CoordinatorTB.Text != "")
                {
                    List<Staff> SearchResult = Staff.GetStaffListBySearchText(this.CoordinatorTB.Text);
                    if(SearchResult.Count > 0)
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaffID != -1)
            {
                Agency.UpdateUnitCoordinator(Code, StaffID);
                this.Close();
            }
            else { MessageBox.Show("No staff member is chosen"); }
        }
    }
}
