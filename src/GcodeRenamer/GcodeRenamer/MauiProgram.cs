using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;
using GcodeRenamer.Services;

namespace GcodeRenamer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureEssentials()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if WINDOWS
        builder.Services.AddTransient<IFolderPicker, Platforms.Windows.Implementations.MyFolderPicker>();
        builder.Services.AddTransient<IFileService, Platforms.Windows.Implementations.FileService>();
#endif

		//TODO Zmiana na builder
		DependencyService.Register<IService<DirectoryPath>, RouteService>();


		return builder.Build();
	}
}
