using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GcodeFile
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string DirectoryPath { get; set; }

        public double Length { get; set; }
        public int Seconds { get; set; }

        public string[] FilamentPrdeictions { get; set; }
        public int BedTemperature { get; set; }
        public int FilamentTemperature { get; set; }
    }
}
