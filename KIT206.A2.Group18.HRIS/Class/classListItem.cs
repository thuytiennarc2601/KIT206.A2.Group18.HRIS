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
    public partial class classListItem : UserControl
    {
        public classListItem()
        {
            InitializeComponent();
        }

        #region Properties

        private int _itemID;
        private string _unitInfo;
        private string _staffName;
        private string _dayTime;
        private string _typeRoomCampus;

        [Category("Class properties")]
        public int ItemID
        {
            get {return _itemID; }
            set {_itemID = value; }
        }

        [Category("Class properties")]
        public string UnitInfo
        {
            get { return _unitInfo; }
            set { _unitInfo = value; unitInfo.Text = value; }
        }

        [Category("Class properties")]
        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; staffInfo.Text = value; }
        }

        [Category("Class properties")]
        public string DayAndTime
        {
            get { return _dayTime; }
            set { _dayTime = value; classDayTime.Text = value; }
        }

        [Category("Class properties")]
        public string TypeRoomCampus
        {
            get { return _typeRoomCampus; }
            set { _typeRoomCampus = value; classTypeRoomCampus.Text = value; }
        }

        #endregion

        private void classListItem_MouseEnter(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.Wheat;
        }

        private void classListItem_MouseLeave(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.White;
        }
    }
}
