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
    /// Interaction logic for ClassDetailWindow.xaml
    /// </summary>
    public partial class ClassDetailWindow : Window
    {
        public ClassDetailWindow(Class classdetail)
        {
            InitializeComponent();
            unitInfo.Content = classdetail.unit;
            classInfo.Content = classdetail.type + " | " + classdetail.staff;
            classLocation.Content = classdetail.campus;
            classTime.Content = classdetail.day + " | " + classdetail.StartTime + " - " + classdetail.EndTime;
        }
    }
}
