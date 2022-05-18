using GcodeRenamer.Utils;

namespace GcodeRenamer;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        InjectSettings.SetSettings();
    }
}
