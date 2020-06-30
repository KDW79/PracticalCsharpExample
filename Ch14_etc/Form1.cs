using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Ch14_etc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RunNotePad()
        {
            label1.Text = "대기";
            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables(path);
            var process = Process.Start(fullpath);
            process.EnableRaisingEvents = true;
            process.Exited += (sender, eventArgs) =>
            {
                this.Invoke((Action)delegate
                {
                    label1.Text = "종료";
                });
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunNotePad();
        }
    }
}
