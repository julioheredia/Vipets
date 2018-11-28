using System;
using Vipets.Services;
using Vipets.Models;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Vipets.View
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
                User user = await GetUser(email.Text, password.Text);
                if (user != null)
                {
                    if (!Singleton<AppProperties>.Instance().isUniquePetshop(user))
                    {
                        /*
                            Later there will be after the client's authentication the option to choose the pertshop
                         */
                    }
                    Singleton<AppProperties>.Instance().SetLoggedUser(user);
                    GoNextPage();
                }
                else { await DisplayAlert("ERROR", "Invalid email or password", "OK"); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private async void GoNextPage()
        {
            var page = new NavigationPage(new ActivityAppPage());
            await Navigation.PushModalAsync(page);
        }

        private async Task<User> GetUser(string e, string p)
        {
            var result = await VipetsApiClient.CurrentAuthentications.Authentication(e, p);
            if (result.Success && result.Data != null)
            {
                return result.Data;
            }
            else return null;
        }

    }
}