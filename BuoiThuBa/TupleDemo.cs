using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuBa
{
    public class TupleDemo
    {
        static (int sum, int count) Caculator(int[] numbers)
        {
            var r = (sum: 0, count: 0);
            foreach(var n in numbers)
            {
                if (n % 2 == 0)
                {
                    r.sum += n;
                    r.count++;
                }
            }
            return r;
        }
        static void Main(string[] args)
        {
            int[] n = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var r= Caculator(n);
            Console.WriteLine($"Sum of even: {r.sum}, count: {r.count}");
            Console.Read();
        }
    }
}
