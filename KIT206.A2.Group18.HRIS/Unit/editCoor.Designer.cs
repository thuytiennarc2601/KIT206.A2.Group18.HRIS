
namespace KIT206.A2.Group18.HRIS
{
    partial class editCoor
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
            this.container = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.FlowLayoutPanel();
            this.editNameTB = new System.Windows.Forms.TextBox();
            this.note = new System.Windows.Forms.Label();
            this.unitCoor = new System.Windows.Forms.Label();
            this.seperator = new System.Windows.Forms.Panel();
            this.unitInfo = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.container.BackColor = System.Drawing.Color.White;
            this.container.Controls.Add(this.updateButton);
            this.container.Controls.Add(this.options);
            this.container.Controls.Add(this.editNameTB);
            this.container.Controls.Add(this.note);
            this.container.Controls.Add(this.unitCoor);
            this.container.Controls.Add(this.seperator);
            this.container.Controls.Add(this.unitInfo);
            this.container.Location = new System.Drawing.Point(12, 12);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(726, 329);
            this.container.TabIndex = 0;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.BackColor = System.Drawing.Color.PaleVioletRed;
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(549, 270);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(110, 44);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "UPDATE";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // options
            // 
            this.options.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.options.AutoScroll = true;
            this.options.BackColor = System.Drawing.Color.White;
            this.options.Location = new System.Drawing.Point(9, 129);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(451, 197);
            this.options.TabIndex = 5;
            this.options.Visible = false;
            // 
            // editNameTB
            // 
            this.editNameTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editNameTB.BackColor = System.Drawing.Color.White;
            this.editNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editNameTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editNameTB.ForeColor = System.Drawing.Color.Gray;
            this.editNameTB.Location = new System.Drawing.Point(8, 87);
            this.editNameTB.Name = "editNameTB";
            this.editNameTB.Size = new System.Drawing.Size(451, 36);
            this.editNameTB.TabIndex = 4;
            this.editNameTB.TextChanged += new System.EventHandler(this.editNameTB_TextChanged);
            // 
            // note
            // 
            this.note.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.note.AutoSize = true;
            this.note.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note.ForeColor = System.Drawing.Color.Gray;
            this.note.Location = new System.Drawing.Point(231, 61);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(228, 18);
            this.note.TabIndex = 3;
            this.note.Text = "(search and click on a staff member)";
            // 
            // unitCoor
            // 
            this.unitCoor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitCoor.AutoSize = true;
            this.unitCoor.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCoor.Location = new System.Drawing.Point(4, 54);
            this.unitCoor.Name = "unitCoor";
            this.unitCoor.Size = new System.Drawing.Size(211, 30);
            this.unitCoor.TabIndex = 2;
            this.unitCoor.Text = "Unit coordinator:";
            // 
            // seperator
            // 
            this.seperator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.seperator.BackColor = System.Drawing.Color.Silver;
            this.seperator.Location = new System.Drawing.Point(3, 38);
            this.seperator.Name = "seperator";
            this.seperator.Size = new System.Drawing.Size(700, 5);
            this.seperator.TabIndex = 1;
            // 
            // unitInfo
            // 
            this.unitInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitInfo.AutoSize = true;
            this.unitInfo.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitInfo.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.unitInfo.Location = new System.Drawing.Point(3, 7);
            this.unitInfo.Name = "unitInfo";
            this.unitInfo.Size = new System.Drawing.Size(373, 28);
            this.unitInfo.TabIndex = 0;
            this.unitInfo.Text = "KIT109 | GAME FUNDAMENTALS";
            // 
            // editCoor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(750, 353);
            this.Controls.Add(this.container);
            this.MaximumSize = new System.Drawing.Size(768, 400);
            this.MinimumSize = new System.Drawing.Size(768, 400);
            this.Name = "editCoor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "editCoor";
            this.Load += new System.EventHandler(this.editCoor_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Label note;
        private System.Windows.Forms.Label unitCoor;
        private System.Windows.Forms.Panel seperator;
        private System.Windows.Forms.Label unitInfo;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.FlowLayoutPanel options;
        private System.Windows.Forms.TextBox editNameTB;
    }
}