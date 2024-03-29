using ITP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ITP.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string eventName;
        private string eventDate;
        private string eventValue;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(eventName)
                && !String.IsNullOrWhiteSpace(eventDate)
                && !String.IsNullOrWhiteSpace(eventValue);
        }


        public string EventName
        {
            get => eventName;
            set => SetProperty(ref eventName, value);
        }

        public string EventDate
        {
            get => eventDate;
            set => SetProperty(ref eventDate, value);
        }

        public string EventValue
        {
            get => eventValue;
            set => SetProperty(ref eventValue, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                EventName = EventName,
                EventDate = EventDate,
                EventValue = EventValue
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
