using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppLauncher
{
    public class Param
    {
        private string userName;
        private string password;
        private string appPath;

        public Param(
             string userName,
             string password,
             string appPath    
            )
        {
            this.userName = userName;
            this.password = password;
            this.appPath = appPath;
        }

        internal string UserName
        {
            get
            {
                return userName;
            }
        }

        internal string Password
        {
            get
            {
                return password;
            }
        }

        internal string ApplicationPath
        {
            get
            {
                return appPath;
            }
        }
    }
}
