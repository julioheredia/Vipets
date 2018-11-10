using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Vipets.Util.ImageUtil;

namespace Vipets.View
{
    public class ActivityUserView
    {
        public long petActivityId { get; set; }
        public string activityDesc { get; set; }
        public string userName { get; set; }
        public long petId { get; set; }
        public string petName { get; set; }
        public ImageSource petImage { get; set; }
        public DateTime scheduledTime { get; set; }

        public ActivityUserView(long petActivityId , string activity, long petId, string user, string pet, DateTime clientScheduledTime)
        {
            this.petActivityId = petActivityId;
            this.activityDesc = activity;
            this.userName = user;
            this.petName = pet;
            this.scheduledTime = clientScheduledTime;

            string idstr = petId.ToString();
            string petImageUrl = "http://179.220.227.97:8080/vipets-mypet-server/images/" + ImagePerformerType.Pet + idstr + "." + ImageType.jpeg;

            var webImage = new Image { Source = ImageSource.FromUri(new Uri(petImageUrl)) };

            this.petImage = webImage.Source;
        }
    }
}
