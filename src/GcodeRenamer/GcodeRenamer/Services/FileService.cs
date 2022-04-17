using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GcodeRenamer.Services
{
    /// <summary>
    /// Class to handle implementation of IFileService for all devices.
    /// </summary>
    public class FileService
    {
        private readonly IFileService fileService;

        public FileService(IFileService fileService)
        {
            this.fileService = fileService;
        }


        /// <summary>
        /// Returns Gcode files from multiple directory.
        /// </summary>
        /// <param name="directoryPaths"></param>
        /// <returns></returns>
        public async Task<List<GcodeFile>> GetGcodeFilesData(IEnumerable<DirectoryPath> directoryPaths)
        {
            List<GcodeFile> Files = new List<GcodeFile>();

            foreach (DirectoryPath directoryPath in directoryPaths)
                    Files.AddRange(await GetGcodeFilesData(directoryPath.Path));

            return Files;
        }
        /// <summary>
        /// Returns Gcode files from single directory.
        /// </summary>
        /// <param name="directoryPaths"></param>
        /// <returns></returns>
        public async Task<List<GcodeFile>> GetGcodeFilesData(string directoryPaths) => await fileService.GetGcodeFilesFromDirectory(directoryPaths);


        /// <summary>
        /// Function reads all file line by line and returns it.
        /// </summary>
        /// <param name="gcodeFile"></param>
        /// <returns></returns>
        public async Task<string[]> ReadGcodeFile(GcodeFile gcodeFile) => await fileService.ReadGcodeFile(gcodeFile);


        /// <summary>
        /// Function saves the same file with new name.
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="gcodeFile"></param>
        /// <returns></returns>
        public async Task<bool> SaveGcodeFile(string newName, GcodeFile gcodeFile) => await fileService.SaveFileWithNewName(newName, gcodeFile);

    }
}
