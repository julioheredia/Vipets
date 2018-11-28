using Vipets.Models;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            User LoggedUser = Singleton<AppProperties>.Instance().GetLoggedUser();
            if (LoggedUser != null)
            {
                UserContinueSession(LoggedUser);
            } else
            {
                GoLoginPage();
            }
        }

        private async void GoLoginPage()
        {
            var page = new LoginPage();
            await Navigation.PushModalAsync(page);
        }

        private async void UserContinueSession(User user)
        {
            var page = new NavigationPage(new ActivityAppPage());
            await Navigation.PushModalAsync(page);
        }

    }
}