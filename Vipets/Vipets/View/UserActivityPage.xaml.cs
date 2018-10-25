using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vipets.Services;
using Vipets.Services.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserActivityPage : ContentView
    {
        private readonly PetActivityApiClient _petActivityApiClient;

        public UserActivityPage(User user)
        {
            InitializeComponent();
            _petActivityApiClient = new PetActivityApiClient();
            ShowListActivity(user);
        }

        private async void ShowListActivity(User user)
        {
            var result = await _petActivityApiClient.SearchPetActivityByUser(user);
            if (result.Success)
            {
                try
                {
                    List<PetActivity> petActivitys = result.Data;
                    Debug.WriteLine("montar lista");
                    List<ActivityUserView> viewUserActivitys = new List<ActivityUserView>();
                    foreach (PetActivity pa in petActivitys)
                    {
                        viewUserActivitys.Add(new ActivityUserView(pa.activity.description, pa.user.name, pa.pet.name, pa.clientScheduledTime));
                    }
                    Debug.WriteLine("send view");
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