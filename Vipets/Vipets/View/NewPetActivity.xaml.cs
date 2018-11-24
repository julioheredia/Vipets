using System;
using System.Collections.Generic;
using System.ComponentModel;
using Vipets.Models;
using Vipets.Services;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPetActivity : ContentPage
    {
        private List<Pet> pets;
        private List<Activity> activitys;
        private List<User> employees;

        public NewPetActivity()
        {
            InitializeComponent();
            LoadLists();
        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            try
            {
                PetActivity pa = new PetActivity();
                pa.clientScheduledTime = getDateTimePickers(clientScDate, clientScTime);
                pa.activityEnd = getDateTimePickers(endDate, endTime);
                pa.activityStart = getDateTimePickers(startDate, startTime);
                pa.activity = (Activity)GetPickerObject(pickerActivitys);
                pa.pet = (Pet)GetPickerObject(pickerPets);
                pa.user = (User)GetPickerObject(pickerEmployees);
                pa.petshop = Singleton<AppProperties>.Instance().GetLoggedUser().PetshopSession;

                var result = await VipetsApiClient.CurrentPetActivitys.CreatePetActivitys(pa);
                if (result.Success)
                {
                    await DisplayAlert("Success", "New activity saved successfully!", "OK");
                }
                else { await DisplayAlert("ERROR", "Error saving data", "OK"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        
        private DateTime getDateTimePickers(DatePicker datePicker, TimePicker timePicker)
        {
            return datePicker.Date + timePicker.Time;
        }

        private object GetPickerObject(Picker picker)
        {
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                return picker.ItemsSource[selectedIndex];
            }
            return null;
        }

        private async void LoadLists()
        {
            long petshopId = Singleton<AppProperties>.Instance().GetLoggedUser().PetshopSession.petshopId;
            var userresult = await VipetsApiClient.CurrentUsers.EmployeesByPetshop(petshopId);
            if (userresult.Success)
                employees = userresult.Data;

            var petresult = await VipetsApiClient.CurrentPets.PetsByPetshop(petshopId);
            if (petresult.Success)
                pets = petresult.Data;

            var activityresult = await VipetsApiClient.CurrentActivitys.Activitys();
            if (activityresult.Success)
                activitys = activityresult.Data;

            pickerEmployees.ItemsSource = employees;
            pickerActivitys.ItemsSource = activitys;
            pickerPets.ItemsSource = pets;
        }

        //private void OnClientScDateSelected(object sender, DateChangedEventArgs args)
        //{
        //    startDate.Date = clientScDate.Date;
        //    endDate.Date = clientScDate.Date;
        //}

        //private void OnclientScTimeChanged(object sender, PropertyChangedEventArgs args)
        //{
        //    startTime.Time = clientScTime.Time.Add(new TimeSpan(-3, 0, 0));
        //    endTime.Time = clientScTime.Time.Add(new TimeSpan(-2, 0, 0));
        //}
    }
}