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
    /// Interaction logic for staffListItem.xaml
    /// </summary>
    public partial class staffListItem : UserControl
    {
        public staffListItem()
        {
            InitializeComponent();
        }

        #region Staff Item Properties
        private string _staffInfo;
        private string _staffID;
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

        private void staffItem1_MouseEnter(object sender, MouseEventArgs e)
        {
            //this.selectBar.Fill = new SolidColorBrush(Color.FromRgb(85, 132, 57));
            //this.selectBar.Stroke = new SolidColorBrush(Color.FromRgb(85, 132, 57));
        }

        private void staffItem1_MouseLeave(object sender, MouseEventArgs e)
        {
            //this.selectBar.Fill = new SolidColorBrush(Colors.White);
            //this.selectBar.Stroke = new SolidColorBrush(Colors.White);
        }
    }
}
