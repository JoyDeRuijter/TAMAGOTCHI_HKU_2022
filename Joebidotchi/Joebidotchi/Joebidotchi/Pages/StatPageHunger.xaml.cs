using Joebidotchi.Logic;
using Joebidotchi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joebidotchi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatPageHunger : ContentPage, IStatPage
    {
        public StatPageHunger()
        {
            InitializeComponent();
        }
        private string name;
        public string Name { get => name; set => throw new NotImplementedException(); }
        public Stat Stat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void OnLeftArrowClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnRightArrowClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnStatButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}