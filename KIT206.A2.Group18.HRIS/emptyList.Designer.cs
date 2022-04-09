
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
            this.emptyMessage.Location = new System.Drawing.Point(231, 47);
            this.emptyMessage.Name = "emptyMessage";
            this.emptyMessage.Size = new System.Drawing.Size(495, 36);
            this.emptyMessage.TabIndex = 0;
            this.emptyMessage.Text = "The list is empty. Please add a new item.";
            // 
            // emptyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.emptyMessage);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.MaximumSize = new System.Drawing.Size(954, 140);
            this.MinimumSize = new System.Drawing.Size(954, 140);
            this.Name = "emptyList";
            this.Size = new System.Drawing.Size(954, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emptyMessage;
    }
}
