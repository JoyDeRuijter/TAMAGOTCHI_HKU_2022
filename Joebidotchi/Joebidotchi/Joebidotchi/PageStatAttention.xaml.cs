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
    public partial class PageStatAttention : ContentPage, IStatPage
    {
        public PageStatAttention()
        {
            InitializeComponent();
        }

        public void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page overstimPage = new PageStatOverstimulated();
            NavigationPage.SetHasBackButton(overstimPage, false);
            Navigation.PushAsync(overstimPage);
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You gave Joe attention!");
            // add points to attention stat
        }
    }
}