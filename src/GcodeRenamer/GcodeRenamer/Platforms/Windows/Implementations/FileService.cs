using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;
using GcodeRenamer.Utils;
using System;

namespace GcodeRenamer.Platforms.Windows.Implementations
{
    internal class FileWindowsService : IFileService
    {
        public async Task<string[]> ReadGcodeFile(GcodeFile gcodeFile) =>  File.ReadAllLines(gcodeFile.FilePath);
        

        public async Task<List<GcodeFile>> GetGcodeFilesFromDirectory(string directoryPath)
        {
            List<GcodeFile> Files = new List<GcodeFile>();

            foreach (string filepath in Directory.GetFiles(directoryPath))
            {
                FileInfo fileInfo = new FileInfo(filepath);

                if (fileInfo.Extension == ".gcode" && fileInfo.Exists) 
                {
                    double length = -1;
                    int seconds = -1, bedTemperature = -1, filamentTemperature = -1;

                    string[] lines = File.ReadAllLines(filepath);

                    bool isMarlin = lines[0].Contains("Marlin");

                    for(int i = 1; i < 17; i++)
                    {
                        if (isMarlin)
                        {
                            if (lines[i].Contains("Time"))
                            {
                                seconds = int.Parse(lines[i].Split(":")[1]);
                            }

                            if (lines[i].Contains("Filament used") && lines[i].Contains("Filament"))
                            {
                                length = Math.Round(double.Parse(lines[i].Split(":")[1]), 2);
                            }

                            if (lines[i].Contains("M190"))
                            {
                                bedTemperature = int.Parse(lines[i].Substring(6));
                            }

                            if (lines[i].Contains("M109"))
                            {
                                filamentTemperature = int.Parse(lines[i].Substring(6));
                            }

                            continue;
                        }

                        //TODO
                        //For variable printers could be other formats 
                    }

            
                    List<string> predictions = new List<string>();

                    foreach(PickerData<FilamentType> filament in Helpers.Filaments)
                        if (filament.Data.IsInTemperatureRange(filamentTemperature))
                            predictions.Add(filament.Data.Type);
                      
                    

                    Files.Add(new GcodeFile()
                    {
                        Name = fileInfo.Name,
                        FilePath = fileInfo.FullName,
                        DirectoryPath = fileInfo.DirectoryName,

                        FilamentTemperature = filamentTemperature,
                        BedTemperature = bedTemperature,
                        FilamentPrdeictions = predictions.ToArray(),

                        Length = length,
                        Seconds = seconds,
                    });
                }
            }

            return Files;
        }

        public async Task<bool> SaveFileWithNewName(string new_path, GcodeFile gcodeFile)
        {
            try
            {
                File.Move(gcodeFile.FilePath, Path.Combine(gcodeFile.DirectoryPath, new_path));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
