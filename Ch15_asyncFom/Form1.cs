using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Ch15_asyncFom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            var th = new Thread(DoSomething);
            //Cursor = Cursors.WaitCursor;
            //DoLongTimeWork();
            //label1.Text = "종료";
            //Cursor = Cursors.Arrow;
            th.Start();                
        }

        private void DoSomething()
        {
            DoLongTimeWork();
            label1.Invoke((Action)delegate ()
           {
               label1.Text = "종료";
           });
            //throw new NotImplementedException();
        }

        private void DoLongTimeWork()
        {
            //for (int i = 0; i < 100000; i++)
            //{
            //    Console.Write($"{i} ");
            //}
            //Console.Write($"\n");
            //Task.Delay(500000000);
            Thread.Sleep(2000);
        }
    }
}
