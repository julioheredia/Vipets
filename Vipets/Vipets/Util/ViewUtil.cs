using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Vipets.Util
{
    public class ViewUtil
    {

        public static string GetUserName(string name, string surname)
        {
            StringBuilder ad = new StringBuilder();
            ad.Append(name).Append(" ").Append(surname);
            return ad.ToString();
        }

        public static ImageSource GeImageSource(string imageName)
        {
            StringBuilder petimage = new StringBuilder();
            petimage.Append(ImageUtil.UrlImages()).Append(imageName);
            var webImage = new Image { Source = ImageSource.FromUri(new Uri(petimage.ToString())) };
            return webImage.Source;
        }

        public static string GetActivityDesc(string activityDesc, DateTime clientScheduledTime)
        {
            string strClientScheduled = String.Format("{0:HH:mm}", clientScheduledTime);
            StringBuilder ad = new StringBuilder();
            ad.Append("Client Scheduled: ").Append(strClientScheduled).Append(" - ").Append(activityDesc);
            return ad.ToString();
        }

        public static object GetPickerObject(Picker picker)
        {
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                return picker.ItemsSource[selectedIndex];
            }
            return null;
        }

        public static void CleanPicker(Picker picker)
        {
            picker.SelectedIndex = -1;
        }

    }
}
