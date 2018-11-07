using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vipets.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vipets.View.Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavBar : ContentPage
    {
        public Image btnMenu, btnSearch, btnBack;
        public Label lblTitle;
        public StackLayout stackNav;
        public Frame MenuFrame, SearchFrame, BackFrame, TitleFrame;

        private int _tapCount;

        public NavBar()
        {

            // InitializeComponent();

            btnMenu = new Image
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Source = Constants.menuIcon,
                Aspect = Aspect.AspectFit
            };

            btnBack = new Image
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Source = Constants.backIcon,
                Aspect = Aspect.AspectFit,
                IsVisible = false
            };


            btnSearch = new Image
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Source = Constants.searchIcon,
                Aspect = Aspect.AspectFit
            };

            lblTitle = new Label
            {
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex(Constants.MainTextColor),
                FontSize = 15,
                LineBreakMode = LineBreakMode.TailTruncation,
                FontFamily = Device.RuntimePlatform == Device.iOS ? Constants.DINRegularFont : Constants.DINRegularNameFont + "#" + Constants.DINRegularFont,
            };

            MenuFrame = new Frame
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                HasShadow = false,
            };
            MenuFrame.Content = btnMenu;

            TapGestureRecognizer btnMenuTapGesture = new TapGestureRecognizer();
            btnMenuTapGesture.NumberOfTapsRequired = 1;
            btnMenuTapGesture.Tapped += BtnMenuTapGestureTapped;
            MenuFrame.GestureRecognizers.Add(btnMenuTapGesture);

            BackFrame = new Frame
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                HasShadow = false,
                IsVisible = false
            };
            BackFrame.Content = btnBack;

            TitleFrame = new Frame
            {
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = false,
            };
            TitleFrame.Content = lblTitle;

            SearchFrame = new Frame
            {
                Padding = new Thickness(10, 10, 10, 10),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                HasShadow = false
            };
            SearchFrame.Content = btnSearch;
            TapGestureRecognizer SearchTapped = new TapGestureRecognizer();
            SearchTapped.Tapped += (object sender, EventArgs e) =>
            {
                if (_tapCount < 1)
                {
                    _tapCount = 1;
                    App.RootPage.Detail = new NavigationPage(new SearchPage());
                    _tapCount = 0;
                }
            };
            SearchFrame.GestureRecognizers.Add(SearchTapped);

            stackNav = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.Transparent,
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                Children =
            {
                MenuFrame,BackFrame,TitleFrame,SearchFrame
            }
            };

            if (Device.RuntimePlatform == Device.iOS)
                stackNav.Padding = new Thickness(15, 20, 15, 0);
            else
                stackNav.Padding = new Thickness(15, 0, 15, 0);

            Content = stackNav;
        }

        void BtnMenuTapGestureTapped(object sender, EventArgs e)
        {
            if (_tapCount < 1)
            {
                _tapCount = 1;
                App.RootPage.IsPresented = true;
                _tapCount = 0;
            }
        }
    }

}