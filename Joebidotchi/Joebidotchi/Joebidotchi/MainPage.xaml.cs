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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRightArrowClicked(object sender, EventArgs e)
        {
            Page eatPage = new PageStatEat();
            NavigationPage.SetHasBackButton(eatPage, false);
            Navigation.PushAsync(eatPage);
        }
    }
}