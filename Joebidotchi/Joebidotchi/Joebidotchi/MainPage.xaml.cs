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

namespace Joebidotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        //public string NumOfDaysProperty = "1";
        //public static readonly bindableproperty numofdaysproperty = bindableproperty.create(nameof(numofdays), typeof(string), typeof(mycustomview));
        private string numOfDaysProperty = "1";
        private Timer timer;

        public string NumOfDaysProperty
        {
            get { return numOfDaysProperty; }
            set
            {
                numOfDaysProperty = value;
                OnPropertyChanged(nameof(NumOfDaysProperty));
            }
        }

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            NumOfDaysProperty = "2";

            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000.0;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page eatPage = new PageStatEat();
            NavigationPage.SetHasBackButton(eatPage, false);
            Navigation.PushAsync(eatPage);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs args)
        {
            Console.WriteLine("Timer elapsed!");

            Device.BeginInvokeOnMainThread(() =>
            {
                // Everything here will be executed on the main thread
            });
        }
    }
}