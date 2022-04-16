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
    public partial class unitListItem : UserControl
    {
        public unitListItem()
        {
            InitializeComponent();
        }

        #region Properties
        private string _unitName;
        private string _unitCode;
        private string _coordinatorName;
        private int _itemID;

        [Category("Unit properties")]
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        [Category("Unit properties")]
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; unitName.Text = value; }
        }

        [Category("Unit properties")]
        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; unitCode.Text = value; }
        }

        [Category("Unit properties")]
        public string CoordinatorName
        {
            get { return _coordinatorName; }
            set { _coordinatorName = value; coordinatorName.Text = value; }
        }

        #endregion

        private void unitListItem_MouseEnter(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.LightPink;
        }

        private void unitListItem_MouseLeave(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.White;
        }

        private void editCor_Click(object sender, EventArgs e)
        {
            editCoor editCoordinator = new editCoor();
            editCoordinator.ItemID = this.ItemID; //pass the index of this unit in the unit list to 'editCoor'
            editCoordinator.UnitCode = this.UnitCode; //pass the unit code to 'editCoor'
            editCoordinator.ShowDialog();
        }

        private void unitListItem_DoubleClick(object sender, EventArgs e)
        {
            unitDetailsView unitView = new unitDetailsView();
            unitView.ItemID = this.ItemID;  //pass the index of this unit in the unit list to 'unitDetailsView'
            unitView.ShowDialog();
        }
    }
}
