﻿using System;
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
    }
}