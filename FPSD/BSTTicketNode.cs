using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSD
{
    public class TicketBSTNode
    {
        public Ticket Ticket { get; set; }
        public TicketBSTNode Left { get; set; }
        public TicketBSTNode Right { get; set; }
    }
}
