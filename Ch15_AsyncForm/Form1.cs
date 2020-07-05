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
using System.Diagnostics;
using System.Net.Http;

namespace Ch15_AsyncForm
{
    public partial class Form1 : Form
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "종료";
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoLongTimeWork();
        }

        private void DoLongTimeWork()
        {
            //Thread t1;
            button1.Hide();
            for (int i = 0; i < 300; i++)
            {
                label1.Text = i.ToString();
                Thread.Sleep(10);
            }
            button1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            _worker.RunWorkerAsync();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            label2.Text = "";
            //Task.Run(() => DoSomething());
            await Task.Run(() => DoSomething());
            label2.Text = "종료";

        }

        private void DoSomething()
        {
            DoLongTimeWork();
            //label2.Invoke((Action)(() =>
            //{
            //    label2.Text = "종료";
            //}));
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            await DoSomeThingAsync();
            label3.Text = "종료";
        }

        private async Task DoSomeThingAsync()
        {
            await Task.Run(() =>
            {
                DoLongTimeWork();
            });
        }

        // ex 16.9
        private async void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            var elasped = await DoSomething4Async(4000);
            label4.Text = $"{elasped}";
        }

        private async Task<long> DoSomething4Async(int milliseconds)
        {
            var sw = Stopwatch.StartNew();
            await Task.Run(() =>
            {
                DoLongTimeWork();
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        // ex 16.10
        private async void button5_Click(object sender, EventArgs e)
        {
            var text = await GetPageAsync(@"http://www.bing.com/");
            textBlock.Text = text;
        }

        private async Task<string> GetPageAsync(string urlstr)
        {
            var str = await _httpClient.GetStringAsync(urlstr);
            return str;
        }

        //
    }
}
