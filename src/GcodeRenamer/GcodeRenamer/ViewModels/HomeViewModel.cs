

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
            SelectedFiles.Clear();

            IsBusy = false;
            IEnumerable<DirectoryPath> Paths = await RouteService.GetItemsAsync();

            foreach (GcodeFile gcodeFile in await FileService.GetGcodeFilesData(Paths))
                FoundFiles.Add(gcodeFile);


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

                if (!Validation.IsPath(path))
                {
                    await Shell.Current.DisplayAlert("Invalid path", "Invalid path.", "OK");

                    IsBusy = false;
                    return;
                }

                if (path != null)
                    await RouteService.AddItemAsync(new DirectoryPath { Path = path });

                IsBusy = false;
            }
        }

        private async void FindFiles()
        {
            if (!IsBusy)
            {
                //TODO Loading Dialog
                await Task.Delay(DELAY);

                IsBusy = true;

                IEnumerable<DirectoryPath> Paths = await RouteService.GetItemsAsync();

                if (Paths.Count() == 0)
                {
                    IsBusy = false;
                    return;
                }

                foreach (GcodeFile gcodeFile in await FileService.GetGcodeFilesData(Paths))
                {
                    if (!FoundFiles.Any(x => x.FileName==gcodeFile.FileName && x.DirectoryPath==gcodeFile.DirectoryPath) && !SelectedFiles.Any(x => x.FileName==gcodeFile.FileName && x.DirectoryPath==gcodeFile.DirectoryPath))
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
                //TODO Loading Dialog

                await Task.Delay(DELAY);

                if (SelectedFiles.Count() == 0)
                {
                    await Shell.Current.DisplayAlert("Files", "There are no files to convert.", "Ok");
                    IsBusy = false;
                    return;
                }

                int counter = 0;
                List<GcodeFile> GcodeFiles = new List<GcodeFile>(SelectedFiles);
                foreach (GcodeFile file in GcodeFiles)
                {
                    string newName = FileNameCreator.CreateFileName(file, SelectedFilament.Data, SelectedFileForamat.Data);
                    bool isSuccesfull = await FileService.SaveGcodeFile(newName, file);
                    if (isSuccesfull)
                    {
                        ++counter;
                        SelectedFiles.Remove(file);
                    }
                }

                if (counter != GcodeFiles.Count)
                    await Shell.Current.DisplayAlert("Some errors occured", $"Some files was not converted ({counter}/{GcodeFiles.Count} succesfull).", "OK");

                IsBusy = false;
            }
        }
    }
}
