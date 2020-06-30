using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
namespace Ch9_File
{
    class Program
    {
        static void Main(string[] args)
        {
            //var filePath = @"E:\프로그래밍관련\0.C#\프랙티컬 C#_完\practical-csharp-master\CSharpPhraseBook\Chapter09\Section01\Greeting.txt";
            //if (File.Exists(filePath))
            //{
            //    using (var reader = new StreamReader(filePath, Encoding.UTF8))
            //    {
            //        while (!reader.EndOfStream)
            //        {
            //            var line = reader.ReadLine();
            //            Console.WriteLine(line);
            //        }
            //    }
            //}

            //var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            //foreach (var line in lines)
            //{
            //    Console.WriteLine(line);
            //}

            //var lines = File.ReadLines(filePath, Encoding.UTF8);
            //foreach (var line in lines)
            //{
            //    Console.WriteLine(line);
            //}

            //var lines = File.ReadLines(filePath, Encoding.UTF8)
            //                .Take(10)
            //                .ToArray();
            //foreach (var line in lines)
            //    Console.WriteLine(line);

            //var count = File.ReadLines(filePath, Encoding.UTF8)
            //                .Count(s => s.Contains("Windows"));
            //Console.WriteLine(count);

            //var lines = File.ReadLines(filePath, Encoding.UTF8)
            //                .Where(s => !String.IsNullOrEmpty(s))
            //                .Any(s => s.All(c => Char.IsDigit(c)));
            //Console.WriteLine(lines);

            //var exists = File.ReadLines(filePath, Encoding.UTF8)
            //    .Distinct()
            //    .OrderBy(s => s.Length)
            //    .ToArray();
            //foreach (var exist in exists)
            //    Console.WriteLine(exist);

            //var lines2 = File.ReadLines(filePath)
            //    .Select((s, ix) => String.Format("{0,4}: {1}", ix + 1, s))
            //    .ToArray();
            //foreach (var line in lines2)
            //{
            //    Console.WriteLine(line);
            //}

            //var filePath = @"D:\고향의봄.txt";
            //using (var writer = new StreamWriter(filePath))
            //{
            //    writer.WriteLine("나의 살던 고향은");
            //    writer.WriteLine("꽃피는 산골");
            //    writer.WriteLine("복숭아꽃 살구꽃");
            //    writer.WriteLine("아기 진달래");

            //}

            //var lines = new[] { "====", "울긋 불긋 꽃대궐", "차리인 동네" };
            //using (var writer = new StreamWriter(filePath, append: true))
            //{
            //    foreach (var line in lines)
            //        writer.WriteLine(line);
            //}

            //var lines2 = new[] { "Seoul", "New Delhi", "Bangkok", "London", "Paris", };
            //var filePath2 = @"D:\Cities.txt";
            //File.WriteAllLines(filePath2, lines2);

            //var names = new List<string> { "Seoul", "New Delhi", "London", "Paris", "berlin", "Canberra", "Hong Kong", };
            //var filePath3 = @"D:\Cities2.txt";
            //File.WriteAllLines(filePath3, names.Where(s => s.Length > 5));

            //var filePath4 = @"D:\Greeting.txt";
            //using (var stream = new FileStream(filePath4, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            //{
            //    using (var reader = new StreamReader(stream))
            //    using (var writer = new StreamWriter(stream))
            //    {
            //        string texts = reader.ReadToEnd();
            //        stream.Position = 0;
            //        writer.WriteLine("삽입할 새 행1");
            //        writer.WriteLine("삽입할 새 행2");
            //        writer.Write(texts);
            //    }
            //}

            //var euckr = Encoding.GetEncoding("euc-kr");
            //using (var writer = new StreamWriter(filePath4, append: false, encoding: euckr))
            //{
            //    writer.WriteLine("동해물과 백두산이");
            //}

            //if(File.Exists(filePath4))
            //{
            //    Console.WriteLine("이미 존재합니다.");
            //}

            //var fi = new FileInfo(filePath4);
            //if (fi.Exists)
            //    Console.WriteLine("이미 존재합니다.");

            //File.Delete(filePath4);

            //fi.Delete();

            //try
            //{
            //    File.Copy(@"D:\source.txt", @"D:\target.txt");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("{0}", ex.Message);
            //    //throw ex;
            //}

            //try
            //{
            //    throw new Exception("예외 던진다.");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //try
            //{
            //    File.Move(@"D:\target.txt", @"D:\Example\target.txt");
            //    Console.WriteLine("이동완료");
            //}
            //catch (DirectoryNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //var fi = new FileInfo(@"D:\Example\oldfile.txt");
            //try
            //{
            //    fi.MoveTo(@"D:\Example\src\newfile.txt");
            //}
            //catch (DirectoryNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //var lastWriteTime = File.GetLastWriteTime(@"D:\Example\Greeting.txt");
            //Console.WriteLine(lastWriteTime);
            //File.SetLastWriteTime(@"D:\Example\Greeting.txt", DateTime.Now);
            //var lastWriteTime2 = File.GetLastWriteTime(@"D:\Example\Greeting.txt");
            //Console.WriteLine(lastWriteTime2);

            //var fi = new FileInfo(@"D:\Example\Greeting.txt");
            //long size = fi.Length;
            //Console.WriteLine(size + " Bytes");

            //var myFIle = File.ReadAllLines(@"D:\Example\TA_060401_TCU_KAPPA_F0.xes");
            //var source = "";
            //foreach (var n in myFIle)
            //{
            //    source += n;
            //}

            //using (MD5 md5Hash = MD5.Create())
            //{
            //    string hash = GetMd5Hash(md5Hash, source);
            //    Console.WriteLine("TA_060401_TCU_KAPPA_F0   Hash : {0}", hash);
            //}

            //var myFIle1 = File.ReadAllLines(@"D:\Example\TA_060401_TCU_KAPPA_F0_1.xes");
            //var source1 = "";
            //foreach (var n in myFIle1)
            //{
            //    source1 += n;
            //}

            //using (MD5 md5Hash = MD5.Create())
            //{
            //    string hash = GetMd5Hash(md5Hash, source1);
            //    Console.WriteLine("TA_060401_TCU_KAPPA_F0_1 Hash : {0}", hash);
            //}

            //if (Directory.Exists(@"D:\Example"))
            //    Console.WriteLine("존재합니다.");
            //else
            //    Console.WriteLine("존재하지 않습니다.");

            //DirectoryInfo di = Directory.CreateDirectory(@"D:\Example1");
            //DirectoryInfo di1 = Directory.CreateDirectory(@"D:\Example2\temp");
            //var di2 = new DirectoryInfo(@"D:\Example");
            //di2.Create();

            try
            {
                Directory.Move(@"D:\Example2\temp", @"D:\MyWork");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                //Directory.Delete(@"D:\MyWork", recursive:true);                                
            }

            //var di3 = new DirectoryInfo(@"D:\Example2\temp");
            //try
            //{
            //    di3.MoveTo(@"D:\Example3");
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            try
            {
                var workDir = Directory.GetCurrentDirectory();
                Console.WriteLine(workDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var di4 = new DirectoryInfo(@"D:\Example");
            //DirectoryInfo[] directories = di4.GetDirectories();
            //DirectoryInfo[] directories = di4.GetDirectories("새*");
            DirectoryInfo[] directories = di4.GetDirectories("*", SearchOption.AllDirectories);
            foreach (var dinfo in directories)
            {
                //Console.WriteLine(dinfo.Parent);
                //Console.WriteLine(dinfo.Name);
                Console.WriteLine(dinfo.FullName);
                //Console.WriteLine(dinfo.Extension);
            }

            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var directoryName = Path.GetDirectoryName(path);
            var fileName = Path.GetFileName(path);
            var extension = Path.GetExtension(path);
            var filenameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            var pathRoot = Path.GetPathRoot(path);
            Console.WriteLine("DirectoryName : {0}", directoryName);
            Console.WriteLine("FileName : {0}", fileName);
            Console.WriteLine("Extension : {0}", extension);
            Console.WriteLine("FilenameWithoutExtension : {0}", filenameWithoutExtension);
            Console.WriteLine("PathRoot : {0}", pathRoot);
            
        }



        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


    }
}
