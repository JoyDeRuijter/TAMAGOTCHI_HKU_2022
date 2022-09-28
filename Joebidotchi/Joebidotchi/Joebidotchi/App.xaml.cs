using Joebidotchi.Services;
using Joebidotchi.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joebidotchi
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.RegisterSingleton<Joe>(new Joe());
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#0d0817"),
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            var sleepTime = DateTime.UtcNow;
            Preferences.Set("SleepTime", sleepTime);
        }

        protected override void OnResume()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.UtcNow);
            var timePassed = DateTime.UtcNow - sleepTime;
        }
    }
}
