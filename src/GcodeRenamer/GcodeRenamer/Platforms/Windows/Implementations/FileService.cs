using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;

namespace GcodeRenamer.Platforms.Windows.Implementations
{
    internal class FileService : IFileService
    {
        public async Task<string[]> GetGcodeFile(GcodeFile gcodeFile)
        {
            string[] text = File.ReadAllLines(gcodeFile.Path);

            return text;
        }

        public async Task<List<GcodeFile>> GetGcodeFiles(string directoryPath)
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

        public async Task<bool> SaveFile(string new_path, GcodeFile gcodeFile)
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
