using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;
using GcodeRenamer.Utils;
using System;

namespace GcodeRenamer.Platforms.Windows.Implementations
{
    internal class FileWindowsService : IFileService
    {

        

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
                            if (lines[i].Contains("TIME"))
                            {
                                seconds = int.Parse(lines[i].Split(":")[1]);
                            }

                            if (lines[i].Contains("Filament used") && lines[i].Contains("Filament"))
                            {
                                // tutaj dziwnie bo trzeba zamienic . na ,
                                string strLen = lines[i].Split(":")[1].Replace('m', ' ').Replace('.',',').Trim();
                                length = Convert.ToDouble(strLen);
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
                        Name = fileInfo.Name.Replace(".gcode", ""),
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

        public async Task<bool> SaveFileWithNewName(string newName, GcodeFile gcodeFile)
        {
            try
            {
                string dirName = gcodeFile.DirectoryPath+"\\"+"convertedGcode";
                if (!Directory.Exists(dirName))
                    Directory.CreateDirectory(gcodeFile.DirectoryPath+"\\"+"convertedGcode");

                string newPath = Path.Combine(gcodeFile.DirectoryPath, "convertedGcode", newName) + ".gcode";

                if (File.Exists(newPath))
                    File.Delete(newPath);
                

                using(StreamReader sr = File.OpenText(gcodeFile.FilePath))
                {
                    string lines = sr.ReadToEnd();

                    using (StreamWriter sw = File.CreateText(newPath))
                    {
                        sw.Write(lines);
                    }
                }
            

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
