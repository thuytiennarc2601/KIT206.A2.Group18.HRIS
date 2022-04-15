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
    public partial class unitDetailsView : Form
    {
        public unitDetailsView()
        {
            InitializeComponent();
        }

        private int _itemID;

        [Category("Properties")]
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        #region Load Unit Information
        //Load unit details into view
        private void unitDetailsView_Load(object sender, EventArgs e)
        {
            List<Unit> unitList = Unit.LoadAllUnit();

            unitCodeName.Text = unitList[this.ItemID].UnitCode.ToUpper() + " | " + unitList[this.ItemID].UnitName;
            unitCoordinator.Text = "Coordinator: " + Staff.GetStaffName(unitList[this.ItemID].Coordinator.ID) + " | " + (unitList[this.ItemID].Coordinator.ID).ToString();
            getClassDetails(unitList[this.ItemID].UnitCode);
        
        }
        #endregion

        #region Get Class Details
        private void getClassDetails(string UnitCode)
        {
            List<Class> classList = Class.LoadAllClasses();

            var result = from Class c in classList
                         where c.unit.UnitCode == UnitCode
                         select c;

            List<Class> resultList = new List<Class>(result);

            if (resultList.Count == 0)
            {
                Label empty = new Label();
                empty.Name = "emptyLabel";
                empty.AutoSize = true;
                empty.ForeColor = Color.Gray;
                empty.Font = new Font("Calibri", 16);
                empty.Text = "No class added for this unit";

                classHolder.Controls.Add(empty);
            }
            else
            {
                classDetails[] classView = new classDetails[resultList.Count];
                for (int i = 0; i < resultList.Count; i++)
                {
                    classView[i] = new classDetails();
                    classView[i].ClassType = resultList[i].type.ToString();
                    classView[i].ClassTime = resultList[i].day.ToString() + " | " + resultList[i].StartTime.ToString() + " - " + resultList[i].EndTime.ToString();
                    classView[i].ClassLocation = "Room: " + resultList[i].Room + " | " + resultList[i].campus.ToString();
                    classView[i].ClassStaff = "Staff: " + Staff.GetStaffName(resultList[i].staff.ID) + " | " + resultList[i].staff.ID;

                    classHolder.Controls.Add(classView[i]);
                }
            }
        }
        #endregion
    }
}