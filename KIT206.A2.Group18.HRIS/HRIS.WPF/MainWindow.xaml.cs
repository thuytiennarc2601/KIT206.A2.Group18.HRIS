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
using System.IO;
using System.Drawing;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KIT206.A2.Group18.HRIS;

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MIN_WIDTH_WITH_SUB_PANEL = 1200;
        private const string STAFF_LIST_KEY = "staffList";
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = (Controller)(Application.Current.FindResource(STAFF_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        #region Button Controls
        private bool choseStaff = false;
        private bool choseUnit = false;
        private bool choseClass = false;
        private bool choseConsultation = false;
        #endregion


        //private void staff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    GeneralListBox.ItemsSource = controller.GetViewableStaffList();
        //    MessageBox.Show("staff is pressed!");
        //}

        //private void Class_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    GeneralListBox.ItemsSource = controller.GetViewableClassList();
        //    MessageBox.Show("class is pressed!");
        //}

        //private void Consultation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    GeneralListBox.ItemsSource = controller.GetViewableConsultationList();
        //    MessageBox.Show("consultation is pressed!");
        //}

        //private void Unit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    GeneralListBox.ItemsSource = controller.GetViewableUnitList();
        //    MessageBox.Show("unit is pressed!");
        //}

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            staffListItem selectedStaff = (staffListItem)GeneralListBox.SelectedItem;
            if (choseStaff)
            {
                
                ShowStaffDetails(selectedStaff.ID);
                this.MinWidth = MIN_WIDTH_WITH_SUB_PANEL;
                this.StaffDetailView.Visibility = Visibility.Visible;
                
            }
            MessageBox.Show(selectedStaff.StaffInfo);
        }

        private void HRIS_Loaded(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffItemList();
            this.Width = this.MinWidth;
            this.StaffDetailView.Visibility = Visibility.Hidden;
            choseStaff = true;
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffItemList();
            choseStaff = true;
            choseUnit = false;
            choseClass = false;
            choseConsultation = false;
        }

        private void unitButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableUnitItemList();
        }

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableClassItemList();
        }

        private void conButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableConsulItemList();
        }

        #region Load Staff Details Into MainView.StaffDetailView By StaffID 
        private void ShowStaffDetails(int staffID)
        {
            List<Staff> staffList = Agency.LoadAllStaffs();

            var getStaff = from Staff s in staffList
                           where s.ID == staffID
                           select s;

            List<Staff> result = new List<Staff>(getStaff);

            if (result[0].Photo == null || result[0].Photo.Length == 0)
            {
                this.StaffPhoto.Source = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
            }
            else
            {
                this.StaffPhoto.Source = Staff.ByteToImage(result[0].Photo);
            }
            this.StaffName.Content = result[0].Title + ". " + result[0].GivenName + " " + result[0].FamilyName;
            this.StaffID.Content = result[0].ID.ToString();
            this.StaffCategory.Content = result[0].category.ToString().ToUpper();
            this.StaffContact.Content = "Phone: " + result[0].Phone;
            this.StaffEmail.Content = "Email: " + result[0].Email;
            this.StaffLocation.Content = "Room: " + result[0].Room + " | " + result[0].campus.ToString();

        }
        #endregion
    }
}
