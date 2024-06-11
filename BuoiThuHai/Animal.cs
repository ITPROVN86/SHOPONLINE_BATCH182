using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuHai
{
    public abstract class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eat everything!");
        }

        public void Sleep()
        {
            Console.WriteLine("Sleep at everywhere!");
        }
        public abstract void AnimalSound();
    }
}
