using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPhrase.Extensions;

namespace Ch3_LambdaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Judgement judge = IsEven;



            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            //var count = Count(numbers, judge);
            //var count = Count(numbers, IsEven);
            //var count = Count(numbers, delegate (int n) { return n % 2 == 0; });
            //var count = Count(numbers, n => n % 2 == 0); // 람다식 짝수의 개수를 센다
            //var count = Count(numbers, n => n % 2 == 1); // 람다식 홀수의 개수를 센다
            //var count = Count(numbers, n => n >= 5); // 5이상인 수를 센다
            //var count = Count(numbers, n => 5 <= n && n < 10); // 5 이상 10미만인 수의 개수를 센다
            var count = Count(numbers, n => n.ToString().Contains('1'));

            Console.WriteLine(count);

            var names = new List<string> { "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong", };
            //IEnumerable<string> query = names.Where(s => s.Length <= 5);
            //foreach (string s in query)
            //    Console.WriteLine(s);

            var query = names.Where(s => s.Length <= 5);
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine("------");

            names[0] = "Busan";
            foreach (var item in query)
                Console.WriteLine(item);

            var word = "gateman";
            var result = word.Reverse();
            Console.WriteLine(result);

        }
        static public bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        public delegate bool Judgement(int value);

        //static public int Count(int[] numbers, Judgement judge)
        //{
        //    int count = 0;
        //    foreach (var n in numbers)
        //    {
        //        if (judge(n) == true)
        //        {
        //            count++;
        //        }
        //    }

        //    return count;
        //}

        static public int Count(int[] numbers, Predicate<int> judge)
        {
            int count = 0;
            foreach (var n in numbers)
            {
                if (judge(n) == true)
                    count++;
            }
            return count;

        }
    }
}

namespace CSharpPhrase.Extensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
    }
}