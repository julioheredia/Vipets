using System;
using Vipets.Services;
using Vipets.Services.Models;
using Vipets.Util;
using Vipets.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginApiClient _loginApiClient;

        public LoginPage()
        {
            InitializeComponent();
            _loginApiClient = new LoginApiClient();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await _loginApiClient.Login(email.Text, password.Text);
                if (result.Success)
                {
                    User user = result.Data;
                    Singleton<AppProperties>.Instance().SetLoggedUser(user);

                    App.RootPage = new RootPage();
                    Application.Current.MainPage = new RootPage();
                }
                else { await DisplayAlert("Title", "email ou senha invalidados", "ERROR"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}