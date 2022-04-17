using GcodeRenamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Utils
{
    public static class Helpers
    {
        public static List<FilamentType> Filaments = new List<FilamentType> {
            new FilamentType { Id = 0, Type = "PLA", Density = 1  },
            new FilamentType { Id = 0, Type = "PET-G", Density = 1 },
            new FilamentType { Id = 0, Type = "ABS", Density = 1  },
            new FilamentType { Id = 0, Type = "ASA", Density = 1  }, };


        public static List<string> FileForamts = new List<string> {
            "name-time-weight",
            "weight-time-name",
            "name-time-length",
            "length-time-name",};
    }
}
