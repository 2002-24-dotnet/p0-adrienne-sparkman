using System;
using PizzaBox.Domain;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{
    public class StoreMenuSingleton
    {
        private static readonly StoreMenuSingleton _sms = new StoreMenuSingleton();
        public static StoreMenuSingleton Instance
        {
            get
            {
                return _sms;
            }
        }
        private StoreMenuSingleton(){}

        private static readonly UserRepository _ur = new UserRepository();
        private static readonly PizzaRepository _pr = new PizzaRepository();
        private static readonly OrderRepository _or = new OrderRepository();
        private static readonly SizeRepository _sr = new SizeRepository();
        private static readonly StoreRepository _str = new StoreRepository();
        private static readonly CrustRepository _cr = new CrustRepository();
        private static readonly PizzaTypeRepository _tr = new PizzaTypeRepository();

        public Store Login()
        {
            bool LoggedIn=false;
            string UsernameIn;
            string PasswordIn;
            Store x=null;
            while(LoggedIn == false)
            {
                Console.WriteLine("Enter username:");
                UsernameIn = Console.ReadLine();
                Console.WriteLine("Enter password:");
                PasswordIn = Console.ReadLine();
                foreach(Store s in _str.Get())
                {
                    if(UsernameIn == s.Username && PasswordIn == s.Password)
                    {
                        LoggedIn=true;
                        x = s;
                        Console.WriteLine("\nWelcome, " + x.Name);
                        Program.LoggedStore = s;
                        StoreMenuMain();
                    }
                }
                if(x==null)
                {
                    Console.WriteLine("Incorrect username or password");
                }

            }
            return x;
        }

        public void StoreMenuMain()
        {
            bool MovedOn = false;
            string input = "";
            while(MovedOn!=true)
            {
                
                Console.WriteLine("\nH - View order history\t\tS - Sales\t\tX - Log Out");
                input = Console.ReadLine().ToUpper();
                if(string.Equals(input, "S"))
                {
                    ViewSales();
                    MovedOn=true;
                }
                else if(string.Equals(input, "H"))
                {
                    ViewOrderHistory();
                    MovedOn=true;
                }
                else if(string.Equals(input, "X"))
                {
                    Program.LoggedStore=null;
                    Program.Intro();
                    MovedOn=true;
                }
                else
                    {Console.WriteLine("Invalid Input");}
            }
        }

        internal void ViewSales()
        {
            
        }

        internal void ViewOrderHistory()
        {
            Console.WriteLine("\nOrder ID\tUser\t\t\tTotal");
            foreach(Order o in _or.Get())
            {
                string UsersName = "";
                if (Program.LoggedStore.StoreId == o.StoreId)
                {
                    foreach(User s in _ur.Get())
                    {
                        if (o.UserId == s.UserId)
                        {
                            UsersName = s.Name;
                        }
                    }

                    Console.WriteLine(o.OrderId + "\t\t" + UsersName + "\t\t$" + o.Total);
                }
            }
            OrderViewMenu();
        }

        internal void ViewOrder()
        {
            Console.WriteLine("\nEnter the ID of the order you want to view:");
            string input = Console.ReadLine();
            foreach(Order o in _or.Get())
            {
                if(string.Equals(input, o.OrderId.ToString()) && Program.LoggedStore.StoreId == o.StoreId)
                {
                    string UsersName = "";
                    foreach(User u in _ur.Get())   
                    {
                        if (o.UserId == u.UserId)
                        {
                            UsersName = u.Name;
                        }
                    }
                    Console.WriteLine("\n\nOrder Id\tTotal\t\tCustomer");
                    Console.WriteLine(o.OrderId + "\t\t$" + o.Total + "\t\t" + UsersName);
                    Console.WriteLine("\nPizza Id\tPizza\t\t\t\t\tPrice");
                    foreach(Pizza p in _pr.Get())
                    {
                        if (p.OrderId == o.OrderId)
                        {
                            Console.WriteLine(p.PizzaId + "\t\t" + p.Size.Name + " " + p.Crust.Name + " " + p.PizzaType.Name + "\t\t$" + p.Price);
                        }
                    }
                    //Order Id, Total, location placed
                    //p1 size crust type      total
                    //etc
                    
                    
                    OrderViewMenu();
                }
            }
        }
        internal void OrderViewMenu()
        {
            bool inputselected = false;
            while(inputselected==false)
            {
                Console.WriteLine("V - View an order\t\tX - Back");
                string input = Console.ReadLine().ToUpper();
                if (string.Equals(input, "V"))
                {
                    inputselected = true;
                    ViewOrder();
                }
                else if (string.Equals(input, "X"))
                {
                    inputselected = true;
                    StoreMenuMain();
                }
                else Console.WriteLine("Invalid input");
            }    
        }

        // RunStoreMenu()
        // {
        //     Login();
        //     //select screen: Order History, Inventory, Sales
        //     if(orderhistory)
        //     {
        //         ShowOrderHistoryInRange(1 week);
        //         //Enter user.Id, Order.Id, or Time
        //         if(user.Id)
        //         {
        //             OrderHistoryWhere(user.Id, store);
        //         }
        //         else if(Order.Id)
        //         {
        //             ViewOrder(Order.Id);
        //         }
        //         else if(time)
        //         {
        //             ShowOrderHistoryInRange(time);
        //         }
        //     }
        //     else if(inventory)
        //     {

        //     }
        //     else if(sales)
        //     {
        //         //TODO: Come back to this
        //         //show pizza types, count, revenue
        //     }
        //}


    }
}