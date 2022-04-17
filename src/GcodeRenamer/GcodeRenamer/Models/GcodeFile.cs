using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GcodeFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public FileInfo File { get; set; }


        //TODO
        //Filament Prediction zgaduje jaki to moze byc filament uzyty do drukowania jaezeli sei nie zgadza to wypisuje uzytkownikowi ze moze miec zle skonfigurowany plik i wyswietla te dane uzytkownik akceptuje czy jest git czy nie jest git itd
    }
}
