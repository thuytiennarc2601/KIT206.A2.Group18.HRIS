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
    /// Interaction logic for staffListItem.xaml
    /// </summary>
    public partial class staffListItem : UserControl
    {
        private Controller controller;

        public staffListItem()
        {
            InitializeComponent();
        }

        #region Staff Item Properties
        //Staff properties
        private int _id;
        private string _givenName;
        private string _familyName;
        private string _email;
        private string _campus;
        private string _phone;
        private string _room;
        private string _category;
        private string _title;
        private byte[] _photo;

        //StaffListItem properties
        private string _staffInfo;
        private string _staffEmail;
        private string _staffLocation;
        private string _staffCategory;
        private ImageSource _staffPhoto;


        //Pubic Staff Properties
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string GivenName
        {
            get { return _givenName;}
            set { _givenName = value; }
        }

        public string FamilyName
        {
            get { return _familyName;}
            set { _familyName = value; }
        }

        public string sCategory
        {
            get { return _category;}
            set { _category = value; }
        }

        public string sCampus
        {
            get { return _campus; }
            set { _campus = value; }
        }

        public string Room
        {
            get { return _room;}
            set { _room = value; }
        }

        public string Phone
        {
            get { return _phone;}
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email;}
            set { _email = value; }
        }

        public byte[] Photo
        {
            get { return _photo;}
            set { _photo = value; }
        }

        //Public StaffListItem properties
        public string StaffInfo
        {
            get { return _staffInfo; }
            set { _staffInfo = value; this.staffInfo.Content = value; }
        }

        public string StaffCategory
        {
            get { return _staffCategory; }
            set { _staffCategory = value; this.staffCate.Content = value; }
        }

        public string StaffEmail
        {
            get { return _staffEmail; }
            set { _staffEmail = value; this.staffEmail.Content = value; }
        }

        public string StaffLocation
        {
            get { return _staffLocation; }
            set { _staffLocation = value; this.staffCampus.Content = value; }
        }

        public ImageSource StaffPhoto
        {
            get { return _staffPhoto; }
            set { _staffPhoto = value; this.staffPhoto.Source = value; }
        }

        #endregion

        private void editInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStaffInfoView view = Controller.LoadStaffDetails(ID, Title, GivenName, FamilyName, Email, Phone, sCampus, sCategory, Room, Photo);
            view.StaffID = ID;
            view.ShowDialog();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            StaffDetailView detailView = Controller.ShowStaffDetails(ID, Title, GivenName, FamilyName, Email, Phone, sCampus, sCategory, Room, Photo);
            detailView.ShowDialog();
        }
    }
}
