using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch16_async
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.DoSomething();
        }

        private void DoSomething()
        {
            for (int i =0; i<100000; i++)
            {
                Console.Write($"{i} ");
            }
            Console.Write($"\n");
        }
    }
}
