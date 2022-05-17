namespace GcodeRenamer.ViewModels.Others
{
    public class RouteManageViewModel : BaseViewModel
    {

        public ObservableCollection<DirectoryPath> DirectoriesPaths { get; set; }

        RouteService RouteService;

        public Command RefreshCollectionCommand { get; set; }
        public Command AddRouteCommand { get; set; }
        public Command<DirectoryPath> DeleteRouteCommand { get; set; }
        public Command<DirectoryPath> EditRouteCommand { get; set; }



        public RouteManageViewModel(RouteService routeService)
        {
            DirectoriesPaths = new ObservableCollection<DirectoryPath>();
            RouteService = routeService;

            RefreshCollectionCommand = new Command(RefreshCollection);
            AddRouteCommand = new Command(AddRoute);
            DeleteRouteCommand = new Command<DirectoryPath>(DeleteRoute);
            EditRouteCommand = new Command<DirectoryPath>(EditRoute);
        }

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            foreach (DirectoryPath path in await RouteService.GetItemsAsync())
                if (!DirectoriesPaths.Any(x => x.Id == path.Id))
                    DirectoriesPaths.Add(path);

        }

        public async void RefreshCollection()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Task.Delay(DELAY);

            DirectoriesPaths.Clear();

            foreach (DirectoryPath Route in await RouteService.GetItemsAsync())
                DirectoriesPaths.Add(Route);

            IsBusy = false;
        }


        public async void AddRoute()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Task.Delay(DELAY);

            string path = await Shell.Current.DisplayPromptAsync("New route", "Please pass new directory route", "OK", "Cancel", @"C:\...");
            if (path != null || path == "Cancel")
                return;

            await RouteService.AddItemAsync(new DirectoryPath { Path = path });

            IsBusy = false;
        }

        public async void EditRoute(DirectoryPath directoryPath)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Task.Delay(DELAY);

            string path = await Shell.Current.DisplayPromptAsync("New route", "Please pass new directory route", "OK", "Cancel", @"C:\...");
            if (path != null || path == "Cancel" || path == directoryPath.Path)
                return;

            directoryPath.Path = path;

            await RouteService.UpdateItemAsync(directoryPath);

            IsBusy = false;
        }

        public async void DeleteRoute(DirectoryPath directoryPath)
        {
            if (IsBusy)
                return;

            IsBusy = true;


            if (await GetBoolFromUser("Delete path","Do you want to delete this path?"))
            {
                await Task.Delay(DELAY);
                await RouteService.DeleteItemAsync(directoryPath.Id);
                DirectoriesPaths.Remove(directoryPath);
            }

            IsBusy = false;
        }
    }
}
