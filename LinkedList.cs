using System;
using System.IO;

namespace CustomerLinkedListApp
{
    class LinkedList
    {
        private Node startnode;

        public LinkedList()
        {
            startnode = null;
        }

        public void CreateLinkedList()
        {
            string line;

            using(var fs = new FileStream("customerdb.txt", FileMode.Open, FileAccess.Read))
            using (var sr = new System.IO.StreamReader(fs))
            {
            
                while((line = sr.ReadLine()) != null)
                {
                    Customer custobj = new Customer();

                    char[] delim = new char[] { ',' };
                    string[] splits = line.Split(delim);

                    custobj.Number = Convert.ToInt32(splits[0]);
                    custobj.Company = splits[1];
                    custobj.Contact = splits[2];
                    custobj.City = splits[3];
                    custobj.State = splits[4];
                    custobj.PurchDate = splits[5];
                    custobj.TotalPurch = Convert.ToDouble(splits[6]);
                    
                    AddToList(custobj);
                }
            }
        }
        public void AddToList(Customer data)
        {
            Node n;
            Node tempnode = new Node(data);

            if(startnode == null)
            {
                startnode = tempnode;
                return;
            }

            n = startnode;

            while(n.handle != null)
                n = n.handle;
                
            n.handle = tempnode;
        }
        public void DisplayList()
        {
            BubbleSortList();

            Node n = startnode;

            while(n != null)
            {
                Console.Write(n.info.Number + " ");
                Console.Write(n.info.Company + " ");
                Console.Write(n.info.Contact + " ");
                Console.Write(n.info.City + " ");
                Console.Write(n.info.State + " ");
                Console.Write(n.info.PurchDate + " ");
                Console.Write(n.info.TotalPurch);
                Console.Write("\n");

                n = n.handle;
            }
        }

        public void SearchList(string x)
        {
            int count = 0;
            Node n = startnode;

            while(n != null)
            {
                if(n.info.Company == x)
                {
                    Console.Write(n.info.Number + " ");
                    Console.Write(n.info.Company + " ");
                    Console.Write(n.info.Contact + " ");
                    Console.Write(n.info.City + " ");
                    Console.Write(n.info.State + " ");
                    Console.Write(n.info.PurchDate + " ");
                    Console.Write(n.info.TotalPurch);
                    Console.Write("\n");
                    count++;
                }

                n = n.handle;
            }

            if(count == 0)
                {
                    Console.WriteLine("Company Not Found!");
                }        
        }

        public void NewCust()
        {
                Customer custobj = new Customer();

                Random rdm = new Random();
                int result = rdm.Next(0,1000);

                Console.WriteLine("Please enter a company name: ");
                custobj.Company = Console.ReadLine();

                Console.WriteLine("Please enter a contact name: ");
                custobj.Contact = Console.ReadLine();

                Console.WriteLine("Please enter a city: ");
                custobj.City = Console.ReadLine();

                Console.WriteLine("Please enter a state: ");
                custobj.State = Console.ReadLine();

                custobj.Number = result;
                custobj.TotalPurch = 0;
                custobj.PurchDate = "N/A";

                AddToList(custobj);
        }

        public void WriteList()
        {
            BubbleSortList();
            
            using(var fs = new FileStream("customerdb.txt", FileMode.Truncate, FileAccess.Write))
            using (var sw = new System.IO.StreamWriter(fs))
            {
                Node n = startnode;

                while(n != null)
                {
                    sw.Write(n.info.Number + ",");
                    sw.Write(n.info.Company + ",");
                    sw.Write(n.info.Contact + ",");
                    sw.Write(n.info.City + ",");
                    sw.Write(n.info.State + ",");
                    sw.Write(n.info.PurchDate + ",");
                    sw.Write(n.info.TotalPurch);
                    sw.Write(Environment.NewLine);

                    n = n.handle;
                }
            }
        }

        public void DeleteCust(int x)
            {
                if(startnode.info.Number == x)
                {
                    startnode = startnode.handle;
                    return;
                }

                Node n = startnode;

                while(n.handle != null)
                {
                    if(n.handle.info.Number == x)
                    break;
                    n = n.handle;  
                }
                if(n.handle == null)
                {
                    Console.WriteLine("Not found!");
                }
                    else
                    {
                        n.handle = n.handle.handle;
                    }
            }

        public void UpdateCust(int x)
        {
            Console.WriteLine("Please enter a date of purchase:");
            string date = Console.ReadLine();

            Console.WriteLine("Please enter a purchase amount to be added to total:");
            int amount = Convert.ToInt32(Console.ReadLine());

            Node n = startnode;

            while(n != null)
            {
                if(n.info.Number == x)
                {
                    n.info.PurchDate = date;
                    n.info.TotalPurch = n.info.TotalPurch + amount;

                    Console.Write(n.info.Number + " ");
                    Console.Write(n.info.Company + " ");
                    Console.Write(n.info.Contact + " ");
                    Console.Write(n.info.City + " ");
                    Console.Write(n.info.State + " ");
                    Console.Write(n.info.PurchDate + " ");
                    Console.Write(n.info.TotalPurch);
                    Console.Write("\n");
                }

                n = n.handle;
            }
        }
        public void BubbleSortList()
        {
            Node n, t, last;

            for(last = null; last != startnode.handle; last = n)
            {
                for(n = startnode; n.handle != last; n = n.handle)
                {
                    t = n.handle;
                    if(string.Compare (n.info.Company, t.info.Company, true) > 0)
                    {
                        Customer temp = n.info;
                        n.info = t.info;
                        t.info = temp;
                    }
                }
            }
        }

    }
}