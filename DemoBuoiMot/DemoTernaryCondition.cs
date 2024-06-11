using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBuoiMot
{
    public class DemoTernaryCondition
    {
        public static void Main(string[] args)
        {
            int ValueOne = 5, ValueTwo = 25, ValueThree = 15;
            int result = 0;
            if (ValueOne > ValueTwo)
            {
                result = (ValueOne>ValueThree)?ValueOne:ValueThree;
            }
            else
            {
                result = (ValueTwo>ValueThree)?ValueTwo:ValueThree;
            }
            Console.WriteLine($"Largest number: {result}");
        }
        
    }
}
