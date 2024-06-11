using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1805
{
    public class Manager: Employee
    {
        public string Department {  get; set; }
        public new string DisplayInfo()
        {
            return base.DisplayInfo()+  $", Department: {Department}";
        }
    }
}
