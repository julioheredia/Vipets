using System;
using Vipets.Services;
using Vipets.Services.Models;
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
                if (result != null)
                {
                    User user = result.Data;
                    Console.WriteLine(" login concluido -- User logged " + user.email);
                    //await DisplayAlert("Title", user.email, "OK");
                    this.Content = new UserActivityPage(user);
                }
                else { await DisplayAlert("Title", "email ou senha invalidados", "ERROR"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

    }
}