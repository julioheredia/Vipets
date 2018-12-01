using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using Vipets.Models;
using Vipets.Services;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClientPage : ContentPage
    {
        private List<Breed> breeds;
        private bool isCreatePet = false;

        public NewClientPage()
        {
            InitializeComponent();
            VisiblePageComponents(false, false, false);
            LoadLists();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            try
            {
                SaveClient();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void SaveClient()
        {
            var result = await VipetsApiClient.CurrentUsers.SaveClient(GetClient());
            if (!result.Success)
            {
                await DisplayAlert("ERROR", "Error saving data", "OK");
                return;
            }
            else
            {
                await DisplayAlert("Success", "New Pet and/or Client saved successfully!", "OK");
            }
        }

        private User GetClient()
        {
            User client = new User();
            client.email = emailClient.Text;
            client.name = clientName.Text;
            client.surname = clientSurname.Text;
            client.petshops = new List<Petshop>() { Singleton<AppProperties>.Instance().GetLoggedUser().PetshopSession };
            if (isCreatePet)
                client.pets = new List<Pet>() { GetPet() };
            return client;
        }

        private Pet GetPet()
        {
            Pet pet = new Pet();
            pet.name = petName.Text;
            pet.breed = (Breed)ViewUtil.GetPickerObject(pickerBreeds);
            pet.photo = ImageUtil.GetImageBytes((StreamImageSource)petImage.Source);
            pet.lastChangeDate = DateUtil.GetFormatRest(DateTime.Now);
            pet.registrationDate = DateUtil.GetFormatRest(DateTime.Now);
            pet.birthDate = DateUtil.GetFormatDateRest(DateTime.Now);
            return pet;
        }

        private async void HandleClicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported
                || !CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device  does not currently support this funcionality", "OK");
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var selectImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if (selectImageFile == null)
            {
                await DisplayAlert("Error", "Could not get the image, plase try again.", "OK");
                CleanFields();
                return;
            }
            petImage.IsVisible = true;
            petImage.Source = ImageSource.FromStream(() => selectImageFile.GetStream());
        }

        private async void LoadLists()
        {
            var breedresult = await VipetsApiClient.CurrentBreeds.Breeds();
            if (breedresult.Success)
                breeds = breedresult.Data;

            pickerBreeds.ItemsSource = breeds;
        }

        void OnSelectedOption(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                var option = picker.ItemsSource[selectedIndex];
                if (option.Equals("Pet/Client"))
                {
                    VisiblePageComponents(true, true, true);
                }
                else if (option.Equals("Client"))
                {
                    VisiblePageComponents(true, false, true);
                }
            }
        }

        private void VisiblePageComponents(bool saveButtonIsVisible, bool petIsVisible, bool clientIsVisible)
        {
            SaveButton.IsVisible = saveButtonIsVisible;
            PetVisible(petIsVisible);
            ClientVisible(clientIsVisible);
        }

        private void PetVisible(bool isVisible)
        {
            isCreatePet = true;
            petTitle.IsVisible = isVisible;
            petName.IsVisible = isVisible;
            pickerBreeds.IsVisible = isVisible;
            UploadPetImageButton.IsVisible = isVisible;
            petImage.IsVisible = false;
        }

        private void ClientVisible(bool isVisible)
        {
            clientTitle.IsVisible = isVisible;
            clientName.IsVisible = isVisible;
            clientSurname.IsVisible = isVisible;
            emailClient.IsVisible = isVisible;
        }

        private void CleanFields()
        {
            VisiblePageComponents(false, false, false);
            ViewUtil.CleanPicker(picker);
            ViewUtil.CleanPicker(pickerBreeds);
            petName.Text = string.Empty;
            petImage.Source = null;
            clientName.Text = string.Empty;
            clientSurname.Text = string.Empty;
            emailClient.Text = string.Empty;
        }

    }
}