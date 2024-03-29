using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ITP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tools : ContentPage
    {
        public Tools()
        {
            InitializeComponent();
        }

        private async void GoToItemsPage_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ItemsPage"); // Navigate to the ItemsPage
        }
    }
}

