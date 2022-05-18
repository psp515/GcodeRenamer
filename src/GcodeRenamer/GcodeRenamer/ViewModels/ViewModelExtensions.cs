
using GcodeRenamer.ViewModels.Others;

namespace GcodeRenamer.ViewModels
{
    public static class ViewModelExtensions
    {
        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddSingleton<RouteManageViewModel>();

            return builder;
        }
    }
}
