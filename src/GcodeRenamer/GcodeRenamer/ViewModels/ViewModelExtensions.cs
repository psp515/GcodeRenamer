using GcodeRenamer.ViewModels.Others;

namespace GcodeRenamer.ViewModels
{
    public static class ViewModelExtensions
    {
        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HelpViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<RouteManageViewModel>();
            builder.Services.AddSingleton<FilamentTypesViewModel>();
            builder.Services.AddTransient<ManageFilamentTypeViewModel>();

            return builder;
        }
    }
}
