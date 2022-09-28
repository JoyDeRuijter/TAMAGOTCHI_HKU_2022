using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Timer = System.Timers.Timer;
using Xamarin.Essentials;

namespace Joebidotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private int numOfDays;
        private Timer secTimer;
        private DateTime date;

        Joe joe = DependencyService.Get<Joe>();

        public string NumOfDaysProperty
        {
            get { return NumOfDaysProperty; }
            set { OnPropertyChanged(nameof(NumOfDaysProperty));}
        }

        //private FileImageSource.FileProperty statImageSrc = "Icon_Hunger_Red";
        //public FileImageSource StatImageSrc 
        //{
        //    get { return statImageSrc; }
        //    set 
        //    {
        //        statImageSrc = value;
        //        OnPropertyChanged(nameof(StatImageSrc));
        //    }
        //}

        public string StatImageSrc
        {

            get { return StatImageSrc; }
            set { OnPropertyChanged(nameof(StatImageSrc));}
        }

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();

            secTimer = new Timer();
            SetTimer(secTimer, 10000.0);
            SetDate();
        }

        private void SetTimer(Timer _timer, double _interval)
        {
            _timer.Enabled = true;
            _timer.Interval = _interval;
            _timer.AutoReset = true;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void SetDate()
        {
            int lastNumOfDays = Preferences.Get("NumOfDays", 1);
            DateTime lastDate = Preferences.Get("Date", DateTime.Today);
            date = DateTime.Today;
            if (lastDate != date)
            {
                int dayDifference = (date - lastDate).Days;
                numOfDays = lastNumOfDays + dayDifference;
            }
            Preferences.Set("NumOfDays", numOfDays);
            Preferences.Set("Date", date);
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page eatPage = new PageStatEat();
            NavigationPage.SetHasBackButton(eatPage, false);
            Navigation.PushAsync(eatPage);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            //Console.WriteLine("Timer elapsed!");
            Console.WriteLine(joe.stats["Hunger"].statValue);

            Device.BeginInvokeOnMainThread(() =>
            {
                // Everything here will be executed on the main thread
                NumOfDaysProperty = (int.Parse(NumOfDaysProperty) + 1).ToString();

                foreach (Stat stat in joe.stats.Values)
                {
                    stat.Decrease(0.01f);
                }
            });
        }


    }
}