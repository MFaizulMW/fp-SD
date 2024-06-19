using System;

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

public class TicketNode
{
    public Ticket Ticket { get; set; }
    public TicketNode Next { get; set; }

    public TicketNode(Ticket ticket)
    {
        Ticket = ticket;
    }
}

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
        var current = head;
        while (current != null)
        {
            Console.WriteLine($"Name: {current.Ticket.Name}, Price: {current.Ticket.Price}");
            current = current.Next;
        }
    }
}

public class TicketBSTNode
{
    public Ticket Ticket { get; set; }
    public TicketBSTNode Left { get; set; }
    public TicketBSTNode Right { get; set; }
}

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

public class Program
{
    

    public static void Main()
    {
        TicketList ticketList = new TicketList();
        TicketBST ticketBST = new TicketBST();
        TicketQueue purchaseQueue = new TicketQueue();
        SoldTicketList soldTicketList = new SoldTicketList();


        // Initialize some tickets
        Ticket tk1 = new Ticket("Yogyakarta", 150);
        Ticket tk2 = new Ticket("Bandung", 350);
        Ticket tk3 = new Ticket("Banyuwangi", 200);

        ticketList.AddTicket(tk1);
        ticketList.AddTicket(tk2);
        ticketList.AddTicket(tk3);

        ticketBST.AddTicket(tk1);
        ticketBST.AddTicket(tk2);
        ticketBST.AddTicket(tk3);

        while (true)
        {
            Console.WriteLine("\n1. View Available Tickets");
            Console.WriteLine("2. Search Ticket by Destination");
            Console.WriteLine("3. Purchase Ticket");
            Console.WriteLine("4. View Purchase Queue");
            Console.WriteLine("5. Process Purchase");
            Console.WriteLine("6. View Sold Tickets");
            Console.WriteLine("7. Exit");

            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                ticketList.DisplayTickets();
            }
            else if (choice == "2")
            {
                Console.Write("\nEnter ticket name to search: ");
                string searchName = Console.ReadLine();
                Ticket searchedTicket = ticketBST.Search(searchName);
                if (searchedTicket != null)
                {
                    Console.WriteLine($"Name: {searchedTicket.Name}, Price: {searchedTicket.Price}");
                }
                else
                {
                    Console.WriteLine("Ticket not found.");
                }
            }
            else if (choice == "3")
            {
                Console.Write("\nEnter ticket name to purchase: ");
                string purchaseName = Console.ReadLine();
                Ticket ticketToPurchase = ticketBST.Search(purchaseName);
                if (ticketToPurchase != null)
                {
                    Console.Write("\nEnter customer name: ");
                    string customerName = Console.ReadLine();
                    purchaseQueue.Enqueue(ticketToPurchase, customerName);
                    Console.WriteLine("Ticket added to purchase queue.");
                }
                else
                {
                    Console.WriteLine("Ticket not found.");
                }
            }
            else if (choice == "4")
            {
                purchaseQueue.DisplayQueue();
            }
            else if (choice == "5")
            {
                Ticket processedTicket = purchaseQueue.Dequeue();
                if (processedTicket != null)
                {
                    Console.WriteLine($"Processing purchase for ticket: Name: {processedTicket.Name}, Price: {processedTicket.Price}, Customer: {processedTicket.CustomerName}");
                    soldTicketList.AddSoldTicket(processedTicket);
                }
                else
                {
                    Console.WriteLine("No tickets to process.");
                }
            }
            else if (choice == "6")
            {
                soldTicketList.DisplaySoldTickets();
            }
            else if (choice == "7")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
