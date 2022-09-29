using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using Joebidotchi.Models;
using Joebidotchi.Logic;
using Joebidotchi.Pages;

namespace Joebidotchi
{
    public partial class MainPage : ContentPage
    {
        private Timer timer;
        private MainViewModel viewModel = DependencyService.Get<MainViewModel>();
        private Joe joe = DependencyService.Get<Joe>();
        private ImageSource[] iconImageSources = new ImageSource[6];

        public MainPage()
        {
            InitializeComponent();

            timer = new Timer();
            SetTimer(timer, 1000);

            AddIconImageSources();

            //foreach (Stat stat in joe.stats)
            //    stat.AddStatObserver(UpdateIconSrc);
        }

        private void AddIconImageSources()
        {
            iconImageSources[0] = Icon_Hunger.Source;
            iconImageSources[1] = Icon_Thirst.Source;
            iconImageSources[2] = Icon_Boredom.Source;
            iconImageSources[3] = Icon_Loneliness.Source;
            iconImageSources[4] = Icon_Overstimulated.Source;
            iconImageSources[5] = Icon_Tired.Source;
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
            //Console.WriteLine("Timer elapsed!");
            Console.WriteLine($"Hunger: " + joe.stats[0].Value);
            //Console.WriteLine($"Thirst: " + joe.stats[1].Value);
            //Console.WriteLine($"Boredom: " + joe.stats[2].Value);
            Console.WriteLine(joe.stats[0].currentIconSrc);

            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (Stat stat in joe.stats)
                    stat.Increase();

                HardcodedIconUpdate();
                UpdateBiden();
                IncreaseNumberOfDays(1);
                viewModel.OnPropertyChanged(nameof(viewModel.DisplayNumOfDays));
            });
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page statPageHunger = new StatPageHunger();
            NavigationPage.SetHasBackButton(statPageHunger, false);
            Navigation.PushAsync(statPageHunger);
        }

        private void IncreaseNumberOfDays(int _value)
        {
            joe.numOfDays += _value;
            NumOfDays.Text = NumberOfDaysDisplay();
        }

        //private void UpdateIconSrc(Stat _stat)
        //{
        //    iconImageSources[_stat.index] = _stat.currentIconSrc;
        //}

        private void HardcodedIconUpdate()
        {
            Icon_Hunger.Source = joe.stats[0].currentIconSrc;
            Icon_Thirst.Source = joe.stats[1].currentIconSrc;
            Icon_Boredom.Source = joe.stats[2].currentIconSrc;
            Icon_Loneliness.Source = joe.stats[3].currentIconSrc;
            Icon_Overstimulated.Source = joe.stats[4].currentIconSrc;
            Icon_Tired.Source = joe.stats[5].currentIconSrc;
        }

        public void UpdateBiden()
        {
            joe.CalculateCurrentMood();
            Image_Biden.Source = joe.currentMood;
        }

        

        private string NumberOfDaysDisplay() => $"Day: {joe.numOfDays}";

        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            joe.OnReset();
        }
    }
}
