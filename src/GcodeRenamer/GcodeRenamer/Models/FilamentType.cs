namespace GcodeRenamer.Models
{
    public class FilamentType
    {
        public FilamentType()
        {
            this.Type = "NULL";
            this.Density = 0;
            this.HighTemperatureRange = 0;
            this.LowTemperatureRange = 0;
        }

        public FilamentType(string type, double density)
        {
            this.Type = type;
            this.Density = density;
            this.HighTemperatureRange = 0;
            this.LowTemperatureRange = 0;
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

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Type { get; set; }
        public double Density { get; set; }

        /*Extruder temperatures*/
        public int LowTemperatureRange { get; set; }
        public int HighTemperatureRange { get; set; }
    }
}
