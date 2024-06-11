using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuBa
{
    public class Parameters
    {
        public delegate void Display(string mess, int num);
        public static void Main(string[] args)
        {
            Display display = (mess,num)=>Console.WriteLine(mess+num);
            display("Gia tri cua number: ",100);
            display("Sum: ", Sum(100, 150));
            Console.ReadLine();
        }
        public static int Sum(int a, int b) => a + b;
    }
}
