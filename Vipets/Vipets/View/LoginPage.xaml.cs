using System;
using Vipets.Services;
using Vipets.Models;
using Vipets.Util;
using Vipets.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await VipetsApiClient.CurrentAuthentications.Authentication(email.Text, password.Text);
                if (result.Success)
                {
                    User user = result.Data;
                    DefinePetshopSession(user);
                    var page = new NavigationPage(new ActivityAppPage());
                    await Navigation.PushModalAsync(page);
                }
                else { await DisplayAlert("ERROR", "Invalid email or password", "OK"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void DefinePetshopSession(User user)
        {

            if(user.petshops.Count > 1)
            {
                // Page to client user select the petshop he's going to authentication in the session
            }
            else
            {
                user.PetshopSession = user.petshops[0];
            }

            Singleton<AppProperties>.Instance().SetLoggedUser(user);
        }
    }
}