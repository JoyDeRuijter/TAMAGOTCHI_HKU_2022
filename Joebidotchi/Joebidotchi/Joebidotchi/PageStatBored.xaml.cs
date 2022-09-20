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
    public partial class PageStatBored : ContentPage
    {
        public PageStatBored()
        {
            InitializeComponent();
        }

        private void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page attentionPage = new PageStatAttention();
            NavigationPage.SetHasBackButton(attentionPage, false);
            Navigation.PushAsync(attentionPage);
        }

        private void OnPlayClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You made Joe no longer bored!");
            // add points to bored stat
        }
    }
}