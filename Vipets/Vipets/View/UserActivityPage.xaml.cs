using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vipets.Services;
using Vipets.Services.Models;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Vipets.Util.ImageUtil;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserActivityPage : ContentPage
    {
        private readonly PetActivityApiClient _petActivityApiClient;

        public UserActivityPage()
        {
            InitializeComponent();
            _petActivityApiClient = new PetActivityApiClient();
            ShowListActivity();
        }

        private async void ShowListActivity()
        {
            var result = await _petActivityApiClient.SearchPetActivityByUser(Singleton<AppProperties>.Instance().GetLoggedUser());
            if (result.Success)
            {
                try
                {
                    List<PetActivity> petActivitys = result.Data;
                    List<ActivityUserView> viewUserActivitys = new List<ActivityUserView>();
                    foreach (PetActivity pa in petActivitys)
                    {
                        viewUserActivitys.Add(new ActivityUserView(pa.petActivityId,
                            pa.activity.description, pa.pet.petId,
                            pa.user.name, pa.pet.name, pa.clientScheduledTime));
                    }

                    activty_List.ItemsSource = viewUserActivitys;

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Debug.WriteLine("OnItemSelected");
            ListView lv = (ListView)sender;

            ActivityUserView activityView = (ActivityUserView) lv.SelectedItem;

            Debug.WriteLine("activityView" + activityView.petActivityId);
            

            await Navigation.PushAsync(new ActivityDatail());
        }

    }
}