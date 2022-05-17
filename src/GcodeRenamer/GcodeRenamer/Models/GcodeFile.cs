namespace GcodeRenamer.Models
{
    public class GcodeFile
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string DirectoryPath { get; set; }

        public double Length { get; set; }
        public int Seconds { get; set; }

        public string[] FilamentPrdeictions { get; set; }
        public int BedTemperature { get; set; }
        public int FilamentTemperature { get; set; }
    }
}
