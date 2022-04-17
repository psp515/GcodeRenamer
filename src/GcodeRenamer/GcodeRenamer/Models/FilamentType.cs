using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Models
{
    public class FilamentType
    {
        public FilamentType(string type, double density)
        {
            this.Type = type;
            this.Density = density;
        }

        public string Type { get; set; }
        public double Density { get; set; }
    }
}
