﻿using System;
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
        private int id;
        private Day day;
        private TimeOnly Start;
        private TimeOnly End;
        private Controller controller;
        public ConsultationDetailWindow(Consultation consultation)
        {
            InitializeComponent();
            staffDetails.Content = consultation.staff.Title + " " + consultation.staff;
            staffID.Content = "Staff ID: " + consultation.staff.ID;
            consultationTime.Content =consultation.day + " | "+  consultation.StartTime + " - " + consultation.EndTime;
            id = consultation.staff.ID;
            day = consultation.day;
            Start = consultation.StartTime;
            End = consultation.EndTime;
        }

        private void conCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Agency.DeleteConsultation(id, day.ToString(), Start.ToString("HH:mm:ss"), End.ToString("HH:mm:ss"));
            MessageBox.Show("Consultation Time Cancelled!");
            Close();
        }
    }
}
