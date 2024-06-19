using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSD
{
    public class TicketList
    {
        private TicketNode head;

        public void AddTicket(Ticket ticket)
        {
            TicketNode newNode = new TicketNode(ticket);
            newNode.Next = head;
            head = newNode;
        }

        public void DisplayTickets()
        {
            TicketNode current = head;
            while (current != null)
            {
                Console.WriteLine($"Name: {current.Ticket.Name}, Price: {current.Ticket.Price}");
                current = current.Next;
            }
        }
    }
}
