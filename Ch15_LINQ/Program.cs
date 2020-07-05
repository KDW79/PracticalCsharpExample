using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch15_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<Book> books = new List<Book>()
            //{
            //    new Book {Title = "Writing C# Soild Code", CategoryId = 1, Price = 25000, PublishedYear = 2016 },
            //};

            //List<Category> categories = new List<Category>();

            //Book book = new Book { Title = "Writing C# Soild Code", CategoryId = 1, Price = 25000, PublishedYear = 2016};
            //books.Add(book);

            //Category category = new Category() {  Id=1, Name = "Development"};

            //categories.Add(category);


            var price = Library.Books
                               .Where(b => b.CategoryId == 1)
                               .Max(b => b.Price);
            Console.WriteLine(price);

            var min = Library.Books
                .Min(x => x.Title.Length);
            var book = Library.Books
                .First(b => b.Title.Length == min);
            Console.WriteLine(book);

            var book1 = Library.Books
                .First(b => b.Title.Length == Library.Books.Min(x => x.Title.Length));
            Console.WriteLine(book1);

            var average = Library.Books
                .Average(x => x.Price);
            var aboves = Library.Books
                .Where(b => b.Price > average);
            foreach (var b in aboves)
            {
                Console.WriteLine(b);
            }

            var query = Library.Books
                               .Select(b => b.PublishedYear)
                               .Distinct()
                               .OrderBy(y => y);

            foreach (var n in query)
            {
                Console.WriteLine(n);
            }

            var books6 = Library.Books
                .OrderBy(b => b.CategoryId)
                .ThenByDescending(b => b.PublishedYear);
            foreach(var b in books6)
            {
                Console.WriteLine(b);
            }

            Console.WriteLine("==================");

            var books7 = Library.Books
                .Where(b => b.PublishedYear == 2013 ||
                b.PublishedYear == 2016)
                .OrderBy(b => b.PublishedYear);
            foreach(var n in books7)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("==================");
            var years7 = new int[] { 2013, 2016 };
            var books77 = Library.Books
                .Where(b => years7.Contains(b.PublishedYear));
            foreach (var n in books77)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("==================");
            var groups = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(g => g.Key);
            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Key}년");
                foreach (var b in g)
                {
                    Console.WriteLine($"   {b}");
                }
            }

            Console.WriteLine("==================");
            var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(group => group.OrderByDescending(b => b.Price)
                                      .First())
                .OrderBy(o => o.PublishedYear);
            foreach (var book9 in selected)
            {
                Console.WriteLine($"{book9.PublishedYear}년 {book9.Title} ({book9.Price})");
            }

            Console.WriteLine("==================");
            var lookup = Library.Books
                .ToLookup(b => b.PublishedYear);
            var books10 = lookup[2014];
            foreach (var book10 in books10)
            {
                Console.WriteLine(book10);
            }

            Console.WriteLine("==================");
            var books = Library.Books
                .OrderBy(b => b.CategoryId)
                .ThenBy(b => b.PublishedYear)
                .Join(Library.Categories,
                      book11 => book11.CategoryId,
                      category11 => category11.Id,
                      (book11, category11) => new
                      {
                          Title = book11.Title,
                          Category = category11.Name,
                          PublishedYear = book11.PublishedYear

                      }
                      );
            foreach (var book11 in books)
            {
                Console.WriteLine($"{book11.Title}, {book11.Category}, {book.PublishedYear}");
            }

            Console.WriteLine("==================");
            var names = Library.Books
                .Where(b => b.PublishedYear == 2016)
                .Join(Library.Categories,
                      book12 => book12.CategoryId,
                      category12 => category12.Id,
                      (book12, category12) => category12.Name)
                .Distinct(); // 중복제거
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("==================");
            var groups13 = Library.Categories
                                  .GroupJoin(Library.Books,
                                  z => z.Id,
                                  y => y.CategoryId,
                                  (z, books13) => new { Category = z.Name, Books = books13 }
                                  );
            foreach (var group in groups13)
            {
                Console.WriteLine(group.Category);
                foreach (var book13 in group.Books)
                {
                    Console.WriteLine($"   {book13.Title} ({book13.PublishedYear}年)");
                }
            }

            Console.WriteLine("ex 15.14==================");
            var groups14 = Library.Categories
                                .GroupJoin(Library.Books,
                                           c => c.Id,
                                           b => b.CategoryId,
                                           (c, books14) => new
                                           {
                                               Category = c.Name,
                                               Count = books14.Count(),
                                               Average = books14.Average(b => b.Price)
                                           }
                                           );
            foreach (var obj in groups14)
            {
                Console.WriteLine($"{obj.Category} 책 수량: {obj.Count} 평균 가격: {obj.Average:0.0}원");
            }

            Console.WriteLine("ex 15.15==================");
            var jWeeks = new List<string>
            {
                "월", "화", "수", "목", "금", "토", "일"
            };
            var eWeeks = new List<string>
            {
                "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"
            };
            var weeks = jWeeks.Zip(eWeeks, (s1, s2) => string.Format($"{s1} ({s2})"));
            weeks.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("ex 15.16==================");
            var animals1 = new[] { "기린", "사자", "코끼리", "얼룩말", "팬더", };
            var animals2 = new[] { "사자", "코알라", "기린", "고릴라", };
            var union = animals1.Union(animals2);
            foreach (var name in union)
            {
                Console.Write($"{name} ");
            }
            Console.Write($"\n");

            Console.WriteLine("ex 15.17==================");
            var intersect = animals1.Intersect(animals2);
            foreach (var name in intersect)
            {
                Console.Write($"{name} ");
            }
            Console.Write($"\n");

            Console.WriteLine("ex 15.18==================");
            var expect = animals1.Except(animals2);
            foreach (var name in expect)
            {
                Console.Write($"{name} ");
            }
            Console.Write($"\n");

        }
    }
}
