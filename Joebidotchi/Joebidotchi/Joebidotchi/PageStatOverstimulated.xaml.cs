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
    public partial class PageStatOverstimulated : ContentPage
    {
        public PageStatOverstimulated()
        {
            InitializeComponent();
        }

        private void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page sleepPage = new PageStatTired();
            NavigationPage.SetHasBackButton(sleepPage, false);
            Navigation.PushAsync(sleepPage);
        }

        private void OnLeaveClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You left Joe to have alone time!");
            // add points to overstimulated stat
        }
    }
}