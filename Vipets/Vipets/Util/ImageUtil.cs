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

        public static byte[] GetImageBytes(StreamImageSource imagesource)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                var stream = imagesource.Stream.Invoke(new System.Threading.CancellationToken()).Result;
                stream.CopyTo(memoryStream);
                stream = null;
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }
    }
}
