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
    public partial class StatPageOverstimulated : ContentPage, IStatPage
    {
        private Timer timer;
        private Joe joe = DependencyService.Get<Joe>();
        private Stat stat;

        public StatPageOverstimulated()
        {
            InitializeComponent();

            timer = new Timer();
            SetTimer(timer, 1000);
            stat = joe.stats[4];
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
                Icon_Overstimulated.Source = joe.stats[4].currentIconSrc;
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
            Page statPageTired = new StatPageTired();
            NavigationPage.SetHasBackButton(statPageTired, false);
            Navigation.PushAsync(statPageTired);
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