using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher
{
    internal static class Constants
    {
        private static string dataPath = System.IO.Directory.GetCurrentDirectory() + "\\data.bin";
        internal static string DataPath
        {
            get
            {
                return dataPath;
            }
        }
    }
}
