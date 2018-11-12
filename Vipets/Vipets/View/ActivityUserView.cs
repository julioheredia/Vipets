using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Vipets.Models;
using Vipets.Util;
using Xamarin.Forms;
using static Vipets.Util.ImageUtil;

namespace Vipets.View
{
    public class ActivityUserView
    {
        public string PetName { get; set; }
        public ImageSource PetImage { get; set; }
        public string ActivityDescription { get; set; }

        public ActivityUserView(PetActivity petActivity)
        {
            this.PetName = petActivity.Pet.Name;
            var webImage = new Image { Source = ImageSource.FromUri(new Uri(GetUrlPetImage(petActivity.Pet.ImageName))) };
            this.PetImage = webImage.Source;
            this.ActivityDescription = GetActivityDesc(petActivity.Activity.Description, petActivity.User.Name, petActivity.ClientScheduledTime);
        }

        private string GetUrlPetImage(string imageName)
        {
            StringBuilder petimage = new StringBuilder();
            petimage.Append(ImageUtil.UrlImages()).Append(imageName);
            return petimage.ToString();
        }

        private string GetActivityDesc(string activityDesc, string employee, DateTime clientScheduledTime)
        {

            Debug.WriteLine("petshopId =" + clientScheduledTime);

            string strClientScheduled = String.Format("{0:HH:mm}", clientScheduledTime);
            StringBuilder ad = new StringBuilder();
            ad.Append(activityDesc).Append(" - ").Append(employee).Append(" - ").Append(strClientScheduled);
            return ad.ToString();
        }
    }

    public class GroupedActivityUser : ObservableCollection<ActivityUserView>
    {
        public string Date { get; set; }
    }
}
