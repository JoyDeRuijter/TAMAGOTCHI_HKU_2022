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
    public partial class PageStatTired : ContentPage, IStatPage
    {
        public PageStatTired()
        {
            InitializeComponent();
        }

        public void OnRightArrowClicked(object sender, EventArgs e){}

        public void OnLeftArrowClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("You made Joe sleep!");
            // add points to tired stat
        }
    }
}