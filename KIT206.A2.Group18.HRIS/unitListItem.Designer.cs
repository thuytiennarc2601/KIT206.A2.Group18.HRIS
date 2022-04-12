
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.unitName = new System.Windows.Forms.Label();
            this.unitCode = new System.Windows.Forms.Label();
            this.coordinatorName = new System.Windows.Forms.Label();
            this.coordinatorUnit = new System.Windows.Forms.Label();
            this.editCor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(13, 130);
            this.panel1.TabIndex = 0;
            // 
            // unitName
            // 
            this.unitName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitName.AutoSize = true;
            this.unitName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitName.ForeColor = System.Drawing.Color.Tan;
            this.unitName.Location = new System.Drawing.Point(91, 18);
            this.unitName.Name = "unitName";
            this.unitName.Size = new System.Drawing.Size(273, 37);
            this.unitName.TabIndex = 1;
            this.unitName.Text = "Game Fundamentals";
            // 
            // unitCode
            // 
            this.unitCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitCode.AutoSize = true;
            this.unitCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCode.ForeColor = System.Drawing.Color.Gray;
            this.unitCode.Location = new System.Drawing.Point(94, 55);
            this.unitCode.Name = "unitCode";
            this.unitCode.Size = new System.Drawing.Size(65, 24);
            this.unitCode.TabIndex = 2;
            this.unitCode.Text = "KIT109";
            // 
            // coordinatorName
            // 
            this.coordinatorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coordinatorName.AutoSize = true;
            this.coordinatorName.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorName.ForeColor = System.Drawing.Color.Black;
            this.coordinatorName.Location = new System.Drawing.Point(265, 82);
            this.coordinatorName.Name = "coordinatorName";
            this.coordinatorName.Size = new System.Drawing.Size(209, 35);
            this.coordinatorName.TabIndex = 3;
            this.coordinatorName.Text = "Dr. Lindsay Wells";
            // 
            // coordinatorUnit
            // 
            this.coordinatorUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coordinatorUnit.AutoSize = true;
            this.coordinatorUnit.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.coordinatorUnit.Location = new System.Drawing.Point(93, 86);
            this.coordinatorUnit.Name = "coordinatorUnit";
            this.coordinatorUnit.Size = new System.Drawing.Size(177, 29);
            this.coordinatorUnit.TabIndex = 4;
            this.coordinatorUnit.Text = "Unit coordinator:";
            // 
            // editCor
            // 
            this.editCor.BackColor = System.Drawing.Color.SteelBlue;
            this.editCor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editCor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCor.ForeColor = System.Drawing.Color.White;
            this.editCor.Location = new System.Drawing.Point(1012, 82);
            this.editCor.Name = "editCor";
            this.editCor.Size = new System.Drawing.Size(160, 33);
            this.editCor.TabIndex = 5;
            this.editCor.Text = "Edit Coordinator";
            this.editCor.UseVisualStyleBackColor = false;
            // 
            // unitListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editCor);
            this.Controls.Add(this.coordinatorUnit);
            this.Controls.Add(this.coordinatorName);
            this.Controls.Add(this.unitCode);
            this.Controls.Add(this.unitName);
            this.Controls.Add(this.panel1);
            this.Name = "unitListItem";
            this.Size = new System.Drawing.Size(1220, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label unitName;
        private System.Windows.Forms.Label unitCode;
        private System.Windows.Forms.Label coordinatorName;
        private System.Windows.Forms.Label coordinatorUnit;
        private System.Windows.Forms.Button editCor;
    }
}
