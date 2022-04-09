
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
            this.staffImage = new System.Windows.Forms.PictureBox();
            this.staffName = new System.Windows.Forms.Label();
            this.staffTitle = new System.Windows.Forms.Label();
            this.staffEmail = new System.Windows.Forms.Label();
            this.imageHolder = new System.Windows.Forms.Panel();
            this.staffCampus = new System.Windows.Forms.Label();
            this.staffEdit = new System.Windows.Forms.Button();
            this.staffID = new System.Windows.Forms.Label();
            this.removeStaff = new System.Windows.Forms.Button();
            this.selectBar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.staffImage)).BeginInit();
            this.imageHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // staffImage
            // 
            this.staffImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffImage.Location = new System.Drawing.Point(16, 11);
            this.staffImage.Name = "staffImage";
            this.staffImage.Size = new System.Drawing.Size(90, 90);
            this.staffImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.staffImage.TabIndex = 0;
            this.staffImage.TabStop = false;
            // 
            // staffName
            // 
            this.staffName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffName.AutoEllipsis = true;
            this.staffName.AutoSize = true;
            this.staffName.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffName.Location = new System.Drawing.Point(253, 22);
            this.staffName.Name = "staffName";
            this.staffName.Size = new System.Drawing.Size(139, 33);
            this.staffName.TabIndex = 1;
            this.staffName.Text = "Staff Name";
            // 
            // staffTitle
            // 
            this.staffTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffTitle.AutoEllipsis = true;
            this.staffTitle.AutoSize = true;
            this.staffTitle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffTitle.Location = new System.Drawing.Point(190, 25);
            this.staffTitle.Name = "staffTitle";
            this.staffTitle.Size = new System.Drawing.Size(57, 29);
            this.staffTitle.TabIndex = 3;
            this.staffTitle.Text = "Prof.";
            // 
            // staffEmail
            // 
            this.staffEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffEmail.AutoEllipsis = true;
            this.staffEmail.AutoSize = true;
            this.staffEmail.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffEmail.Location = new System.Drawing.Point(191, 77);
            this.staffEmail.Name = "staffEmail";
            this.staffEmail.Size = new System.Drawing.Size(133, 23);
            this.staffEmail.TabIndex = 4;
            this.staffEmail.Text = "abc@gmail.com";
            // 
            // imageHolder
            // 
            this.imageHolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageHolder.BackColor = System.Drawing.Color.Transparent;
            this.imageHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageHolder.Controls.Add(this.staffImage);
            this.imageHolder.Location = new System.Drawing.Point(43, 13);
            this.imageHolder.Name = "imageHolder";
            this.imageHolder.Size = new System.Drawing.Size(124, 114);
            this.imageHolder.TabIndex = 5;
            // 
            // staffCampus
            // 
            this.staffCampus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffCampus.AutoSize = true;
            this.staffCampus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffCampus.Location = new System.Drawing.Point(191, 100);
            this.staffCampus.Name = "staffCampus";
            this.staffCampus.Size = new System.Drawing.Size(153, 23);
            this.staffCampus.TabIndex = 6;
            this.staffCampus.Text = "Sandy Bay campus";
            // 
            // staffEdit
            // 
            this.staffEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.staffEdit.BackColor = System.Drawing.Color.DimGray;
            this.staffEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.staffEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staffEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffEdit.ForeColor = System.Drawing.Color.White;
            this.staffEdit.Location = new System.Drawing.Point(801, 100);
            this.staffEdit.Name = "staffEdit";
            this.staffEdit.Size = new System.Drawing.Size(70, 23);
            this.staffEdit.TabIndex = 7;
            this.staffEdit.Text = "Edit";
            this.staffEdit.UseVisualStyleBackColor = false;
            // 
            // staffID
            // 
            this.staffID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffID.AutoSize = true;
            this.staffID.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffID.Location = new System.Drawing.Point(191, 54);
            this.staffID.Name = "staffID";
            this.staffID.Size = new System.Drawing.Size(85, 23);
            this.staffID.TabIndex = 8;
            this.staffID.Text = "ID: xxxxxx";
            // 
            // removeStaff
            // 
            this.removeStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeStaff.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeStaff.Location = new System.Drawing.Point(877, 100);
            this.removeStaff.Name = "removeStaff";
            this.removeStaff.Size = new System.Drawing.Size(70, 23);
            this.removeStaff.TabIndex = 9;
            this.removeStaff.Text = "Remove";
            this.removeStaff.UseVisualStyleBackColor = true;
            // 
            // selectBar
            // 
            this.selectBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectBar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.selectBar.Location = new System.Drawing.Point(0, 0);
            this.selectBar.Name = "selectBar";
            this.selectBar.Size = new System.Drawing.Size(10, 140);
            this.selectBar.TabIndex = 10;
            // 
            // staffListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.selectBar);
            this.Controls.Add(this.removeStaff);
            this.Controls.Add(this.staffID);
            this.Controls.Add(this.staffEdit);
            this.Controls.Add(this.staffCampus);
            this.Controls.Add(this.imageHolder);
            this.Controls.Add(this.staffEmail);
            this.Controls.Add(this.staffTitle);
            this.Controls.Add(this.staffName);
            this.MaximumSize = new System.Drawing.Size(954, 150);
            this.MinimumSize = new System.Drawing.Size(954, 140);
            this.Name = "staffListItem";
            this.Size = new System.Drawing.Size(954, 140);
            ((System.ComponentModel.ISupportInitialize)(this.staffImage)).EndInit();
            this.imageHolder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox staffImage;
        private System.Windows.Forms.Label staffName;
        private System.Windows.Forms.Label staffTitle;
        private System.Windows.Forms.Label staffEmail;
        private System.Windows.Forms.Panel imageHolder;
        private System.Windows.Forms.Label staffCampus;
        private System.Windows.Forms.Button staffEdit;
        private System.Windows.Forms.Label staffID;
        private System.Windows.Forms.Button removeStaff;
        private System.Windows.Forms.Panel selectBar;
    }
}
