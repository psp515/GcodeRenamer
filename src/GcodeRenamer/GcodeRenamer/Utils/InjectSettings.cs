
namespace GcodeRenamer.Utils
{
    public class InjectSettings
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
        public static void SetTheme(AppTheme theme)
        {
            switch (theme)
            {
                default:
                case AppTheme.Light:
                    App.Current.UserAppTheme = AppTheme.Light;
                    break;
                case AppTheme.Dark:
                    App.Current.UserAppTheme = AppTheme.Dark;
                    break;
            }
        }

        internal static void SetSettings()
        {
            SetTheme();
        }
    }
}
