using GcodeRenamer.ViewModels;

namespace GcodeRenamer;

public partial class RouteManageView : ContentPage
{
	private RouteManageViewModel ViewModel => BindingContext as RouteManageViewModel;
	public RouteManageView(RouteManageViewModel vm)
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