using ITP.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ITP.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string eventName;
        private DateTime eventDate; 
        private double eventValue;
        public string EventDateFormatted { get; set; }

        public string Id { get; set; }

        public string EventName
        {
            get => eventName;
            set => SetProperty(ref eventName, value);
        }

        public DateTime EventDate
        {
            get => eventDate;
            set => SetProperty(ref eventDate, value);
        }

        public double EventValue
        {
            get => eventValue;
            set => SetProperty(ref eventValue, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                EventName = item.EventName;
                EventDate = item.EventDate;
                EventValue = item.EventValue;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}