using KIT206.A2.Group18.HRIS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.WPF
{
    class Controller
    {
        private List<Staff> staff;
        public List<Staff> Workers { get { return staff; } set { } }

        private ObservableCollection<Staff> viewableStaff;
        public ObservableCollection<Staff> VisibleWorkers { get { return viewableStaff; } set { } }

    
        public Controller ()
        {
            staff = Agency.LoadAllStaffs();
            viewableStaff = new ObservableCollection<Staff>(staff); 

            
            foreach (Staff e in staff)
            {
                e.Consultations = Agency.LoadConsultations(e.ID);
                e.Classes = Agency.LoadClasses(e.ID);
            }
        }
        public ObservableCollection<Staff> GetViewableList()
        {
            return VisibleWorkers;
        }
    }
}
