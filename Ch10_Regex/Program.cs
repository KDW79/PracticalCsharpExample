using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Ch10_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "private List<string> result = new List<string>();";

            //var regex = new Regex(@"List<\w+>");
            var regex = new Regex("List<\\w+>");
            //bool isMatch = Regex.IsMatch(text, @"List<\w+>");
            bool isMatch = regex.IsMatch(text);
            if (isMatch)
                Console.WriteLine("찾았습니다.");
            else
                Console.WriteLine("찾지 못했습니다.");

            var text1 = "using System.Text.RegularExpressions;";
            bool isMatch1 = Regex.IsMatch(text1, @"^using");
            if (isMatch1)
                Console.WriteLine("'using'으로 시작됩니다.");
            else
                Console.WriteLine("'using'으로 시작되지 않습니다.");

            bool isMatch2 = Regex.IsMatch(text, @"()$");
            if (isMatch2)
                Console.WriteLine("'()'으로 끝납니다.");
            else
                Console.WriteLine("'()'으로 끝나지 않습니다.");

            var strings = new[] { "Microsoft windows", "Windows Server", "Windows", };
            var regex3 = new Regex(@"^(W|w)indows$");
            var count = strings.Count(s => regex3.IsMatch(s));
            Console.WriteLine("{0}행과 일치", count);

            var strings4 = new[] { "13000", "-50.6", "0.123", "+180.00", "10.2.5", "320-0851", " 123", "$1200", "500원", };
            var regex4 = new Regex(@"^[-+]?(\d+)(\.\d+)?$");
            foreach (var s in strings4)
            {
                var isMatch4 = regex4.IsMatch(s);
                if (isMatch4)
                    Console.WriteLine(s);
            }

            var text8 = "Regex 클래스에 있는 Match 메서드를 사용합니다.";
            Match match8 = Regex.Match(text8, @"\p{IsHangulSyllables}+");
            if (match8.Success)
                Console.WriteLine("Success {0}, Index {1}, Length {2}, Value {3}, Groups {4}", match8.Success, match8.Index, match8.Length, match8.Value, match8.Groups);

            var text9 = "private List<string> results = new List<string>();";
            var matches9 = Regex.Matches(text9, @"List<\w+>");
            foreach (Match match9 in matches9)
            {
                Console.WriteLine("Index = {0}, Length = {1}, Value = {2}", match9.Index, match9.Length, match9.Value);
            }

            Match match10 = Regex.Match(text9, @"List<\w+>");
            while (match10.Success)
            {
                Console.WriteLine("Index = {0}, Length = {1}, Value = {2}",
                    match10.Index, match10.Length, match10.Value);
                match10 = match10.NextMatch();
            }

            var matches11 = Regex.Matches(text9, @"\b[a-z]+\b")
                .Cast<Match>()
                .OrderBy(x => x.Length);
            foreach (Match match11 in matches11)
            {
                Console.WriteLine("Index = {0}, Length = {1}, Value = {2}",
                    match11.Index, match11.Length, match11.Value);
            }

            var text12 = "C#에는 <값형>과 <참조형>이라는 두 가지의 형이 존재합니다.";
            var matches12 = Regex.Matches(text12, @"<([^<>]+)>");
            foreach (Match match12 in matches12)
            {
                Console.WriteLine("<{0}>", match12.Groups[1]);
            }

            var text13 = "kor, KOR, Kor";
            var mc13 = Regex.Matches(text13, @"\bkor\b", RegexOptions.IgnoreCase);
            foreach (Match m13 in mc13)
            {
                Console.WriteLine(m13.Value);
            }

            var text14 = "Word\nExcel\nPowerPoint\nOutlook\nOneNote\n";
            var pattern14 = @"^[a-zA-Z]{5,7}$";
            var matches14 = Regex.Matches(text14, pattern14, RegexOptions.Multiline);
            foreach (Match m in matches14)
            {
                Console.WriteLine("{0} {1}", m.Index, m.Value);
            }

            Console.WriteLine(square(5));

            int[] numbers = { 2, 3, 4, 5 };
            var squareNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squareNumbers));

            var text15 = "C# 공부를 조금씩 진행해보자.";
            var pattern15 = @"쪼금씩|쪼끔씩|쬐끔씩";
            var replaced15 = Regex.Replace(text15, pattern15, "조금씩");
            Console.WriteLine(replaced15);

            var text16 = "Word, Excel, PowerPoint , Outlook,OneNote";
            var pattern16 = @"\s*,\s*"; // "\s*.\s*" == "," | ", " | " ," | " , "
            var replaced16 = Regex.Replace(text16, pattern16, ", ");
            Console.WriteLine(replaced16);

            var text17 = "foo.htm bar.html baz.htm";
            var pattern17 = @"\.(htm)\b";
            var replaced17 = Regex.Replace(text17, pattern17, ".html");
            Console.WriteLine(replaced17);

            var text18 = "1024바이트, 8바이트 문자, 바이트, 킬로바이트";
            var pattern18 = @"(\d+)바이트";
            var replaced18 = Regex.Replace(text18, pattern18, "$1byte");
            Console.WriteLine(replaced18);

            var text19 = "1234567890123456";
            var pattern19 = @"(\d{4})(\d{4})(\d{4})(\d{4})";
            var replaced19 = Regex.Replace(text19, pattern19, "$1-$2-$3-$4");
            Console.WriteLine(replaced19);

            var text20 = "Word, Excel, PowerPoint , Outlook,OneNote";
            var pattern20 = @"\s*,\s*";
            string[] substrings = Regex.Split(text20, pattern20);
            foreach(var m in substrings)
            {
                Console.WriteLine("'{0}'", m);
            }

            var text21 = "aa12345 a123456 b123 Z12345 AX98765";
            var pattern21 = @"\b[a-zA-Z]{2,}[0-9]{5,}\b"; //알파벳 2개 연속 된 뒤 숫자 5개 연속된 경우 매칭 확인
            var matches21 = Regex.Matches(text21, pattern21);
            foreach (Match m in matches21)
            {
                Console.WriteLine("'{0}'", m.Value);
            }

            var text22 = "삼겹살-84-58433,상추-95838-488,키보드-840-48484,마우스-3274-38,샴푸-489-58493,치약-38-4839,장갑-48490-483,통조림-3840-203,카레-43-28490,계란-48594-283";
            var pattern22 = @"\p{IsHangulSyllables}+-[0-9]{2,3}-[0-9]+";
            var matches22 = Regex.Matches(text22, pattern22);
            foreach (Match m in matches22)
            {
                Console.WriteLine("'{0}'", m.Value);
            }

            var text23 = "<person><name>김삿갓</name><age>22</age></person>";
            var pattern23 = @"<.+>";
            var matches23 = Regex.Matches(text23, pattern23);
            foreach (Match m in matches23)
                Console.WriteLine("'{0}'", m.Value);

            var pattern24 = @"<(\w[^>]+)>";
            var matches24 = Regex.Matches(text23, pattern24);
            foreach (Match m in matches24)
            {
                Console.WriteLine("'{0}'", m.Groups[1].Value);
            }

            var text26 = "<p>가나다라마</p><p>바사아자차</p>";
            var pattern26 = @"<p>(.*?)</p>";
            var matches26 = Regex.Matches(text26, pattern26);
            foreach (Match m in matches26)
            {
                Console.WriteLine("'{0}'", m.Groups[1].Value);
            }

            var text27 = "도로를 지나가는 차들이 뛰뛰하고 경적을 울리면 반대쪽 차들이 빵빵하고 울렸다.";
            var pattern27 = @"(\w)\1";
            var matches27 = Regex.Matches(text27, pattern27);
            foreach (Match m in matches27)
            {
                Console.WriteLine("'{0}'", m.Value);
            }

            var text28 = "기러기 펠리컨 청둥오리 오리너구리 토마토 오서요서오 pops push pop";
            var pattern28 = @"\b(\w)\w\1\b";
            var matches28 = Regex.Matches(text28, pattern28);
            foreach (Match m in matches28)
            {
                Console.WriteLine("'{0}'", m.Value);
            }

        }

        static Func<int, int> square = x => x * x;
    }
}
