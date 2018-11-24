using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vipets.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActivityDatail : ContentPage
    {

        private PetActivity PetActivity;

        public ActivityDatail (PetActivity pa)
		{
            InitializeComponent ();
            this.PetActivity = pa;
        }

    }
}