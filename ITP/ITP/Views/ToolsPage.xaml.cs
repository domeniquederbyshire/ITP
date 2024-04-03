using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ITP.Views.ToolsPage;

namespace ITP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolsPage : ContentPage
    {
        public MainMenuItem[] mainMenuItem;

        public ToolsPage()
        {
            InitializeComponent();
            mainMenuItem = new MainMenuItem[3];
            mainMenuItem[0] = new MainMenuItem
            { Title = "Money calendar"};
            mainMenuItem[1] = new MainMenuItem
            { Title = "Dashboard"};
            mainMenuItem[2] = new MainMenuItem
            { Title = "Spending insights"};
            ListView1.ItemsSource = mainMenuItem;
        }
        
        public class MainMenuItem
        {
            public string Title { get; set; }
        }

        private void ListView1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MainMenuItem item = (MainMenuItem)e.Item;
            if (item.Title == "Money calendar")
            {
                ItemsPage p = new ItemsPage();
                Navigation.PushAsync(p);
            }
            if (item.Title == "Dashboard")
            {
                DashboardPage p = new DashboardPage();
                Navigation.PushAsync(p);
            }
            if (item.Title == "Spending insights")
            {
                SpendingInsightsPage p = new SpendingInsightsPage();
                Navigation.PushAsync(p);
            }
        }
    }
}