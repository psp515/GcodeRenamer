using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Utils
{
    public class Theme
    {
        public static void SetTheme()
        {
            switch (Settings.Theme)
            {
                default:
                case (int)AppTheme.Light:
                    App.Current.UserAppTheme = AppTheme.Light;
                    break;
                case (int)AppTheme.Dark:
                    App.Current.UserAppTheme = AppTheme.Dark;
                    break;
            }
        }
    }
}
