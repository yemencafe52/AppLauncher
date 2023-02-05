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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(Param param)
        {
            InitializeComponent();
            this.textBox1.Text = param.UserName;
            this.textBox2.Text = param.Password;
            this.textBox3.Text = param.ApplicationPath;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        return;
                    }
                }
            }

            MessageBox.Show("تعذر تنفيذ العملية");
        }

        private bool Test()
        {
            bool res = false;
            return res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Param param = new Param(textBox1.Text, textBox2.Text, textBox3.Text);
            if (!(new ParamWriter(Constants.DataPath, new ParamToBytes(param)).Write()))
            {
                MessageBox.Show("تعذر تنفيذ العملية");
                return;
            }

            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult r =  ofd.ShowDialog();

            if(r == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;
            }
        }
    }
}
