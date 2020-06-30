using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch6_Array_ListT
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book { Title = "태평천하", Price = 400, Pages = 378},
                new Book { Title = "운수 좋은 날", Price = 281, Pages = 212},
                new Book { Title = "만세전", Price = 389, Pages = 201},
                new Book { Title = "삼대", Price = 637, Pages = 464},
                new Book { Title = "상록수", Price = 410, Pages = 276},
                new Book { Title = "혈의 누", Price = 961, Pages = 666},
                new Book { Title = "금수회의록", Price = 514, Pages = 268},
            };

            var numbers = Enumerable.Repeat(-1, 20)
                .ToList();
            foreach (var n in numbers)
                Console.WriteLine(n);

            var strings = Enumerable.Repeat("(unknown)", 12)
                .ToArray();
            foreach (var str in strings)
                Console.WriteLine(str);

            var array = Enumerable.Range(1, 20)
                .ToArray();
            foreach (var ar in array)
                Console.WriteLine(ar);

            var numbers2 = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            var average = numbers2.Average();
            Console.WriteLine(average);
            var average2 = books.Average(x => x.Price);
            Console.WriteLine(average2);

            var sum = numbers2.Sum();
            Console.WriteLine(sum);

            var totalPrice = books.Sum(x => x.Price);
            Console.WriteLine(totalPrice);

            var min = numbers2.Where(n => n > 0)
                .Min();
            Console.WriteLine(min);

            var pages = books.Max(x => x.Pages);
            Console.WriteLine(pages);

            var count = numbers2.Count(n => n == 0);
            Console.WriteLine(count);

            var count2 = books.Count(x => x.Title.Contains("운수"));
            Console.WriteLine(count2);

            bool exists = numbers2.Any(n => n % 7 == 0);
            Console.WriteLine(exists);

            bool exists2 = books.Any(x => x.Price >= 10000);
            Console.WriteLine(exists2);

            bool isAllPositive = numbers2.TrueForAll(delegate (int n) { return n > 0; });
            Console.WriteLine(isAllPositive);

            bool isAllPositive2 = numbers2.All(n => n > 0);
            Console.WriteLine(isAllPositive2);


        }
    }
}
