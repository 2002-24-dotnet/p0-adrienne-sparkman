using System;
using PizzaBox.Domain;
using PizzaBox.Storing.Repositories;

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

        private static readonly StoreRepository _sr = new StoreRepository();

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
                foreach(Store s in _sr.Get())
                {
                    if(UsernameIn == s.Username && PasswordIn == s.Password)
                    {
                        LoggedIn=true;
                        x = s;
                        Console.WriteLine("Welcome, " + x.Name);
                    }
                }
                if(x==null)
                {
                    Console.WriteLine("Incorrect username or password");
                }

            }
            return x;
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