using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1805
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string DisplayInfo()
        {
            return $"Id: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: {Salary}";
        }
    }
}
