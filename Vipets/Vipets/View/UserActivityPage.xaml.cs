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
                        viewUserActivitys.Add(new ActivityUserView(pa.activity.description, pa.user.name, pa.pet.name, pa.clientScheduledTime));
                    }
                    Activty_List.ItemsSource = viewUserActivitys;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
    }
}