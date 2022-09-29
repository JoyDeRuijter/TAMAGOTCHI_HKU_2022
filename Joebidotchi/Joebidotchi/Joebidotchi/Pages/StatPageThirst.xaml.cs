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
    public partial class StatPageThirst : ContentPage, IStatPage
    {
        private Timer timer;
        private Joe joe = DependencyService.Get<Joe>();
        private Stat stat;

        public StatPageThirst()
        {
            InitializeComponent();

            timer = new Timer();
            SetTimer(timer, 1000);
            stat = joe.stats[1];
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
                Icon_Thirst.Source = joe.stats[1].currentIconSrc;
                UpdateBiden();
                //HardcodedIconUpdate();
                //UpdateBiden();
                //IncreaseNumberOfDays(1);
                //viewModel.OnPropertyChanged(nameof(viewModel.DisplayNumOfDays));
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
            Page statPageBoredom = new StatPageBoredom();
            NavigationPage.SetHasBackButton(statPageBoredom, false);
            Navigation.PushAsync(statPageBoredom);
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            stat.Decrease(0.1f);
        }
    }
}