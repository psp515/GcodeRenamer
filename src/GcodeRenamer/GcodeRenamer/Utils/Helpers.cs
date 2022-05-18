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
        public static List<FilamentType> Filaments = new List<FilamentType>
        {
            new FilamentType("PLA", 1.24, 190, 220)  ,
             new FilamentType("PET-G", 1.23, 230, 250) ,
              new FilamentType("ASA", 1.07, 235, 255) ,
              new FilamentType("ABS", 1.04, 220, 250) ,
        };

        public static List<PickerData<FilamentType>> PickerFilaments = new List<PickerData<FilamentType>> 
        {
            new PickerData<FilamentType> { Index = 0, Data = new FilamentType("PLA", 1.24, 190, 220)  },
            new PickerData<FilamentType> { Index = 1, Data = new FilamentType("PET-G", 1.23, 230, 250) },
            new PickerData<FilamentType> { Index = 2, Data = new FilamentType("ASA", 1.07, 235, 255) },
            new PickerData<FilamentType> { Index = 3, Data = new FilamentType("ABS", 1.04, 220, 250) }, 
        };


        public static List<PickerData<string>> FileForamts = new List<PickerData<string>> 
        {
            new PickerData<string> { Index = 0, Data="name-time-weight" },
            new PickerData<string> { Index = 1, Data="weight-time-name" },
            new PickerData<string> { Index = 2, Data="name-time-length" },
            new PickerData<string> { Index = 2, Data="length-time-name" },
        };


        public static List<PickerData<string>> Themes = new List<PickerData<string>> 
        {
            new PickerData<string> { Index = 0, Data="Device" },
            new PickerData<string> { Index = 1, Data="Light" },
            new PickerData<string> { Index = 2, Data="Dark"  },
        };

        public static List<PickerData<string>> WeightFormats = new List<PickerData<string>>
        {
            new PickerData<string> { Index = 0, Data="x,xx kg" },
            new PickerData<string> { Index = 1, Data="x g" },
        };

        public static List<PickerData<string>> TimeFormats = new List<PickerData<string>>
        {
            new PickerData<string> { Index = 0, Data="hh:mm:ss" },
            new PickerData<string> { Index = 1, Data="hh" },
            new PickerData<string> { Index = 2, Data="hh:mm"  },
        };

        public static List<PickerData<string>> LengthFormats = new List<PickerData<string>>
        {
            new PickerData<string> { Index = 0, Data="x,xx m" },
            new PickerData<string> { Index = 1, Data="x,x m " },
            new PickerData<string> { Index = 2, Data="x m"  },
        };


        public static List<PickerData<string>> Radius = new List<PickerData<string>>
        {
            new PickerData<string> { Index = 0, Data="1.75" },
            new PickerData<string> { Index = 1, Data="2.85" },
        };

    }
}
