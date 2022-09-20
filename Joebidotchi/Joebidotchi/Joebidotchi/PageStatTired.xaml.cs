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
    public partial class PageStatTired : ContentPage
    {
        public PageStatTired()
        {
            InitializeComponent();
        }

        private void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnSleepClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You made Joe sleep!");
            // add points to tired stat
        }
    }
}