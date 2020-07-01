using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.IO.Compression;
using System.Collections.ObjectModel;

namespace Ch14_etcConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"%SystemRoot%\system32\notepad.exe";
            //var fullpath = Environment.ExpandEnvironmentVariables(path);
            //var startInfo = new ProcessStartInfo
            //{
            //    FileName = fullpath,
            //    Arguments = @"D:\temp\Sample.txt",
            //    WindowStyle = ProcessWindowStyle.Maximized
            //};
            //Process.Start(startInfo);

            //var startInfo5 = new ProcessStartInfo
            //{
            //    FileName = @"C:\Windows\Media\Alarm01.wav",
            //    WindowStyle = ProcessWindowStyle.Normal,
            //    Verb = "Play",
            //};
            //Process.Start(startInfo5);

            //var wc = new WebClient();
            //wc.Encoding = Encoding.UTF8;
            //var html = wc.DownloadString("https://visualstudio.microsoft.com/ko/");
            //Console.WriteLine(html);

            //var wc16 = new WebClient();
            //var url16 = "https://assets.vector.com/cms/content/consulting/events/VectorForum2020/VectorForum_Agenda_2020.pdf";
            //var filename16 = @"D:\VectorForum_Agenda_2020.pdf";
            //wc.DownloadFile(url16, filename16);

            //var wc17 = new WebClient();
            //var url17 = new Uri("https://download.vector.com/servicepacks/vsignalyzer/vSignalyzer17SP5.zip");
            //var filename17 = @"D:\vSignalyzer17SP5.zip";
            //wc17.DownloadProgressChanged += wc_DownloadProgressChanged;
            //wc17.DownloadFileCompleted += wc_DownloadFileCompleted;
            //wc17.DownloadFileCompleted += wc_DownloadFileCanceled;
            //wc17.DownloadFileAsync(url17, filename17);
            //wc17.CancelAsync();

            //Console.ReadLine();

            //var wc18 = new WebClient();
            //using (var stream = wc18.OpenRead(@"http://wikibook.co.kr/list/"))
            //using (var sr = new StreamReader(stream, Encoding.UTF8))
            //{
            //    string html = sr.ReadToEnd();
            //    Console.WriteLine(html);
            //}

            //WeatherRSS();

            //GetWikipediaData();

            var archiveFile = @"D:\example.zip";
            //var destinationFolder = @"D:\";
            //if (Directory.Exists(destinationFolder))
            //{
            //    ZipFile.ExtractToDirectory(archiveFile, destinationFolder);
            //}

            //using (ZipArchive zip = ZipFile.OpenRead(archiveFile))
            //{
            //    var entries = zip.Entries;
            //    foreach (var entry in entries)
            //    {
            //        Console.WriteLine("{0}, {1}", entry.FullName, entry.GetHashCode());
            //    }
            //}

            //using (var zip = ZipFile.OpenRead(archiveFile))
            //{
            //    var entry = zip.Entries.FirstOrDefault(x => x.Name == name);
            //    if (entry != null)
            //    {
            //        var destPath = Path.Combine(@"d:\", entry.FullName);
            //        Directory.CreateDirectory(Path.GetDirectoryName(destPath));
            //        entry.ExtractToFile(destPath, overwrite: true);
            //    }
            //}

            var sourceFolder = @"d:\example";
            var archiveFile24 = @"d:\newArchive.zip";
            ZipFile.CreateFromDirectory(sourceFolder, archiveFile24, CompressionLevel.Fastest, includeBaseDirectory: false);
        }

        static public void GetWikipediaData()
        {
            var keyword = "경복궁";
            var content = GetFromWikipedia(keyword);
            Console.WriteLine(content ?? "찾을 수 없습니다.");
        }

        private static string GetFromWikipedia(string keyword)
        {
            var wc = new WebClient();
            wc.QueryString = new NameValueCollection()
            {
                ["action"] = "query",
                ["prop"] = "revisions",
                ["rvprop"] = "content",
                ["format"] = "xml",
                ["titles"] = WebUtility.UrlEncode(keyword),

            };

            wc.Headers.Add("Content-type", "charset=UTF-8");
            var result = wc.DownloadString("http://ko.wikipedia.org/w/api.php");
            var xmldoc = XDocument.Parse(result);
            var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            return WebUtility.HtmlDecode(rev?.Value);
        }

        static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("{0}% {1}/{2}", e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive);
        }

        static void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("내려받기가 끝났습니다.");
        }

        static void wc_DownloadFileCanceled(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("내려받기가 취소되었습니다.");
        }

        static public void WeatherRSS()
        {
            GetWeatherReportFromWethercast();
        }

        static public void GetWeatherReportFromWethercast()
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-type", "charset=UTF-8");
                var uriString = @"http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=109";
                var url = new Uri(uriString);
                var stream = wc.OpenRead(url);
                XDocument xdoc = XDocument.Load(stream);
                var nodes = xdoc.Root.Descendants("location");

                XElement xprovince = nodes.Elements("province").ElementAt(0);
                Console.WriteLine("[[ " + xprovince.Value + " ]]");

                foreach (var node in nodes)
                {
                    XElement xcity = node.Element("city");
                    Console.WriteLine("<" + xcity.Value + ">");

                    var xdatas = node.Elements("data");
                    foreach (var xweather in xdatas)
                    {
                        XElement xtmEf = xweather.Element("tmEf");
                        XElement xwf = xweather.Element("wf");
                        XElement xtmn = xweather.Element("tmn");
                        XElement xtmx = xweather.Element("tmx");
                        XElement xrnSt = xweather.Element("rnSt");
                        

                        Console.WriteLine("시각: " + xtmEf.Value);
                        Console.WriteLine("날씨: " + xwf.Value);
                        Console.WriteLine("최저기온: " + xtmn.Value);
                        Console.WriteLine("최고기온: " + xtmx.Value);
                        Console.WriteLine("강수확률: " + xrnSt.Value);
                          
                    }
                    Console.WriteLine("");


                }
            }
        }


    }
}
