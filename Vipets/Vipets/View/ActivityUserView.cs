using System.Collections.ObjectModel;
using Vipets.Models;
using Vipets.Util;
using Xamarin.Forms;

namespace Vipets.View
{
    public class ActivityUserView
    {
        public PetActivity PetActivityIt { get; set; }
        public string PetName { get; set; }
        public ImageSource PetImage { get; set; }
        public string ActivityDescription { get; set; }
        public string ClientName { get; set; }
        public string EmployeedName { get; set; }
        

        public ActivityUserView(PetActivity petActivity)
        {
            this.PetActivityIt = petActivity;
            this.PetName = petActivity.pet.name;
            this.PetImage = ViewUtil.GeImageSource(petActivity.pet.imageName);
            this.ActivityDescription = ViewUtil.GetActivityDesc(petActivity.activity.description, petActivity.clientScheduledTime);
            this.EmployeedName = ViewUtil.GetUserName(petActivity.employed.name, petActivity.employed.surname);
            this.ClientName = ViewUtil.GetUserName(petActivity.clientGetPet.name, petActivity.clientGetPet.surname);
        }
    }

    public class GroupedActivityUser : ObservableCollection<ActivityUserView>
    {
        public string Date { get; set; }
    }
}
