using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBuoiMot
{
    public class DemoPlaceholder
    {
        public static void Main(string[] args)
        {
            /*int a = GetInt("Input a: ");
            int b = GetInt("Input b: ");
            int result;
            result = a + b;//Add
            //Console.WriteLine("Sum of {0} and {1}: {2}",a,b,result);//Example: Placeholder
            Console.WriteLine($"Sum of {a,5} and {b,5}: {result}");
            result = b - a;//Sub
            Console.WriteLine("Sub of {0} and {1}: {2}", a, b, result);*/
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString("dd/MM/yyyy"));
        }

        public static int GetInt(string mes)
        {
            Console.Write(mes);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
