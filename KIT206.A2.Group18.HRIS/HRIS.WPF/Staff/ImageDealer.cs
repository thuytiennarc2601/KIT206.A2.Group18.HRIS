using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;

namespace HRIS.WPF
{
    //Working with Image and Byte Array: Uploading an Image, Converting an ImageSource to ByteArray and vice versa
    class ImageDealer
    {
        public const int MINIMUM_IMAGE_SIZE = 20000;

        //Convert from byte array to imagesource
        #region Convert An Byte Array To Image
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
        #endregion

        //Convert an Image file path to a byte array
        #region Convert An ImageSource to A Byte Array
        public static byte[] BytesFromImage(String imageFile)
        {
            MemoryStream ms = new MemoryStream();
            if (imageFile != "")
            {
                Image img = Image.FromFile(imageFile);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            return ms.ToArray();
        }
        #endregion

        //Upload a photo
        #region Get An Image File Name For Upload Staff Photo
        public static string GetImageFileName()
        {
            string filePath = "";

            Microsoft.Win32.OpenFileDialog newDialog = new Microsoft.Win32.OpenFileDialog();
            newDialog.Filter = "All Image Files | *.*";
            if (newDialog.ShowDialog() == true)
            {
                filePath = newDialog.FileName;
            }

            return filePath;
        }
        #endregion
    }
}
