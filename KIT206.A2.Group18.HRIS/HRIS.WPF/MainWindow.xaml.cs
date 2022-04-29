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
        private const string STAFF_LIST_KEY = "staffList";
        private const int DIFFER_LIST_BOX = 32;
        private Controller controller;

        private double differSize = 0;
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

        private void HRIS_Loaded(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffItemList();
            choseStaff = true;
            ChangeContentOnTab("Displaying Staff List", "Nothing", choseStaff);
        }

        private void GeneralListBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            differSize = ChangeListItemSize();
        }

        #region Display a functioning dialog when a GeneralListBox's item is chosen
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (choseStaff)
            {
                
            }

            if(choseUnit)
            {
                unitListItems selectedUnit = (unitListItems)GeneralListBox.SelectedItem;
                if(selectedUnit != null)
                {
                    EditUnitView view = Controller.ShowUnitDetails(selectedUnit.UnitCode, selectedUnit.UnitName, selectedUnit.StaffID);
                    view.Code = selectedUnit.UnitCode;
                    view.ShowDialog();
                }
            }

            if(choseClass)
            {
                classListItems tClass = (classListItems)GeneralListBox.SelectedItem;
                if( tClass != null)
                {
                    EditClassDetails view = Controller.LoadClassDetails(tClass.StaffID, tClass.UnitCode, tClass.Day, tClass.Campus, tClass.StartTime, tClass.EndTime, tClass.Room, tClass.thisClassType);
                    view.UnitCode = tClass.UnitCode;
                    view.Day = tClass.Day;
                    view.Campus = tClass.Campus;
                    view.ClassStart = tClass.StartTime;
                    view.ShowDialog();
                }
            }
        }
        #endregion

        #region Functions for clicking Staff button, Unit button, Class button, Consultation button
        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableStaffItemList();
            choseStaff = true; //staff tab is chosen
            choseUnit = false;
            choseClass = false;
            choseConsultation = false;
            SetNewSize();
            ChangeContentOnTab("Displaying Staff List", "Nothing", choseStaff);
        }

        private void unitButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableUnitItemList();
            choseStaff = false;
            choseUnit = true; //Unit tab is chosen
            choseClass = false;
            choseConsultation = false;
            SetNewSize();
            ChangeContentOnTab("Displaying Unit List", "Add Unit", choseUnit);
        }

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableClassItemList();
            choseStaff = false;
            choseUnit = false;
            choseClass = true; //class tab is chosen
            choseConsultation = false;
            SetNewSize();
            ChangeContentOnTab("Displaying Class List", "Add Class", choseClass);
        }

        private void conButton_Click(object sender, RoutedEventArgs e)
        {
            GeneralListBox.ItemsSource = controller.GetViewableConsulItemList();
            choseStaff = false;
            choseUnit = false;
            choseClass = false;
            choseConsultation = true; //consultation tab is chosen
            SetNewSize();
            ChangeContentOnTab("Displaying Consultation List", "Add Consultation", choseConsultation);
        }
        #endregion

        #region Perform different operations based on the chosen tab when clicking Add Button 
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(choseUnit)
            {
                AddUnitView view = Controller.ShowAddUnit();
                view.ShowDialog();
            }

            if(choseClass)
            {
                AddClassView view = Controller.ShowAddClass();
                view.ShowDialog();
            }

            if(choseConsultation)
            {
                AddConsultationView view = Controller.ShowAddConsultation();
                view.ShowDialog();
            }
        }
        #endregion

        #region Load an entity list again when HRIS is re-activated
        private void HRIS_Activated(object sender, EventArgs e)
        {
            if (choseStaff)
            {
                GeneralListBox.ItemsSource = controller.GetViewableStaffItemList();
                SetNewSize();
            }
            if (choseUnit)
            {
                GeneralListBox.ItemsSource = controller.GetViewableUnitItemList();
                SetNewSize();
            }
            if (choseClass)
            {
                GeneralListBox.ItemsSource = controller.GetViewableClassItemList();
                SetNewSize();
            }
            if (choseConsultation)
            {
                GeneralListBox.ItemsSource = controller.GetViewableConsulItemList();
                SetNewSize();
            }
        }
        #endregion

        //Makes GeneralListBox Responsive
        #region Set a new size to GeneralListBox's items when size changed
        private double ChangeListItemSize()
        {
            double size = 0;

            if(GeneralListBox.Items.Count > 0)
            {
                for(int i = 0; i < GeneralListBox.Items.Count; i++)
                {
                    if (choseStaff)
                    {
                        staffListItem staffItem = (staffListItem)GeneralListBox.Items[i];
                        staffItem.Width = GeneralListBox.ActualWidth - DIFFER_LIST_BOX;
                        
                        if(size == 0)
                        {
                            size = staffItem.Width;
                        }
                    }
                    if(choseUnit)
                    {
                        unitListItems unitItem = (unitListItems)GeneralListBox.Items[i];
                        unitItem.Width = GeneralListBox.ActualWidth - DIFFER_LIST_BOX;
                        if(size == 0)
                        {
                            size = unitItem.Width;
                        }
                    }
                    if(choseClass)
                    {
                        classListItems classItem = (classListItems)GeneralListBox.Items[i];
                        classItem.Width = GeneralListBox.ActualWidth - DIFFER_LIST_BOX;
                        if(size == 0)
                        {
                            size = classItem.Width;
                        }
                    }
                    if(choseConsultation)
                    {
                        consultationListItem conItem = (consultationListItem)GeneralListBox.Items[i];
                        conItem.Width = GeneralListBox.ActualWidth - DIFFER_LIST_BOX;
                        if(size == 0)
                        {
                            size = conItem.Width;
                        }
                    }
                }
            }
            return size;
        }
        #endregion

        #region Set the new size to GeneralListBox's items when choosing a tab
        private void SetNewSize()
        {
            if(GeneralListBox.Items.Count > 0)
            {
                for (int i = 0; i < GeneralListBox.Items.Count; i++)
                {
                    if(choseStaff && differSize != 0)
                    {
                        staffListItem staffItem = (staffListItem)GeneralListBox.Items[i];
                        staffItem.Width = differSize;
                    }
                    if(choseUnit && differSize != 0)
                    {
                        unitListItems unitItem = (unitListItems)GeneralListBox.Items[i];
                        unitItem.Width = differSize;
                    }
                    if(choseClass && differSize != 0)
                    {
                        classListItems classItem = (classListItems)GeneralListBox.Items[i];
                        classItem.Width = differSize;
                    }
                    if(choseConsultation && differSize != 0)
                    {
                        consultationListItem conItem = (consultationListItem)GeneralListBox.Items[i];
                        conItem.Width = differSize;
                    }
                }
            }
        }
        #endregion

        //Change Add Button content and inform user what list is shown
        #region Change Add Button content and display message
        private void ChangeContentOnTab(string displayMessage, string buttonContent, bool choice)
        {
            if(choseStaff)
            {
                this.AddButton.Visibility = Visibility.Collapsed;
                this.DisplayInform.Content = displayMessage;
            }
            else if(choice)
            {
                this.AddButton.Visibility= Visibility.Visible;
                this.AddButton.Content = buttonContent;
                this.DisplayInform.Content = displayMessage;
            }
        }

        #endregion
    }
}
