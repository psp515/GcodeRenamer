

namespace GcodeRenamer.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected const int DELAY = 100;

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

        protected async Task<bool> GetBoolFromUser(string title, string message)
        {

            bool value = await Shell.Current.DisplayAlert(title, message, "Yes", "No");

            if (value == null || value == false)
                return false;
            
            return true;
        }

    }
}
