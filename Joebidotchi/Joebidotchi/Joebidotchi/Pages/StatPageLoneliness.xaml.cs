using Joebidotchi.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joebidotchi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatPageLoneliness : ContentPage, IStatPage
    {
        private Timer timer;
        private Joe joe = DependencyService.Get<Joe>();
        private Stat stat;

        public StatPageLoneliness()
        {
            InitializeComponent();

            timer = new Timer();
            SetTimer(timer, 1000);
            stat = joe.stats[3];
        }

        private void SetTimer(Timer _timer, double _interval)
        {
            _timer.Enabled = true;
            _timer.Interval = _interval;
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        public void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Icon_Loneliness.Source = joe.stats[3].currentIconSrc;
                UpdateBiden();
            });
        }

        public void UpdateBiden()
        {
            joe.CalculateCurrentMood();
            Image_Biden.Source = joe.currentMood;
        }

        public void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page statPageOverstimulated = new StatPageOverstimulated();
            NavigationPage.SetHasBackButton(statPageOverstimulated, false);
            Navigation.PushAsync(statPageOverstimulated);
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            stat.Decrease(0.1f);
            BounceBiden();
        }

        private async void BounceBiden()
        {
            await Image_Biden.ScaleTo(1.15f, 250, Easing.Linear);
            await Image_Biden.ScaleTo(1f, 250, Easing.Linear);
        }
    }
}