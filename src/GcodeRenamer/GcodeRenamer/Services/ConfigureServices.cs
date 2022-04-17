using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GcodeRenamer.Interfaces;
using GcodeRenamer.ViewModels;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GcodeRenamer.Services
{
    public static class ServicesExtensions
    {
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {

            /* Implementation */
#if WINDOWS
            builder.Services.AddSingleton<IFileService, Platforms.Windows.Implementations.FilePickerWindowsService>();
#endif

            builder.Services.TryAddTransient<FileService>();

            /* DB */
            builder.Services.AddSingleton<RouteService>();

            return builder;
        }
    }
}
