using FPSD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





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

