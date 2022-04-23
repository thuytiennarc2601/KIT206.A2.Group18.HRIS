using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KIT206.A2.Group18.HRIS
{
    public enum Campus { Hobart, Launceston, Unknown }

    public enum Category { academic, technical, admin, casual, uncategorised }

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

        //Convert from byte array to imagesource
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }


    }
}
