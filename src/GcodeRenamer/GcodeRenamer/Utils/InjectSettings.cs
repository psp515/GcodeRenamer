



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
    }
}
