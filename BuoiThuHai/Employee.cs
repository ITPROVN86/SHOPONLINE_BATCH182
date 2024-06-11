using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuHai
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                Id = 1,
                Name = "Nguyen Van An"
            };
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}");
        }
    }
}
