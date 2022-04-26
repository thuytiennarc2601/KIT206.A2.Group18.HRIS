using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206.A2.Group18.HRIS;
using System.Windows;

namespace HRIS.WPF
{
    class Validation
    {
        #region Validate Adding Unit Operation
        //Check if a unit exists or not
        public static bool AddUnitValidation(string UnitCode, string UnitName, int StaffID)
        {
            bool valid = true;
            Unit UnitByCode = Unit.GetUnitByCode(UnitCode);
            Unit UnitByName = Unit.GetUnitByTitle(UnitName);
            if (UnitCode == "")
            {
                valid = false;
                MessageBox.Show("Unit code required");
            }
            else if(UnitName == "")
            {
                valid = false;
                MessageBox.Show("Unit name required");
            }
            else if(UnitByCode.UnitCode != "")
            {
                valid = false;
                MessageBox.Show("This unit code already exist");                
            }
            else if(UnitByName.UnitName != "")
            {
                valid = false;
                MessageBox.Show("This unit name already exist");
            }
            else if (StaffID == -1)
            {
                valid = false;
                MessageBox.Show("A coordinator required");
            }
            return valid;
        }
        #endregion
    }
}
