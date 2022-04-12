
namespace KIT206.A2.Group18.HRIS
{
    partial class staffListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.staffName = new System.Windows.Forms.Label();
            this.staffTitle = new System.Windows.Forms.Label();
            this.staffEmail = new System.Windows.Forms.Label();
            this.staffCampus = new System.Windows.Forms.Label();
            this.staffID = new System.Windows.Forms.Label();
            this.editStaff = new System.Windows.Forms.Button();
            this.selectBar = new System.Windows.Forms.Panel();
            this.staffImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.staffImage)).BeginInit();
            this.SuspendLayout();
            // 
            // staffName
            // 
            this.staffName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffName.AutoEllipsis = true;
            this.staffName.AutoSize = true;
            this.staffName.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffName.Location = new System.Drawing.Point(301, 15);
            this.staffName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.staffName.Name = "staffName";
            this.staffName.Size = new System.Drawing.Size(175, 41);
            this.staffName.TabIndex = 1;
            this.staffName.Text = "Staff Name";
            this.staffName.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.staffName.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.staffName.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // staffTitle
            // 
            this.staffTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffTitle.AutoEllipsis = true;
            this.staffTitle.AutoSize = true;
            this.staffTitle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffTitle.Location = new System.Drawing.Point(232, 18);
            this.staffTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.staffTitle.Name = "staffTitle";
            this.staffTitle.Size = new System.Drawing.Size(73, 37);
            this.staffTitle.TabIndex = 3;
            this.staffTitle.Text = "Prof.";
            this.staffTitle.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.staffTitle.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.staffTitle.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // staffEmail
            // 
            this.staffEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffEmail.AutoEllipsis = true;
            this.staffEmail.AutoSize = true;
            this.staffEmail.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffEmail.ForeColor = System.Drawing.Color.Gray;
            this.staffEmail.Location = new System.Drawing.Point(235, 82);
            this.staffEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.staffEmail.Name = "staffEmail";
            this.staffEmail.Size = new System.Drawing.Size(171, 29);
            this.staffEmail.TabIndex = 4;
            this.staffEmail.Text = "abc@gmail.com";
            this.staffEmail.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.staffEmail.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.staffEmail.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // staffCampus
            // 
            this.staffCampus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffCampus.AutoSize = true;
            this.staffCampus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffCampus.ForeColor = System.Drawing.Color.Gray;
            this.staffCampus.Location = new System.Drawing.Point(235, 111);
            this.staffCampus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.staffCampus.Name = "staffCampus";
            this.staffCampus.Size = new System.Drawing.Size(195, 29);
            this.staffCampus.TabIndex = 6;
            this.staffCampus.Text = "Sandy Bay campus";
            this.staffCampus.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.staffCampus.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.staffCampus.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // staffID
            // 
            this.staffID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffID.AutoSize = true;
            this.staffID.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffID.ForeColor = System.Drawing.Color.Gray;
            this.staffID.Location = new System.Drawing.Point(235, 54);
            this.staffID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.staffID.Name = "staffID";
            this.staffID.Size = new System.Drawing.Size(105, 29);
            this.staffID.TabIndex = 8;
            this.staffID.Text = "ID: xxxxxx";
            this.staffID.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.staffID.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.staffID.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // editStaff
            // 
            this.editStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editStaff.BackColor = System.Drawing.Color.SteelBlue;
            this.editStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editStaff.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editStaff.ForeColor = System.Drawing.Color.White;
            this.editStaff.Location = new System.Drawing.Point(1113, 98);
            this.editStaff.Margin = new System.Windows.Forms.Padding(4);
            this.editStaff.Name = "editStaff";
            this.editStaff.Size = new System.Drawing.Size(93, 28);
            this.editStaff.TabIndex = 9;
            this.editStaff.Text = "Edit";
            this.editStaff.UseVisualStyleBackColor = false;
            this.editStaff.Click += new System.EventHandler(this.editStaff_Click);
            this.editStaff.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.editStaff.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // selectBar
            // 
            this.selectBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectBar.BackColor = System.Drawing.Color.White;
            this.selectBar.Location = new System.Drawing.Point(0, -12);
            this.selectBar.Margin = new System.Windows.Forms.Padding(4);
            this.selectBar.Name = "selectBar";
            this.selectBar.Size = new System.Drawing.Size(13, 172);
            this.selectBar.TabIndex = 10;
            this.selectBar.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.selectBar.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.selectBar.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // staffImage
            // 
            this.staffImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffImage.ErrorImage = null;
            this.staffImage.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.CAT_HAIR_TIE_1000;
            this.staffImage.InitialImage = null;
            this.staffImage.Location = new System.Drawing.Point(74, 4);
            this.staffImage.Margin = new System.Windows.Forms.Padding(4);
            this.staffImage.Name = "staffImage";
            this.staffImage.Size = new System.Drawing.Size(150, 140);
            this.staffImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.staffImage.TabIndex = 0;
            this.staffImage.TabStop = false;
            this.staffImage.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.staffImage.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.staffImage.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            // 
            // staffListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.staffImage);
            this.Controls.Add(this.selectBar);
            this.Controls.Add(this.editStaff);
            this.Controls.Add(this.staffID);
            this.Controls.Add(this.staffCampus);
            this.Controls.Add(this.staffEmail);
            this.Controls.Add(this.staffTitle);
            this.Controls.Add(this.staffName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1227, 148);
            this.MinimumSize = new System.Drawing.Size(1227, 148);
            this.Name = "staffListItem";
            this.Size = new System.Drawing.Size(1227, 148);
            this.DoubleClick += new System.EventHandler(this.staffListItem_DoubleClick);
            this.MouseEnter += new System.EventHandler(this.staffListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.staffListItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.staffImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label staffName;
        private System.Windows.Forms.Label staffTitle;
        private System.Windows.Forms.Label staffEmail;
        private System.Windows.Forms.Label staffCampus;
        private System.Windows.Forms.Label staffID;
        private System.Windows.Forms.Button editStaff;
        private System.Windows.Forms.Panel selectBar;
        private System.Windows.Forms.PictureBox staffImage;
    }
}
