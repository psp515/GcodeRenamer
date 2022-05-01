using GcodeRenamer.Interfaces;
using GcodeRenamer.Services;
using GcodeRenamer.ViewModels;

namespace GcodeRenamer;

public partial class HomeView : ContentPage
{
    private HomeViewModel ViewModel => BindingContext as HomeViewModel;

	public HomeView(HomeViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}