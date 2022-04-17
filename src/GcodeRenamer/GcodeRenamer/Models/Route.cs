using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Models
{
    public class DirectoryPath
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Path { get; set; }   
    }
}
