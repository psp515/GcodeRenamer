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
            new FilamentType("PLA", 1.24, 190, 220),
            new FilamentType("PET-G", 1.23, 230, 250),
            new FilamentType("ASA", 1.07, 235, 255),
            new FilamentType("ABS", 1.04, 220, 250),
            new FilamentType("Flex", 1.2, 225, 245),
            new FilamentType("HIPS", 1.04, 230, 245),
            new FilamentType("Nylon", 1.1, 220, 270),
            new FilamentType("Carbon Fiber", 1.3, 200, 230),
            new FilamentType("Polycarbonate", 1.2, 260, 310),
            new FilamentType("Polypropylene", 0.9, 220, 250),
            new FilamentType("PVA", 1.23, 185, 200),
        };

        public static List<PickerData<FilamentType>> PickerFilaments()
        {
            List<PickerData<FilamentType>> items = new List<PickerData<FilamentType>>();

            for (int i = 0; i < Filaments.Count; i++) 
            {
                items.Add(new PickerData<FilamentType> { Index =i, Data = Filaments[i] });
            }

            return items;
        }

        public static List<PickerData<string>> FileForamts = new List<PickerData<string>>
        {
            new PickerData<string> { Index = 0, Data="name-time-weight" },
            new PickerData<string> { Index = 1, Data="name-time-length" },
            new PickerData<string> { Index = 2, Data="weight-time-name" },
            new PickerData<string> { Index = 3, Data="length-time-name" },
            new PickerData<string> { Index = 4, Data="weight-length-time-name" },
            new PickerData<string> { Index = 5, Data="length-time-weight-name" },
            new PickerData<string> { Index = 6, Data="name-length-time-weight" },
            new PickerData<string> { Index = 7, Data="name-time-weight-length" },
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
            new PickerData<string> { Index = 1, Data="hh:mm" },
            new PickerData<string> { Index = 2, Data="hh"  },
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
            new PickerData<string> { Index = 1, Data="3" },
        };

    }
}
