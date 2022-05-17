namespace GcodeRenamer.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public List<PickerData<FilamentType>> Filaments { get; set; }
        public List<PickerData<string>> FileFormats { get; set; }
        public List<PickerData<string>> Themes { get; set; }

        public List<PickerData<string>> TimeFormats { get; set; }
        public List<PickerData<string>> WeightFormats { get; set; }
        public List<PickerData<string>> LengthFormats { get; set; }
        public List<PickerData<string>> RadiusFormats { get; set; }


        int selectedFileForamat, theme, selectedTimeFormat, selectedWeightFormat, selectedLengthFormat, selectedRadiusFormat, selectedFilament;
        public int SelectedFileForamatIndex { get => selectedFileForamat; set => SetProperty(ref selectedFileForamat, value, ""); }
        public int SelcetedThemeIndex { get => theme; set => SetProperty(ref theme, value, ""); }
        public int SelectedTimeFormatIndex { get => selectedTimeFormat; set => SetProperty(ref selectedTimeFormat, value, ""); }
        public int SelectedWeightFormatIndex { get => selectedWeightFormat; set => SetProperty(ref selectedWeightFormat, value, ""); }
        public int SelectedLengthFormatIndex { get => selectedLengthFormat; set => SetProperty(ref selectedLengthFormat, value, ""); }
        public int SelectedRadiusFormat { get => selectedRadiusFormat; set => SetProperty(ref selectedRadiusFormat, value, ""); }

        public int SelectedFilamentIndex { get => selectedFilament; set => SetProperty(ref selectedFilament, value, ""); }

        public Command UpdateSettingsCommand { get; }

        public SettingsViewModel()
        {
            Themes = Helpers.Themes;
            Filaments = Helpers.PickerFilaments;
            FileFormats = Helpers.FileForamts;
            TimeFormats = Helpers.TimeFormats;
            WeightFormats = Helpers.WeightFormats;
            LengthFormats = Helpers.LengthFormats;
            RadiusFormats = Helpers.Radius;

            SelectedFilamentIndex = Settings.Filament;
            SelcetedThemeIndex = Settings.Theme;
            SelectedFileForamatIndex = Settings.FileForamat;
            SelectedLengthFormatIndex = Settings.LengthFormat;
            SelectedWeightFormatIndex = Settings.WeightFormat;
            SelectedTimeFormatIndex = Settings.TimeFormat;

            UpdateSettingsCommand = new Command(UpdateSettings);
        }

        protected internal override void OnAppearing()
        {
            base.OnAppearing();

            SelectedFilamentIndex = Settings.Filament;
            SelcetedThemeIndex = Settings.Theme;
            SelectedFileForamatIndex = Settings.FileForamat;
            SelectedLengthFormatIndex = Settings.LengthFormat;
            SelectedWeightFormatIndex = Settings.WeightFormat;
            SelectedTimeFormatIndex = Settings.TimeFormat;
        }

        private async void UpdateSettings()
        {
            IsBusy = true;

            await Task.Delay(DELAY);
            
            Settings.Filament = SelectedFilamentIndex;
            Settings.Theme = SelcetedThemeIndex;
            Settings.FileForamat = SelectedFileForamatIndex;

            Settings.TimeFormat = SelectedTimeFormatIndex;
            Settings.WeightFormat = SelectedWeightFormatIndex;
            Settings.LengthFormat = SelectedLengthFormatIndex;
            Settings.Radius = SelectedRadiusFormat;
            
            InjectSettings.SetTheme();

            IsBusy = false;
        }
    }
}
