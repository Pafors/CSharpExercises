using Exercise_5_Garage.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_Garage.Extensions
{
    // Was used, but not anymore
    public static class ListExtensions
    {
        public static string CommaSeparated(this List<string> list)
        {
            return string.Join(",", list);
        }
    }
}
