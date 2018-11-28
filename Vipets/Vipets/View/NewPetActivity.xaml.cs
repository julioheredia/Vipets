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
        private List<User> clients;

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
                pa.activity = (Activity) ViewUtil.GetPickerObject(pickerActivitys);
                pa.pet = (Pet)ViewUtil.GetPickerObject(pickerPets);
                pa.employed = (User)ViewUtil.GetPickerObject(pickerEmployees);
                pa.clientGetPet = (User)ViewUtil.GetPickerObject(pickerClients);
                pa.petshop = Singleton<AppProperties>.Instance().GetLoggedUser().PetshopSession;

                var result = await VipetsApiClient.CurrentPetActivitys.CreatePetActivitys(pa);
                if (result.Success)
                {
                    await DisplayAlert("Success", "New activity saved successfully!", "OK");
                    CleanFields();
                }
                else { await DisplayAlert("ERROR", "Error saving data", "OK"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private DateTime getDateTimePickers(DatePicker datePicker, TimePicker timePicker)
        {
            return datePicker.Date + timePicker.Time;
        }

        private async void LoadLists()
        {
            long petshopId = Singleton<AppProperties>.Instance().GetLoggedUser().PetshopSession.petshopId;
            var userresult = await VipetsApiClient.CurrentUsers.EmployeesByPetshop(petshopId);
            if (userresult.Success)
                employees = userresult.Data;

            var clientresult = await VipetsApiClient.CurrentUsers.clientsByPetshop(petshopId);
            if (clientresult.Success)
                clients = clientresult.Data;
            
            var activityresult = await VipetsApiClient.CurrentActivitys.Activitys();
            if (activityresult.Success)
                activitys = activityresult.Data;

            pickerEmployees.ItemsSource = employees;
            pickerClients.ItemsSource = clients;
            pickerActivitys.ItemsSource = activitys;
            
        }

        void OnSelectedClientChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            User client = null;
            if (selectedIndex != -1)
            {
                client = (User)picker.ItemsSource[selectedIndex];
                pets = client.pets;
                pickerPets.ItemsSource = pets;
            }
        }

        private void CleanFields()
        {
            CleanPicker(pickerEmployees);
            CleanPicker(pickerClients);
            CleanPicker(pickerPets);
            CleanPicker(pickerActivitys);
            clientScDate.Date = DateTime.Now;
            startDate.Date = DateTime.Now;
            endDate.Date = DateTime.Now;
            clientScTime.Time = DateTime.Now.TimeOfDay;
            startTime.Time = DateTime.Now.TimeOfDay;
            endTime.Time = DateTime.Now.TimeOfDay;
        }

        private void CleanPicker(Picker picker)
        {
            picker.SelectedIndex = -1;
        }

        private void OnClientScDateSelected(object sender, DateChangedEventArgs args)
        {
            startDate.Date = clientScDate.Date;
            endDate.Date = clientScDate.Date;
        }

        private void OnClientScTimeChanged(object sender, PropertyChangedEventArgs args)
        {
            // startTime.Time = DateUtil.CalculateTime(clientScTime.Time, -2, 0);
            // endTime.Time = DateUtil.CalculateTime(clientScTime.Time, -1, 0);
        }
    }
}