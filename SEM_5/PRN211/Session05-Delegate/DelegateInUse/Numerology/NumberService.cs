using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology
{
    internal class NumberService
    {
        static private List<int> _arr = new List<int> { -5, -10, -15, 20, 1, 3, 5, 7, 90, 101 };

        public static void PrintNumbers (Action<int> f)
        {
            foreach (int i in _arr)
            {
                f(i);
            }

        }
    }
}
