﻿using System;
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
    public partial class staffListItem : UserControl
    {
        public staffListItem()
        {
            InitializeComponent();
        }

        #region Properties
        //defines all elements existing in a staff list item
        private string _name;
        private string _campus;
        private string _email;
        private string _id;
        private Image _icon;
        private int _itemID;

        [Category("Staff Properties")]
        public int ItemID
        {
            get {return _itemID; }
            set {_itemID = value; }
        }

        [Category("Staff Properties")]
        public string StaffName
        {
            get { return _name; }
            set { _name = value; staffName.Text = value; }
        }

        [Category("Staff Properties")]
        public string Campus
        {
            get { return _campus; }
            set { _campus = value; staffCampus.Text = value; }
        }

        [Category("Staff Properties")]
        public string Email
        {
            get { return _email; }
            set { _email = value; staffEmail.Text = value; }
        }

        [Category("Staff Properties")]
        public string ID
        {
            get { return _id; }
            set { _id = value; staffID.Text = value; }
        }

        [Category("Staff Properties")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; staffImage.Image = value ; }
        }
        #endregion

        private void staffListItem_MouseEnter(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.DarkSeaGreen;
        }

        private void staffListItem_MouseLeave(object sender, EventArgs e)
        {
            selectBar.BackColor = Color.White;
        }

        //open staff details
        //pass the list's index into 'staffDetailView'
        private void staffListItem_DoubleClick(object sender, EventArgs e)
        {
            staffDetailView staffDetail = new staffDetailView();
            staffDetail.ItemID = this.ItemID;
            staffDetail.ShowDialog();
        }

        //open edit staff info
        //pass the list's index into 'addStaffInfo'
        private void editStaff_Click(object sender, EventArgs e)
        {
            addStaffInfo addStaff = new addStaffInfo();
            addStaff.ItemID = this.ItemID;
            addStaff.ShowDialog();
        }
    }
}
