using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected const int DELAY = 500;

        protected internal virtual void OnAppearing()
        {
            IsBusy = false;
        }


        private bool isBusy;
        protected bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetProperty<T>(ref T backingStore, T value, string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            onChanged?.Invoke();
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }



        protected async Task<bool> GetBoolFromUser(string title)
        {

            IsBusy = true;

            string value = await Shell.Current.DisplayActionSheet(title, "Cancel", "Back", "Yes", "No");

            if (value == null)
            {
                IsBusy = false;
                return false;
            }

            if (value == "Cancel" || value == "Back" || value == "No")
                return false;

            return true;

        }

    }
}
