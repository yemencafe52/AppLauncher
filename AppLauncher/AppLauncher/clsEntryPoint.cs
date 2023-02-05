using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLauncher
{
    static class clsEntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ParamReader pr = new ParamReader(Constants.DataPath);

            byte[] data = null;
            if (pr.Read(ref data))
            {
                BytesToParam ptp = new BytesToParam(data);

                Param param = null;
                if (!(ptp.GetParam(ref param)))
                {
                    frmMain fm = new frmMain();
                    fm.ShowDialog();
                    return;
                }

                //if ((new RunAs.RunAs().Run(param.UserName, param.Password, param.ApplicationPath)))
                //{
                //    return;
                //}
            }
            else
            {
                frmMain fm = new frmMain();
                fm.ShowDialog();
                return;
            }

         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLauncher());
        }
    }
}
