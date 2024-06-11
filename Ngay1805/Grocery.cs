using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1805
{
    internal class Grocery: Product
    {
        public new decimal CalculateTax()
        {
            return Price * 0.05M;
        }
    }
}
