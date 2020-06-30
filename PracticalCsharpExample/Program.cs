using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PracticalCsharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Product yakkwa = new Product(123, "약과", 180);
            int price = yakkwa.Price;
            int taxIncluded = yakkwa.GetPriceIncludingTax();

            Product chapssal = new Product(235, "찹쌀떡", 160);
            int yakkwaTax = yakkwa.GetTax();
            int chapssalTax = chapssal.GetTax();

            DateTime date = new DateTime(2017, 9, 2);
            int year = date.Year;
            // 10일 후를 구한다.
            DateTime daysAfter10 = date.AddDays(10);

            MyPoint a = new MyPoint(10, 20);
            MyPoint b = a;

            Console.WriteLine("a: ({0}, {1})", a.X, a.Y);
            Console.WriteLine("b: ({0}, {1})", b.X, b.Y);
            a.X = 80;
            Console.WriteLine("a: ({0}, {1})", a.X, a.Y);
            Console.WriteLine("b: ({0}, {1})", b.X, b.Y);

            MyPoint1 c = new MyPoint1(10, 20);
            MyPoint1 d = c;

            Console.WriteLine("a: ({0}, {1})", c.X, c.Y);
            Console.WriteLine("b: ({0}, {1})", d.X, d.Y);
            c.X = 80;
            Console.WriteLine("a: ({0}, {1})", c.X, c.Y);
            Console.WriteLine("b: ({0}, {1})", d.X, d.Y);

            // Today는 static 속성
            DateTime today = DateTime.Today;

            // Console은 static 클래스, WriteLine은 static 메서드
            Console.WriteLine("오늘은 {0}월{1}일 입니다.", today.Month, today.Day);

            Employee employee = new Employee { Id = 100, Name = "홍길동", BirthDay = new DateTime(1992, 4, 5), DivisionName = "제1영업부" };

            Console.WriteLine("{0}({1}는 {2}에 소속되어 있습니다.", employee.Name, employee.GetAge(), employee.DivisionName);

        }

        struct MyPoint
        {
            public int X { get; set; }
            public int Y { get; set; }

            // 생성자
            public MyPoint(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

    }
}

namespace nsMine
{
    class myPgm
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("내가 만든 ns, class");
        //}
    }
}