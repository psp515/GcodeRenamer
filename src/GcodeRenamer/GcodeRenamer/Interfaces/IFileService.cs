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
        Task<bool> SaveFile(string new_name, GcodeFile gcodeFile);
        Task<string[]> GetGcodeFile(GcodeFile gcodeFile);
        Task<List<GcodeFile>> GetGcodeFiles(string directoryPath);
    }
}
