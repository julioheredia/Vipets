using System;
using System.Collections.Generic;
using Vipets.Services;
using Vipets.Models;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserActivityPage : ContentPage
    {
        private readonly PetActivityApiClient _petActivityApiClient;
        private List<PetActivity> petActivitys;

        private ObservableCollection<GroupedActivityUser> grouped { get; set; }

        public UserActivityPage()
        {
            InitializeComponent();
            _petActivityApiClient = new PetActivityApiClient();
            CallPetActivitys();
        }

        private async void CallPetActivitys()
        {
            User LoggedUser = Singleton<AppProperties>.Instance().GetLoggedUser();
            
            Debug.WriteLine("petshopId ="+LoggedUser.Petshops[0].PetshopId);
            
            var result = await _petActivityApiClient.PetActivitysByPetshop(LoggedUser.Petshops[0].PetshopId);
            if (result.Success)
            {
                petActivitys = result.Data;
                GroupedList();
            }
        }

        private void GroupedList()
        {
            grouped = new ObservableCollection<GroupedActivityUser>();
            List<ActivityUserView> vuaaux = new List<ActivityUserView>();

            DateTime itDt = DateUtil.NullDateTime;
            foreach (PetActivity pa in petActivitys)
            {
                if (itDt == DateUtil.NullDateTime || DateUtil.isSameDate(itDt, pa.ActivityStart))
                {
                    itDt = pa.ActivityStart;
                    vuaaux.Add(new ActivityUserView(pa));
                } else
                {
                    GroupedActivityUser activitGroup = AgroupedActivityUser(vuaaux, itDt);
                    grouped.Add(activitGroup);

                    vuaaux = new List<ActivityUserView>();
                    vuaaux.Add(new ActivityUserView(pa));
                    itDt = pa.ActivityStart;
                }
            }

            GroupedActivityUser activitGroupUltimo = AgroupedActivityUser(vuaaux, itDt);
            grouped.Add(activitGroupUltimo);

            activtyList.ItemsSource = grouped;
        }

        public GroupedActivityUser AgroupedActivityUser(List<ActivityUserView> vuaaux, DateTime itDt)
        {
            string date = String.Format("{0:d}", itDt);
            GroupedActivityUser activitGroup = new GroupedActivityUser() { Date = date };
            foreach (ActivityUserView aux in vuaaux)
            {
                activitGroup.Add(aux);
            }
            return activitGroup;
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ActivityUserView activityView = (ActivityUserView)activtyList.SelectedItem;
            await Navigation.PushAsync(new ActivityDatail());
            activtyList.SelectedItem = null;
        }

    }
}