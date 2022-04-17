using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;

namespace GcodeRenamer.Platforms.Windows.Implementations
{
    internal class FilePickerWindowsService : IFileService
    {
        public async Task<string[]> ReadGcodeFile(GcodeFile gcodeFile) =>  File.ReadAllLines(gcodeFile.Path);
        

        public async Task<List<GcodeFile>> GetGcodeFilesFromDirectory(string directoryPath)
        {
            List<GcodeFile> Files = new List<GcodeFile>();

            foreach (string filepath in Directory.GetFiles(directoryPath))
            {
                FileInfo fileInfo = new FileInfo(filepath);

                if (fileInfo.Extension == ".gcode")
                    Files.Add(new GcodeFile() { File = fileInfo, Name = fileInfo.Name, Path = fileInfo.FullName });
            }

            return Files;
        }

        public async Task<bool> SaveFileWithNewName(string new_path, GcodeFile gcodeFile)
        {
            try
            {
                File.Delete(new_path);
                File.Move(gcodeFile.Path, new_path);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
