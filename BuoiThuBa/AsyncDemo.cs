using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuBa
{
    public class AsyncDemo
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine($"Time: {DateTime.Now}");
            await Task.Delay(3000);
            Console.WriteLine($"Time: {DateTime.Now}");
            Console.Read();
        }
    }
}
