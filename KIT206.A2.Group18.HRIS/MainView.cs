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
    public partial class HRIS : Form
    {
        public HRIS()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.titleHolder = new System.Windows.Forms.Panel();
            this.systemTitle = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.listViewHolder = new System.Windows.Forms.Panel();
            this.listHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.searchFieldHolder = new System.Windows.Forms.Panel();
            this.menuHolder = new System.Windows.Forms.TableLayoutPanel();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.unitListButton = new System.Windows.Forms.Button();
            this.classListButton = new System.Windows.Forms.Button();
            this.consultationListButton = new System.Windows.Forms.Button();
            this.staffListButton = new System.Windows.Forms.Button();
            this.addUnitbtn = new System.Windows.Forms.Button();
            this.addClassBtn = new System.Windows.Forms.Button();
            this.addConBtn = new System.Windows.Forms.Button();
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
            this.titleHolder.BackColor = System.Drawing.Color.SeaShell;
            this.titleHolder.Controls.Add(this.systemTitle);
            this.titleHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleHolder.Location = new System.Drawing.Point(0, 0);
            this.titleHolder.Name = "titleHolder";
            this.titleHolder.Size = new System.Drawing.Size(1289, 83);
            this.titleHolder.TabIndex = 0;
            // 
            // systemTitle
            // 
            this.systemTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.systemTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemTitle.ForeColor = System.Drawing.Color.BurlyWood;
            this.systemTitle.Location = new System.Drawing.Point(149, 5);
            this.systemTitle.Name = "systemTitle";
            this.systemTitle.Size = new System.Drawing.Size(1013, 78);
            this.systemTitle.TabIndex = 0;
            this.systemTitle.Text = "Human Resource Information System";
            this.systemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.SeaShell;
            this.container.Controls.Add(this.listViewHolder);
            this.container.Controls.Add(this.menuHolder);
            this.container.Cursor = System.Windows.Forms.Cursors.Default;
            this.container.Dock = System.Windows.Forms.DockStyle.Top;
            this.container.Location = new System.Drawing.Point(0, 83);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1289, 750);
            this.container.TabIndex = 1;
            // 
            // listViewHolder
            // 
            this.listViewHolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listViewHolder.BackColor = System.Drawing.Color.Tan;
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
            this.listHolder.AutoScroll = true;
            this.listHolder.BackColor = System.Drawing.Color.White;
            this.listHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listHolder.Location = new System.Drawing.Point(23, 70);
            this.listHolder.Name = "listHolder";
            this.listHolder.Size = new System.Drawing.Size(954, 491);
            this.listHolder.TabIndex = 1;
            // 
            // searchFieldHolder
            // 
            this.searchFieldHolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchFieldHolder.Controls.Add(this.addConBtn);
            this.searchFieldHolder.Controls.Add(this.addClassBtn);
            this.searchFieldHolder.Controls.Add(this.addUnitbtn);
            this.searchFieldHolder.Controls.Add(this.searchBar);
            this.searchFieldHolder.Location = new System.Drawing.Point(0, 0);
            this.searchFieldHolder.Name = "searchFieldHolder";
            this.searchFieldHolder.Size = new System.Drawing.Size(996, 71);
            this.searchFieldHolder.TabIndex = 0;
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
            // searchBar
            // 
            this.searchBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBar.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.ForeColor = System.Drawing.Color.Gray;
            this.searchBar.Location = new System.Drawing.Point(23, 21);
            this.searchBar.Margin = new System.Windows.Forms.Padding(10);
            this.searchBar.MaxLength = 50;
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(367, 36);
            this.searchBar.TabIndex = 1;
            // 
            // unitListButton
            // 
            this.unitListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.unitListButton.BackColor = System.Drawing.Color.Transparent;
            this.unitListButton.BackgroundImage = global::KIT206.A2.Group18.HRIS.Properties.Resources.unit1;
            this.unitListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unitListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.classListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources._class;
            this.classListButton.Location = new System.Drawing.Point(501, 3);
            this.classListButton.Name = "classListButton";
            this.classListButton.Size = new System.Drawing.Size(243, 151);
            this.classListButton.TabIndex = 3;
            this.classListButton.UseVisualStyleBackColor = true;
            // 
            // consultationListButton
            // 
            this.consultationListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.consultationListButton.AutoSize = true;
            this.consultationListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.consultationListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.consultationListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.consultation;
            this.consultationListButton.Location = new System.Drawing.Point(750, 3);
            this.consultationListButton.Name = "consultationListButton";
            this.consultationListButton.Size = new System.Drawing.Size(245, 151);
            this.consultationListButton.TabIndex = 4;
            this.consultationListButton.UseVisualStyleBackColor = true;
            // 
            // staffListButton
            // 
            this.staffListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.staffListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.staffListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staffListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.staff2;
            this.staffListButton.Location = new System.Drawing.Point(3, 3);
            this.staffListButton.Name = "staffListButton";
            this.staffListButton.Size = new System.Drawing.Size(243, 151);
            this.staffListButton.TabIndex = 1;
            this.staffListButton.UseVisualStyleBackColor = true;
            this.staffListButton.Click += new System.EventHandler(this.staffListButton_Click);
            // 
            // addUnitbtn
            // 
            this.addUnitbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addUnitbtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUnitbtn.Location = new System.Drawing.Point(591, 15);
            this.addUnitbtn.Name = "addUnitbtn";
            this.addUnitbtn.Size = new System.Drawing.Size(110, 37);
            this.addUnitbtn.TabIndex = 2;
            this.addUnitbtn.Text = "Add unit";
            this.addUnitbtn.UseVisualStyleBackColor = true;
            // 
            // addClassBtn
            // 
            this.addClassBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addClassBtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClassBtn.Location = new System.Drawing.Point(707, 15);
            this.addClassBtn.Name = "addClassBtn";
            this.addClassBtn.Size = new System.Drawing.Size(110, 37);
            this.addClassBtn.TabIndex = 3;
            this.addClassBtn.Text = "Add class";
            this.addClassBtn.UseVisualStyleBackColor = true;
            // 
            // addConBtn
            // 
            this.addConBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addConBtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addConBtn.Location = new System.Drawing.Point(823, 14);
            this.addConBtn.Name = "addConBtn";
            this.addConBtn.Size = new System.Drawing.Size(154, 37);
            this.addConBtn.TabIndex = 4;
            this.addConBtn.Text = "Add consultation";
            this.addConBtn.UseVisualStyleBackColor = true;
            // 
            // HRIS
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1289, 845);
            this.Controls.Add(this.container);
            this.Controls.Add(this.titleHolder);
            this.Name = "HRIS";
            this.Text = "Human Resource Information System";
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



        //view staff list when clicking STAFF button
        private void staffListButton_Click(object sender, EventArgs e)
        {
            populateStaffList();
        } 

        //generates a list on staff list view
        private void populateStaffList()
        {
            List<Staff> staffList = Staff.LoadAllStaffList();
            int element_num = staffList.Count;

            staffListItem[] listView = new staffListItem[element_num];

            if (listHolder.Controls.Count > 0)
            {
                listHolder.Controls.Clear();
            }

            for (int i = 0; i < staffList.Count; i++)
            {
                listView[i] = new staffListItem();
                listView[i].Title = staffList[i].Title+ ".";
                listView[i].ID = "ID: " + (staffList[i].ID).ToString();
                listView[i].StaffName = staffList[i].GivenName + " " + staffList[i].FamilyName;
                listView[i].Email = staffList[i].Email;
                listView[i].Campus = staffList[i].campus.ToString() + " campus";

                listView[i].ItemID = i;

                if (staffList[i].Photo == null)
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

        private void unitListButton_Click(object sender, EventArgs e)
        {
            if (listHolder.Controls.Count > 0)
            {
                listHolder.Controls.Clear();
            }
            emptyList empty = new emptyList();
            listHolder.Controls.Add(empty);
        }

        private void HRIS_Load(object sender, EventArgs e)
        {
            populateStaffList();
        }
    }
}
