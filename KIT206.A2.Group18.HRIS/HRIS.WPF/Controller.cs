
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
        public void DeleteConsultation(int id, string day, string Start, string End)
        {
            Agency.DeleteConsultation(id, day, Start, End);
        }
        public void AddConsultation(int id, string day, string Start, string End)
        {
            Agency.AddConsultation(id, day, Start, End);
        }
        public void EditClassDetail(string new_campus, string new_day, string new_start, string new_end, string new_type, string new_room, string new_staffID,
            string unitCode, string campus, string day, string start, string end, string type, string room, int staffID)
        {
            Agency.EditClassDetail(new_campus, new_day, new_start, new_end, new_type, new_room, new_staffID, unitCode, campus, day, start, end, type, room, staffID);
        }
    }
}
