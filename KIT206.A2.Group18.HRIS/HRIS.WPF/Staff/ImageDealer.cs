using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace HRIS.WPF
{
    //Working with Image and Byte Array: Uploading an Image, Converting an ImageSource to ByteArray and vice versa
    class ImageDealer
    {
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

        //Convert an Image file path to a byte array
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
