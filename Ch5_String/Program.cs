using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Ch5_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "Windows";
            var str2 = "WINDOWS";

            if (String.Compare(str1, str2) == 0)
                Console.WriteLine("같다.");
            else
                Console.WriteLine("같지 않다.");

            if (String.Compare(str1, str2, true) == 0)
                Console.WriteLine("같다.");
            else
                Console.WriteLine("같지 않다.");

            if (String.Compare(str1, str2, ignoreCase: true) == 0)
                Console.WriteLine("같다.");
            else
                Console.WriteLine("같지 않다.");

            var str3 = "ＣＯＭＰＵＴＥＲ";
            var str4 = "COMPUTer";

            var cultureInfo = new CultureInfo("ja-JP");

            if (String.Compare(str3, str4, cultureInfo, CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase) == 0)
                Console.WriteLine("일치합니다.");

            var str5 = "";
            if (String.IsNullOrEmpty(str5))
                Console.WriteLine("null 또는 빈 문자열입니다.");

            var str6 = "Visual Studio 2015";
            if (str6.StartsWith("Visual"))
                Console.WriteLine("Visual로 시작됩니다.");

            var str7 = "NullException";
            if (str7.EndsWith("Exception"))
                Console.WriteLine("Exception으로 끝납니다.");

            var str8 = "My Program is Good";
            if (str8.Contains("Program"))
                Console.WriteLine("Program이 포함되 있습니다.");

            var target = "C# Programming";
            var isExists = target.Any(c => Char.IsLower(c));
            Console.WriteLine("{0}", isExists);

            var target1 = "141421356";
            var isAllDigits = target1.All(c => Char.IsDigit(c));
            Console.WriteLine("{0}", isAllDigits);

            var target2 = "01234ABC567";
            var result = target2.Remove(5, 3);
            Console.WriteLine("{0}", result);

            var target3 = "01234";
            var result3 = target3.Insert(2, "abc");
            Console.WriteLine("{0}", result3);

            var text = "The quick brown for jumps over the lazy dog";
            string[] words = text.Split(' ');
            foreach (var word in words)
                Console.WriteLine("{0}", word);

            var words2 = text.Split(new []{ ' ','.'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word2 in words2)
                Console.WriteLine("{0}", word2);

            var sb = new StringBuilder();
            foreach (var word in GetWords())
            {
                sb.Append(word);
            }
            var text2 = sb.ToString();
            Console.WriteLine(text2);

            var str10 = "C#프로그래밍";
            foreach (var c in str10)
                Console.Write("[{0}]", c);
            Console.WriteLine();

            var chars = new char[] { 'P', 'r', 'o', 'g', 'r', 'a', 'm' };
            var str11 = new string(chars);
            Console.WriteLine(str11);

            var target4 = "Novelist\t=\t김만중";
            var chars4 = target4.SkipWhile(c => c != '=')
                .Skip(1)
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();
            var str12 = new string(chars4);
            Console.WriteLine(str12);

            int number = 12345;
            var s1 = number.ToString();
            var s2 = number.ToString("#");
            var s3 = number.ToString("0000000");
            var s4 = number.ToString("#,0");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);

            decimal distance = 9876.123m;
            var s5 = distance.ToString();
            var s6 = distance.ToString("#");
            var s7 = distance.ToString("#,0.0");
            var s8 = distance.ToString(",0.0000");
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);
            Console.WriteLine(s8);
            Console.WriteLine("----------------------------------");

            int number2 = 0;
            var s10 = number2.ToString();
            var s11 = number2.ToString("#");
            var s12 = number2.ToString("0000000");
            var s13 = number2.ToString("#,0");
            Console.WriteLine(s10);
            Console.WriteLine(s11);
            Console.WriteLine(s12);
            Console.WriteLine(s13);
            Console.WriteLine("----------------------------------");

            decimal distance2 = 0.0m;
            var s14 = distance2.ToString();
            var s15 = distance2.ToString("#");
            var s16 = distance2.ToString("#,0.0");
            var s17 = distance2.ToString("#,0.0000");
            Console.WriteLine(s14);
            Console.WriteLine(s15);
            Console.WriteLine(s16);
            Console.WriteLine(s17);
            Console.WriteLine("----------------------------------");

            var s20 = string.Format("{0,10}", number);
            var s21 = string.Format("{0,10:#,0}", number);
            var s22 = string.Format("{0,10}", distance);
            var s23 = string.Format("{0,10:0.0}", distance);
            Console.WriteLine(s20);
            Console.WriteLine(s21);
            Console.WriteLine(s22);
            Console.WriteLine(s23);
            Console.WriteLine("----------------------------------");

            var s31 = $"{number:#,0}";
            var s32 = $"{number:0000000}";
            var s33 = $"{number,8}";
            var s34 = $"{number,8:#,0}";
            Console.WriteLine(s31);
            Console.WriteLine(s32);
            Console.WriteLine(s33);
            Console.WriteLine(s34);
            Console.WriteLine("----------------------------------");

            var novelist = "김만중";
            var bestWork = "구운몽";
            var bookline = String.Format("Novelist = {0}; BestWork = {1}", novelist, bestWork);
            var bookline2 = "Novelist = " + novelist + "; BestWork = " + bestWork;
            var bookline3 = $"Novelist = { novelist}; bestWork = { bestWork}";
            Console.WriteLine(bookline);
            Console.WriteLine(bookline2);
            Console.WriteLine(bookline3);
            Console.WriteLine("----------------------------------");

            var article = 12;
            var clause = 5;
            var header = String.Format("제{0,2}조{1,2}항", article, clause);
            var header2 = $"제{article,2}조{clause,2}항";
            Console.WriteLine(header);
            Console.WriteLine(header2);

            
        }

        static public string[] GetWords()
        {
            string[] temp = new string[10];
            for (int i = 0; i < 10; i++)
                temp[i] = "a";
            return temp;
        }
    }
}
