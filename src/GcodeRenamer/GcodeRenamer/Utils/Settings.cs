using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Utils
{
    public static class Settings
    {
        public static int Theme
        { 
            get => Preferences.Get(nameof(Theme), 0, nameof(Settings)); 
            set => Preferences.Set(nameof(Theme),value, nameof(Settings)); 
        }

        public static int FileForamat
        {
            get => Preferences.Get(nameof(FileForamat), 0, nameof(Settings));
            set => Preferences.Set(nameof(FileForamat), value, nameof(Settings));
        }

        public static int Filament
        {
            get => Preferences.Get(nameof(Filament), 0, nameof(Settings));
            set => Preferences.Set(nameof(Filament), value, nameof(Settings));
        }

        public static int TimeFormat
        {
            get => Preferences.Get(nameof(TimeFormat), 0, nameof(Settings));
            set => Preferences.Set(nameof(TimeFormat), value, nameof(Settings));
        }

        public static int WeightFormat
        {
            get => Preferences.Get(nameof(WeightFormat), 0, nameof(Settings));
            set => Preferences.Set(nameof(WeightFormat), value, nameof(Settings));
        }

        public static int LengthFormat
        {
            get => Preferences.Get(nameof(LengthFormat), 0, nameof(Settings));
            set => Preferences.Set(nameof(LengthFormat), value, nameof(Settings));
        }
    }
}
