using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuHai
{
    public class Lion : Animal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("Lion roars!!!");
        }

        public static void Main(string[] args)
        {
            Lion lion = new Lion();
            lion.Eat();
            lion.AnimalSound();
        }
    }
}
