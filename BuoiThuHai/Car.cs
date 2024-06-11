using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuHai
{
    public class Car : IVehicle
    {
        public void StarEngine()
        {
            Console.WriteLine("Car start Engine");
        }

        public void StopEngine()
        {
            Console.WriteLine("Car stop Engine");
        }
    }
}
