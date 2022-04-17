using GcodeRenamer.Interfaces;

namespace GcodeRenamer.Platforms.Windows.Implementations
{
    internal class MyFolderPicker : IFolderPicker
    {
        public async Task<string> PickFolder()
        {

            /*
            var folderPicker = new WindowsFolderPicker();

            // Get the current window's HWND by passing in the Window object
            var hwnd = ((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).WindowHandle;

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            var result = await folderPicker.PickSingleFolderAsync();

            return result.Path;*/
            return null;
        }
    }
}
