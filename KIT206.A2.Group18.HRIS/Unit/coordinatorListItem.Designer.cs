
namespace KIT206.A2.Group18.HRIS
{
    partial class coordinatorListItem
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
            this.selectBar = new System.Windows.Forms.Panel();
            this.coorIDName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectBar
            // 
            this.selectBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectBar.Location = new System.Drawing.Point(0, 0);
            this.selectBar.Name = "selectBar";
            this.selectBar.Size = new System.Drawing.Size(7, 35);
            this.selectBar.TabIndex = 5;
            this.selectBar.MouseEnter += new System.EventHandler(this.coordinatorListItem_MouseEnter);
            this.selectBar.MouseLeave += new System.EventHandler(this.coordinatorListItem_MouseLeave);
            // 
            // coorIDName
            // 
            this.coorIDName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.coorIDName.AutoSize = true;
            this.coorIDName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coorIDName.ForeColor = System.Drawing.Color.Gray;
            this.coorIDName.Location = new System.Drawing.Point(10, 5);
            this.coorIDName.Name = "coorIDName";
            this.coorIDName.Size = new System.Drawing.Size(178, 24);
            this.coorIDName.TabIndex = 5;
            this.coorIDName.Text = "Staff ID - Staff Name";
            this.coorIDName.MouseEnter += new System.EventHandler(this.coordinatorListItem_MouseEnter);
            this.coorIDName.MouseLeave += new System.EventHandler(this.coordinatorListItem_MouseLeave);
            // 
            // coordinatorListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.coorIDName);
            this.Controls.Add(this.selectBar);
            this.Name = "coordinatorListItem";
            this.Size = new System.Drawing.Size(270, 35);
            this.MouseEnter += new System.EventHandler(this.coordinatorListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.coordinatorListItem_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label coorIDName;
        private System.Windows.Forms.Panel selectBar;
    }
}
