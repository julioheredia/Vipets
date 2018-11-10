using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vipets.Services;
using Xamarin.Forms;

namespace Vipets.Util
{
    class ImageUtil
    {
        public enum ImagePerformerType { Pet, User, Breed };
        public enum ImageType { jpeg, png };
        public static string point = ".";


        public static ImageSource ConvertByteArrayToImage(byte[] image)
        {
            ImageSource retSource = null;
            byte[] imageAsBytes = (byte[])image;
            retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            return retSource;
        }
    }
}
