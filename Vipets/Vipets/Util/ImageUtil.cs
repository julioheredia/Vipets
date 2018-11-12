using System.IO;
using Xamarin.Forms;

namespace Vipets.Util
{
    class ImageUtil
    {
        public enum ImagePerformerType { Pet, User, Breed };
        public enum ImageType { jpeg, png };
        public static string Point = ".";

        public static string UrlImages()
        {
            return Vipets.Resources.Application.restUrl + "/images/";
        }

        public static ImageSource ConvertByteArrayToImage(byte[] image)
        {
            ImageSource retSource = null;
            byte[] imageAsBytes = (byte[])image;
            retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            return retSource;
        }
    }
}
