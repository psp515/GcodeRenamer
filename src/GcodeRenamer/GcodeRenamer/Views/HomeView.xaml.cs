using GcodeRenamer.Interfaces;
using GcodeRenamer.Services;
using GcodeRenamer.ViewModels;

namespace GcodeRenamer;

public partial class HomeView : ContentPage
{
    //private HomeViewModel ViewModel => BindingContext as HomeViewModel;
    private HomeViewModel vm;

	public HomeView()
	{
        InitializeComponent();
        BindingContext = vm = new HomeViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.OnAppearing();
    }
}