using GcodeRenamer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.ViewModels
{
    public class HelpViewModel
    {
        public HelpViewModel()
        {

        }

        FileService FileService;

        public HelpViewModel(FileService fileService)
        {
            FileService = fileService;
        }
    }
}
