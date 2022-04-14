
namespace KIT206.A2.Group18.HRIS
{
    partial class addStaffInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.container = new System.Windows.Forms.Panel();
            this.separator = new System.Windows.Forms.Panel();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.saveStaffButton = new System.Windows.Forms.Button();
            this.imageButton = new System.Windows.Forms.Button();
            this.campusList = new System.Windows.Forms.ComboBox();
            this.roomTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.contactTB = new System.Windows.Forms.TextBox();
            this.campusLB = new System.Windows.Forms.Label();
            this.roomLB = new System.Windows.Forms.Label();
            this.emailLB = new System.Windows.Forms.Label();
            this.ContactLB = new System.Windows.Forms.Label();
            this.FNameTB = new System.Windows.Forms.TextBox();
            this.FNameLB = new System.Windows.Forms.Label();
            this.GNameTB = new System.Windows.Forms.TextBox();
            this.GNameLb = new System.Windows.Forms.Label();
            this.cateList = new System.Windows.Forms.ComboBox();
            this.cateLb = new System.Windows.Forms.Label();
            this.titleLb = new System.Windows.Forms.Label();
            this.staffAvatar = new System.Windows.Forms.PictureBox();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.staffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.container.BackColor = System.Drawing.Color.White;
            this.container.Controls.Add(this.separator);
            this.container.Controls.Add(this.titleTB);
            this.container.Controls.Add(this.saveStaffButton);
            this.container.Controls.Add(this.imageButton);
            this.container.Controls.Add(this.campusList);
            this.container.Controls.Add(this.roomTB);
            this.container.Controls.Add(this.emailTB);
            this.container.Controls.Add(this.contactTB);
            this.container.Controls.Add(this.campusLB);
            this.container.Controls.Add(this.roomLB);
            this.container.Controls.Add(this.emailLB);
            this.container.Controls.Add(this.ContactLB);
            this.container.Controls.Add(this.FNameTB);
            this.container.Controls.Add(this.FNameLB);
            this.container.Controls.Add(this.GNameTB);
            this.container.Controls.Add(this.GNameLb);
            this.container.Controls.Add(this.cateList);
            this.container.Controls.Add(this.cateLb);
            this.container.Controls.Add(this.titleLb);
            this.container.Controls.Add(this.staffAvatar);
            this.container.Cursor = System.Windows.Forms.Cursors.Hand;
            this.container.Location = new System.Drawing.Point(24, 22);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(784, 454);
            this.container.TabIndex = 0;
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.LightGray;
            this.separator.Location = new System.Drawing.Point(521, 26);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(10, 404);
            this.separator.TabIndex = 21;
            // 
            // titleTB
            // 
            this.titleTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleTB.BackColor = System.Drawing.Color.White;
            this.titleTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTB.Location = new System.Drawing.Point(165, 26);
            this.titleTB.MaxLength = 10;
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(146, 36);
            this.titleTB.TabIndex = 19;
            // 
            // saveStaffButton
            // 
            this.saveStaffButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveStaffButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.saveStaffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveStaffButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStaffButton.ForeColor = System.Drawing.Color.White;
            this.saveStaffButton.Location = new System.Drawing.Point(605, 395);
            this.saveStaffButton.Name = "saveStaffButton";
            this.saveStaffButton.Size = new System.Drawing.Size(112, 34);
            this.saveStaffButton.TabIndex = 18;
            this.saveStaffButton.Text = "SAVE";
            this.saveStaffButton.UseVisualStyleBackColor = false;
            this.saveStaffButton.Click += new System.EventHandler(this.saveStaffButton_Click);
            // 
            // imageButton
            // 
            this.imageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageButton.BackColor = System.Drawing.Color.White;
            this.imageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageButton.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.imageButton.Location = new System.Drawing.Point(572, 212);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(180, 34);
            this.imageButton.TabIndex = 17;
            this.imageButton.Text = "LOAD NEW ";
            this.imageButton.UseVisualStyleBackColor = false;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // campusList
            // 
            this.campusList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.campusList.BackColor = System.Drawing.Color.White;
            this.campusList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.campusList.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campusList.FormattingEnabled = true;
            this.campusList.Location = new System.Drawing.Point(165, 394);
            this.campusList.MaxDropDownItems = 15;
            this.campusList.Name = "campusList";
            this.campusList.Size = new System.Drawing.Size(321, 36);
            this.campusList.TabIndex = 16;
            this.campusList.SelectedIndexChanged += new System.EventHandler(this.campusList_SelectedIndexChanged);
            // 
            // roomTB
            // 
            this.roomTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomTB.BackColor = System.Drawing.Color.White;
            this.roomTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomTB.Location = new System.Drawing.Point(165, 338);
            this.roomTB.MaxLength = 20;
            this.roomTB.Name = "roomTB";
            this.roomTB.Size = new System.Drawing.Size(321, 36);
            this.roomTB.TabIndex = 15;
            // 
            // emailTB
            // 
            this.emailTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emailTB.BackColor = System.Drawing.Color.White;
            this.emailTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTB.Location = new System.Drawing.Point(165, 285);
            this.emailTB.MaxLength = 50;
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(321, 36);
            this.emailTB.TabIndex = 14;
            // 
            // contactTB
            // 
            this.contactTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.contactTB.BackColor = System.Drawing.Color.White;
            this.contactTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactTB.Location = new System.Drawing.Point(165, 232);
            this.contactTB.MaxLength = 15;
            this.contactTB.Name = "contactTB";
            this.contactTB.Size = new System.Drawing.Size(321, 36);
            this.contactTB.TabIndex = 13;
            // 
            // campusLB
            // 
            this.campusLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.campusLB.AutoSize = true;
            this.campusLB.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campusLB.Location = new System.Drawing.Point(3, 392);
            this.campusLB.Name = "campusLB";
            this.campusLB.Size = new System.Drawing.Size(120, 35);
            this.campusLB.TabIndex = 12;
            this.campusLB.Text = "Campus:";
            // 
            // roomLB
            // 
            this.roomLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomLB.AutoSize = true;
            this.roomLB.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomLB.Location = new System.Drawing.Point(3, 338);
            this.roomLB.Name = "roomLB";
            this.roomLB.Size = new System.Drawing.Size(94, 35);
            this.roomLB.TabIndex = 11;
            this.roomLB.Text = "Room:";
            // 
            // emailLB
            // 
            this.emailLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emailLB.AutoSize = true;
            this.emailLB.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLB.Location = new System.Drawing.Point(3, 284);
            this.emailLB.Name = "emailLB";
            this.emailLB.Size = new System.Drawing.Size(91, 35);
            this.emailLB.TabIndex = 10;
            this.emailLB.Text = "Email:";
            // 
            // ContactLB
            // 
            this.ContactLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ContactLB.AutoSize = true;
            this.ContactLB.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactLB.Location = new System.Drawing.Point(3, 231);
            this.ContactLB.Name = "ContactLB";
            this.ContactLB.Size = new System.Drawing.Size(117, 35);
            this.ContactLB.TabIndex = 9;
            this.ContactLB.Text = "Contact:";
            // 
            // FNameTB
            // 
            this.FNameTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FNameTB.BackColor = System.Drawing.Color.White;
            this.FNameTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FNameTB.Location = new System.Drawing.Point(165, 181);
            this.FNameTB.MaxLength = 20;
            this.FNameTB.Name = "FNameTB";
            this.FNameTB.Size = new System.Drawing.Size(321, 36);
            this.FNameTB.TabIndex = 8;
            // 
            // FNameLB
            // 
            this.FNameLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FNameLB.AutoSize = true;
            this.FNameLB.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FNameLB.Location = new System.Drawing.Point(3, 180);
            this.FNameLB.Name = "FNameLB";
            this.FNameLB.Size = new System.Drawing.Size(145, 35);
            this.FNameLB.TabIndex = 7;
            this.FNameLB.Text = "Last name:";
            // 
            // GNameTB
            // 
            this.GNameTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GNameTB.BackColor = System.Drawing.Color.White;
            this.GNameTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNameTB.Location = new System.Drawing.Point(165, 127);
            this.GNameTB.MaxLength = 20;
            this.GNameTB.Name = "GNameTB";
            this.GNameTB.Size = new System.Drawing.Size(321, 36);
            this.GNameTB.TabIndex = 6;
            // 
            // GNameLb
            // 
            this.GNameLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GNameLb.AutoSize = true;
            this.GNameLb.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNameLb.Location = new System.Drawing.Point(3, 128);
            this.GNameLb.Name = "GNameLb";
            this.GNameLb.Size = new System.Drawing.Size(149, 35);
            this.GNameLb.TabIndex = 5;
            this.GNameLb.Text = "First name:";
            // 
            // cateList
            // 
            this.cateList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cateList.BackColor = System.Drawing.Color.White;
            this.cateList.DisplayMember = "0";
            this.cateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cateList.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cateList.FormattingEnabled = true;
            this.cateList.Location = new System.Drawing.Point(165, 77);
            this.cateList.MaxDropDownItems = 15;
            this.cateList.Name = "cateList";
            this.cateList.Size = new System.Drawing.Size(321, 36);
            this.cateList.TabIndex = 4;
            this.cateList.ValueMember = "0";
            this.cateList.SelectedIndexChanged += new System.EventHandler(this.cateList_SelectedIndexChanged);
            // 
            // cateLb
            // 
            this.cateLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cateLb.AutoSize = true;
            this.cateLb.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cateLb.Location = new System.Drawing.Point(3, 76);
            this.cateLb.Name = "cateLb";
            this.cateLb.Size = new System.Drawing.Size(128, 35);
            this.cateLb.TabIndex = 3;
            this.cateLb.Text = "Category:";
            // 
            // titleLb
            // 
            this.titleLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLb.AutoSize = true;
            this.titleLb.Font = new System.Drawing.Font("Constantia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLb.Location = new System.Drawing.Point(3, 25);
            this.titleLb.Name = "titleLb";
            this.titleLb.Size = new System.Drawing.Size(78, 35);
            this.titleLb.TabIndex = 1;
            this.titleLb.Text = "Title:";
            // 
            // staffAvatar
            // 
            this.staffAvatar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffAvatar.Cursor = System.Windows.Forms.Cursors.Default;
            this.staffAvatar.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources._0cc4f09cdee89166635771b853a50326;
            this.staffAvatar.Location = new System.Drawing.Point(572, 26);
            this.staffAvatar.MaximumSize = new System.Drawing.Size(180, 180);
            this.staffAvatar.MinimumSize = new System.Drawing.Size(180, 180);
            this.staffAvatar.Name = "staffAvatar";
            this.staffAvatar.Size = new System.Drawing.Size(180, 180);
            this.staffAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.staffAvatar.TabIndex = 0;
            this.staffAvatar.TabStop = false;
            // 
            // openImage
            // 
            this.openImage.FileName = "openFileDialog1";
            // 
            // staffBindingSource
            // 
            this.staffBindingSource.DataSource = typeof(KIT206.A2.Group18.HRIS.Staff);
            // 
            // addStaffInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.container);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(850, 550);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "addStaffInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addStaffInfo";
            this.Load += new System.EventHandler(this.addStaffInfo_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.PictureBox staffAvatar;
        private System.Windows.Forms.Label titleLb;
        private System.Windows.Forms.TextBox GNameTB;
        private System.Windows.Forms.Label GNameLb;
        private System.Windows.Forms.ComboBox cateList;
        private System.Windows.Forms.Label cateLb;
        private System.Windows.Forms.ComboBox campusList;
        private System.Windows.Forms.TextBox roomTB;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.TextBox contactTB;
        private System.Windows.Forms.Label campusLB;
        private System.Windows.Forms.Label roomLB;
        private System.Windows.Forms.Label emailLB;
        private System.Windows.Forms.Label ContactLB;
        private System.Windows.Forms.TextBox FNameTB;
        private System.Windows.Forms.Label FNameLB;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.Button saveStaffButton;
        private System.Windows.Forms.BindingSource staffBindingSource;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.Panel separator;
    }
}