using GcodeRenamer.ViewModels;

namespace GcodeRenamer;

public partial class SettingsView : ContentPage
{
	SettingsViewModel ViewModel;
	public SettingsView()
	{
		InitializeComponent();
		BindingContext = ViewModel = new SettingsViewModel();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		ViewModel.OnAppearing();
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		ViewModel.OnDisappearing();
    }
}