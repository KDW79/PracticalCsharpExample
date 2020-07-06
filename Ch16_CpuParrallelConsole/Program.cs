using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch16_CpuParrallelConsole
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

            var selected = books.AsParallel()
                                .Where(b => b.Price > 500 && b.Pages > 400)
                                .Select(b => new { b.Title });

            Console.WriteLine(selected);

            //ex16.19
            var selected19 = books.AsParallel()
                                  .Where(b => b.Price > 500);
            selected19.AsParallel().ForAll(book =>
            {
                Console.WriteLine(book.Title);
            });

            //ex16.20
            ex16_20Async().Wait();
            ex16_20();
            ex16_20AsyncWhenAll().Wait();
        }

        static async Task ex16_20Async()
        {
            var sw = Stopwatch.StartNew();
            var task1 = Task.Run(() => GetPrimeAt5000());
            var task2 = Task.Run(() => GetPrimeAt6000());
            var prime1 = await task1;
            var prime2 = await task2;
            sw.Stop();
            Console.WriteLine(prime1);
            Console.WriteLine(prime2);
            Console.WriteLine($"실행시간: {sw.ElapsedMilliseconds}ms");
        }

        static async Task ex16_20AsyncWhenAll()
        {
            var sw = Stopwatch.StartNew();
            var tasks = new Task<int>[] {
                Task.Run(() => GetPrimeAt5000()),
                Task.Run(() => GetPrimeAt6000()),
            };
            var results = await Task.WhenAll(tasks);
            sw.Stop();
            foreach (var prime in results)
            {
                Console.WriteLine(prime);
            }
            Console.WriteLine($"실행시간: {sw.ElapsedMilliseconds}ms");
        }

        static void ex16_20()
        {
            var sw = Stopwatch.StartNew();
            var prime1 = GetPrimeAt5000();
            var prime2 = GetPrimeAt6000();
            sw.Stop();
            Console.WriteLine(prime1);
            Console.WriteLine(prime2);
            Console.WriteLine($"실행시간: {sw.ElapsedMilliseconds}ms");
        }

        private static int GetPrimeAt5000()
        {
            return GetPrimes().Skip(4999).First();
        }

        private static int GetPrimeAt6000()
        {
            return GetPrimes().Skip(5999).First();
        }

        static IEnumerable<int> GetPrimes()
        {
            for (int i = 2; i < int.MaxValue; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return i;
                }
            }

        }
    }
}
