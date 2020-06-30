using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length >= 1 && args[0] == "-tom")
            {
                PrintFeetToMeterList(1, 10);

            }
            else
            {
                PrintMeterToFeetList(1, 10);
            }
            // 피트에서 미터로의 환산표
        }

        static void PrintFeetToMeterList(int start, int stop)
        {
            //FeetConverter converter = new FeetConverter();
            for (int feet = start; feet <= stop; feet++)
            {
                //double meter = FeetToMeter(feet);
                //double meter = converter.ToMeter(feet);
                double meter = FeetConverter.ToMeter(feet);
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
            Console.WriteLine("{0:0.0000}", FeetConverter.ratio2);
        }

        static void PrintMeterToFeetList(int start, int stop)
        {
            //FeetConverter converter = new FeetConverter();
            for (int meter = start; meter <= stop; meter++)
            {
                //double feet = meter / 0.3048;
                //double feet = converter.FromMeter(meter);
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000} feet", meter, feet);
            }
            Console.WriteLine("{0:0.0000}", FeetConverter.ratio2);
        }

        static double FeetToMeter(int feet)
        {
            return feet * 0.3048;
        }

        static double MeterToFeet(int meter)
        {
            return meter / 0.3048;
        }
    }
}
