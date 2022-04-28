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
        private string _staffInfo;
        private string _staffID;
        private int _id;
        private string _staffEmail;
        private string _staffLocation;
        private string _staffCategory;
        private ImageSource _staffPhoto;

        public string StaffInfo
        {
            get { return _staffInfo; }
            set { _staffInfo = value; this.staffInfo.Content = value; }
        }

        public string StaffID
        {
            get { return _staffID; }
            set { _staffID = value; this.staffID.Content = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
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
            AddStaffInfoView view = Controller.LoadStaffDetails(ID);
            view.StaffID = ID;
            view.ShowDialog();
        }
    }
}
