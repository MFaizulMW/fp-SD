using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSD
{
    public class TicketQueue
    {
        private TicketNode front;
        private TicketNode rear;

        public void Enqueue(Ticket ticket, string customerName)
        {
            TicketNode newNode = new TicketNode(ticket);
            newNode.Ticket.CustomerName = customerName;
            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
        }

        public Ticket Dequeue()
        {
            if (front == null) return null;

            TicketNode ticketNode = front;
            front = front.Next;

            if (front == null)
            {
                rear = null;
            }

            return ticketNode.Ticket;
        }

        public void DisplayQueue()
        {
            if (front == null)
            {
                Console.WriteLine("No tickets in purchase queue.");
                return;
            }

            TicketNode current = front;
            while (current != null)
            {
                Console.WriteLine($"Customer: {current.Ticket.CustomerName}, Ticket: {current.Ticket.Name}, Price: {current.Ticket.Price}");
                current = current.Next;
            }
        }
    }
}
