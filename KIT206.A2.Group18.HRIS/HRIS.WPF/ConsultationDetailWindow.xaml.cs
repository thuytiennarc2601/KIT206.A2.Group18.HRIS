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
    /// Interaction logic for ConsultationDetailWindow.xaml
    /// </summary>
    public partial class ConsultationDetailWindow : Window
    {
        public ConsultationDetailWindow(Consultation consultation)
        {
            InitializeComponent();
            staffDetails.Content = consultation.staff.Title + " " + consultation.staff;
            staffID.Content = consultation.staff.ID;
            consultationTime.Content = consultation.StartTime + " - " + consultation.EndTime;
        }
    }
}
