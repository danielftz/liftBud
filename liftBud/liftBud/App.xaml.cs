using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace liftBud
{
    public partial class App : Application
    {

        public static string dbLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Homepage_dev());
            dbLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
