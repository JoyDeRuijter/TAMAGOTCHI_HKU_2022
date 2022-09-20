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
    public partial class PageStatEat : ContentPage
    {
        public PageStatEat()
        {
            InitializeComponent();
        }

        private void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page drinkPage = new PageStatDrink();
            NavigationPage.SetHasBackButton(drinkPage, false);
            Navigation.PushAsync(drinkPage);
        }

        private void OnEatClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You made Joe eat!");
            // add points to hunger stat
        }
    }
}