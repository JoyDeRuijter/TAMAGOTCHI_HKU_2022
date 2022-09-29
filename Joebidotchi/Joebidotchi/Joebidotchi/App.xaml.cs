using Joebidotchi.Models;
using Xamarin.Forms;
using Joebidotchi.Logic;

namespace Joebidotchi
{
    public partial class App : Application
    {
        private Joe joe;
        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<MainViewModel>(new MainViewModel());
            DependencyService.RegisterSingleton<Joe>(new Joe());

            joe = DependencyService.Get<Joe>();
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("0d0817"),
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
            foreach (Stat stat in joe.stats)
                stat.GetData();

            joe.GetData();
        }

        protected override void OnSleep()
        {
            foreach (Stat stat in joe.stats)
                stat.SaveData();

            joe.SaveData();
        }

        protected override void OnResume()
        {
            foreach (Stat stat in joe.stats)
                stat.GetData();

            joe.GetData();
        }
    }
}
