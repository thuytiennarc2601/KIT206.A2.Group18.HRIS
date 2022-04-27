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
using System.IO;

namespace KIT206.A2.Group18.HRIS
{
    public partial class addStaffInfo : Form
    {
        public addStaffInfo()
        {
            InitializeComponent();
        }

        private static MySqlConnection conn;

        #region Properties
        private int _itemID;
        private int _staffID;
        private string _category;
        private string _campus;
        private byte[] _imageByteArray;
        
        [Category("Extra properties")]
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        #endregion

        #region Generate category options
        //if a staff mem's category is yet added, display a list of categories, else show the his/her category
        private void categoryOptions(List<Staff> staffList, Staff staff)
        {
            /*
            if (staff.category == Category.unknown)
            {
                cateList.Items.Add("Select..");
                foreach (Category cate in Enum.GetValues(typeof(Category)))
                {
                    if (cate != Category.unknown)
                    {
                        cateList.Items.Add((cate.ToString()).ToUpper());
                        cateList.SelectedIndex = 0;
                    }
                }
            }
            else
            {
            */
                cateList.Items.Add(((staff.category).ToString()).ToUpper());
                cateList.SelectedIndex = 0;
            //}
        }
        #endregion

        #region Generate campus options
        //if a staff mem's campus is yet added, display a list of title, else show the his/her campus
        private void campusOptions(List<Staff> staffList, Staff staff)
        {
            /*
            if (staff.campus == Campus.Notlocated)
            {
                campusList.Items.Add("Select..");
                foreach (Campus cam in Enum.GetValues(typeof(Campus)))
                {
                    if (cam != Campus.Notlocated)
                    {
                        campusList.Items.Add((cam.ToString()).ToUpper());
                        campusList.SelectedIndex = 0;
                    }
                }
            }
            else
            {
            */
                campusList.Items.Add(((staff.campus).ToString()).ToUpper());
                campusList.SelectedIndex = 0;
            //}
        }
        #endregion

        #region Display staff info
        //if a staff mem's is already added, unable the corresponding fields
        private void displayStaffInfo(List<Staff> staffList, Staff staff)
        {
            titleTB.Text = staff.Title;
            this._staffID = staff.ID;
            
            GNameTB.Text = staff.GivenName;
            GNameTB.Enabled = false;

            FNameTB.Text = staff.FamilyName;
            FNameTB.Enabled = false;

            //staff's phone, email, room cannot be modified if they are already added
            contactTB.Text = staff.Phone;
            if (staff.Phone != "No number added")
            {
                contactTB.Enabled = false;
            }

            emailTB.Text = staff.Email;
            if (staff.Email != "No email added")
            {
                emailTB.Enabled = false;
            }

            roomTB.Text = staff.Room;
            if (staff.Room != "No room assigned")
            {
                roomTB.Enabled = false;
            }

            if(staff.Photo == null || staff.Photo.Length == 0)
            {
                staffAvatar.Image = Properties.Resources.avatar;
            }
            else
            {
                ImageConverter converter = new System.Drawing.ImageConverter();
                staffAvatar.Image = converter.ConvertFrom(staff.Photo) as Image;
            }
        }
        #endregion

        #region Load all data into the form
        //Load all data when starting loading the form
        private void addStaffInfo_Load(object sender, EventArgs e)
        {
            List<Staff> staffList = Staff.LoadAllStaffList();
            Staff staff = staffList[this.ItemID]; //get staff from the staff list using its index

            this.Text = "Edit " + staff.GivenName + " " + staff.FamilyName + "'s Information";
            categoryOptions(staffList, staff);
            campusOptions(staffList, staff);
            displayStaffInfo(staffList, staff);
        }
        #endregion

        private void cateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _category = ((cateList.SelectedItem).ToString()).ToLower();   
        }

