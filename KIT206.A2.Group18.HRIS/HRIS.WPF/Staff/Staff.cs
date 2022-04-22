using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;


namespace HRIS.WPF
{

    public enum Campus { Hobart, Launceston }

    public enum Category { academic, technical, admin, casual }

    class Staff
    {
        #region Staff Properties
        public int ID { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Title { get; set; }

        public Campus campus { get; set; }

        public string Phone { get; set; }

        public string Room { get; set; }

        public string Email { get; set; }

        public Category category { get; set; }

        public byte[] Photo { get; set; }
        public List<Consultation> Consultations { get; set; }
        public List<Class> Classes { get; set; }
        #endregion
        public override string ToString()
        {
            return GivenName + " " + FamilyName;
        }
    }
}
