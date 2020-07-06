﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace Ch17_OopFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            TextProcessor.Run<LineCounterProcessor>(args[0]);
        }
    }

    class LineCounterProcessor : TextProcessor
    {
        private int _count;

        protected override void Initialize(string fname)
        {
            _count = 0;
        }

        protected override void Execute(string line)
        {
            _count++;
        }

        protected override void Terminate()
        {
            Console.WriteLine("{0}줄", _count);
        }
    }
}
