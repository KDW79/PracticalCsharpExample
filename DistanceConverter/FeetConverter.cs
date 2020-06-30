using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    public static class FeetConverter
    {
        private const double ratio = 0.3048;
        public static readonly double ratio2 = 0.3048;

        //미터를 피트로 환산한다.
        public static double FromMeter(double meter)
        {
            //return meter / 0.3048;
            return meter / ratio;
        }

        //피트를 미터로 환산한다.
        public static double ToMeter(double feet)
        {
            //return feet * 0.3048;
            return feet * ratio;
        }
    }
}
