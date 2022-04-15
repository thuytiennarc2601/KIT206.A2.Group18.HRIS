using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIT206.A2.Group18.HRIS
{
    public partial class classDetails : UserControl
    {
        public classDetails()
        {
            InitializeComponent();
        }

        private string _classType;
        private string _classTime;
        private string _classLocation;
        private string _classStaff;

        [Category("Class Properties")]
        public string ClassType
        {
            get { return _classType; }
            set { _classType = value; classType.Text = value; }
        }

        [Category("Class Properties")]
        public string ClassTime
        {
            get { return _classTime; }
            set { _classTime = value; classTime.Text = value; }
        }

        [Category("Class Properties")]
        public string ClassLocation
        {
            get { return _classLocation; }
            set { _classLocation = value; classLocation.Text = value; }
        }

        [Category("Class Properties")]
        public string ClassStaff
        {
            get { return _classStaff; }
            set { _classStaff = value; classStaff.Text = value; }
        }


    }
}
