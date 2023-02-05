using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher
{
    internal class ParamToBytes
    {
        private readonly Param param;
        internal ParamToBytes(Param param)
        {
            this.param = param;
        }

        internal byte[] GetBytes()
        {
            List<byte> res = new List<byte>();

            res.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetBytes(param.UserName).Length));
            res.AddRange((Encoding.UTF8.GetBytes(param.UserName)));

            res.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetBytes(param.Password).Length));
            res.AddRange((Encoding.UTF8.GetBytes(param.Password)));

            res.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetBytes(param.ApplicationPath).Length));
            res.AddRange((Encoding.UTF8.GetBytes(param.ApplicationPath)));

            return res.ToArray();
        }
    }
}
