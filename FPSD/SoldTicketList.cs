using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSD
{
    public class SoldTicketList
    {
        private TicketNode head;

        public void AddSoldTicket(Ticket ticket)
        {
            TicketNode newNode = new TicketNode(ticket);
            newNode.Next = head;
            head = newNode;
        }

        public void DisplaySoldTickets()
        {
            if (head == null)
            {
                Console.WriteLine("No ticket were sold.");
                return;
            }

            TicketNode current = head;
            while (current != null)
            {
                Console.WriteLine($"Customer: {current.Ticket.CustomerName}, Ticket: {current.Ticket.Name}, Price: {current.Ticket.Price}");
                current = current.Next;
            }
        }
    }
}
