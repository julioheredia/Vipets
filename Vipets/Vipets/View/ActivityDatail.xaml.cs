using System;
using Vipets.Models;
using Vipets.Services;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityDatail : ContentPage
    {
        public PetActivity PetActivityIt { get; set; }

        public ActivityDatail(PetActivity pa)
        {
            InitializeComponent();
            PetActivityIt = pa;
            SetFields();
        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            try
            {
                PetActivityIt.isActivityCompleted = true;
                PetActivityIt.activityCompletedTime = DateUtil.GetFormatRest(DateTime.Now);

                var result = await VipetsApiClient.CurrentPetActivitys.CreatePetActivitys(PetActivityIt);
                if (result.Success)
                {
                    await DisplayAlert("Success", "Activity saved successfully!", "OK");
                }
                else { await DisplayAlert("ERROR", "Error saving data", "OK"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void SetFields()
        {
            employed.Text = ViewUtil.GetUserName(PetActivityIt.employed.name, PetActivityIt.employed.surname);
            client.Text = ViewUtil.GetUserName(PetActivityIt.clientGetPet.name, PetActivityIt.clientGetPet.surname);
            activity.Text = PetActivityIt.activity.description;
            petName.Text = PetActivityIt.pet.name;
            petImage.Source = ViewUtil.GeImageSource(PetActivityIt.pet.imageName);
            clientSc.Text = DateUtil.GetStringToDateTime(PetActivityIt.clientScheduledTime);
            startDate.Text = DateUtil.GetStringToDateTime(PetActivityIt.activityStart);
            endDate.Text = DateUtil.GetStringToDateTime(PetActivityIt.activityEnd);
        }
    }
}