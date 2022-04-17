using GcodeRenamer.Interfaces;
using GcodeRenamer.ViewModels;

namespace GcodeRenamer;

public partial class HomeView : ContentPage
{
    HomeViewModel ViewModel;
	public HomeView()
	{
        //TODO Zobacz jak to ma dzia³ac z tymi servisami
        InitializeComponent();
        BindingContext = ViewModel = new HomeViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
}