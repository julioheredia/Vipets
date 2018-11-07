using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RootPage : MasterDetailPage
    {
		public RootPage ()
		{
			InitializeComponent ();

            // var page = (Page)Activator.CreateInstance(item.TargetType);
            // page.Title = item.Title;

            Detail = new NavigationPage(new UserActivityPage());
            IsPresented = false;
        }

	}
}