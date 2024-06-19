using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSD
{
    public class Ticket
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string CustomerName { get; set; }

        public Ticket(String name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
