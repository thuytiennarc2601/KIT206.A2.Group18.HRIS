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

namespace HRIS.WPF
{
    /// <summary>
    /// Interaction logic for StaffDetailWindow.xaml
    /// </summary>
    public partial class StaffDetailWindow : Window
    {
        public StaffDetailWindow(Staff staff)
        {
            InitializeComponent();
            if (staff.Photo == null || staff.Photo.Length == 0)
            {
                staffPhoto.Source = new BitmapImage(new System.Uri("https://www.shareicon.net/data/128x128/2016/07/10/793851_people_512x512.png"));
            }
            else { 
                staffPhoto.Source = Controller.ByteToImage(staff.Photo);
            }
            staffInfo.Content = "Staff: "+staff.Title + " " + staff;
            staffID.Content = "Staff ID: "+staff.ID;
            staffEmail.Content ="Email: "+ staff.Email;
            staffCampus.Content ="Location: " + staff.Room + " | " + staff.campus;
            staffCate.Content = "Employment Type: " + staff.category;
        }
    }
}
