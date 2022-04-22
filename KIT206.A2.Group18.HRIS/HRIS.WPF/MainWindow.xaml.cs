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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffList();
        }

        private void HRIS_Loaded(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffList();
        }

        private void unitButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableUnitList();
        }

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableClassList();
        }

        private void conButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableConsultationList();
        }
        /*
        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("delete is pressed!");
        }

        private void addConsultation_Click(object sender, RoutedEventArgs e)
        {
            controller.AddConsultation(Int32.Parse(addConsultationDetailWindow.staffIDTextBox.Text), addConsultationDetailWindow.dayComboBox.Text, addConsultationDetailWindow.startTextBox.Text, addConsultationDetailWindow.endTextBox.Text);
            MessageBox.Show("add consultation is pressed!");
        }
        */
    }
}
