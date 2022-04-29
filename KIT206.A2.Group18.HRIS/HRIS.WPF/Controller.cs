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

        //LOAD FOUR LISTS
        #region Load Staff List Into GeneralListBox
        //Load all staff info into the main listbox
        private List<staffListItem> AddStaffInfoToItem()
        {
            List<Staff> staff = Staff.LoadAllStaff();
            List<staffListItem> items = new List<staffListItem>();
            if (staff.Count > 0)
            {
                for (int i = 0; i < staff.Count; i++)
                {
                    staffListItem item = new staffListItem();
                    item.ID = staff[i].ID;
                    item.GivenName = staff[i].GivenName;
                    item.FamilyName = staff[i].FamilyName;
                    item.Email = staff[i].Email;
                    item.Phone = staff[i].Phone;
                    item.sCampus = staff[i].campus.ToString();
                    item.sCategory = staff[i].category.ToString();
                    item.Photo = staff[i].Photo;
                    item.Room = staff[i].Room;
                    item.Title = staff[i].Title;

                    item.StaffInfo = staff[i].ToString();
                    item.StaffCategory = staff[i].category.ToString().ToUpper();
                    item.StaffEmail = "Email: " + staff[i].Email;
                    item.StaffLocation = "Room: " + staff[i].Room + " | " + staff[i].campus.ToString() + " campus";

                    if (staff[i].Photo == null || staff[i].Photo.Length < ImageDealer.MINIMUM_IMAGE_SIZE)
                    {
                        item.StaffPhoto = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
                    }
                    else if(staff[i].Photo.Length >= ImageDealer.MINIMUM_IMAGE_SIZE)
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
            List<Unit> unitList = Unit.LoadAllUnits();
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
                    item.EndTime = classList[i].EndTime;
                    item.Room = classList[i].Room;
                    item.thisClassType = classList[i].type.ToString();

                    Unit unit = Unit.GetUnitByCode(item.UnitCode);
                    item.UnitDetails = unit.ToString();

                    Staff staff = Staff.GetStaffByID(item.StaffID);

                    item.ClassType = item.thisClassType + " | Staff: " + staff.ToString();
                    item.ClassTime = item.Day + " | " + item.StartTime + " - " + item.EndTime;
                    item.ClassLocation = "Room: " + item.Room + " | " + item.Campus + " campus";
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
            List<Consultation> conList = Consultation.LoadAllConsultations();
            List<consultationListItem> items = new List<consultationListItem>();

            if(conList.Count > 0)
            {
                for (int i = 0; i < conList.Count; i++)
                {
                    consultationListItem item = new consultationListItem();
                    item.StaffID = conList[i].staff.ID;

                    Staff staff = Staff.GetStaffByID(item.StaffID);

                    item.StaffName = staff.ToString();
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
        public static StaffDetailView ShowStaffDetails(int StaffID, string title, string gname, string fname, string email, string phone, string campus, string category, string room, byte[] photo)
        {
            List<Unit> thisStaffUnits = Unit.GetUnitsByStaffID(StaffID);
            List<Consultation> thisStaffConsultations = Consultation.GetConsultationByStaffID(StaffID);
            StaffDetailView detailView = new StaffDetailView();

            detailView.Title = StaffID.ToString() + " | " + title + ". " + gname + " " + fname + "Information";

            //set staff data
            if (photo == null || photo.Length < ImageDealer.MINIMUM_IMAGE_SIZE)
            {
                detailView.StaffPhoto.Source = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
            }
            else if(photo.Length >= ImageDealer.MINIMUM_IMAGE_SIZE)
            {
                detailView.StaffPhoto.Source = ImageDealer.ByteToImage(photo);
            }
            detailView.StaffName.Text = StaffID.ToString() + " | " + title + ". " + gname + " " + fname;
            detailView.StaffCategory.Content = category.ToString().ToUpper();
            detailView.StaffPhone.Content = "Phone: " + phone;
            detailView.StaffEmail.Content = "Email: " + email;

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
        public static AddStaffInfoView LoadStaffDetails(int StaffID, string title, string gname, string fname, string email, string phone, string campus, string category, string room, byte[] photo)
        {
            AddStaffInfoView addInfoView = new AddStaffInfoView();

            addInfoView.Title = StaffID.ToString() + title + ". " + gname + " " + fname;
            //set staff data
            if (photo == null || photo.Length < ImageDealer.MINIMUM_IMAGE_SIZE)
            {
                addInfoView.StaffPhoto.Source = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
            }
            else if(photo.Length >= ImageDealer.MINIMUM_IMAGE_SIZE)
            {
                addInfoView.StaffPhoto.Source = ImageDealer.ByteToImage(photo);
            }
            addInfoView.TitleTB.Text = title;
            addInfoView.GNameTB.Text = gname;
            addInfoView.GNameTB.IsEnabled = false;
            addInfoView.FNameTB.Text = fname;
            addInfoView.FNameTB.IsEnabled = false;

            if(category == Category.uncategorised.ToString())
            {
                addInfoView.CategoryCB.Items.Add("Select..");
                foreach(string name in Enum.GetNames(typeof(Category)))
                {
                    if(name != "uncategorised")
                    {
                        addInfoView.CategoryCB.Items.Add(name.ToUpper());
                    }
                }
                addInfoView.CategoryCB.SelectedIndex = 0;
            } else{ addInfoView.CategoryCB.Items.Add(category.ToUpper()); addInfoView.CategoryCB.SelectedIndex = 0;}

            addInfoView.ContactTB.Text = phone;
            if(phone != "No contact added")
            {
                addInfoView.ContactTB.IsEnabled = false;
            }

            addInfoView.EmailTB.Text = email;
            if(email != "No email added")
            {
                addInfoView.EmailTB.IsEnabled = false;
            }

            addInfoView.RoomTB.Text = room;
            if(room != "Unknown")
            {
                addInfoView.RoomTB.IsEnabled = false;
            }

            if(campus == Campus.Unknown.ToString())
            {
                addInfoView.CampusCB.Items.Add("Select..");
                foreach(string name in Enum.GetNames(typeof(Campus)))
                {
                    if(name != "Unknown")
                    {
                        addInfoView.CampusCB.Items.Add(name);
                    }
                }
                addInfoView.CampusCB.SelectedIndex = 0;
            }
            else { addInfoView.CampusCB.Items.Add(campus); addInfoView.CampusCB.SelectedIndex = 0;}

            return addInfoView;
        }
        #endregion

        //UNIT MANAGEMENT: Show Unit Details, Search For A Staff Member, Add A New Unit
            //Show unit details (with classes) and allow users to change unit coordination
        #region Show A Unit Details
        public static EditUnitView ShowUnitDetails(string UnitCode, string UnitName, int StaffID)
        {
            EditUnitView view = new EditUnitView();
            List<Class> classes = Class.GetClassesByUnitCode(UnitCode);
            Staff staff = Staff.GetStaffByID(StaffID);

            view.UnitName.Content = UnitName;
            view.UnitCode.Content = UnitCode.ToUpper();

            if (classes.Count > 0)
            {
                view.ClassList.ItemsSource = classes;
            }
            view.CoordinatorTB.Text = staff.ToString();

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
            //Display AddClassView
        #region Display AddClassView
        public static AddClassView ShowAddClass()
        {
            AddClassView view = new AddClassView();

            view.UnitList.ItemsSource = Unit.LoadAllUnits();
            view.StaffList.ItemsSource = Staff.GetStaffsWithIDName();

            view.DayList.Items.Add("Select..");
            foreach (string name in Enum.GetNames(typeof(Day)))
            {
                view.DayList.Items.Add(name);
            }
            view.DayList.SelectedIndex = 0;

            view.CampusList.Items.Add("Select..");
            foreach (string name in Enum.GetNames(typeof(Campus)))
            {
                if (name != "Unknown")
                {
                    view.CampusList.Items.Add(name);
                }
            }
            view.CampusList.SelectedIndex = 0;


            view.TypeList.Items.Add("Select..");
            foreach (string name in Enum.GetNames(typeof(KIT206.A2.Group18.HRIS.Type)))
            {
                view.TypeList.Items.Add(name);
            }
            view.TypeList.SelectedIndex = 0;

            return view;
        }
        #endregion

            //Load class details into EditClassDetails
        #region Show Class Details And Allows Users To Edit That Class Information
        public static EditClassDetails LoadClassDetails(int staffID, string code, string day, string campus, TimeOnly start, TimeOnly end, string room, string type)
        {
            EditClassDetails view = new EditClassDetails();
            Unit unit = Unit.GetUnitByCode(code);
            Staff staff = Staff.GetStaffByID(staffID);

            view.StaffID = staffID;
            view.UnitDetailsTB.Text = unit.ToString();
            view.StaffDetailsTB.Text = staff.ToString();

            foreach (string dayName in Enum.GetNames(typeof(Day)))
            {
                view.DayList.Items.Add(dayName);
            }
            view.DayList.SelectedItem = day;

            view.CampusList.Items.Add(campus);
            view.CampusList.SelectedIndex = 0;

            foreach (string typeName in Enum.GetNames(typeof(KIT206.A2.Group18.HRIS.Type)))
            {
                view.TypeList.Items.Add(typeName);
            }
            view.TypeList.SelectedItem = type;

            view.RoomTB.Text = room;

            view.StartHourTB.Text = start.ToString("HH");
            view.StartMinute.Text = start.ToString("mm");
            view.EndHourTB.Text = end.ToString("HH");
            view.EndMinuteTB.Text = end.ToString("mm");
            return view;
        }
        #endregion

        //CONSULTATION MANAGEMENT
        //Display AddConsultationView
        #region Display AddConsultationView
        public static AddConsultationView ShowAddConsultation()
        {
            AddConsultationView view = new AddConsultationView();

            view.StaffList.ItemsSource = Staff.GetStaffsWithIDName();

            view.DayList.Items.Add("Select..");
            foreach(string name in Enum.GetNames (typeof(Day)))
            {
                view.DayList.Items.Add(name);
            }
            view.DayList.SelectedIndex = 0;
            return view;
        }
        #endregion

    }
}
