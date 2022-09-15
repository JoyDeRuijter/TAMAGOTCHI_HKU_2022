using Joebidotchi.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Joebidotchi.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}