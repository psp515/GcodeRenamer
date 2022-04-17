using GcodeRenamer.ViewModels;

namespace GcodeRenamer;

public partial class SettingsView : ContentPage
{
	SettingsViewModel ViewModel;
	public SettingsView()
	{
		InitializeComponent();
		BindingContext = ViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		ViewModel.OnAppearing();
	}
}