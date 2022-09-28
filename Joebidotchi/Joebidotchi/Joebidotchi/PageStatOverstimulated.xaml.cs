using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joebidotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageStatOverstimulated : ContentPage, IStatPage
    {
        public PageStatOverstimulated()
        {
            InitializeComponent();
        }

        public void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page sleepPage = new PageStatTired();
            NavigationPage.SetHasBackButton(sleepPage, false);
            Navigation.PushAsync(sleepPage);
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You left Joe to have alone time!");
            // add points to overstimulated stat
        }
    }
}