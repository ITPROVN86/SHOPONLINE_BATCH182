
using System.Collections.Generic;

namespace BuoiThuHai
{
    public class Program
    {

        public static void Main(string[] args)
        {
            IVehicle car = new Car();
            Console.WriteLine(car.GetType().Name);
            car.StarEngine();
            car.StopEngine();
            IVehicle moto = new MotoCycle();
            Console.WriteLine(moto.GetType().Name);
            moto.StarEngine();
            moto.StopEngine();
        }

    }
}
