using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public static class Counter
    {
        public static int CounterValue { get; set; }

        static Counter()
        {
            CounterValue = 0;
        }

        public static void IncrementCounter()
        {
            CounterValue++;
        }

        public static void DecrementCounter()
        {
            CounterValue--;
        }
    }
}
