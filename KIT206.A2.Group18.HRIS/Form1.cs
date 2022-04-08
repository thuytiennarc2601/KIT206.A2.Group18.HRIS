using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIT206.A2.Group18.HRIS
{
    public partial class HRIS : Form
    {
        public HRIS()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.titleHolder = new System.Windows.Forms.Panel();
            this.systemTitle = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.menuHolder = new System.Windows.Forms.TableLayoutPanel();
            this.unitListButton = new System.Windows.Forms.Button();
            this.classListButton = new System.Windows.Forms.Button();
            this.consultationListButton = new System.Windows.Forms.Button();
            this.staffListButton = new System.Windows.Forms.Button();
            this.listHolder = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleHolder.SuspendLayout();
            this.container.SuspendLayout();
            this.menuHolder.SuspendLayout();
            this.listHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleHolder
            // 
            this.titleHolder.BackColor = System.Drawing.Color.White;
            this.titleHolder.Controls.Add(this.systemTitle);
            this.titleHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleHolder.Location = new System.Drawing.Point(0, 0);
            this.titleHolder.Name = "titleHolder";
            this.titleHolder.Size = new System.Drawing.Size(1289, 113);
            this.titleHolder.TabIndex = 0;
            // 
            // systemTitle
            // 
            this.systemTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.systemTitle.AutoSize = true;
            this.systemTitle.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemTitle.ForeColor = System.Drawing.Color.BurlyWood;
            this.systemTitle.Location = new System.Drawing.Point(149, 13);
            this.systemTitle.Name = "systemTitle";
            this.systemTitle.Size = new System.Drawing.Size(1272, 97);
            this.systemTitle.TabIndex = 0;
            this.systemTitle.Text = "Human Resource Information System";
            this.systemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // container
            // 
            this.container.Controls.Add(this.listHolder);
            this.container.Controls.Add(this.menuHolder);
            this.container.Cursor = System.Windows.Forms.Cursors.Default;
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 113);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1289, 669);
            this.container.TabIndex = 1;
            // 
            // menuHolder
            // 
            this.menuHolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuHolder.BackColor = System.Drawing.Color.Transparent;
            this.menuHolder.ColumnCount = 4;
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuHolder.Controls.Add(this.unitListButton, 1, 0);
            this.menuHolder.Controls.Add(this.classListButton, 2, 0);
            this.menuHolder.Controls.Add(this.consultationListButton, 3, 0);
            this.menuHolder.Controls.Add(this.staffListButton, 0, 0);
            this.menuHolder.Location = new System.Drawing.Point(152, 0);
            this.menuHolder.Name = "menuHolder";
            this.menuHolder.RowCount = 1;
            this.menuHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuHolder.Size = new System.Drawing.Size(998, 157);
            this.menuHolder.TabIndex = 0;
            // 
            // unitListButton
            // 
            this.unitListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.unitListButton.BackgroundImage = global::KIT206.A2.Group18.HRIS.Properties.Resources.unit1;
            this.unitListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unitListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unitListButton.Location = new System.Drawing.Point(252, 3);
            this.unitListButton.Name = "unitListButton";
            this.unitListButton.Size = new System.Drawing.Size(243, 151);
            this.unitListButton.TabIndex = 1;
            this.unitListButton.UseVisualStyleBackColor = true;
            // 
            // classListButton
            // 
            this.classListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.classListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.classListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources._class;
            this.classListButton.Location = new System.Drawing.Point(501, 3);
            this.classListButton.Name = "classListButton";
            this.classListButton.Size = new System.Drawing.Size(243, 151);
            this.classListButton.TabIndex = 2;
            this.classListButton.UseVisualStyleBackColor = true;
            // 
            // consultationListButton
            // 
            this.consultationListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.consultationListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.consultationListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.consultationListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.consultation;
            this.consultationListButton.Location = new System.Drawing.Point(750, 3);
            this.consultationListButton.Name = "consultationListButton";
            this.consultationListButton.Size = new System.Drawing.Size(245, 151);
            this.consultationListButton.TabIndex = 3;
            this.consultationListButton.UseVisualStyleBackColor = true;
            // 
            // staffListButton
            // 
            this.staffListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.staffListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.staffListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staffListButton.Image = global::KIT206.A2.Group18.HRIS.Properties.Resources.staff2;
            this.staffListButton.Location = new System.Drawing.Point(3, 3);
            this.staffListButton.Name = "staffListButton";
            this.staffListButton.Size = new System.Drawing.Size(243, 151);
            this.staffListButton.TabIndex = 4;
            this.staffListButton.UseVisualStyleBackColor = true;
            // 
            // listHolder
            // 
            this.listHolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listHolder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listHolder.Controls.Add(this.panel1);
            this.listHolder.Location = new System.Drawing.Point(152, 163);
            this.listHolder.Name = "listHolder";
            this.listHolder.Size = new System.Drawing.Size(998, 496);
            this.listHolder.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 74);
            this.panel1.TabIndex = 0;
            // 
            // HRIS
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1289, 782);
            this.Controls.Add(this.container);
            this.Controls.Add(this.titleHolder);
            this.Name = "HRIS";
            this.Text = "Human Resource Information System";
            this.titleHolder.ResumeLayout(false);
            this.titleHolder.PerformLayout();
            this.container.ResumeLayout(false);
            this.menuHolder.ResumeLayout(false);
            this.listHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
