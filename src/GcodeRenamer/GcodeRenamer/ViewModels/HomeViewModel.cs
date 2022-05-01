using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;
using GcodeRenamer.Services;
using GcodeRenamer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        public ObservableCollection<GcodeFile> SelectedFiles { get; set; }
        public ObservableCollection<GcodeFile> FoundFiles { get; set; }

        public List<PickerData<FilamentType>> Filaments { get; set; }
        PickerData<FilamentType> selectedFilament;
        public PickerData<FilamentType> SelectedFilament { get => selectedFilament; set => SetProperty(ref selectedFilament, value); }

        public List<PickerData<string>> FileFormats { get; set; }

        PickerData<string> selectedFileForamat;
        public PickerData<string> SelectedFileForamat { get => selectedFileForamat; set => SetProperty(ref selectedFileForamat, value); }

        public Command AddRouteCommand { get; }
        public Command FindFilesCommand { get; }
        public Command ConvertFilesCommand { get; }

        public Command RefreshCollectionCommand { get; }

        public Command<GcodeFile> AddToStagingCommand { get; }
        public Command<GcodeFile> RemoveFromStagingCommand { get; }

        private readonly FolderService FolderPicker;
        private readonly FileService FileService;
        private readonly RouteService RouteService;

        public HomeViewModel(FileService fileService, FolderService folderService, RouteService routeService)
        {
            RouteService = routeService;
            FolderPicker = folderService;
            FileService = fileService;

            FoundFiles = new ObservableCollection<GcodeFile>();
            SelectedFiles = new ObservableCollection<GcodeFile>();

            Filaments = Helpers.Filaments;
            FileFormats = Helpers.FileForamts;
            
            FindFilesCommand = new Command(FindFiles);
            ConvertFilesCommand = new Command(ConvertFiles);
            AddRouteCommand = new Command(AddRoute);

            AddToStagingCommand = new Command<GcodeFile>(AddToStaging);
            RemoveFromStagingCommand = new Command<GcodeFile>(RemoveFromStaging);

            RefreshCollectionCommand = new Command(RefreshCollection);
        }




        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            SelectedFilament = Filaments[Settings.Filament];
            SelectedFileForamat = FileFormats[Settings.FileForamat];

            FindFiles();
        }


        private async void RefreshCollection()
        {
            IsBusy = true;

            await Task.Delay(DELAY);

            FoundFiles.Clear();

            FindFiles();
            
            foreach(GcodeFile gcodeFile in SelectedFiles)
            {
                if (FoundFiles.Contains(gcodeFile))
                    FoundFiles.Remove(gcodeFile);
                else
                    SelectedFiles.Remove(gcodeFile);
            }

            IsBusy = false;
        }
        private async void AddToStaging(GcodeFile file)
        {
            IsBusy = true;

            await Task.Delay(DELAY);

            FoundFiles.Remove(file);
            SelectedFiles.Add(file);

            IsBusy = false;
        }
        private async void RemoveFromStaging(GcodeFile file)
        {
            IsBusy = true;

            await Task.Delay(DELAY);

            SelectedFiles.Remove(file);
            FoundFiles.Add(file);

            IsBusy = false;
        }

        private async void AddRoute()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                string path = await Shell.Current.DisplayPromptAsync("New route", "Please pass new directory route", "OK", "Cancel", @"C:\...");
                //TODO Is valid route 
                if(path != null)    
                    await RouteService.AddItemAsync(new DirectoryPath { Path = path });

                IsBusy = false;
            }
        }

        private async void FindFiles() 
        {
            if (!IsBusy)
            {
                IsBusy = true;


                IEnumerable<DirectoryPath> Paths = await RouteService.GetItemsAsync();

                if (Paths.Count() == 0 )
                {
                    IsBusy = false;
                    return;
                }

                foreach (GcodeFile gcodeFile in await FileService.GetGcodeFilesData(Paths))
                {
                    if(!FoundFiles.Any(x=>x.Name==gcodeFile.Name && x.DirectoryPath==gcodeFile.DirectoryPath) && !SelectedFiles.Any(x => x.Name==gcodeFile.Name && x.DirectoryPath==gcodeFile.DirectoryPath))
                        FoundFiles.Add(gcodeFile);
                }
                IsBusy = false;
            }
        }

        private async void ConvertFiles()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                if (SelectedFiles.Count() == 0) 
                {
                    await Shell.Current.DisplayAlert("Files", "There is no files to convert.", "Ok");
                    return;
                }

                foreach (GcodeFile file in new List<GcodeFile>(SelectedFiles))
                {
                    string newName = FileNameCreator.CreateFileName(file, SelectedFilament.Data, SelectedFileForamat.Data);

                    bool isSuccesfull = await FileService.SaveGcodeFile(newName, file);

                    if (!isSuccesfull)
                    {
                        //await Shell.Current.DisplayAlert("Error occured", "Problems with changing " + file.Name + " file.", "Ok");
                    }
                    else
                        SelectedFiles.Remove(file);
                    
                }
                IsBusy = false;
            }
        }
    }
}
