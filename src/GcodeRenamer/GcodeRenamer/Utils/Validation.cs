using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GcodeRenamer.Utils
{
    public static class Validation
    {

        /// <summary>
        /// Returns true if string is path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsPath(string path) => Regex.IsMatch(path, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");

    }
}
