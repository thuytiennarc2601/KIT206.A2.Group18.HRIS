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
    public partial class consultationListItem : UserControl
    {
        public consultationListItem()
        {
            InitializeComponent();
        }

        #region Properties

        private int _itemID;
        private string _staffName;
        private string _dayTime;
        private string _location;
        private string _staffID;

        [Category("Consultation properties")]
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        [Category("Consultation properties")]
        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; staffInfo.Text = value; }
        }

        [Category("Consultation properties")]
        public string StaffID
        {
            get { return _staffID; }
            set { _staffID = value; staffID.Text = value; }
        }

        [Category("Consultation properties")]
        public string DayTimeCon
        {
            get { return _dayTime; }
            set { _dayTime = value; DayTime.Text = value; }
        }
        [Category("Consultation properties")]
        public string ConLocation
        {
            get { return _location; }
            set { _location = value; conLocation.Text = value; }
        }

        #endregion

        private void consultationListItem_MouseEnter(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.LightSteelBlue;
        }

        private void consultationListItem_MouseLeave(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.White;
        }
    }
}
