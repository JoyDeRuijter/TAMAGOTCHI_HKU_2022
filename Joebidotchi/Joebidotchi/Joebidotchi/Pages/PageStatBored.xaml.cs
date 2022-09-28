using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joebidotchi.Functionality;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joebidotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageStatBored : ContentPage, IStatPage
    {
        public PageStatBored()
        {
            InitializeComponent();
        }

        public void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page attentionPage = new PageStatAttention();
            NavigationPage.SetHasBackButton(attentionPage, false);
            Navigation.PushAsync(attentionPage);
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You made Joe no longer bored!");
            // add points to bored stat
        }
    }
}