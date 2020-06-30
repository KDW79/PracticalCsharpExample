using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ch7_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var flowerDict = new Dictionary<string, int>()
            {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 200,
                ["rose"] = 500,
                ["dahlia"] = 400,
            };

            var newDict = flowerDict.Where(x => x.Value >= 400)
                .ToDictionary(flower => flower.Key, flower => flower.Value);
            foreach(var item in newDict.Keys)
            {
                Console.WriteLine(item);
            }

            var flo = "sunflower";
            var f = flowerDict[flo];
            Console.WriteLine(f);

            var dict = new Dictionary<MonthDay, string>
            {
                [new MonthDay(6, 6)] = "현충일",
                [new MonthDay(8,15)] = "광복절",
                [new MonthDay(10,3)] = "개천절",

            };
            var md = new MonthDay(8,15);
            var s = dict[md];
            Console.WriteLine(s);


            //Wookoa wookoa = new Wookoa();
            //WookoaTistory tistory = new WookoaTistory();

            //tistory = wookoa as WookoaTistory;

            //if (tistory == null)
            //    Console.WriteLine("형변환 불가능!");
            //else
            //    Console.WriteLine("형변환 가능!");


            ////출처: https://wookoa.tistory.com/64 [Wookoa]

            //Wookoa wookoa1 = new Wookoa();

            //if (wookoa1 is WookoaTistory)
            //{
            //    Console.WriteLine("형변환 불가능!");
            //}
            //else
            //{
            //    Console.WriteLine("형변환 가능!");
            //    WookoaTistory tistory1 = (WookoaTistory)wookoa1;
            //}

            ////출처: https://wookoa.tistory.com/64 [Wookoa]

            var lines = File.ReadAllLines("sample.txt");
            var we = new WordsExtractor(lines);
            foreach (var word in we.Extract())
                Console.WriteLine(word);
        }
    }

    class MonthDay
    {
        public int Day { get; private set; }
        public int Month { get; private set; }

        public MonthDay (int month, int day)
        {
            this.Month = month;
            this.Day = day;
        }

        // MonthDay끼리 비교한다.
        public override bool Equals(object obj)
        {
            var other = obj as MonthDay;
            if (other == null)
                throw new ArgumentException();
            return this.Day == other.Day && this.Month == other.Month;
        }

        // 해시코드를 구한다.
        public override int GetHashCode()
        {
            return Month.GetHashCode() * 31 + Day.GetHashCode();
        }
    }

    class WordsExtractor
    {
        private string[] _lines;

        // 생성자
        // 파일 외의 것에도 추출할 수 있도록 string[]을 인수로 받는다
        public WordsExtractor (string[] lines)
        {
            _lines = lines;

        }

        // 10 문자 이상인 단어를 중복 없이 알파벳순으로 열거한다.
        public IEnumerable<string> Extract()
        {
            var hash = new HashSet<string>();
            foreach (var line in _lines)
            {
                var words = GetWords(line);
                foreach (var word in words)
                {
                    if (word.Length >= 10)
                        hash.Add(word.ToLower());
                }
            }
            return hash.OrderBy(s => s);
        }

        // 단어로 분할할 때 사용되는 분리자
        // 문자 배열을 초기화하기 보다는 ToCharArray 메서드를 사용하는 것이 편한다
        private char[] _separators = @" !?"",.".ToCharArray();

        // 1행부터 단어를 꺼내서 열거한다
        private IEnumerable<string> GetWords(string line)
        {
            var items = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                // you're, it's, don't 에서 아포스트로피 이후에 나오는 부분을 삭제한다
                var index = item.IndexOf("'");
                var word = index <= 0 ? item : item.Substring(0, index);
                // 모두 알파벳만을 대상으로 한다.
                if (word.ToLower().All(c => 'a' <= c && c <= 'z'))
                    yield return word;
            }
        }
    }

    class Wookoa
    {
        string _name = "Wookoa";

        public void NamePrint()
        {
            Console.WriteLine(_name);
        }
    }

    class WookoaTistory : Wookoa
    {
        String _title = "Wookoa:Tistory";

        public void TitlePrint()
        {
            Console.WriteLine(_title);
        }
    }


    //출처: https://wookoa.tistory.com/64 [Wookoa]
}
