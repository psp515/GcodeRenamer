using GcodeRenamer.Models;

namespace GcodeRenamer;

public partial class App : Application
{


    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
        Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
        Routing.RegisterRoute(nameof(RouteManageView), typeof(RouteManageView));
    }
}
