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
    public partial class staffDetailView : Form
    {
        public staffDetailView()
        {
            InitializeComponent();
        }

        private int _itemID;

        #region Properties

        [Category("Ëxtra properties")]
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        #endregion

        //Load staff details based on its index in the list
        private void staffDetailView_Load(object sender, EventArgs e)
        {
            List<Staff> staffList = Staff.LoadAllStaffList();
            int id = this.ItemID;
            this.Text = staffList[id].Title + ". " + staffList[id].GivenName + " " + staffList[id].FamilyName;
            staffNameDetail.Text = staffList[id].Title + ". " + staffList[id].GivenName + " " + staffList[id].FamilyName;
            staffIDDetail.Text = "ID: " + (staffList[id].ID).ToString();
            staffCategoryDetail.Text = ((staffList[id].category).ToString() + " staff").ToUpper();
            staffPhoneDetail.Text = "Contact: " + staffList[id].Phone;
            staffEmailDetail.Text = "Email address: " + staffList[id].Email;
            staffCampusdetail.Text = "Location: " + staffList[id].Room + " | " + staffList[id].campus + " campus";

            if(staffList[id].Photo == null || staffList[id].Photo.Length == 0)
            {
                staffAvatar.Image = Properties.Resources.avatar;
            }
            else
            {
                ImageConverter converter = new System.Drawing.ImageConverter();
                staffAvatar.Image = converter.ConvertFrom(staffList[id].Photo) as Image;
            }
        }
    }
}
