using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppLauncher
{
    internal class ParamWriter
    {
        private readonly string path;
        private readonly ParamToBytes writer;

        internal ParamWriter(string path, ParamToBytes writer)
        {
            this.path = path;
            this.writer = writer;
        }

        internal bool Write()
        {
            bool res = false;

            try
            {
                File.WriteAllBytes(this.path, new AES().Encrypt( writer.GetBytes(), MD5.CreateMD5(Security.FingerPrint.Value())));
                res = true;
            }
            catch { }

            return res;
        }
    }
}
