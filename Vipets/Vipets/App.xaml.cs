using Vipets.Models;
using Vipets.Util;
using Vipets.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Vipets
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            User LoggedUser = Singleton<AppProperties>.Instance().GetLoggedUser();
            if (LoggedUser != null)
            {
                MainPage = new NavigationPage(new ActivityAppPage());                
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
