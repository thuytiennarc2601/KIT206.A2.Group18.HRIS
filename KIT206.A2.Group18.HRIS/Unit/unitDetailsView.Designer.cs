
namespace KIT206.A2.Group18.HRIS
{
    partial class unitDetailsView
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
            this.classHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.classLB = new System.Windows.Forms.Label();
            this.unitCoordinator = new System.Windows.Forms.Label();
            this.unitCodeName = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.container.BackColor = System.Drawing.Color.White;
            this.container.Controls.Add(this.classHolder);
            this.container.Controls.Add(this.classLB);
            this.container.Controls.Add(this.unitCoordinator);
            this.container.Controls.Add(this.unitCodeName);
            this.container.Location = new System.Drawing.Point(23, 27);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(887, 420);
            this.container.TabIndex = 0;
            // 
            // classHolder
            // 
            this.classHolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.classHolder.AutoScroll = true;
            this.classHolder.Location = new System.Drawing.Point(23, 136);
            this.classHolder.Name = "classHolder";
            this.classHolder.Size = new System.Drawing.Size(842, 265);
            this.classHolder.TabIndex = 3;
            // 
            // classLB
            // 
            this.classLB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.classLB.AutoSize = true;
            this.classLB.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLB.Location = new System.Drawing.Point(18, 105);
            this.classLB.Name = "classLB";
            this.classLB.Size = new System.Drawing.Size(108, 28);
            this.classLB.TabIndex = 2;
            this.classLB.Text = "CLASSES";
            // 
            // unitCoordinator
            // 
            this.unitCoordinator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitCoordinator.AutoSize = true;
            this.unitCoordinator.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCoordinator.Location = new System.Drawing.Point(5, 50);
            this.unitCoordinator.Name = "unitCoordinator";
            this.unitCoordinator.Size = new System.Drawing.Size(354, 23);
            this.unitCoordinator.TabIndex = 1;
            this.unitCoordinator.Text = "Coordinator: Lindsay Wells | 123456";
            // 
            // unitCodeName
            // 
            this.unitCodeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unitCodeName.AutoSize = true;
            this.unitCodeName.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCodeName.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.unitCodeName.Location = new System.Drawing.Point(3, 9);
            this.unitCodeName.Name = "unitCodeName";
            this.unitCodeName.Size = new System.Drawing.Size(569, 32);
            this.unitCodeName.TabIndex = 0;
            this.unitCodeName.Text = "KIT206 | SOFTWARE DEVELOPMENT";
            // 
            // unitDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(933, 472);
            this.Controls.Add(this.container);
            this.Name = "unitDetailsView";
            this.Text = "unitDetailsView";
            this.Load += new System.EventHandler(this.unitDetailsView_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.FlowLayoutPanel classHolder;
        private System.Windows.Forms.Label classLB;
        private System.Windows.Forms.Label unitCoordinator;
        private System.Windows.Forms.Label unitCodeName;
    }
}