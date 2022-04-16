using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KIT206.A2.Group18.HRIS
{
    public partial class editCoor : Form
    {
        private static MySqlConnection conn;
        public editCoor()
        {
            InitializeComponent();
        }

        #region Properties
        private string coordinatorInfo;
        private int coorID;
        private int iniCoorID;

        private int _itemID;
        [Category("Properties")]
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        private string _unitCode;
        [Category("Properties")]
        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; }
        }
        #endregion

        #region Load unit data
        private void editCoor_Load(object sender, EventArgs e)
        {
            List<Unit> unitList = Unit.LoadAllUnit();

            Unit unit = unitList[this.ItemID];
            coordinatorInfo = Staff.GetStaffName(unit.Coordinator.ID);
            iniCoorID = unit.Coordinator.ID;
            coorID = iniCoorID;
            unitInfo.Text = unit.UnitCode.ToString() + " | " + unit.UnitName;
            editNameTB.Text = unit.Coordinator.ID.ToString() + " | " + coordinatorInfo;
            this.Text = "Edit " + unitInfo.Text + " Coordinator";
        }
        #endregion

        //get all staff members that have name or id similar to the searching text
        #region Retrieve staff details
        private List<Staff> getCoordinatorDetail(string searchText)
        {
            List<Staff> staffList = Staff.LoadAllStaffList();
            var searchResult = from Staff s in staffList
                               where (s.GivenName).ToLower().Contains(searchText.ToLower()) ||
                               (s.FamilyName).ToLower().Contains(searchText.ToLower()) || (s.ID).ToString().Contains(searchText)
                               select s;
            return new List<Staff>(searchResult);
        }
        #endregion

        //search a staff member on search bar
        #region Search a staff member
        private void editNameTB_TextChanged(object sender, EventArgs e)
        {
            String searchText = editNameTB.Text;
            if (options.Controls.Count > 0)
            {
                options.Controls.Clear();
            }

            if (searchText != "")
            {
                options.Visible = true;
                List<Staff> staffList = getCoordinatorDetail(searchText);
                coordinatorListItem[] coorList = new coordinatorListItem[staffList.Count];

                if (staffList.Count > 0)
                {
                    for (int i = 0; i < staffList.Count; i++)
                    {
                        coorList[i] = new coordinatorListItem();
                        coorList[i].CoorName = (staffList[i].ID).ToString() + " | " + staffList[i].GivenName + " " + staffList[i].FamilyName;
                        coorList[i].CoorID = staffList[i].ID;

                        options.Controls.Add(coorList[i]);
                        coorList[i].Click += new System.EventHandler(this.Coordinator_Click);
                        (coorList[i].coorIDName).Click += new System.EventHandler(this.coorName_Click);
                    }
                }
                else
                {
                    coordinatorListItem empty = new coordinatorListItem();
                    empty.CoorName = "No result found";
                    options.Controls.Add(empty);
                }
            }
            else
            {
                options.Visible = false;
            }
        }
        #endregion

        //click on a staff member's name to get and display their info
        #region Choose a coordinator
        private void Coordinator_Click(object sender, EventArgs e)
        {
            coordinatorListItem coorItem = (coordinatorListItem)sender;

            editNameTB.Text = coorItem.CoorName;
            options.Visible = false;
            coorID = coorItem.CoorID;
        }

        private void coorName_Click(object sender, EventArgs e)
        {
            Label coorFullName = (Label)sender;

            editNameTB.Text = coorFullName.Text;
            options.Visible = false;
            string subID = (editNameTB.Text).Substring(0, 6).Trim();
            coorID = Int32.Parse(subID);
        }
        #endregion

        //check if any new staff member is chosen or not
        #region Validation
        private bool validation()
        {
            bool valid = true;

            if(coorID == iniCoorID)
            {
                MessageBox.Show("You have not chosen any new coordinator");
                valid = false;
            }

            return valid;
        }
        #endregion

        //change a coordinator as requested
        #region Update coordinator
        private void updateButton_Click(object sender, EventArgs e)
        {
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();
            bool valid = validation();

            if(valid)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("update unit set coordinator=@coorID where code=@code", conn);
                    cmd.Parameters.AddWithValue("@coorID", this.coorID);
                    cmd.Parameters.AddWithValue("@code", this.UnitCode);
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read()) { }
                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    } 
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                MessageBox.Show("Unit Coordinator Updated");
                this.Close();
            }
            
        }
        #endregion
    }
}
