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
    public partial class coordinatorListItem : UserControl
    {
        public coordinatorListItem()
        {
            InitializeComponent();
        }

        #region Properties
        private string _name;
        private int _id;

        [Category("Coordinator Properties")]
        public string CoorName
        {
            get { return _name; }
            set { _name = value; coorIDName.Text = value; }
        }

        [Category("Coordinator Properties")]
        public int CoorID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        private void coordinatorListItem_MouseEnter(object sender, EventArgs e)
        {
            if (coorIDName.Text != "No result found")
            {
                selectBar.BackColor = Color.PaleVioletRed;
            }
        }

        private void coordinatorListItem_MouseLeave(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.White;
        }
    }
}
