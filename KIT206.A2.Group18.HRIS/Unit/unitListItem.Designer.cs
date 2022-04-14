
namespace KIT206.A2.Group18.HRIS
{
    partial class unitListItem
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
            this.unitName = new System.Windows.Forms.Label();
            this.unitCode = new System.Windows.Forms.Label();
            this.coordinatorName = new System.Windows.Forms.Label();
            this.coordinatorUnit = new System.Windows.Forms.Label();
            this.editCor = new System.Windows.Forms.Button();
            this.Seperator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // selectBar
            // 
            this.selectBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectBar.BackColor = System.Drawing.Color.White;
            this.selectBar.Location = new System.Drawing.Point(0, 0);
            this.selectBar.Name = "selectBar";
            this.selectBar.Size = new System.Drawing.Size(13, 130);
            this.selectBar.TabIndex = 0;
            this.selectBar.MouseEnter += new System.EventHandler(this.unitListItem_MouseEnter);
            this.selectBar.MouseLeave += new System.EventHandler(this.unitListItem_MouseLeave);
            // 
            // unitName
            // 
            this.unitName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitName.AutoSize = true;
            this.unitName.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitName.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.unitName.Location = new System.Drawing.Point(91, 15);
            this.unitName.Name = "unitName";
            this.unitName.Size = new System.Drawing.Size(334, 35);
            this.unitName.TabIndex = 1;
            this.unitName.Text = "Game Fundamentals";
            this.unitName.MouseEnter += new System.EventHandler(this.unitListItem_MouseEnter);
            this.unitName.MouseLeave += new System.EventHandler(this.unitListItem_MouseLeave);
            // 
            // unitCode
            // 
            this.unitCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitCode.AutoSize = true;
            this.unitCode.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCode.ForeColor = System.Drawing.Color.Gray;
            this.unitCode.Location = new System.Drawing.Point(94, 52);
            this.unitCode.Name = "unitCode";
            this.unitCode.Size = new System.Drawing.Size(79, 29);
            this.unitCode.TabIndex = 2;
            this.unitCode.Text = "KIT109";
            this.unitCode.MouseEnter += new System.EventHandler(this.unitListItem_MouseEnter);
            this.unitCode.MouseLeave += new System.EventHandler(this.unitListItem_MouseLeave);
            // 
            // coordinatorName
            // 
            this.coordinatorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coordinatorName.AutoSize = true;
            this.coordinatorName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorName.ForeColor = System.Drawing.Color.Black;
            this.coordinatorName.Location = new System.Drawing.Point(276, 82);
            this.coordinatorName.Name = "coordinatorName";
            this.coordinatorName.Size = new System.Drawing.Size(206, 28);
            this.coordinatorName.TabIndex = 3;
            this.coordinatorName.Text = "Dr. Lindsay Wells";
            this.coordinatorName.MouseEnter += new System.EventHandler(this.unitListItem_MouseEnter);
            this.coordinatorName.MouseLeave += new System.EventHandler(this.unitListItem_MouseLeave);
            // 
            // coordinatorUnit
            // 
            this.coordinatorUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coordinatorUnit.AutoSize = true;
            this.coordinatorUnit.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.coordinatorUnit.Location = new System.Drawing.Point(93, 82);
            this.coordinatorUnit.Name = "coordinatorUnit";
            this.coordinatorUnit.Size = new System.Drawing.Size(177, 29);
            this.coordinatorUnit.TabIndex = 4;
            this.coordinatorUnit.Text = "Unit coordinator:";
            this.coordinatorUnit.MouseEnter += new System.EventHandler(this.unitListItem_MouseEnter);
            this.coordinatorUnit.MouseLeave += new System.EventHandler(this.unitListItem_MouseLeave);
            // 
            // editCor
            // 
            this.editCor.BackColor = System.Drawing.Color.LightPink;
            this.editCor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editCor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCor.ForeColor = System.Drawing.Color.White;
            this.editCor.Location = new System.Drawing.Point(1101, 76);
            this.editCor.Name = "editCor";
            this.editCor.Size = new System.Drawing.Size(97, 42);
            this.editCor.TabIndex = 5;
            this.editCor.Text = "EDIT";
            this.editCor.UseVisualStyleBackColor = false;
            this.editCor.Click += new System.EventHandler(this.editCor_Click);
            this.editCor.MouseEnter += new System.EventHandler(this.unitListItem_MouseEnter);
            this.editCor.MouseLeave += new System.EventHandler(this.unitListItem_MouseLeave);
            // 
            // Seperator
            // 
            this.Seperator.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Seperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Seperator.Location = new System.Drawing.Point(48, 126);
            this.Seperator.Name = "Seperator";
            this.Seperator.Size = new System.Drawing.Size(1171, 10);
            this.Seperator.TabIndex = 6;
            // 
            // unitListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Seperator);
            this.Controls.Add(this.editCor);
            this.Controls.Add(this.coordinatorUnit);
            this.Controls.Add(this.coordinatorName);
            this.Controls.Add(this.unitCode);
            this.Controls.Add(this.unitName);
            this.Controls.Add(this.selectBar);
            this.Name = "unitListItem";
            this.Size = new System.Drawing.Size(1220, 130);
            this.MouseEnter += new System.EventHandler(this.unitListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.unitListItem_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel selectBar;
        private System.Windows.Forms.Label unitName;
        private System.Windows.Forms.Label unitCode;
        private System.Windows.Forms.Label coordinatorName;
        private System.Windows.Forms.Label coordinatorUnit;
        private System.Windows.Forms.Button editCor;
        private System.Windows.Forms.Panel Seperator;
    }
}
