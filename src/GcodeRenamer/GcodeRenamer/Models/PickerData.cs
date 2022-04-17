using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Models
{
    public class PickerData<T>
    {
        public int Index { get; set; }
        public T Data { get; set; }
    }
}
