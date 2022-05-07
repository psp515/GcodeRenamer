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
        public List<PickerData<string>> RadiusFormats { get; set; }


        int selectedFileForamat, theme, selectedTimeFormat, selectedWeightFormat, selectedLengthFormat, selectedRadiusFormat;
        public int SelectedFileForamatIndex { get => selectedFileForamat; set => SetProperty(ref selectedFileForamat, value, "", UpdateSettings); }
        public int SelcetedThemeIndex { get => theme; set => SetProperty(ref theme, value, "", UpdateSettings); }
        public int SelectedTimeFormatIndex { get => selectedTimeFormat; set => SetProperty(ref selectedTimeFormat, value, "", UpdateSettings); }
        public int SelectedWeightFormatIndex { get => selectedWeightFormat; set => SetProperty(ref selectedWeightFormat, value, "", UpdateSettings); }
        public int SelectedLengthFormatIndex { get => selectedLengthFormat; set => SetProperty(ref selectedLengthFormat, value, "", UpdateSettings); }
        public int SelectedRadiusFormat { get => selectedRadiusFormat; set => SetProperty(ref selectedRadiusFormat, value, "", UpdateSettings); }


        PickerData<FilamentType> selectedFilament;
        public PickerData<FilamentType> SelectedFilament { get => selectedFilament; set => SetProperty(ref selectedFilament, value, "", UpdateSettings); }

        public Command UpdateSettingsCommand { get; }

        public SettingsViewModel()
        {
            Themes = Helpers.Themes;
            Filaments = Helpers.Filaments;
            FileFormats = Helpers.FileForamts;
            TimeFormats = Helpers.TimeFormats;
            WeightFormats = Helpers.WeightFormats;
            LengthFormats = Helpers.LengthFormats;
            RadiusFormats = Helpers.Radius;

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

        private async void UpdateSettings()
        {
            IsBusy = true;

            Settings.Filament = SelectedFilament.Index;
            Settings.Theme = SelcetedThemeIndex;
            Settings.FileForamat = SelectedFileForamatIndex;

            Settings.TimeFormat = SelectedTimeFormatIndex;
            Settings.WeightFormat = SelectedWeightFormatIndex;
            Settings.LengthFormat = SelectedLengthFormatIndex;
            Settings.Radius = SelectedRadiusFormat;

            Theme.SetTheme();

            IsBusy = false;
        }
    }
}
