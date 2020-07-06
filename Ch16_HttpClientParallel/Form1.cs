using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch16_HttpClientParallel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var tasks = new Task<string>[]
            {
                GetPageAsync(@"https://msdn.microsoft.com/magazine/"),
                GetPageAsync(@"https://google.com/"),
            };
            var results = await Task.WhenAll(tasks);

            textBox1.Text =
                results[0].Substring(0, 300) +
                Environment.NewLine + Environment.NewLine +
                results[1].Substring(0, 300);
        }

        private readonly HttpClient _httpClient = new HttpClient();

        private async Task<string> GetPageAsync(string urlstr)
        {
            var str = await _httpClient.GetStringAsync(urlstr);
            return str;
        }
    
    }
}
