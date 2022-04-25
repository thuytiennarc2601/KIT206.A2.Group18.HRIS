using KIT206.A2.Group18.HRIS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace HRIS.WPF
{
    class Controller
    {
        private List<staffListItem> staffItem;
        private List<unitListItems> unitItem;
        private List<classListItems> classItem;
        private List<consultationListItem> consultationItem;

        //private ObservableCollection<staffListItem> viewableStaffItem;
        //private ObservableCollection<unitListItems> viewableUnitItem;
        //private ObservableCollection<classListItems> viewableClassItem;
        //private ObservableCollection<consultationListItem > viewableConsultationItem;

        //public ObservableCollection<staffListItem> VisibleStaffItem { get { return viewableStaffItem; } set { } }
        //public ObservableCollection<unitListItems> VisibleUnitItem { get { return viewableUnitItem; } set { } }
        //public ObservableCollection <classListItems> VisibleClassItem { get { return viewableClassItem; } set { } }
        //public ObservableCollection<consultationListItem> VisibleConsultationItem { get { return viewableConsultationItem; } set { } }
        //public Controller ()
        //{
            

            

            

            
        //}

        //Load details and display lists of four entities
        #region Load Staff List Into GeneralListBox
        //Load all staff info into the main listbox
        private List<staffListItem> AddStaffInfoToItem()
        {
            List<Staff> staff = Agency.LoadAllStaffs();
            List<staffListItem> items = new List<staffListItem>();

            if (staff.Count > 0)
            {
                for (int i = 0; i < staff.Count; i++)
                {
                    staffListItem item = new staffListItem();
                    item.ID = staff[i].ID;
                    item.StaffInfo = staff[i].ToString();
                    item.StaffID = "ID: " + staff[i].ID.ToString();
                    item.StaffCategory = staff[i].category.ToString().ToUpper();
                    item.StaffEmail = "Email: " + staff[i].Email;
                    item.StaffLocation = "Room: " + staff[i].Room + " | " + staff[i].campus.ToString() + " campus";

                    if (staff[i].Photo == null || staff[i].Photo.Length == 0)
                    {
                        item.StaffPhoto = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
                    }
                    else
                    {
                        item.StaffPhoto = ImageDealer.ByteToImage(staff[i].Photo);
                    }
                    items.Add(item);
                }
            }
            return items;
        }

        #endregion

        #region Load Unit List Into GeneralListBox
        //Load units info to the main listbox
        private List<unitListItems> AddUnitInfoToItem()
        {
            List<Unit> unitList = Agency.LoadAllUnits();
            List<Staff> staffList = Agency.LoadAllStaffs();
            List<unitListItems> items = new List<unitListItems>();

            if(unitList.Count > 0)
            {
                for(int i = 0; i < unitList.Count; i++)
                {
                    unitListItems item = new unitListItems();
                    item.UnitName = unitList[i].UnitName;
                    item.UnitCode = unitList[i].UnitCode.ToUpper();
                    item.StaffID = unitList[i].Coordinator.ID;

                    //LINQ
                    var getStaff = from Staff s in staffList
                                   where s.ID == item.StaffID
                                   select s;
                    List<Staff> result = new List<Staff>(getStaff);
                    item.StaffName = "Coordinator: " + result[0].Title + ". " + result[0].GivenName + " " + result[0].FamilyName;  
                    items.Add(item);
                }
            }
            return items;
        }
        #endregion

        #region Load Class List Into GeneralListBox
        //Load classes' details into the main listbox
        private List<classListItems> AddClassInfoToItem()
        {
            List<Class> classList = Agency.LoadAllClasses();
            List<Staff> staffList = Agency.LoadAllStaffs();
            List<Unit> unitList = Agency.LoadAllUnits();
            List<classListItems> items = new List<classListItems>();

            if(classList.Count > 0)
            {
                for(int i = 0; i < classList.Count; i++)
                {
                    classListItems item = new classListItems();
                    item.UnitCode = classList[i].unit.UnitCode;
                    item.StaffID = classList[i].staff.ID;

                    //LINQ
                    var getUnit = from Unit u in unitList
                                  where u.UnitCode == item.UnitCode
                                  select u;
                    List<Unit> resultUnit = new List<Unit>(getUnit);
                    item.UnitDetails = item.UnitCode.ToUpper() + " | " + resultUnit[0].UnitName;

                    //LINQ
                    var getStaff = from Staff s in staffList
                                   where s.ID == item.StaffID
                                   select s;

                    List<Staff> resultStaff = new List<Staff>(getStaff);
                    string staffName = resultStaff[0].Title + ". " + resultStaff[0].GivenName + resultStaff[0].FamilyName;

                    item.ClassType = classList[i].type.ToString() + " | Staff: " + staffName;
                    item.ClassTime = classList[i].day.ToString() + " | " + classList[i].StartTime.ToString() + " - " + classList[i].EndTime.ToString();
                    item.ClassLocation = "Room: " + classList[i].Room + " | " + classList[i].campus.ToString() + " campus";
                    items.Add(item);
                }    
            }
            return items;
        }
        #endregion

        #region Load Consultation List Into GeneralListBox
        //Load all consultations' details into the main listbox
        private List<consultationListItem> AddConsultationInfoToItem()
        {
            List<Consultation> conList = Agency.LoadAllConsultations();
            List<Staff> staffList = Agency.LoadAllStaffs();
            List<consultationListItem> items = new List<consultationListItem>();

            if(conList.Count > 0)
            {
                for (int i = 0; i < conList.Count; i++)
                {
                    consultationListItem item = new consultationListItem();
                    item.StaffID = conList[i].staff.ID;

                    var getStaff = from Staff s in staffList
                                   where s.ID == item.StaffID
                                   select s;

                    List<Staff> resultList = new List<Staff>(getStaff);

                    item.StaffName = resultList[0].Title + ". " + resultList[0].GivenName + " " + resultList[0].FamilyName;
                    item.ID = "ID: " + item.StaffID.ToString();
                    item.ConTime = conList[i].day.ToString() + " | " + conList[i].StartTime.ToString() + " - " + conList[i].EndTime.ToString();
                    items.Add(item);
                }
            }
            return items;
        }
        #endregion

        #region Return Item List
        public List<staffListItem> GetViewableStaffItemList()
        {
            //generate a list of staff items
            staffItem = AddStaffInfoToItem();
            return staffItem;
        }
        public List<unitListItems> GetViewableUnitItemList()
        {
            //generate a list of unit items
            unitItem = AddUnitInfoToItem();
            return unitItem;
        }
        public List<classListItems> GetViewableClassItemList()
        {
            //generate a list of class items
            classItem = AddClassInfoToItem();
            return classItem;
        }
        public List<consultationListItem> GetViewableConsulItemList()
        {
            //generate a list of consultation items
            consultationItem = AddConsultationInfoToItem();
            return consultationItem;
        }
        #endregion

        //STAFF MANAGEMENT: Show Staff Details, Add Staff Info
        //Show staff member's details (their information, their units and their consultations)
        #region Show A Staff Member Details
        public static StaffDetailView ShowStaffDetails(int StaffID)
        {
            Staff shownStaff = Staff.GetStaffByID(StaffID);
            List<Unit> thisStaffUnits = Unit.GetUnitsByStaffID(StaffID);
            List<Consultation> thisStaffConsultations = Consultation.GetConsultationByStaffID(StaffID);
            StaffDetailView detailView = new StaffDetailView();

            detailView.Title = shownStaff.ToString() + " Information";

            //set staff data
            if (shownStaff.Photo == null || shownStaff.Photo.Length == 0)
            {
                detailView.StaffPhoto.Source = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
            }
            else
            {
                detailView.StaffPhoto.Source = ImageDealer.ByteToImage(shownStaff.Photo);
            }
            detailView.StaffName.Content = shownStaff.ToString();
            detailView.StaffID.Content = "ID: " + StaffID.ToString();
            detailView.StaffCategory.Content = shownStaff.category.ToString().ToUpper();
            detailView.StaffPhone.Content = "Phone: " + shownStaff.Phone;
            detailView.StaffEmail.Content = "Email: " + shownStaff.Email;

            if (thisStaffUnits.Count > 0)
            {
                detailView.UnitList.ItemsSource = thisStaffUnits;
            }

            if( thisStaffConsultations.Count > 0)
            {
                detailView.ConsultationList.ItemsSource = thisStaffConsultations;
            }

            return detailView;
        }
        #endregion

        //Load staff details into AddStaffInfoView.
        #region Load Staff Details Into AddStaffInfoView
        public static AddStaffInfoView LoadStaffDetails(int StaffID)
        {
            AddStaffInfoView addInfoView = new AddStaffInfoView();
            Staff shownStaff = Staff.GetStaffByID(StaffID);

            //set staff data
            if (shownStaff.Photo == null || shownStaff.Photo.Length == 0)
            {
                addInfoView.StaffPhoto.Source = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
            }
            else
            {
                addInfoView.StaffPhoto.Source = ImageDealer.ByteToImage(shownStaff.Photo);
            }
            addInfoView.TitleTB.Text = shownStaff.Title;
            addInfoView.GNameTB.Text = shownStaff.GivenName;
            addInfoView.GNameTB.IsEnabled = false;
            addInfoView.FNameTB.Text = shownStaff.FamilyName;
            addInfoView.FNameTB.IsEnabled = false;

            if(shownStaff.category == Category.uncategorised)
            {
                addInfoView.CategoryCB.Items.Add("Select..");
                foreach(string category in Enum.GetNames(typeof(Category)))
                {
                    if(category != "uncategorised")
                    {
                        addInfoView.CategoryCB.Items.Add(category.ToUpper());
                    }
                }
                addInfoView.CategoryCB.SelectedIndex = 0;
            } else{ addInfoView.CategoryCB.Items.Add(shownStaff.category.ToString().ToUpper()); addInfoView.CategoryCB.SelectedIndex = 0;}

            addInfoView.ContactTB.Text = shownStaff.Phone;
            if(shownStaff.Phone != "No contact added")
            {
                addInfoView.ContactTB.IsEnabled = false;
            }

            addInfoView.EmailTB.Text = shownStaff.Email;
            if(shownStaff.Email != "No email added")
            {
                addInfoView.EmailTB.IsEnabled = false;
            }

            addInfoView.RoomTB.Text = shownStaff.Room;
            if(shownStaff.Room != "Unknown")
            {
                addInfoView.RoomTB.IsEnabled = false;
            }

            if(shownStaff.campus == Campus.Unknown)
            {
                addInfoView.CampusCB.Items.Add("Select..");
                foreach(string campus in Enum.GetNames(typeof(Campus)))
                {
                    if(campus != "Unknown")
                    {
                        addInfoView.CampusCB.Items.Add(campus);
                    }
                }
                addInfoView.CampusCB.SelectedIndex = 0;
            }
            else { addInfoView.CampusCB.Items.Add(shownStaff.campus); addInfoView.CampusCB.SelectedIndex = 0;}

            return addInfoView;
        }
        #endregion

    }
}
