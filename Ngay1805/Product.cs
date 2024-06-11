using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1805
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal CalculateTax()
        {
            return 0;
        }

        public string DisplayInfo()
        {
            return $"Id: {ProductId}, Name: {ProductName}, Price: {Price}";
        }
    }
}
