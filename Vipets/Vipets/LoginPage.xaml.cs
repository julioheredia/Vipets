using System;
using Vipets.Services;
using Vipets.Services.Models;
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
                if (email.Text != null && password.Text != null)
                {
                    var result = await _loginApiClient.Login(email.Text, password.Text);
                    Console.WriteLine("retornou");
                    if (result.Success)
                    {
                        User user = result.Data;
                        Console.WriteLine(user.name);

                        await DisplayAlert("Title", user.name + " " + user.surname, "ERROR");

                    }
                    else { await DisplayAlert("Title", "email ou senha invalidados", "ERROR"); }

                }
                else { await DisplayAlert("Title", "email ou senha invalidados", "ERROR"); }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}