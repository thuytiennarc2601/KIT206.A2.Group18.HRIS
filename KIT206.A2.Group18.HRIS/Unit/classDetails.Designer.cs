
namespace KIT206.A2.Group18.HRIS
{
    partial class classDetails
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
            this.classLocation = new System.Windows.Forms.Label();
            this.classTime = new System.Windows.Forms.Label();
            this.classType = new System.Windows.Forms.Label();
            this.classStaff = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // classLocation
            // 
            this.classLocation.AutoSize = true;
            this.classLocation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLocation.ForeColor = System.Drawing.Color.Gray;
            this.classLocation.Location = new System.Drawing.Point(46, 57);
            this.classLocation.Name = "classLocation";
            this.classLocation.Size = new System.Drawing.Size(236, 24);
            this.classLocation.TabIndex = 1;
            this.classLocation.Text = "Room: C0 | Hobart campus";
            // 
            // classTime
            // 
            this.classTime.AutoSize = true;
            this.classTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTime.ForeColor = System.Drawing.Color.Gray;
            this.classTime.Location = new System.Drawing.Point(46, 33);
            this.classTime.Name = "classTime";
            this.classTime.Size = new System.Drawing.Size(212, 24);
            this.classTime.TabIndex = 2;
            this.classTime.Text = "Thursday | 13:00 - 15:00";
            // 
            // classType
            // 
            this.classType.AutoSize = true;
            this.classType.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classType.Location = new System.Drawing.Point(45, 5);
            this.classType.Name = "classType";
            this.classType.Size = new System.Drawing.Size(97, 28);
            this.classType.TabIndex = 3;
            this.classType.Text = "Lecture";
            // 
            // classStaff
            // 
            this.classStaff.AutoSize = true;
            this.classStaff.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classStaff.ForeColor = System.Drawing.Color.Black;
            this.classStaff.Location = new System.Drawing.Point(46, 81);
            this.classStaff.Name = "classStaff";
            this.classStaff.Size = new System.Drawing.Size(199, 24);
            this.classStaff.TabIndex = 4;
            this.classStaff.Text = "Staff: Dr. Lindsay Wells";
            // 
            // classDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.classStaff);
            this.Controls.Add(this.classType);
            this.Controls.Add(this.classTime);
            this.Controls.Add(this.classLocation);
            this.Name = "classDetails";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.Size = new System.Drawing.Size(826, 112);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label classLocation;
        private System.Windows.Forms.Label classTime;
        private System.Windows.Forms.Label classType;
        private System.Windows.Forms.Label classStaff;
    }
}
