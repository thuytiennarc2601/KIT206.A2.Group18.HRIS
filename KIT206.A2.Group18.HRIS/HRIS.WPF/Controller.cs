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
        //private List<Staff> staff;
        //private List<Unit> unit;
        //private List<Class> classes;
        //private List<Consultation> consultation;

        private List<staffListItem> staffItem;
        private List<unitListItems> unitItem;
        private List<classListItems> classItem;
        private List<consultationListItem> consultationItem;
        //public List<Staff> Workers { get { return staff; } set { } }

        //private ObservableCollection<Staff> viewableStaff;
        //private ObservableCollection<Unit> viewableUnit;
        //private ObservableCollection<Class> viewableClasses;
        //private ObservableCollection<Consultation> viewableConsultation;

        private ObservableCollection<staffListItem> viewableStaffItem;
        private ObservableCollection<unitListItems> viewableUnitItem;
        private ObservableCollection<classListItems> viewableClassItem;
        private ObservableCollection<consultationListItem > viewableConsultationItem;
        //public ObservableCollection<Staff> VisibleStaffs { get { return viewableStaff; } set { } }
        //public ObservableCollection<Unit> VisibleUnits { get { return viewableUnit; } set { } }
        //public ObservableCollection<Class> VisibleClasses { get { return viewableClasses; } set { } }
        //public ObservableCollection<Consultation> VisibleConsultations { get { return viewableConsultation; } set { } }

        public ObservableCollection<staffListItem> VisibleStaffItem { get { return viewableStaffItem; } set { } }
        public ObservableCollection<unitListItems> VisibleUnitItem { get { return viewableUnitItem; } set { } }
        public ObservableCollection <classListItems> VisibleClassItem { get { return viewableClassItem; } set { } }
        public ObservableCollection<consultationListItem> VisibleConsultationItem { get { return viewableConsultationItem; } set { } }
        public Controller ()
        {
            //generate a list of staff items
            staffItem = AddStaffInfoToItem();
            viewableStaffItem = new ObservableCollection<staffListItem>(staffItem);

            //generate a list of unit items
            unitItem = AddUnitInfoToItem();
            viewableUnitItem = new ObservableCollection<unitListItems>(unitItem);

            //generate a list of class items
            classItem = AddClassInfoToItem();
            viewableClassItem = new ObservableCollection<classListItems>(classItem);

            //generate a list of consultation items
            consultationItem = AddConsultationInfoToItem();
            viewableConsultationItem = new ObservableCollection<consultationListItem>(consultationItem);

            //should use LINQ
            //foreach (Staff e in staff)
            //{
            //    e.Consultations = Agency.LoadConsultations(e.ID);
            //    e.Classes = Agency.LoadClasses(e.ID);
            //}

            //unitItem = Agency.LoadAllUnits();
            //viewableUnit = new ObservableCollection<Unit>(unit);

            //classes = Agency.LoadAllClasses();
            //viewableClasses = new ObservableCollection<Class>(classes);

            //consultation = Agency.LoadAllConsultations();
            //viewableConsultation = new ObservableCollection<Consultation>(consultation);
        }

        #region Display Staff List
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
                    item.StaffInfo = staff[i].Title + ". " + staff[i].GivenName + " " + staff[i].FamilyName;
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
                        item.StaffPhoto = ByteToImage(staff[i].Photo);
                    }
                    items.Add(item);
                }
            }
            return items;
        }

        //Convert from byte array to imagesource
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
        #endregion

        #region Display Unit List
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

        #region Display Class List
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

        #region Display Consultation List
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
        //public ObservableCollection<Staff> GetViewableStaffList()
        //{
        //    return VisibleStaffs;
        //}
        //public ObservableCollection<Unit> GetViewableUnitList()
        //{
        //    return VisibleUnits;
        //}
        //public ObservableCollection<Class> GetViewableClassList()
        //{
        //    return VisibleClasses;
        //}
        //public ObservableCollection<Consultation> GetViewableConsultationList()
        //{
        //    return VisibleConsultations;
        //}
        public ObservableCollection<staffListItem> GetViewableStaffItemList()
        {
            return VisibleStaffItem;
        }
        public ObservableCollection<unitListItems> GetViewableUnitItemList()
        {
            return VisibleUnitItem;
        }
        public ObservableCollection<classListItems> GetViewableClassItemList()
        {
            return VisibleClassItem;
        }
        public ObservableCollection<consultationListItem> GetViewableConsulItemList()
        {
            return VisibleConsultationItem;
        }
    }
}
