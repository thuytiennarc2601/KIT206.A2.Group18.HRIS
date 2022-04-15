
namespace KIT206.A2.Group18.HRIS
{
    partial class classListItem
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
            this.unitInfo = new System.Windows.Forms.Label();
            this.classTypeRoomCampus = new System.Windows.Forms.Label();
            this.staffInfo = new System.Windows.Forms.Label();
            this.classDayTime = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.selectBar = new System.Windows.Forms.Panel();
            this.registerButton = new System.Windows.Forms.Button();
            this.Seperator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // unitInfo
            // 
            this.unitInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitInfo.AutoSize = true;
            this.unitInfo.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitInfo.ForeColor = System.Drawing.Color.Tan;
            this.unitInfo.Location = new System.Drawing.Point(132, 10);
            this.unitInfo.Name = "unitInfo";
            this.unitInfo.Size = new System.Drawing.Size(478, 32);
            this.unitInfo.TabIndex = 0;
            this.unitInfo.Text = "KIT206 | Software Development";
            this.unitInfo.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.unitInfo.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // classTypeRoomCampus
            // 
            this.classTypeRoomCampus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.classTypeRoomCampus.AutoSize = true;
            this.classTypeRoomCampus.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTypeRoomCampus.ForeColor = System.Drawing.Color.Gray;
            this.classTypeRoomCampus.Location = new System.Drawing.Point(133, 76);
            this.classTypeRoomCampus.Name = "classTypeRoomCampus";
            this.classTypeRoomCampus.Size = new System.Drawing.Size(383, 29);
            this.classTypeRoomCampus.TabIndex = 2;
            this.classTypeRoomCampus.Text = "Lecture | Room: 275 | Hobart campus";
            this.classTypeRoomCampus.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.classTypeRoomCampus.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // staffInfo
            // 
            this.staffInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.staffInfo.AutoSize = true;
            this.staffInfo.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffInfo.Location = new System.Drawing.Point(132, 42);
            this.staffInfo.Name = "staffInfo";
            this.staffInfo.Size = new System.Drawing.Size(203, 35);
            this.staffInfo.TabIndex = 3;
            this.staffInfo.Text = "Dr. Lindsay Wells";
            this.staffInfo.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.staffInfo.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // classDayTime
            // 
            this.classDayTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.classDayTime.AutoSize = true;
            this.classDayTime.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classDayTime.ForeColor = System.Drawing.Color.Gray;
            this.classDayTime.Location = new System.Drawing.Point(133, 105);
            this.classDayTime.Name = "classDayTime";
            this.classDayTime.Size = new System.Drawing.Size(220, 29);
            this.classDayTime.TabIndex = 4;
            this.classDayTime.Text = "Friday | 15:00 - 17:00";
            this.classDayTime.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.classDayTime.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.BackColor = System.Drawing.Color.Wheat;
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Location = new System.Drawing.Point(1114, 99);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(85, 35);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "EDIT";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.editButton.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // selectBar
            // 
            this.selectBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectBar.Location = new System.Drawing.Point(0, 0);
            this.selectBar.Name = "selectBar";
            this.selectBar.Size = new System.Drawing.Size(13, 150);
            this.selectBar.TabIndex = 6;
            this.selectBar.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.selectBar.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // registerButton
            // 
            this.registerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registerButton.BackColor = System.Drawing.Color.Wheat;
            this.registerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.White;
            this.registerButton.Location = new System.Drawing.Point(985, 99);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(123, 35);
            this.registerButton.TabIndex = 7;
            this.registerButton.Text = "REGISTER";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.registerButton.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // Seperator
            // 
            this.Seperator.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Seperator.BackColor = System.Drawing.Color.LightGray;
            this.Seperator.Location = new System.Drawing.Point(44, 145);
            this.Seperator.Name = "Seperator";
            this.Seperator.Size = new System.Drawing.Size(1176, 10);
            this.Seperator.TabIndex = 8;
            this.Seperator.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.Seperator.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            // 
            // classListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Seperator);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.selectBar);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.classDayTime);
            this.Controls.Add(this.staffInfo);
            this.Controls.Add(this.classTypeRoomCampus);
            this.Controls.Add(this.unitInfo);
            this.Name = "classListItem";
            this.Size = new System.Drawing.Size(1220, 150);
            this.MouseEnter += new System.EventHandler(this.classListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.classListItem_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label unitInfo;
        private System.Windows.Forms.Label classTypeRoomCampus;
        private System.Windows.Forms.Label staffInfo;
        private System.Windows.Forms.Label classDayTime;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Panel selectBar;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Panel Seperator;
    }
}
