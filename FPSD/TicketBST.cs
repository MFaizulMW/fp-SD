using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSD
{
    public class TicketBST
    {
        private TicketBSTNode root;

        public void AddTicket(Ticket ticket)
        {
            root = AddTicket(root, ticket);
        }


        private TicketBSTNode AddTicket(TicketBSTNode node, Ticket ticket)
        {
            if (node == null)
            {
                return new TicketBSTNode { Ticket = ticket };
            }

            int comparison = string.Compare(ticket.Name, node.Ticket.Name, StringComparison.OrdinalIgnoreCase);
            if (comparison < 0)
            {
                node.Left = AddTicket(node.Left, ticket);
            }
            else if (comparison > 0)
            {
                node.Right = AddTicket(node.Right, ticket);
            }

            return node;
        }

        public Ticket Search(string name)
        {
            return Search(root, name);
        }

        private Ticket Search(TicketBSTNode node, string name)
        {
            if (node == null) return null;

            int comparison = string.Compare(name, node.Ticket.Name, StringComparison.OrdinalIgnoreCase);
            if (comparison == 0)
            {
                return node.Ticket;
            }
            else if (comparison < 0)
            {
                return Search(node.Left, name);
            }
            else
            {
                return Search(node.Right, name);
            }
        }
    }
}
