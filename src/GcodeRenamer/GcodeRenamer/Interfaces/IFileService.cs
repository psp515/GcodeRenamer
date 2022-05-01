using GcodeRenamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Renames file with changed name.
        /// </summary>
        /// <param name="new_name"></param>
        /// <param name="gcodeFile"></param>
        /// <returns></returns>
        Task<bool> SaveFileWithNewName(string new_name, GcodeFile gcodeFile);

        /// <summary>
        /// Returns GcodeFiles From Directory
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        Task<List<GcodeFile>> GetGcodeFilesFromDirectory(string directoryPath);
    }
}
