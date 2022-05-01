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
    public class RouteManageViewModel : BaseViewModel
    {

        public ObservableCollection<DirectoryPath> Paths;

        RouteService RouteService;

        public Command RefreshCollectionCommand { get; set; }
        public Command AddRouteCommand { get; set; }
        public Command DeleteRouteCommand { get; set; }
        public Command EditRouteCommand { get; set; }



        public RouteManageViewModel(RouteService routeService)
        {
            Paths = new ObservableCollection<DirectoryPath>();
            RouteService = routeService;
        }

        protected internal override async void OnAppearing()
        {
            base.OnAppearing();

            foreach (DirectoryPath path in await RouteService.GetItemsAsync())
                if (!Paths.Any(x => x.Id == path.Id))
                    Paths.Add(path);
            
        }

        public async void RefreshCollection()
        {
            IsBusy = true;
            await Task.Delay(DELAY);

            IsBusy = false;
        }
                

    }
}
