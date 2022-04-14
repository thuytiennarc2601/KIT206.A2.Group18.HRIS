﻿using System;
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
    public partial class addUnit : Form
    {
        public addUnit()
        {
            InitializeComponent();
        }

        private static MySqlConnection conn;
        private int coorID;

        //check if all input is valid or not
        #region Input validation
        private bool Validation(int coorID, string code, string title)
        {
            bool valid = true;
            int checkStaff = 0;
            string checkUnitCode = "";
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            try
            {
                conn.Open();
                MySqlCommand staffCmd = new MySqlCommand("select id from staff where id='" + coorID + "'", conn);
                rdr = staffCmd.ExecuteReader();
                while(rdr.Read())
                {
                    checkStaff = rdr.GetInt32(0);
                }
                rdr.Close();

                MySqlCommand unitCmd = new MySqlCommand("select code from unit where code='" + code + "' or title='" + title + "'", conn);
                rdr = unitCmd.ExecuteReader();
                while(rdr.Read())
                {
                    checkUnitCode = rdr.GetString(0);
                }
            }

            finally
            {
                if(rdr != null)
                {
                    rdr.Close();
                }
                if(conn != null)
                {
                    conn.Close();
                }
            }

            if(unitCodeTB.Text == "")
            {
                MessageBox.Show("Unit code required");
                valid = false;
            }

            else if(unitNameTB.Text == "")
            {
                MessageBox.Show("Unit name required");
                valid = false;
            }

            else if (checkUnitCode != "")
            {
                MessageBox.Show("Unit code or name already exist");
                valid = false;
            }

            else if(coordinatorTB.Text == "")
            {
                MessageBox.Show("Unit coordinator required");
                valid = false;
            }

            else if (checkStaff == 0)
            {
                MessageBox.Show("The staff does not exist");
                valid = false;
            }

            return valid;
        }
        #endregion

        //search for a specific staff member when typing their name or id
        #region Search staff member's name or id
        private void coordinatorTB_TextChanged(object sender, EventArgs e)
        {
            String searchText = coordinatorTB.Text;
            if(coorOptions.Controls.Count > 0)
            {
                coorOptions.Controls.Clear();
            }

            if (searchText != "")
            {
                coorOptions.Visible = true;
                List<Staff> staffList = getCoordinatorDetail(searchText);
                coordinatorListItem[] coorList = new coordinatorListItem[staffList.Count];

                if (staffList.Count > 0)
                {
                    for (int i = 0; i < staffList.Count; i++)
                    {
                        coorList[i] = new coordinatorListItem();
                        coorList[i].CoorName = (staffList[i].ID).ToString() + " | " + staffList[i].GivenName + " " + staffList[i].FamilyName;
                        coorList[i].CoorID = staffList[i].ID;

                        coorOptions.Controls.Add(coorList[i]);
                        coorList[i].Click += new System.EventHandler(this.Coordinator_Click);
                        (coorList[i].coorIDName).Click += new System.EventHandler(this.coorName_Click);
                    }
                }
                else
                {
                    coordinatorListItem empty = new coordinatorListItem();
                    empty.CoorName = "No result found";
                    coorOptions.Controls.Add(empty);
                }
            }
            else
            {
                coorOptions.Visible = false;
            }
        }
        #endregion

        //click on a staff member's name to get and display their info
        #region Choose a coordinator
        private void Coordinator_Click(object sender, EventArgs e)
        {
            coordinatorListItem coorItem = (coordinatorListItem)sender;

            coordinatorTB.Text = coorItem.CoorName;
            coorOptions.Visible = false;
            coorID = coorItem.CoorID;
        }

        private void coorName_Click(object sender, EventArgs e)
        {
            Label coorFullName = (Label)sender;

            coordinatorTB.Text = coorFullName.Text;
            coorOptions.Visible = false;
            string subID = (coordinatorTB.Text).Substring(0, 6).Trim();
            coorID = Int32.Parse(subID);
        }
        #endregion

        //get all staff members that have name or id similar to the searching text
        #region Retrieve staff details
        private List<Staff> getCoordinatorDetail(string searchText)
        {
            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();
            List<Staff> staffList = new List<Staff>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name from staff where id like '" + searchText + "%' or given_name like '" + searchText + "%' or family_name like '" + searchText + "%'", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Staff staff = new Staff();
                    staff.ID = rdr.GetInt32(0);
                    staff.GivenName = rdr.GetString(1);
                    staff.FamilyName = rdr.GetString(2);

                    staffList.Add(staff);
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
            return staffList;
        }
        #endregion

        //add a new unit to database
        #region Add a new unit
        private void addUnitButton_Click(object sender, EventArgs e)
        {
            bool valid = Validation(coorID, unitCodeTB.Text, unitNameTB.Text);

            MySqlDataReader rdr = null;
            conn = GetSqlConnection.GetConnection();

            if (valid)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into unit(code, title, coordinator) value(@code, @title, @coordinator)", conn);
                    cmd.Parameters.Add("@code", MySqlDbType.VarChar, 6);
                    cmd.Parameters.Add("@title", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@coordinator", MySqlDbType.Int32);

                    cmd.Parameters["@code"].Value = unitCodeTB.Text;
                    cmd.Parameters["@title"].Value = unitNameTB.Text;
                    cmd.Parameters["@coordinator"].Value = this.coorID;

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read()) { }
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
                MessageBox.Show("Unit added successfully");
                this.Close();
            }
        }
        #endregion
    }
}