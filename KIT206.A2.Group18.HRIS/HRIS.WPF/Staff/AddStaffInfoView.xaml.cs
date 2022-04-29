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
using System.Windows.Shapes;
using KIT206.A2.Group18.HRIS;

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for AddStaffInfoView.xaml
    /// </summary>
    public partial class AddStaffInfoView : Window
    { 

        public AddStaffInfoView()
        {
            InitializeComponent();
        }
        private int _id;
        private string fileImageName = "";
        public int StaffID
        {
            get { return _id; }
            set { _id = value; }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            fileImageName = ImageDealer.GetImageFileName();
            if (fileImageName != "")
            {
                this.StaffPhoto.Source = new BitmapImage(new Uri(fileImageName, UriKind.Absolute));
                
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string Title = this.TitleTB.Text;
            string Category = this.CategoryCB.SelectedItem.ToString().ToLower();
            string Phone = this.ContactTB.Text;
            string Room = this.RoomTB.Text;
            string Email = this.EmailTB.Text;
            string Campus = this.CampusCB.SelectedItem.ToString();
            byte[] Photo = ImageDealer.BytesFromImage(fileImageName);

            if (Validation.PhotoValidation(Photo))
            {
                Staff.UpdateStaffDetails(StaffID, Title, Category, Phone, Room, Email, Campus, Photo);
                this.Close();
            }
        }
    }
}
