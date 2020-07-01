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
        }
    }
}
