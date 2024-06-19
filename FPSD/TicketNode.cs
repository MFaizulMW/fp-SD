using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSD
{
    public class TicketNode
    {
        public Ticket Ticket { get; set; }
        public TicketNode Next { get; set; }

        public TicketNode(Ticket ticket)
        {
            Ticket = ticket;
        }
    }
}
