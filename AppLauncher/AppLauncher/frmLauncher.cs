using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLauncher
{
    public partial class frmLauncher : Form
    {
        public frmLauncher()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = null;
            Param param = null;

            if (new ParamReader(Constants.DataPath).Read(ref data))
            {
                if (new BytesToParam(data).GetParam(ref param))
                {
                    if ((new RunAs.RunAs().Run(param.UserName, param.Password, param.ApplicationPath)))
                    {
                        this.Close();
                        return;
                    }
                }
            }

            MessageBox.Show("تعذر تنفيذ العملية");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = null;
            frmMain fm = null;

            if (new ParamReader(Constants.DataPath).Read(ref data))
            {
                Param param = null;
                if (new BytesToParam(data).GetParam(ref param))
                {
                    fm = new frmMain(param);
                }
            }

            if (fm is null)
            {
                fm = new frmMain();
            }

            fm.ShowDialog();
        }
    }
}
