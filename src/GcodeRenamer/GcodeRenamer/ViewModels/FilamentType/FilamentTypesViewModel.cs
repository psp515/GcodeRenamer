using GcodeRenamer.Models;
using GcodeRenamer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.ViewModels
{
    public class FilamentsViewModel : BaseViewModel
    {

        public ObservableCollection<DirectoryPath> FilamentType;

        FilamentService FilamentService;

        public Command RefreshCollectionCommand { get; set; }
        public Command AddFilamentTypeCommand { get; set; }
        public Command<FilamentType> DeleteFilamentTypeCommand { get; set; }
        public Command<FilamentType> EditFilamentTypeCommand { get; set; }



        public FilamentsViewModel(FilamentService filamentService)
        {
            FilamentType = new ObservableCollection<DirectoryPath>();
            FilamentService = filamentService;

            RefreshCollectionCommand = new Command(RefreshCollection);
            AddRouteCommand = new Command(AddRoute);
            DeleteRouteCommand = new Command<DirectoryPath>(DeleteRoute);
            EditRouteCommand = new Command<DirectoryPath>(EditRoute);
        }

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            foreach (DirectoryPath path in await FilamentService.GetItemsAsync())
                if (!Paths.Any(x => x.Id == path.Id))
                    Paths.Add(path);

        }

        public async void RefreshCollection()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Task.Delay(DELAY);

            Paths.Clear();

            foreach (DirectoryPath Route in await FilamentService.GetItemsAsync())
                Paths.Add(Route);

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

            await FilamentService.AddItemAsync();

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


            if (await GetBoolFromUser("Do you want to delete this item?"))
            {
                await Task.Delay(DELAY);
                await RouteService.DeleteItemAsync(directoryPath.Id);
            }

            IsBusy = false;
        }
    }
}