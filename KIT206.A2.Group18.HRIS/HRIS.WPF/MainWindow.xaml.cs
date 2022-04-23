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
        private Window subWindow;
        private ListType listType;
        public enum ListType { Staff, Class, Unit, Consultation};
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
            listType = ListType.Staff;
        }

        private void HRIS_Loaded(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffList();
        }

        private void unitButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableUnitList();
            listType = ListType.Unit;
        }

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableClassList();
            listType = ListType.Class;
        }

        private void conButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableConsultationList();
            listType = ListType.Consultation;
        }

        private void GeneralListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                switch (listType)
                {
                    case ListType.Staff:
                        subWindow = new StaffDetailWindow((Staff) e.AddedItems[0]);
                        subWindow.Show();
                        break;
                        
                    case ListType.Class:
                        subWindow = new ClassDetailWindow((Class)e.AddedItems[0]);
                        subWindow.Show();
                        break;
                        
                        
                    case ListType.Unit:
                        subWindow = new UnitDetailWindow((Unit)e.AddedItems[0]);
                        subWindow.Show();
                        break;
                        
                    case ListType.Consultation:
                        subWindow = new ConsultationDetailWindow((Consultation)e.AddedItems[0]);
                        subWindow.Show();
                        break;
                        
                }
            }
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
