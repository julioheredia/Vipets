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
        private readonly AuthenticationApiClient _authenticationApiClient;

        public LoginPage()
        {
            InitializeComponent();
            _authenticationApiClient = new AuthenticationApiClient();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await _authenticationApiClient.Authentication(email.Text, password.Text);
                if (result.Success)
                {
                    User user = result.Data;
                    Singleton<AppProperties>.Instance().SetLoggedUser(user);

                    var page = new NavigationPage(new ActivityAppPage());
                    await Navigation.PushModalAsync(page);
                }
                else { await DisplayAlert("Title", "Email ou senha invalidados", "ERROR"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}