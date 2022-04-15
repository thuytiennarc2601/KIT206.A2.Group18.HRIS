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
        private int staffID;

        #region Properties

        [Category("Ëxtra properties")]
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        #endregion

        #region Display detail
        //Load staff details based on its index in the list
        private void staffDetailView_Load(object sender, EventArgs e)
        {
            List<Staff> staffList = Staff.LoadAllStaffList();
            int id = this.ItemID;
            this.staffID = staffList[id].ID;
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
            getUnit(staffID);
            getConsultation(staffID);
        }
        #endregion

        #region Get Unit
        //Get the units that the staff member teachs
        private void getUnit(int staffID)
        {
            List<Unit> unitList = Unit.LoadAllUnit();

            var getUnitList = from Unit u in unitList
                              where staffID == u.Coordinator.ID
                              select u;

            List<Unit> result = new List<Unit>(getUnitList);
            Label[] unitLabels = new Label[result.Count];

            for(int i = 0; i < result.Count; i++)
            {
                unitLabels[i] = new Label();
                unitLabels[i].Name = "unitLabel";
                unitLabels[i].ForeColor = Color.Gray;
                unitLabels[i].AutoSize = true;
                unitLabels[i].Font = new Font("Calibri", 16);
                unitLabels[i].Text = result[i].UnitCode.ToUpper() + " | " + result[i].UnitName;

                unitHolder.Controls.Add(unitLabels[i]);
            }
        }
        #endregion

        #region Get Consultation
        //Get the consultations of the staff member
        private void getConsultation(int staffID)
        {
            List<Consultation> conList = Consultation.GetAllConsultation();
            var getConList = from Consultation c in conList
                             where staffID == c.staff.ID
                             select c;
            List<Consultation> result = new List<Consultation>(getConList);
            Label[] conLabels = new Label[result.Count];

            for(int i = 0; i<result.Count; i++)
            {
                conLabels[i] = new Label();
                conLabels[i].Name = "conLabel";
                conLabels[i].ForeColor = Color.Gray;
                conLabels[i].AutoSize = true;
                conLabels[i].Font = new Font("Calibri", 16);
                conLabels[i].Text = result[i].day.ToString() + " | " + result[i].StartTime.ToString() + " - " + result[i].EndTime.ToString();

                consultationHolder.Controls.Add(conLabels[i]);
            }
        }
        #endregion
    }
}
