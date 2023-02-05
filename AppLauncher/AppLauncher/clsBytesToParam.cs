using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher
{
    internal class BytesToParam
    {
        private readonly byte[] ar;
        internal BytesToParam(byte[]ar)
        {
            this.ar = new byte[ar.Length];
            Array.Copy(ar, 0, this.ar, 0, ar.Length);
        }

        internal bool GetParam(ref Param param)
        {
            bool res = false;

            try
            {
                string username;
                string password;
                string path;

                int index = 0;
                int len;

                len = BitConverter.ToInt32(ar, index);
                index += 4;

                byte[] temp = new byte[len];
                Array.Copy(ar, index, temp, 0, len);
                index += len;

                username = Encoding.UTF8.GetString(temp);

                len = BitConverter.ToInt32(ar, index);
                index += 4;

                temp = new byte[len];
                Array.Copy(ar, index, temp, 0, len);
                index += len;

                password = Encoding.UTF8.GetString(temp);

                len = BitConverter.ToInt32(ar, index);
                index += 4;

                temp = new byte[len];
                Array.Copy(ar, index, temp, 0, len);
                index += len;

                path = Encoding.UTF8.GetString(temp);

                param = new Param(username, password, path);
                res = true;
            }
            catch { }

            return res;
        }
    }
}
