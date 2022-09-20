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
    public partial class PageStatDrink : ContentPage
    {
        public PageStatDrink()
        {
            InitializeComponent();
        }

        private void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page boredPage = new PageStatBored();
            NavigationPage.SetHasBackButton(boredPage, false);
            Navigation.PushAsync(boredPage);
        }

        private void OnDrinkClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You made Joe drink!");
            // add points to thirst stat
        }
    }
}