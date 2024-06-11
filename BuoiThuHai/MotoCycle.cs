using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuHai
{
    public class MotoCycle: IVehicle
    {
        public void StarEngine()
        {
            Console.WriteLine("MotoCycle start Engine");
        }

        public void StopEngine()
        {
            Console.WriteLine("MotoCycle stop Engine");
        }
    }
}
