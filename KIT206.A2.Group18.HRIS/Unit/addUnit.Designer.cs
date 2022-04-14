
namespace KIT206.A2.Group18.HRIS
{
    partial class addUnit
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
            this.addUnitButton = new System.Windows.Forms.Button();
            this.note = new System.Windows.Forms.Label();
            this.coordinatorTB = new System.Windows.Forms.TextBox();
            this.coorOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.unitCodeTB = new System.Windows.Forms.TextBox();
            this.unitNameTB = new System.Windows.Forms.TextBox();
            this.CoorLB = new System.Windows.Forms.Label();
            this.unitCodeLB = new System.Windows.Forms.Label();
            this.unitNameLB = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.container.BackColor = System.Drawing.Color.White;
            this.container.Controls.Add(this.addUnitButton);
            this.container.Controls.Add(this.note);
            this.container.Controls.Add(this.coordinatorTB);
            this.container.Controls.Add(this.coorOptions);
            this.container.Controls.Add(this.unitCodeTB);
            this.container.Controls.Add(this.unitNameTB);
            this.container.Controls.Add(this.CoorLB);
            this.container.Controls.Add(this.unitCodeLB);
            this.container.Controls.Add(this.unitNameLB);
            this.container.Location = new System.Drawing.Point(12, 12);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(558, 329);
            this.container.TabIndex = 0;
            // 
            // addUnitButton
            // 
            this.addUnitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addUnitButton.BackColor = System.Drawing.Color.PaleVioletRed;
            this.addUnitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUnitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUnitButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUnitButton.ForeColor = System.Drawing.Color.White;
            this.addUnitButton.Location = new System.Drawing.Point(21, 268);
            this.addUnitButton.Name = "addUnitButton";
            this.addUnitButton.Size = new System.Drawing.Size(95, 44);
            this.addUnitButton.TabIndex = 6;
            this.addUnitButton.Text = "ADD";
            this.addUnitButton.UseVisualStyleBackColor = false;
            this.addUnitButton.Click += new System.EventHandler(this.addUnitButton_Click);
            // 
            // note
            // 
            this.note.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.note.AutoSize = true;
            this.note.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note.ForeColor = System.Drawing.Color.Gray;
            this.note.Location = new System.Drawing.Point(6, 150);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(211, 17);
            this.note.TabIndex = 8;
            this.note.Text = "(Search and click on a staff member)";
            // 
            // coordinatorTB
            // 
            this.coordinatorTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coordinatorTB.AutoCompleteCustomSource.AddRange(new string[] {
            "Tran Ngoc Thuy Tien\t",
            "Lisa Bella",
            "123456 - Anabella",
            "Ian 0123456"});
            this.coordinatorTB.BackColor = System.Drawing.Color.White;
            this.coordinatorTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorTB.ForeColor = System.Drawing.Color.Gray;
            this.coordinatorTB.Location = new System.Drawing.Point(249, 116);
            this.coordinatorTB.MaxLength = 100;
            this.coordinatorTB.Name = "coordinatorTB";
            this.coordinatorTB.Size = new System.Drawing.Size(293, 36);
            this.coordinatorTB.TabIndex = 7;
            this.coordinatorTB.TextChanged += new System.EventHandler(this.coordinatorTB_TextChanged);
            // 
            // coorOptions
            // 
            this.coorOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coorOptions.AutoScroll = true;
            this.coorOptions.BackColor = System.Drawing.Color.White;
            this.coorOptions.Location = new System.Drawing.Point(249, 150);
            this.coorOptions.MinimumSize = new System.Drawing.Size(266, 105);
            this.coorOptions.Name = "coorOptions";
            this.coorOptions.Size = new System.Drawing.Size(291, 176);
            this.coorOptions.TabIndex = 5;
            this.coorOptions.Visible = false;
            // 
            // unitCodeTB
            // 
            this.unitCodeTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitCodeTB.BackColor = System.Drawing.Color.White;
            this.unitCodeTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCodeTB.ForeColor = System.Drawing.Color.Gray;
            this.unitCodeTB.Location = new System.Drawing.Point(176, 66);
            this.unitCodeTB.MaxLength = 6;
            this.unitCodeTB.Name = "unitCodeTB";
            this.unitCodeTB.Size = new System.Drawing.Size(364, 36);
            this.unitCodeTB.TabIndex = 4;
            // 
            // unitNameTB
            // 
            this.unitNameTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitNameTB.BackColor = System.Drawing.Color.White;
            this.unitNameTB.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitNameTB.ForeColor = System.Drawing.Color.Gray;
            this.unitNameTB.Location = new System.Drawing.Point(176, 20);
            this.unitNameTB.MaxLength = 45;
            this.unitNameTB.Name = "unitNameTB";
            this.unitNameTB.Size = new System.Drawing.Size(364, 36);
            this.unitNameTB.TabIndex = 3;
            // 
            // CoorLB
            // 
            this.CoorLB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CoorLB.AutoSize = true;
            this.CoorLB.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoorLB.Location = new System.Drawing.Point(3, 115);
            this.CoorLB.Name = "CoorLB";
            this.CoorLB.Size = new System.Drawing.Size(212, 35);
            this.CoorLB.TabIndex = 2;
            this.CoorLB.Text = "Unit coordinator:";
            // 
            // unitCodeLB
            // 
            this.unitCodeLB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unitCodeLB.AutoSize = true;
            this.unitCodeLB.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCodeLB.Location = new System.Drawing.Point(3, 67);
            this.unitCodeLB.Name = "unitCodeLB";
            this.unitCodeLB.Size = new System.Drawing.Size(133, 35);
            this.unitCodeLB.TabIndex = 1;
            this.unitCodeLB.Text = "Unit code:";
            // 
            // unitNameLB
            // 
            this.unitNameLB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unitNameLB.AutoSize = true;
            this.unitNameLB.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitNameLB.Location = new System.Drawing.Point(3, 19);
            this.unitNameLB.Name = "unitNameLB";
            this.unitNameLB.Size = new System.Drawing.Size(141, 35);
            this.unitNameLB.TabIndex = 0;
            this.unitNameLB.Text = "Unit name:";
            // 
            // addUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.container);
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "addUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new unit";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Button addUnitButton;
        private System.Windows.Forms.FlowLayoutPanel coorOptions;
        private System.Windows.Forms.TextBox unitCodeTB;
        private System.Windows.Forms.TextBox unitNameTB;
        private System.Windows.Forms.Label CoorLB;
        private System.Windows.Forms.Label unitCodeLB;
        private System.Windows.Forms.Label unitNameLB;
        private System.Windows.Forms.TextBox coordinatorTB;
        private System.Windows.Forms.Label note;
    }
}