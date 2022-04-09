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
    public partial class staffListItem : UserControl
    {
        public staffListItem()
        {
            InitializeComponent();
        }

        //defines all elements existing in a staff list item
        private string _title;
        private string _name;
        private string _campus;
        private string _email;
        private string _id;
        private Image _icon;

        public string Title
        {
            get { return _title; }
            set { _title = value; staffTitle.Text = value; }
        }

        public string StaffName
        {
            get { return _name; }
            set { _name = value; staffName.Text = value; }
        }
        public string Campus
        {
            get { return _campus; }
            set { _campus = value; staffCampus.Text = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; staffEmail.Text = value; }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; staffID.Text = value; }
        }

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; staffImage.Image = value ; }
        }
    }
}
