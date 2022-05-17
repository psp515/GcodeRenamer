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
    public class FilamentTypesViewModel : BaseViewModel
    {

        public ObservableCollection<FilamentType> FilamentTypes;

        FilamentService FilamentService;

        public Command RefreshCollectionCommand { get; set; }
        public Command AddFilamentTypeCommand { get; set; }
        public Command<FilamentType> DeleteFilamentTypeCommand { get; set; }
        public Command<FilamentType> EditFilamentTypeCommand { get; set; }



        public FilamentTypesViewModel(FilamentService filamentService)
        {
            FilamentTypes = new ObservableCollection<FilamentType>();
            FilamentService = filamentService;

            RefreshCollectionCommand = new Command(RefreshCollection);
            AddFilamentTypeCommand = new Command(AddFilament);
            DeleteFilamentTypeCommand = new Command<FilamentType>(DeleteRoute);
            EditFilamentTypeCommand = new Command<FilamentType>(EditFilament);
        }

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            foreach (FilamentType filament in await FilamentService.GetItemsAsync())
                if (!FilamentTypes.Any(x => x.Id == filament.Id))
                    FilamentTypes.Add(filament);

        }

        public async void RefreshCollection()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Task.Delay(DELAY);

            FilamentTypes.Clear();

            foreach (FilamentType filamentType in await FilamentService.GetItemsAsync())
                FilamentTypes.Add(filamentType);

            IsBusy = false;
        }


        public async void AddFilament()
        {
            if (IsBusy)
                return;

            await Shell.Current.GoToAsync(nameof(ManageFilamentTypeView));

            IsBusy = false;
        }

        public async void EditFilament(FilamentType filamentType)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await Task.Delay(DELAY);

            await Shell.Current.GoToAsync(nameof(ManageFilamentTypeView)+$"?Id={filamentType.Id}");

            IsBusy = false;
        }

        public async void DeleteRoute(FilamentType filamentType)
        {
            if (IsBusy)
                return;

            IsBusy = true;


            if (await GetBoolFromUser("Delete Filament", "Do you want to delete this item?"))
            {
                await Task.Delay(DELAY);
                await FilamentService.DeleteItemAsync(filamentType.Id);

                FilamentTypes.Remove(filamentType);
            }

            IsBusy = false;
        }
    }
}