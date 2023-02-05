using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppLauncher
{
    internal class ParamReader
    {
        private readonly string path;
        internal ParamReader(string path)
        {
            this.path = path;
        }

        internal bool Read(ref byte[] data)
        {
            bool res = false;

            try
            {
                data = new AES().Decrypt((File.ReadAllBytes(this.path)), MD5.CreateMD5(Security.FingerPrint.Value()));
                res = true;
            }
            catch { }

            return res;
        }
    }
}
