using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch17_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var greetings = new List<GreetingBase>()
            {
                new GreetingMorning(),
                new GreetingAfternoon(),
                new GreetingEvening(),
            };

            foreach (var greeting in greetings)
            {
                Console.WriteLine(greeting.GetMessage());
            }

            var greetings2 = new List<IGreeting>()
            {
                new GreetingMorning2(),
                new GreetingAfternoon2(),
                new GreetingEvening2(),
            };

            foreach (var obj in greetings2)
            {
                Console.WriteLine(obj.GetMessage());
            }
        }
    }
}
