﻿
namespace KIT206.A2.Group18.HRIS
{
    partial class emptyList
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
            this.emptyMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // emptyMessage
            // 
            this.emptyMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emptyMessage.AutoSize = true;
            this.emptyMessage.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptyMessage.Location = new System.Drawing.Point(480, 41);
            this.emptyMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emptyMessage.Name = "emptyMessage";
            this.emptyMessage.Size = new System.Drawing.Size(273, 45);
            this.emptyMessage.TabIndex = 0;
            this.emptyMessage.Text = "The list is empty. ";
            this.emptyMessage.Click += new System.EventHandler(this.emptyMessage_Click);
            // 
            // emptyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.emptyMessage);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1227, 148);
            this.MinimumSize = new System.Drawing.Size(1227, 148);
            this.Name = "emptyList";
            this.Size = new System.Drawing.Size(1227, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emptyMessage;
    }
}
