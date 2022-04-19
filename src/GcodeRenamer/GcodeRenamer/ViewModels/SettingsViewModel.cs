using GcodeRenamer.Models;
using GcodeRenamer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        int selectedFileForamat, theme, selectedTimeFormat, selectedWeightFormat, selectedLengthFormat;
        public int SelectedFileForamatIndex { get => selectedFileForamat; set => SetProperty(ref selectedFileForamat, value); }
        public int SelcetedThemeIndex { get => theme; set => SetProperty(ref theme,value); }
        public int SelectedTimeFormatIndex { get => selectedTimeFormat; set => SetProperty(ref selectedTimeFormat, value); }
        public int SelectedWeightFormatIndex { get => selectedWeightFormat; set => SetProperty(ref selectedWeightFormat, value); }
        public int SelectedLengthFormatIndex { get => selectedLengthFormat; set => SetProperty(ref selectedLengthFormat, value); }


        PickerData<FilamentType> selectedFilament;
        public PickerData<FilamentType> SelectedFilament { get => selectedFilament; set => SetProperty(ref selectedFilament, value); }

        public Command UpdateSettingsCommand { get; }

        public SettingsViewModel()
        {
            Themes = Helpers.Themes;
            Filaments = Helpers.Filaments;
            FileFormats = Helpers.FileForamts;
            TimeFormats = Helpers.TimeFormats;
            WeightFormats = Helpers.WeightFormats;
            LengthFormats = Helpers.LengthFormats;

            UpdateSettingsCommand = new Command(UpdateSettings);
        }

        protected internal override void OnAppearing()
        {
            base.OnAppearing();

            SelectedFilament = Filaments[Settings.Filament];
            SelcetedThemeIndex = Settings.Theme;
            SelectedFileForamatIndex = Settings.FileForamat;
            SelectedLengthFormatIndex = Settings.LengthFormat;
            SelectedWeightFormatIndex = Settings.WeightFormat;
            SelectedTimeFormatIndex = Settings.TimeFormat;
        }

        protected internal void OnDisappearing()
        {
            UpdateSettings();
        }

        private async void UpdateSettings()
        {
            IsBusy = true;

            //  tu dziwny error
            Settings.Filament = SelectedFilament.Index;
            Settings.Theme = SelcetedThemeIndex;
            Settings.FileForamat = SelectedFileForamatIndex;

            Settings.TimeFormat = SelectedTimeFormatIndex;
            Settings.WeightFormat = SelectedWeightFormatIndex;
            Settings.LengthFormat = SelectedLengthFormatIndex;

            Theme.SetTheme();

            IsBusy = false;
        }
    }
}
