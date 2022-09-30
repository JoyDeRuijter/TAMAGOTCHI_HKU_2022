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
using Joebidotchi.Logic;
using Joebidotchi.Pages;
using Xamarin.Essentials;

namespace Joebidotchi
{
    public partial class MainPage : ContentPage
    {
        private Timer timer;
        private DateTime date;
        private Joe joe = DependencyService.Get<Joe>();

        public MainPage()
        {
            InitializeComponent();
            timer = new Timer();
            SetTimer(timer, 1000);
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
                foreach (Stat stat in joe.stats)
                    stat.Increase();

                HardcodedIconUpdate();
                UpdateBiden();
                UpdateDialogue();
                SetDate();
            });
        }

        private void SetDate()
        {
            int lastNumOfDays = Preferences.Get("NumOfDays", 1);
            DateTime lastDate = Preferences.Get("Date", DateTime.Today);
            date = DateTime.Today;
            if (lastDate != date)
            {
                int dayDifference = (date - lastDate).Days;
                joe.numOfDays = lastNumOfDays + dayDifference;
            }
            Preferences.Set("NumOfDays", joe.numOfDays);
            Preferences.Set("Date", date);

            NumOfDays.Text = NumberOfDaysDisplay();
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page statPageHunger = new StatPageHunger();
            NavigationPage.SetHasBackButton(statPageHunger, false);
            Navigation.PushAsync(statPageHunger);
        }

        private void UpdateDialogue()
        {
            TextBubbleText.Text = joe.currentDialogue;
        }

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
