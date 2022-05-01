using GcodeRenamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Utils
{
    public class FileNameCreator
    {
        public string CreateFileName(GcodeFile file, FilamentType filamentType, string fileNameFormat)
        {
            string[] order = fileNameFormat.Split("-");

            string newName = "";

            foreach (string item in order)
            {
                switch (item)
                {
                    case "name":
                        newName += "-" + item;
                        break;
                    case "time":
                        newName += "-" + GetTime(file.Seconds);
                        break;
                    case "weight":
                        newName += "-" + GetLength(file.Length);
                        break;
                    case "length":
                        newName += "-" + GetWeight(file.Length, filamentType);
                        break;
                    default:
                        break;
                }
            }

            return newName.Substring(1);
        }
        private string GetTime(int seconds)
        {
            int hours = 0, minutes = 0;
            switch (Settings.TimeFormat) 
            {
                case 0:
                    hours = seconds/3600;
                    seconds -= hours*3600;
                    minutes = seconds/60;
                    seconds -= minutes*60;
                    return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
                case 1:
                    hours = seconds / 3600 + (seconds%3600< 600 ? 0 : 1);
                    if(hours == 0)
                        hours = 1;
                    return hours.ToString("00");
                case 2:
                    hours = seconds/3600;
                    seconds -= hours*3600;
                    minutes = seconds/60;
                    return hours.ToString("00") + ":" + minutes.ToString("00");
                default:
                    hours = seconds/3600;
                    seconds -= hours*3600;
                    minutes = seconds/60;
                    seconds -= minutes*60;
                    return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }

        private string GetLength(double length)
        {
            switch (Settings.TimeFormat)
            {
                case 0:
                    return Math.Round(length,2).ToString()+" m";
                case 1:
                    return Math.Round(length, 1).ToString()+" m";
                case 2:
                    return Math.Floor(length).ToString()+" m";
                default:
                    return Math.Round(length, 2).ToString()+" m";
            }
        }

        private string GetWeight(double length, FilamentType filamentType)
        {
            double radius = Convert.ToDouble(Helpers.Radius[0])/20;
            int grams = (int)(filamentType.Density*length*100*Math.PI*radius*radius);
            switch (Settings.TimeFormat)
            {
                case 0:
                    return Math.Round((double)(grams/1000), 2).ToString() + "kg";
                case 1:
                    return grams.ToString()+ "g";
                default:
                    return grams.ToString()+ "g";
            }
        }
    }
}
