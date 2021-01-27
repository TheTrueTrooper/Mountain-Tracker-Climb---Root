using MTCPhoneApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTCPhoneApp.Views
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