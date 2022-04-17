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
        public List<FilamentType> Filaments { get; set; }
        public List<string> FileFormats { get; set; }

        int selectedFilamentIndex, selectedFileForamatIndex, themeIndex;
        public int SelectedFileForamatIndex { get => selectedFileForamatIndex; set => SetProperty(ref selectedFileForamatIndex, value); }
        public int SelectedFilamentIndex { get => selectedFilamentIndex; set => SetProperty(ref selectedFilamentIndex, value); }
        public int ThemeIndex { get => themeIndex; set => SetProperty(ref themeIndex,value); }

        public Command UpdateSettingsCommand { get; }


        public SettingsViewModel()
        {
            Filaments = Helpers.Filaments;
            FileFormats = Helpers.FileForamts;

            UpdateSettingsCommand = new Command(UpdateSettings);
        }

        private void UpdateSettings()
        {

        }
    }
}
