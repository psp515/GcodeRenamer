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

        public FilamentType(string type, double density, int lowTemperatureRange, int highTemperatureRange)
        {
            this.Type = type;
            this.Density = density;
            this.LowTemperatureRange = lowTemperatureRange;
            this.HighTemperatureRange = highTemperatureRange;
        }

        public bool IsInTemperatureRange(int temperature)
        {
            return temperature >= LowTemperatureRange && temperature <= HighTemperatureRange;
        }
        public bool IsInTemperatureRange(GcodeFile file)
        {
            return file.FilamentTemperature >= LowTemperatureRange && file.FilamentTemperature <= HighTemperatureRange;
        }

        public string Type { get; set; }
        public double Density { get; set; }

        /*Extruder temperatures*/
        public int LowTemperatureRange { get; set; }
        public int HighTemperatureRange { get; set; }
    }
}
