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
            staffInfo.Content = staff.Title + " " + staff;
            staffID.Content = staff.ID;
            staffEmail.Content = staff.Email;
            staffCampus.Content = staff.campus;
            staffCate.Content = staff.category;
        }
    }
}