        private void campusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _campus = (campusList.SelectedItem).ToString();
        }

        #region Load photo from desktop file
        //load staff photo from desktop's file and convert that photo to a byte array
        private void imageButton_Click(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                string filePath = openImage.FileName;
                staffAvatar.Image = Image.FromFile(filePath);
                _imageByteArray = (byte[])(new ImageConverter().ConvertTo(Image.FromFile(filePath), typeof(Byte[])));
            }
        }
        #endregion

        #region Validation
        //for checking any invalid data
        private bool validation()
        {
            bool valid = true;
            return valid;
        }
        #endregion

        #region Update staff details to database
        //save all modified data when clicking SAVE button
        private void saveStaffButton_Click(object sender, EventArgs e)
        {
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();
            bool valid = validation();
            if (valid)
            {
                try
                {
                    conn.Open();

                    if (titleTB.Text != "Unknown") //edit title
                    {
                        MySqlCommand cmdTitle = new MySqlCommand("update staff set title =@title where id = @id", conn);
                        cmdTitle.Parameters.AddWithValue("@title", titleTB.Text);
                        cmdTitle.Parameters.AddWithValue("@id", _staffID);
                        rdr = cmdTitle.ExecuteReader();
                        while (rdr.Read()) { }
                        rdr.Close();
                    }

                    if (_category != "Select..") //add category
                    {
                        MySqlCommand cmdCate = new MySqlCommand("update staff set category =@category where id = @id", conn);
                        cmdCate.Parameters.AddWithValue("@category", _category);
                        cmdCate.Parameters.AddWithValue("@id", _staffID);
                        rdr = cmdCate.ExecuteReader();
                        while (rdr.Read()) { }
                        rdr.Close();
                    }

                    if (contactTB.Text != "No number added") //add contact
                    {
                        MySqlCommand cmdContact = new MySqlCommand("update staff set phone =@phone where id = @id", conn);
                        cmdContact.Parameters.AddWithValue("@phone", contactTB.Text);
                        cmdContact.Parameters.AddWithValue("@id", _staffID);
                        rdr = cmdContact.ExecuteReader();
                        while (rdr.Read()) { }
                        rdr.Close();
                    }

                    if (emailTB.Text != "No email added") //add email
                    {
                        MySqlCommand cmdEmail = new MySqlCommand("update staff set email =@email where id =@id", conn);
                        cmdEmail.Parameters.AddWithValue("@email", emailTB.Text);
                        cmdEmail.Parameters.AddWithValue("@id", _staffID);
                        rdr = cmdEmail.ExecuteReader();
                        while (rdr.Read()) { }
                        rdr.Close();
                    }

                    if (roomTB.Text != "No room assigned") //add room
                    {
                        MySqlCommand cmdRoom = new MySqlCommand("update staff set room =@room where id =@id", conn);
                        cmdRoom.Parameters.AddWithValue("@room", roomTB.Text);
                        cmdRoom.Parameters.AddWithValue("@id", _staffID);
                        rdr = cmdRoom.ExecuteReader();
                        while (rdr.Read()) { }
                        rdr.Close();
                    }

                    if (_campus != "Select..") // add campus
                    {
                        MySqlCommand cmdCampus = new MySqlCommand("update staff set campus =@campus where id =@id", conn);
                        cmdCampus.Parameters.AddWithValue("@campus", _campus);
                        cmdCampus.Parameters.AddWithValue("@id", _staffID);
                        rdr = cmdCampus.ExecuteReader();
                        while (rdr.Read()) { }
                        rdr.Close();
                    }

                    if (_imageByteArray != null) //edit photo
                    {
                        MySqlCommand cmdPhoto = new MySqlCommand("update staff set photo = @_imageByteArray where id = @id", conn);
                        cmdPhoto.Parameters.AddWithValue("@_imageByteArray", _imageByteArray);
                        cmdPhoto.Parameters.AddWithValue("@id", _staffID);
                        rdr = cmdPhoto.ExecuteReader();
                        while (rdr.Read()) { }
                        rdr.Close();
                    }
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
                MessageBox.Show("Information updated");
                this.Close();
            }
        }
        #endregion
    }
}
