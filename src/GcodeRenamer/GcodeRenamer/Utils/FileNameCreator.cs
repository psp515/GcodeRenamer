using GcodeRenamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Utils
{
    public  class FileNameCreator
    {
        public static string CreateFileName(GcodeFile file, FilamentType filamentType, string fileNameFormat)
        {
            string[] order = fileNameFormat.Split("-");

            string newName = "";

            foreach (string item in order)
            {
                switch (item)
                {
                    case "name":
                        newName += "-" + file.Name;
                        break;
                    case "time":
                        newName += "-" + GetTime(file.Seconds);
                        break;
                    case "length":
                        newName += "-" + GetLength(file.Length);
                        break;
                    case "weight":
                        newName += "-" + GetWeight(file.Length, filamentType);
                        break;
                    default:
                        break;
                }
            }

            return newName.Substring(1);
        }
        private static string GetTime(int seconds)
        {
            int hours = 0, minutes = 0;
            switch (Settings.TimeFormat) 
            {
                case 0:
                    hours = seconds/3600;
                    seconds -= hours*3600;
                    minutes = seconds/60;
                    seconds -= minutes*60;
                    return hours.ToString("00") + "h" + minutes.ToString("00") +"m" + seconds.ToString("00")+"s";
                case 1:
                    hours = seconds / 3600 + (seconds%3600< 600 ? 0 : 1);
                    if(hours == 0)
                        hours = 1;
                    return hours.ToString("00");
                case 2:
                    hours = seconds/3600;
                    seconds -= hours*3600;
                    minutes = seconds/60;
                    return hours.ToString("00") +"h" + minutes.ToString("00")+ "m";
                default:
                    hours = seconds/3600;
                    seconds -= hours*3600;
                    minutes = seconds/60;
                    seconds -= minutes*60;
                    return hours.ToString("00") + "h" + minutes.ToString("00") + "m" + seconds.ToString("00")+"s";
            }
        }

        private static string GetLength(double length)
        {
            switch (Settings.TimeFormat)
            {
                case 0:
                    return Math.Round(length,2).ToString()+"m";
                case 1:
                    return Math.Round(length, 1).ToString()+"m";
                case 2:
                    return Math.Floor(length).ToString()+"m";
                default:
                    return Math.Round(length, 2).ToString()+"m";
            }
        }

        private static string GetWeight(double length, FilamentType filamentType)
        {

            int index = Settings.Radius;
            string strDiam = Helpers.Radius[index].Data.Replace('.',',');
            double x = Convert.ToDouble(strDiam);
            double diameter = Convert.ToDouble(x);
            double radius = diameter/20;
            int grams = (int)(filamentType.Density*length*100*Math.PI*radius*radius);
            switch (Settings.TimeFormat)
            {
                case 0:
                    return Math.Round((double)(grams/1000), 2).ToString() + "kg";
                case 1:
                    return grams.ToString() + "g";
                default:
                    return grams.ToString() + "g";
            }
        }
    }
}
