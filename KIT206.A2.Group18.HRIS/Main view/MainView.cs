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
    //HRIS main view
    public partial class HRIS : Form
    {
        public HRIS()
        {
            InitializeComponent();
        }

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.titleHolder = new System.Windows.Forms.Panel();
            this.systemTitle = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.listViewHolder = new System.Windows.Forms.Panel();
            this.listHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.searchFieldHolder = new System.Windows.Forms.Panel();
            this.addConBtn = new System.Windows.Forms.Button();
            this.addClassBtn = new System.Windows.Forms.Button();
            this.addUnitbtn = new System.Windows.Forms.Button();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.menuHolder = new System.Windows.Forms.TableLayoutPanel();
            this.searchButton = new System.Windows.Forms.Button();
            this.unitListButton = new System.Windows.Forms.Button();
            this.classListButton = new System.Windows.Forms.Button();
            this.consultationListButton = new System.Windows.Forms.Button();
            this.staffListButton = new System.Windows.Forms.Button();
            this.searchBarHolder = new System.Windows.Forms.Panel();
            this.titleHolder.SuspendLayout();
            this.container.SuspendLayout();
            this.listViewHolder.SuspendLayout();
            this.searchFieldHolder.SuspendLayout();
            this.menuHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleHolder
            // 
            this.titleHolder.AutoSize = true;
            this.titleHolder.BackColor = System.Drawing.Color.White;
            this.titleHolder.Controls.Add(this.systemTitle);
            this.titleHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleHolder.Location = new System.Drawing.Point(0, 0);
            this.titleHolder.Name = "titleHolder";
            this.titleHolder.Size = new System.Drawing.Size(1289, 85);
            this.titleHolder.TabIndex = 0;
            // 
            // systemTitle
            // 
            this.systemTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.systemTitle.BackColor = System.Drawing.Color.White;
            this.systemTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.systemTitle.Location = new System.Drawing.Point(149, -4);
            this.systemTitle.Name = "systemTitle";
            this.systemTitle.Size = new System.Drawing.Size(1013, 89);
            this.systemTitle.TabIndex = 0;
            this.systemTitle.Text = "Human Resource Information System";
            this.systemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.White;
            this.container.Controls.Add(this.listViewHolder);
            this.container.Controls.Add(this.menuHolder);
            this.container.Cursor = System.Windows.Forms.Cursors.Default;
            this.container.Dock = System.Windows.Forms.DockStyle.Top;
            this.container.Location = new System.Drawing.Point(0, 85);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1289, 771);
            this.container.TabIndex = 1;
            // 
            // listViewHolder
            // 
            this.listViewHolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listViewHolder.BackColor = System.Drawing.Color.Silver;
            this.listViewHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewHolder.Controls.Add(this.listHolder);
            this.listViewHolder.Controls.Add(this.searchFieldHolder);
            this.listViewHolder.Location = new System.Drawing.Point(151, 169);
            this.listViewHolder.Name = "listViewHolder";
            this.listViewHolder.Size = new System.Drawing.Size(998, 578);
            this.listViewHolder.TabIndex = 1;
            // 
            // listHolder
            // 
            this.listHolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listHolder.AutoScroll = true;
            this.listHolder.BackColor = System.Drawing.Color.White;
            this.listHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listHolder.Location = new System.Drawing.Point(23, 69);
            this.listHolder.Name = "listHolder";
            this.listHolder.Size = new System.Drawing.Size(954, 492);
            this.listHolder.TabIndex = 1;
            // 
            // searchFieldHolder
            // 
            this.searchFieldHolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchFieldHolder.BackColor = System.Drawing.Color.Silver;
            this.searchFieldHolder.Controls.Add(this.searchBarHolder);
            this.searchFieldHolder.Controls.Add(this.searchButton);
            this.searchFieldHolder.Controls.Add(this.addConBtn);
            this.searchFieldHolder.Controls.Add(this.addClassBtn);
            this.searchFieldHolder.Controls.Add(this.addUnitbtn);
            this.searchFieldHolder.Controls.Add(this.searchBar);
            this.searchFieldHolder.Location = new System.Drawing.Point(0, 0);
            this.searchFieldHolder.Name = "searchFieldHolder";
            this.searchFieldHolder.Size = new System.Drawing.Size(996, 69);
            this.searchFieldHolder.TabIndex = 0;
            // 
            // addConBtn
            // 
            this.addConBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addConBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addConBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addConBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addConBtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addConBtn.Location = new System.Drawing.Point(823, 19);
            this.addConBtn.Name = "addConBtn";
            this.addConBtn.Size = new System.Drawing.Size(154, 37);
            this.addConBtn.TabIndex = 4;
            this.addConBtn.Text = "Add consultation";
            this.addConBtn.UseVisualStyleBackColor = false;
            // 
            // addClassBtn
            // 
            this.addClassBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addClassBtn.BackColor = System.Drawing.Color.Gray;
            this.addClassBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addClassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addClassBtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClassBtn.ForeColor = System.Drawing.Color.White;
            this.addClassBtn.Location = new System.Drawing.Point(707, 19);
            this.addClassBtn.Name = "addClassBtn";
            this.addClassBtn.Size = new System.Drawing.Size(110, 37);
            this.addClassBtn.TabIndex = 3;
            this.addClassBtn.Text = "Add class";
            this.addClassBtn.UseVisualStyleBackColor = false;
            // 
            // addUnitbtn
            // 
            this.addUnitbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addUnitbtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addUnitbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUnitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUnitbtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUnitbtn.Location = new System.Drawing.Point(591, 19);
            this.addUnitbtn.Name = "addUnitbtn";
            this.addUnitbtn.Size = new System.Drawing.Size(110, 37);
            this.addUnitbtn.TabIndex = 2;
            this.addUnitbtn.Text = "Add unit";
            this.addUnitbtn.UseVisualStyleBackColor = false;
            this.addUnitbtn.Click += new System.EventHandler(this.addUnitbtn_Click);
            // 
            // searchBar
            // 
            this.searchBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBar.BackColor = System.Drawing.Color.Silver;
            this.searchBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBar.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.searchBar.Location = new System.Drawing.Point(30, 25);
            this.searchBar.Margin = new System.Windows.Forms.Padding(10);
            this.searchBar.MaxLength = 50;
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(367, 29);
            this.searchBar.TabIndex = 1;
            this.searchBar.Text = "What are you looking for?";
            this.searchBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBar_KeyPress);
            // 
            // menuHolder
            // 
            this.menuHolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuHolder.BackColor = System.Drawing.Color.Transparent;
            this.menuHolder.ColumnCount = 4;
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.Controls.Add(this.unitListButton, 1, 0);
            this.menuHolder.Controls.Add(this.classListButton, 2, 0);
            this.menuHolder.Controls.Add(this.consultationListButton, 3, 0);
            this.menuHolder.Controls.Add(this.staffListButton, 0, 0);
            this.menuHolder.Location = new System.Drawing.Point(151, 6);
            this.menuHolder.Name = "menuHolder";
            this.menuHolder.RowCount = 1;
            this.menuHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuHolder.Size = new System.Drawing.Size(998, 157);
            this.menuHolder.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchButton.BackColor = System.Drawing.Color.White;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.icons8_search_30;
            this.searchButton.Location = new System.Drawing.Point(396, 20);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(34, 36);
            this.searchButton.TabIndex = 5;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // unitListButton
            // 
            this.unitListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.unitListButton.BackColor = System.Drawing.Color.Transparent;
            this.unitListButton.BackgroundImage = global::KIT206.A2.Group18.HRIS.Properties.Resources.unit1;
            this.unitListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unitListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unitListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.unit2;
            this.unitListButton.Location = new System.Drawing.Point(252, 3);
            this.unitListButton.Name = "unitListButton";
            this.unitListButton.Size = new System.Drawing.Size(243, 151);
            this.unitListButton.TabIndex = 2;
            this.unitListButton.UseVisualStyleBackColor = false;
            this.unitListButton.Click += new System.EventHandler(this.unitListButton_Click);
            // 
            // classListButton
            // 
            this.classListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.classListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.classListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.class1;
            this.classListButton.Location = new System.Drawing.Point(501, 3);
            this.classListButton.Name = "classListButton";
            this.classListButton.Size = new System.Drawing.Size(243, 151);
            this.classListButton.TabIndex = 3;
            this.classListButton.UseVisualStyleBackColor = true;
            this.classListButton.Click += new System.EventHandler(this.classListButton_Click);
            // 
            // consultationListButton
            // 
            this.consultationListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.consultationListButton.AutoSize = true;
            this.consultationListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.consultationListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.consultationListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.consultation_1;
            this.consultationListButton.Location = new System.Drawing.Point(750, 3);
            this.consultationListButton.Name = "consultationListButton";
            this.consultationListButton.Size = new System.Drawing.Size(245, 151);
            this.consultationListButton.TabIndex = 4;
            this.consultationListButton.UseVisualStyleBackColor = true;
            this.consultationListButton.Click += new System.EventHandler(this.consultationListButton_Click);
            // 
            // staffListButton
            // 
            this.staffListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.staffListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.staffListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staffListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.staff3;
            this.staffListButton.Location = new System.Drawing.Point(3, 3);
            this.staffListButton.Name = "staffListButton";
            this.staffListButton.Size = new System.Drawing.Size(243, 151);
            this.staffListButton.TabIndex = 1;
            this.staffListButton.UseVisualStyleBackColor = true;
            this.staffListButton.Click += new System.EventHandler(this.staffListButton_Click);
            // 
            // searchBarHolder
            // 
            this.searchBarHolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBarHolder.BackColor = System.Drawing.Color.Black;
            this.searchBarHolder.Location = new System.Drawing.Point(23, 53);
            this.searchBarHolder.Name = "searchBarHolder";
            this.searchBarHolder.Size = new System.Drawing.Size(367, 3);
            this.searchBarHolder.TabIndex = 6;
            // 
            // HRIS
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1289, 845);
            this.Controls.Add(this.container);
            this.Controls.Add(this.titleHolder);
            this.Name = "HRIS";
            this.Text = "Human Resource Information System";
            this.Activated += new System.EventHandler(this.HRIS_Activated);
            this.Load += new System.EventHandler(this.HRIS_Load);
            this.titleHolder.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.listViewHolder.ResumeLayout(false);
            this.searchFieldHolder.ResumeLayout(false);
            this.searchFieldHolder.PerformLayout();
            this.menuHolder.ResumeLayout(false);
            this.menuHolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region option controls
        private bool chooseStaff = false;
        private bool chooseUnit = false;
        private bool chooseClass = false;
        private bool chooseConsultation = false;
        #endregion

        //use 4 different bool varibles to indicate what tab (staff, unit, class, consultation) is selected by user
        #region Choose one of four tabs (staff, unit, class, consultation)
        //view staff list when clicking STAFF button
        private void staffListButton_Click(object sender, EventArgs e)
        {
            List<Staff> staffList = Staff.LoadAllStaffList();
            populateStaffList(staffList);
            chooseUnit = false;
            chooseStaff = true; //staff button is clicked
            chooseClass = false;
            chooseConsultation = false;
        }

        //view consultation list when click on CONSULTATION button
        private void consultationListButton_Click(object sender, EventArgs e)
        {

            List<Consultation> conList = Consultation.GetAllConsultation();
            populateConsultationList(conList);
            chooseUnit = false;
            chooseStaff = false;
            chooseClass = false;
            chooseConsultation = true; //consultation button is clicked
        }

        //view unit list when click on CLASS button
        private void unitListButton_Click(object sender, EventArgs e)
        {
            List<Unit> unitList = Unit.LoadAllUnit();
            populateUnitList(unitList);
            chooseUnit = true; //unit button is clicked
            chooseStaff = false;
            chooseClass = false;
            chooseConsultation = false;
        }

        //view class list when click on CLASS button
        private void classListButton_Click(object sender, EventArgs e)
        {
            List<Class> classList = Class.getClassWithUnitDetails();
            populateClassList(classList);
            chooseUnit = false;
            chooseStaff = false;
            chooseClass = true; //class button is clicked
            chooseConsultation = false;
        }

        //display 'ADD A UNIT' view when click on 'ADD UNIT' button
        private void addUnitbtn_Click(object sender, EventArgs e)
        {
            chooseUnit = true; //changes to tab Unit when clicking 'Add unit' button
            chooseStaff = false;
            chooseClass = false;
            chooseConsultation = false;
            addUnit addNewUnit = new addUnit();
            addNewUnit.ShowDialog();
        }
        #endregion

        #region Generate a staff list
        //generates a list on staff list view
        private void populateStaffList(List<Staff> staffList)
        {
            //clear all items from the last choice before displaying the new ones
            if (listHolder.Controls.Count > 0)
            {
                listHolder.Controls.Clear();
            }

            //if the staff list is empty, inform user that the list is empty
            if (staffList.Count <= 0)
            {
                emptyList empty = new emptyList();
                listHolder.Controls.Add(empty);
            }
            else //if not, generate the staff list with some details
            {
                staffListItem[] listView = new staffListItem[staffList.Count];
                for (int i = 0; i < staffList.Count; i++)
                {
                    listView[i] = new staffListItem();
                    listView[i].ID = "ID: " + (staffList[i].ID).ToString();
                    listView[i].StaffName = staffList[i].Title + ". " + staffList[i].GivenName + " " + staffList[i].FamilyName;
                    listView[i].Email = staffList[i].Email;
                    listView[i].Campus = staffList[i].campus.ToString() + " campus";
                    listView[i].ItemID = i;

                    if (staffList[i].Photo == null || staffList[i].Photo.Length == 0)
                    {
                        listView[i].Icon = Properties.Resources.avatar;
                    }
                    else
                    {
                        ImageConverter converter = new System.Drawing.ImageConverter();
                        listView[i].Icon = converter.ConvertFrom(staffList[i].Photo) as Image;
                    }

                    listHolder.Controls.Add(listView[i]);
                }
            }
        }
        #endregion

        #region Generate a unit list
        //generate unit list retrieved from database
        private void populateUnitList(List<Unit> unitList)
        {
            //clear all last items
            if (listHolder.Controls.Count > 0)
            {
                listHolder.Controls.Clear();
            }

            //if the unit list is empty, inform user that the list is empty
            if (unitList.Count <= 0)
            {
                emptyList empty = new emptyList();
                listHolder.Controls.Add(empty);
            }
            else //if not, display all units
            {
                unitListItem[] unitView = new unitListItem[unitList.Count];
                for (int i = 0; i < unitList.Count; i++)
                {
                    unitView[i] = new unitListItem();
                    unitView[i].UnitCode = (unitList[i].UnitCode).ToUpper();
                    unitView[i].UnitName = unitList[i].UnitName;
                    unitView[i].CoordinatorName = Staff.GetStaffName(unitList[i].Coordinator.ID);
                    unitView[i].ItemID = i;

                    listHolder.Controls.Add(unitView[i]);
                }
            }
        }
        #endregion

        #region Generate class list
        //Display all classes on main view
        private void populateClassList(List<Class> classList)
        {
            //clear all items from the last choice before displaying the new ones
            if(listHolder.Controls.Count > 0)
            {
                listHolder.Controls.Clear();
            }

            //if there is no class, inform user that the list is empty
            if(classList.Count <= 0)
            {
                emptyList empty = new emptyList();
                listHolder.Controls.Add(empty);
            }
            else //if not, display all classes
            {
                classListItem[] classView = new classListItem[classList.Count];
                for (int i = 0; i < classList.Count; i++)
                {
                    classView[i] = new classListItem();
                    classView[i].ItemID = i;
                    classView[i].UnitInfo = (classList[i].unit.UnitCode).ToUpper() + " | " + classList[i].unit.UnitName;
                    classView[i].StaffName = Staff.GetStaffName(classList[i].staff.ID);
                    classView[i].DayAndTime = classList[i].day.ToString() + " | " + classList[i].StartTime.ToString() + " - " + classList[i].EndTime.ToString();
                    classView[i].TypeRoomCampus = classList[i].type.ToString() + " | Room: " + classList[i].Room + " | " + classList[i].campus.ToString() + " campus";

                    listHolder.Controls.Add(classView[i]);
                }
            }
        }
        #endregion

        #region Generate Consultation List
        private void populateConsultationList(List<Consultation> conList)
        {
            //clear all items from the last choice before displaying the new ones
            if(listHolder.Controls.Count > 0)
            {
                listHolder.Controls.Clear();
            }
            //if there is no consultation, inform user that the list is empty
            if(conList.Count <= 0)
            {
                emptyList empty = new emptyList();
                listHolder.Controls.Add(empty);
            }
            else //if not, display all consultations
            {
                consultationListItem[] conView = new consultationListItem[conList.Count];
                for (int i = 0; i<conList.Count; i++)
                {
                    conView[i] = new consultationListItem();
                    conView[i].ItemID = i;
                    conView[i].StaffName = Staff.GetStaffName(conList[i].staff.ID);
                    conView[i].StaffID = "ID: " + conList[i].staff.ID;
                    conView[i].DayTimeCon = conList[i].day.ToString() + " | " + conList[i].StartTime.ToString() + " - " + conList[i].EndTime.ToString();
                    conView[i].ConLocation = Staff.GetStaffLocation(conList[i].staff.ID);

                    listHolder.Controls.Add(conView[i]);
                }
            }
        }
        #endregion

        #region Load tabs when activated
        //load a specific list when the form is activated based on the chosen tab
        private void HRIS_Activated(object sender, EventArgs e)
        {
            if (chooseStaff)
            {
                List<Staff> staffList = Staff.LoadAllStaffList();
                populateStaffList(staffList);
            }

            else if(chooseUnit)
            {
                List<Unit> unitList = Unit.LoadAllUnit();
                populateUnitList(unitList);
            }

            else if(chooseClass)
            {
                List<Class> classList = Class.getClassWithUnitDetails();
                populateClassList(classList);
            }

            else if(chooseConsultation)
            {
                List<Consultation> conList = Consultation.GetAllConsultation();
                populateConsultationList(conList);
            }
        }


        #endregion

        #region Return A List Of Result
        //return a staff list based on search text
        private void returnStaffListOnSearch(string searchText)
        {
            List<Staff> staffList = Staff.LoadAllStaffList();
            var result = from Staff s in staffList
                         where (s.GivenName).ToLower().Contains(searchText) || (s.FamilyName).ToLower().Contains(searchText)
                                || (s.ID).ToString().Contains(searchText) || (s.Email).ToLower().Contains(searchText)
                                || (s.Title).ToLower().Contains(searchText) || (s.campus).ToString().ToLower().Contains(searchText)
                         select s; //LINQ

            List<Staff> resultList = new List<Staff>(result);
            populateStaffList(resultList);
        }

        //return a unit list based on search text
        private void returnUnitListOnSearch(string searchText)
        {
            List<Unit> unitList = Unit.LoadFullUnitList();
            var result = from Unit u in unitList
                         where (u.UnitCode).ToLower().Contains(searchText) || (u.UnitName).ToLower().Contains(searchText)
                               || (u.Coordinator.ID).ToString().Contains(searchText) || (u.Coordinator.GivenName).ToLower().Contains(searchText)
                               || (u.Coordinator.FamilyName).ToLower().Contains(searchText) || (u.Coordinator.Title).ToLower().Contains(searchText)
                         select u; //LINQ

            List<Unit> resultList = new List<Unit>(result);
            populateUnitList(resultList);
        }

        //return a class list based on search text
        private void returnClassListOnSearch(string searchText)
        {
            List<Class> classList = Class.LoadFullClassList();
            var result = from Class c in classList
                         where (c.unit.UnitCode).ToLower().Contains(searchText) || (c.unit.UnitName).ToLower().Contains(searchText)
                               || (c.type).ToString().ToLower().Contains(searchText) || (c.staff.GivenName).ToLower().Contains(searchText)
                               || (c.staff.FamilyName).ToLower().Contains(searchText) || (c.staff.Title).ToLower().Contains(searchText)
                               || c.StartTime.ToString().Contains(searchText) || c.EndTime.ToString().Contains(searchText) ||
                               (c.day).ToString().ToLower().Contains(searchText) || (c.staff.campus).ToString().ToLower().Contains(searchText)
                         select c; //LINQ

            List<Class> resultList = new List<Class>(result);
            populateClassList(resultList);
        }

        //return a Consultation list based on search text
        private void returnConsultationListOnSearch(string searchText)
        {
            List<Consultation> conList = Consultation.LoadFullConsultationList();
            var result = from Consultation c in conList
                         where (c.staff.GivenName).ToLower().Contains(searchText) || (c.staff.FamilyName).ToLower().Contains(searchText)
                                || (c.staff.ID).ToString().Contains(searchText) || (c.StartTime).ToString().Contains(searchText) ||
                                (c.EndTime).ToString().Contains(searchText) || (c.day).ToString().ToLower().Contains(searchText)
                         select c; //LINQ

            List<Consultation> resultList = new List<Consultation>(result);
            populateConsultationList(resultList);
        }
        #endregion

        #region Search for an entity
        //search for specific data based on tab chosen
        private void Search()
        {
            string searchText = searchBar.Text.ToLower();
            if (chooseStaff) //if tab 'staff' is chosen, results are related to staff details
            {
                if (searchText == "")
                {
                    List<Staff> staffList = Staff.LoadAllStaffList();
                    populateStaffList(staffList);
                    searchBar.Text = "What are you looking for?";
                }
                else
                {
                    returnStaffListOnSearch(searchText);
                }
            }
            else if (chooseUnit) //if tab 'unit' is chosen, results are related to unit details
            {
                if (searchText == "")
                {
                    List<Unit> unitList = Unit.LoadAllUnit();
                    populateUnitList(unitList);
                    searchBar.Text = "What are you looking for?";
                }
                else
                {
                    returnUnitListOnSearch(searchText);
                }
            }
            else if (chooseClass) //if tab 'class' is chosen, results are related to class details
            {
                if (searchText == "")
                {
                    List<Class> classList = Class.LoadAllClasses();
                    populateClassList(classList);
                    searchBar.Text = "What are you looking for?";
                }
                else
                {
                    returnClassListOnSearch(searchText);
                }
            }
            else if (chooseConsultation) //if tab 'consultation' is choosen, results are related to consultation details
            {
                if (searchText == "")
                {
                    List<Consultation> conList = Consultation.GetAllConsultation();
                    populateConsultationList(conList);
                    searchBar.Text = "What are you looking for?";
                }
                else
                {
                    returnConsultationListOnSearch(searchText);
                }
            }
        }
        #endregion

        //Load staff list when the system starts
        private void HRIS_Load(object sender, EventArgs e)
        {
            chooseStaff = true;

            List<Staff> staffList = Staff.LoadAllStaffList();
            populateStaffList(staffList);
        }

        //search by pressing 'Enter'
        private void searchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Convert.ToInt32(e.KeyChar) == 13)
            {
                Search();
            }
        }

        //search by clicking on 'Search' button
        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
