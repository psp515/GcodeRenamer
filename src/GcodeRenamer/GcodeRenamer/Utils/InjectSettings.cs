using AppTheme = GcodeRenamer.Models.AppTheme;

namespace GcodeRenamer.Utils
{
    public class InjectSettings
    {
        public static void SetTheme()
        {
            switch (1)//Settings.Theme)
            {
                default:
                case (int)AppTheme.Light:
                    App.Current.UserAppTheme = (Microsoft.Maui.ApplicationModel.AppTheme)AppTheme.Light;
                    break;
                case (int)AppTheme.Dark:
                    App.Current.UserAppTheme = (Microsoft.Maui.ApplicationModel.AppTheme)AppTheme.Dark;
                    break;
            }
        }
    }
}
