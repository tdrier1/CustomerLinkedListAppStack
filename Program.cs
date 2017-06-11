using System;

namespace CustomerLinkedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList customerlist = new LinkedList();

            customerlist.CreateLinkedList();

            Console.WriteLine("CUSTOMER LIST ");
            Console.WriteLine("\n");
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1: View Sorted Customer List");
            Console.WriteLine("2: Search By Company Name");
            Console.WriteLine("3: Add A Customer to List");
            Console.WriteLine("4: Delete A Customer from List");
            Console.WriteLine("5: Exit");
            Console.WriteLine("++++++++++++++++++++++++++");
            int choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 1)
            {
                customerlist.DisplayList();
            }
            if(choice == 2)
            {
                Console.WriteLine("Please enter a company name: ");
                string x = Console.ReadLine();
                customerlist.SearchList(x);
            }
            if(choice == 3)
            {
                customerlist.NewCust();
                customerlist.WriteList();
            }
            if(choice == 4)
            {
                Console.WriteLine("Please enter a number to delete: \n");         
                customerlist.DisplayList();
                int x = Convert.ToInt32(Console.ReadLine());
                customerlist.DeleteCust(x);
                customerlist.DisplayList();
                customerlist.WriteList();
            }
        }
    }
}
