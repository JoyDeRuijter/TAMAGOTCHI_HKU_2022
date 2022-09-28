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
    public partial class PageStatEat : ContentPage, IStatPage
    {
        public string OtherProperty => "Other";

        public PageStatEat()
        {
            BindingContext = this;

            InitializeComponent();
        }

        public void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page drinkPage = new PageStatDrink();
            NavigationPage.SetHasBackButton(drinkPage, false);
            Navigation.PushAsync(drinkPage);
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You made Joe eat!");
            // add points to hunger stat
        }
    }
}