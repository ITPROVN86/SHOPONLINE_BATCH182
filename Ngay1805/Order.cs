using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1805
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public double TotalOrder()
        {
            double total = 0;
            foreach(var p in Products)
            {
                total += (double) (p.Price + p.CalculateTax());
            }
            return total;
        }

        public string DisplayInfo()
        {
            string str = $"OrderId: {OrderId}, CustomerName: {CustomerName}, OrderDate: {OrderDate}, TotalOrder: {Common.CurrencyFormat(TotalOrder().ToString())} VND";
            foreach(var p in Products)
            {
                str += "\n"+ p.DisplayInfo();
            }
            return str;
        }
    }
}
