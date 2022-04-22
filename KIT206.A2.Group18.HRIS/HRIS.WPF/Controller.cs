
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
        private List<Unit> unit;
        private List<Class> classes;
        private List<Consultation> consultation;
        //public List<Staff> Workers { get { return staff; } set { } }

        private ObservableCollection<Staff> viewableStaff;
        private ObservableCollection<Unit> viewableUnit;
        private ObservableCollection<Class> viewableClasses;
        private ObservableCollection<Consultation> viewableConsultation;
        public ObservableCollection<Staff> VisibleStaffs { get { return viewableStaff; } set { } }
        public ObservableCollection<Unit> VisibleUnits { get { return viewableUnit; } set { } }
        public ObservableCollection<Class> VisibleClasses { get { return viewableClasses; } set { } }
        public ObservableCollection<Consultation> VisibleConsultations { get { return viewableConsultation; } set { } }


        public Controller ()
        {
            staff = Agency.LoadAllStaffs();
            viewableStaff = new ObservableCollection<Staff>(staff); 

            foreach (Staff e in staff)
            {
                e.Consultations = Agency.LoadConsultations(e.ID);
                e.Classes = Agency.LoadClasses(e.ID);
            }

            unit = Agency.LoadAllUnits();
            viewableUnit = new ObservableCollection<Unit>(unit);

            classes = Agency.LoadAllClasses();
            viewableClasses = new ObservableCollection<Class>(classes);

            consultation = Agency.LoadAllConsultations();
            viewableConsultation = new ObservableCollection<Consultation>(consultation);
        }
        public ObservableCollection<Staff> GetViewableStaffList()
        {
            return VisibleStaffs;
        }
        public ObservableCollection<Unit> GetViewableUnitList()
        {
            return VisibleUnits;
        }
        public ObservableCollection<Class> GetViewableClassList()
        {
            return VisibleClasses;
        }
        public ObservableCollection<Consultation> GetViewableConsultationList()
        {
            return VisibleConsultations;
        }
        public void DeleteConsultation(int id, Day day, TimeOnly Start, TimeOnly End)
        {

        }
        public void AddConsultation(int id, string day, string Start, string End)
        {
            Agency.AddConsultation(id, day, Start, End);
        }
    }
}
