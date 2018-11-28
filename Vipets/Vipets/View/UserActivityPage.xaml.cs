using System;
using System.Collections.Generic;
using Vipets.Services;
using Vipets.Models;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserActivityPage : ContentPage
    {
        private List<PetActivity> petActivitys;
        private ObservableCollection<GroupedActivityUser> grouped { get; set; }
        private bool _isRefreshing = false;

        public UserActivityPage()
        {
            InitializeComponent();
            CallPetActivitys();
        }

        protected void OnRefreshData(object sender, EventArgs e)
        {        
            CallPetActivitys();
            activtyList.EndRefresh();
            IsRefreshing = false;
        }
        
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        private async void CallPetActivitys()
        {
            User LoggedUser = Singleton<AppProperties>.Instance().GetLoggedUser();
            var result = await VipetsApiClient.CurrentPetActivitys.PetActivitysByPetshop(LoggedUser.PetshopSession.petshopId);
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
                if (itDt == DateUtil.NullDateTime || DateUtil.isSameDate(itDt, pa.activityStart))
                {
                    itDt = pa.activityStart;
                    vuaaux.Add(new ActivityUserView(pa));
                }
                else
                {
                    GroupedActivityUser activitGroup = AgroupedActivityUser(vuaaux, itDt);
                    grouped.Add(activitGroup);

                    vuaaux = new List<ActivityUserView>();
                    vuaaux.Add(new ActivityUserView(pa));
                    itDt = pa.activityStart;
                }
            }

            if (itDt != DateUtil.NullDateTime)
            {
                GroupedActivityUser activitGroupUltimo = AgroupedActivityUser(vuaaux, itDt);
                grouped.Add(activitGroupUltimo);
            }

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
            if (activityView != null)
            {
                await Navigation.PushAsync(new ActivityDatail(activityView.PetActivityIt));
                activtyList.SelectedItem = null;
            }
        }

    }
}