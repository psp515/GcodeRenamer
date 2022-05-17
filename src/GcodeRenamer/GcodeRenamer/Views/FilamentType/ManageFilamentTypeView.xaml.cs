namespace GcodeRenamer.Views.FilamentType;

public partial class ManageFilamentTypeView : ContentPage
{
    private ManageFilamentTypeViewModel ViewModel => BindingContext as ManageFilamentTypeViewModel;
    public ManageFilamentTypeView(ManageFilamentTypeViewModel vm)
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