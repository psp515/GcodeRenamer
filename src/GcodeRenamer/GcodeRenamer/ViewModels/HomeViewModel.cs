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

        private readonly IFolderService FolderPicker;
        private readonly FileService FileService;
        private readonly RouteService RouteService;

        public HomeViewModel(RouteService routeService)
        {
            this.RouteService = routeService;

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

            //FolderPicker = folderPicker;
            //FileService = fileService;
        }



        public HomeViewModel()
        {

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

        protected internal override void OnAppearing()
        {
            base.OnAppearing();

            SelectedFilament = Filaments[Settings.Filament];
            SelectedFileForamat = FileFormats[Settings.FileForamat];

            //DirectoryPathService.AddItemAsync(new DirectoryPath { Path = @"C:\Users\psp515\Desktop" });

            SelectedFiles.Add(new GcodeFile { Path = @"C:\path\path", Name="Name" });
            SelectedFiles.Add(new GcodeFile { Path = @"C:\path\path1", Name="Name1" });
            SelectedFiles.Add(new GcodeFile { Path = @"C:\path\path2", Name="Name2" });

            FoundFiles.Add(new GcodeFile { Path = @"C:\path\path3", Name="Name3" });
            FoundFiles.Add(new GcodeFile { Path = @"C:\path\path4", Name="Name4" });
            FoundFiles.Add(new GcodeFile { Path = @"C:\path\path5", Name="Name5" });

            //FindFiles();
        }


        private async void RefreshCollection()
        {
            IsBusy = true;

            await Task.Delay(DELAY);

            FoundFiles.Clear();

            List<GcodeFile> refreshed = new List<GcodeFile>();
            foreach(GcodeFile gcodeFile in refreshed)
                FoundFiles.Add(gcodeFile);
            
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

                string path = await Shell.Current.DisplayPromptAsync("New route", "Please pass new directory route", "OK", "Cancle", @"C:\...");
                //TODO Is valid route 
                if(path != null)    
                    await DirectoryPathService.AddItemAsync(new DirectoryPath { Path = path });
            }
        }

        private async void FindFiles() 
        {
            if (!IsBusy)
            {
                IsBusy = true;

                IEnumerable<DirectoryPath> Paths = await DirectoryPathService.GetItemsAsync();

                if (Paths.Count() == 0)
                {
                    await Shell.Current.DisplayAlert("Routes","There is no directory paths to search for files.", "Ok");
                    return;
                }

                foreach(GcodeFile gcodeFile in await FileService.GetGcodeFilesData(Paths))
                    FoundFiles.Add(gcodeFile);
                
            }
        }

        private async void ConvertFiles()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                if (SelectedFiles.Count() != 0) 
                {
                    await Shell.Current.DisplayAlert("Files", "There is no files to convert.", "Ok");
                    return;
                }

                foreach (GcodeFile file in new List<GcodeFile>(SelectedFiles))
                {
                    //TODO
                    string newName = "";

                    bool isSuccesfull = await FileService.SaveGcodeFile(newName, file);

                    if (!isSuccesfull)
                    {
                        await Shell.Current.DisplayAlert("Error occured", "Problems with changing " + file.Name + " file.", "Ok");
                    }
                    else
                        SelectedFiles.Remove(file);
                    
                }

            }
        }
    }
}
