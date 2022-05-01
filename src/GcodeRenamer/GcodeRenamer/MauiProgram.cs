using GcodeRenamer.Services;
using GcodeRenamer.ViewModels;
using GcodeRenamer.Views;

namespace GcodeRenamer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureServices()
			.ConfigureViewModels()
			.ConfigureViews()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		//DependencyInjcetion ToDo bo nie działa jakies dziwne problmey

        return builder.Build();
	}
}
