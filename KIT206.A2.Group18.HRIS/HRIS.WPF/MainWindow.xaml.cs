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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string STAFF_LIST_KEY = "staffList";
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = (Controller)(Application.Current.FindResource(STAFF_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }



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

        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffItemList();
        }

        private void HRIS_Loaded(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffItemList();
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
    }
}
