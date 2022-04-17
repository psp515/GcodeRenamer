using GcodeRenamer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Services
{
    public class FolderService
    {
        private readonly IFolderService folderService;
        public FolderService(IFolderService folderService)
        {
            this.folderService = folderService; 
        }

        public Task<string> PickFolder() => folderService.PickFolder();
    }
}
