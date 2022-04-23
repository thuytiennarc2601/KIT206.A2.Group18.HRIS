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
    /// Interaction logic for UnitDetailWindow.xaml
    /// </summary>
    public partial class UnitDetailWindow : Window
    {
        public UnitDetailWindow(Unit unit)
        {
            InitializeComponent();
            unitName.Content = unit.UnitName;
            unitCode.Content = unit.UnitCode;
            unitCoordinator.Content = unit.Coordinator;
        }
    }
}
