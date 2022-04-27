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
        private List<staffListItem> staffItems;
        private List<unitListItems> unitItems;
        private List<classListItems> classItems;
        private List<consultationListItem> consultationItems;

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

                    Staff staff = Staff.GetStaffByID(item.StaffID);
                    item.StaffName = "Coordinator: " + staff.ToString();  
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
                    item.Day = classList[i].day.ToString();
                    item.Campus = classList[i].campus.ToString();
                    item.StartTime = classList[i].StartTime;

                    Unit unit = Unit.GetUnitByCode(item.UnitCode);
                    item.UnitDetails = unit.ToString();

                    Staff staff = Staff.GetStaffByID(item.StaffID);

                    item.ClassType = classList[i].type.ToString() + " | Staff: " + staff.ToString();
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

                    Staff staff = Staff.GetStaffByID(item.StaffID);

                    item.StaffName = staff.ToString();
                    item.ID = "ID: " + item.StaffID.ToString();
                    item.ConTime = conList[i].day.ToString() + " | " + conList[i].StartTime.ToString() + " - " + conList[i].EndTime.ToString();
                    item.ConsultationDay = conList[i].day.ToString();
                    item.Start = conList[i].StartTime.ToString("HH:mm:ss");
                    item.End = conList[i].EndTime.ToString("HH:mm:ss");
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
            staffItems = AddStaffInfoToItem();
            return staffItems;
        }
        public List<unitListItems> GetViewableUnitItemList()
        {
            //generate a list of unit items
            unitItems = AddUnitInfoToItem();
            return unitItems;
        }
        public List<classListItems> GetViewableClassItemList()
        {
            //generate a list of class items
            classItems = AddClassInfoToItem();
            return classItems;
        }
        public List<consultationListItem> GetViewableConsulItemList()
        {
            //generate a list of consultation items
            consultationItems = AddConsultationInfoToItem();
            return consultationItems;
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

            //Load staff details into AddStaffInfoView
        #region Load Staff Details Into AddStaffInfoView
        public static AddStaffInfoView LoadStaffDetails(int StaffID)
        {
            AddStaffInfoView addInfoView = new AddStaffInfoView();
            Staff shownStaff = Staff.GetStaffByID(StaffID);

            addInfoView.Title = shownStaff.ToString();
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

        //UNIT MANAGEMENT: Show Unit Details, Search For A Staff Member, Add A New Unit
            //Show unit details (with classes) and allow users to change unit coordination
        #region Show A Unit Details
        public static EditUnitView ShowUnitDetails(string UnitCode, int StaffID)
        {
            EditUnitView view = new EditUnitView();
            List<Class> classes = Class.GetClassesByUnitCode(UnitCode);
            Staff staff = Staff.GetStaffByID(StaffID);

            Unit unit = Unit.GetUnitByCode(UnitCode);

            view.UnitName.Content = unit.UnitName;
            view.UnitCode.Content = unit.UnitCode.ToUpper();

            if (classes.Count > 0)
            {
                view.ClassList.ItemsSource = classes;
            }
            view.CoordinatorTB.Text = StaffID.ToString() + " | " + staff.ToString();

            return view;
        }
        #endregion

            //Show AddUnitView
        #region Show AddUnitView
        public static AddUnitView ShowAddUnit()
        {
            AddUnitView view = new AddUnitView();
            return view;
        }
        #endregion

        //CLASS MANAGEMENT
            //Load class details into EditClassDetails
        #region Show Class Details And Allows Users To Edit That Class Information
        public static EditClassDetails LoadClassDetails(int staffID, string code, string day, string campus, TimeOnly start)
        {
            EditClassDetails view = new EditClassDetails();

            Class thisClass = Class.GetClassByPrimaryKeys(code, day, campus, start);
            Unit unit = Unit.GetUnitByCode(code);
            Staff staff = Staff.GetStaffByID(staffID);

            view.StaffID = staffID;
            view.UnitDetailsTB.Text = unit.ToString();
            if (staff.ID != -1)
            {
                view.StaffDetailsTB.Text = staffID.ToString() + " | " + staff.ToString();
            }

            foreach (string dayName in Enum.GetNames(typeof(Day)))
            {
                view.DayList.Items.Add(dayName);
            }
            view.DayList.SelectedItem = day;

            view.CampusList.Items.Add(campus);
            view.CampusList.SelectedIndex = 0;

            if (thisClass.type == KIT206.A2.Group18.HRIS.Type.Undefined)
            {
                view.TypeList.Items.Add("Select..");
                foreach (string typeName in Enum.GetNames(typeof(KIT206.A2.Group18.HRIS.Type)))
                {
                    if (typeName != "Undefined")
                    {
                        view.TypeList.Items.Add(typeName);
                    }
                }
                view.TypeList.SelectedIndex = 0;
            }
            else
            {
                foreach (string typeName in Enum.GetNames(typeof(KIT206.A2.Group18.HRIS.Type)))
                {
                    if (typeName != "Undefined")
                    {
                        view.TypeList.Items.Add(typeName);
                    }
                }
                view.TypeList.SelectedItem = thisClass.type.ToString();
            }

            view.RoomTB.Text = thisClass.Room;

            view.StartHourTB.Text = thisClass.StartTime.ToString("HH");
            view.StartMinute.Text = thisClass.StartTime.ToString("mm");
            view.EndHourTB.Text = thisClass.EndTime.ToString("HH");
            view.EndMinuteTB.Text = thisClass.EndTime.ToString("mm");
            return view;
        }
        #endregion

    }
}
