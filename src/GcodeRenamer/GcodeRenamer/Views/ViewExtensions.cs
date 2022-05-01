using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Views
{
    public static class ViewExtensions
    {
        public static MauiAppBuilder ConfigureViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<HelpView>();
            builder.Services.AddSingleton<SettingsView>();
            builder.Services.AddSingleton<RouteManageView>();

            return builder;
        }
    }
}
