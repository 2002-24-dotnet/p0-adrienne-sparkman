using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
    public class UserMenuSingleton
    {
        private static readonly UserMenuSingleton _ums = new UserMenuSingleton();
        public static UserMenuSingleton Instance
        {
            get
            {
                return _ums;
            }
        }
        private UserMenuSingleton(){}
        private static readonly UserRepository _ur = new UserRepository();
        private static readonly PizzaRepository _pr = new PizzaRepository();
        private static readonly OrderRepository _or = new OrderRepository();
        private static readonly SizeRepository _sr = new SizeRepository();
        private static readonly StoreRepository _str = new StoreRepository();
        private static readonly CrustRepository _cr = new CrustRepository();
        private static readonly PizzaTypeRepository _tr = new PizzaTypeRepository();
        private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;
        private static readonly OrderSingleton _os = OrderSingleton.Instance;

        public User Login()
        {
            bool LoggedIn=false;

            string UsernameIn;
            string PasswordIn;
            User x=null;
            while(LoggedIn == false)
            {
                Console.WriteLine("Enter username:");
                UsernameIn = Console.ReadLine();
                Console.WriteLine("Enter password:");
                PasswordIn = Console.ReadLine();
                foreach(User u in _ur.Get())
                {
                    if(UsernameIn == u.Username && PasswordIn == u.Password)
                    {
                        LoggedIn=true;
                        x = u;
                        Console.WriteLine("\nWelcome, " + x.Name);
                        Program.LoggedUser = u;
                        UserMenuMain();
                    }
                }
                if(x==null)
                {
                    Console.WriteLine("Incorrect username or password");
                }

            }
            return x;
        }


        public void UserMenuMain()
        {
            bool MovedOn = false;
            string input = "";
            while(MovedOn!=true)
            {
                
                Console.WriteLine("\nO - Place an order \t\t H - View order history \t\t X - Log Out");
                input = Console.ReadLine().ToUpper();
                if(string.Equals(input, "O"))
                {
                    OrderPlace();
                    MovedOn=true;
                }
                else if(string.Equals(input, "H"))
                {
                    ViewOrderHistory();
                    MovedOn=true;
                }
                else if(string.Equals(input, "X"))
                {
                    Program.LoggedUser=null;
                    Program.Intro();
                    MovedOn=true;
                }
                else
                    {Console.WriteLine("Invalid Input");}
            }
        }

        internal void ViewOrderHistory()
        {

            Console.WriteLine("\nOrder ID\tTotal\t\tStore");
            foreach(Order o in _or.Get())
            {
                string StoreName = "";
                if (Program.LoggedUser.UserId == o.UserId)
                {
                    foreach(Store s in _str.Get())
                    {
                        if (o.StoreId == s.StoreId)
                        {
                            StoreName = s.Name;
                        }
                    }

                    Console.WriteLine(o.OrderId + "\t\t" + o.Total + "\t\t" + StoreName);
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
                if(string.Equals(input, o.OrderId.ToString()) && Program.LoggedUser.UserId == o.UserId)
                {
                    string StoreName = "";
                    foreach(Store s in _str.Get())   
                    {
                        if (o.StoreId == s.StoreId)
                        {
                            StoreName = s.Name;
                        }
                    }
                    Console.WriteLine("\n\nOrder Id\t\tTotal\tStore");
                    Console.WriteLine(o.OrderId + "\t\t\t" + o.Total + "\t" + StoreName);
                    Console.WriteLine("\n\nPizza Id\tPizza\t\t\t\t\tPrice");
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
                    UserMenuMain();
                }
                else Console.WriteLine("Invalid input");
            }    
        }
        
        public Size GetSize()
        {
            string input="";
            bool ValidInput = false;
            while(ValidInput == false)
            {
                foreach(Size s in _sr.Get())
                {
                    Console.WriteLine(s.Name + "\t$" + s.Price);
                }
                Console.WriteLine("Select your size:");
                Console.WriteLine("S - Small \t\tM - Medium \t\tL - Large");
                input = Console.ReadLine().ToUpper();
                if (string.Equals(input, "S"))
                {
                    foreach(Size s in _sr.Get())
                    {
                        if (string.Equals(s.Name, "Small"))
                        {
                            ValidInput = true;
                            return s;
                        }
                    }                    
                }
                else if (string.Equals(input, "M"))
                {
                    foreach(Size s in _sr.Get())
                    {
                        if (string.Equals(s.Name, "Medium"))
                        {
                            ValidInput = true;
                            return s;
                        }
                    }
                }
                else if (string.Equals(input, "L"))
                {
                    foreach(Size s in _sr.Get())
                    {
                        if (string.Equals(s.Name, "Large"))
                        {
                            ValidInput = true;
                            return s;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return new Size();
        }

        public Crust GetCrust()
        {
            string input="";
            bool ValidInput = false;
            while(ValidInput == false)
            {
                foreach(Crust c in _cr.Get())
                {
                    Console.WriteLine(c.Name + "\t$" + c.Price);
                }
                Console.WriteLine("\nSelect your crust type:");
                Console.WriteLine("HT - Handtossed \t\tNY - New York \t\tTC - Thin Crust");
                Console.WriteLine("DD - Deep Dish \t\t\tGF - Gluten Free");
                
                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "HT":
                        foreach(Crust c in _cr.Get())
                        {
                            
                            if (string.Equals(c.Name, "Hand Tossed"))
                            {
                                
                                ValidInput = true;
                                return c;
                            }
                            
                        }
                        break;
                    case "NY":
                        foreach(Crust c in _cr.Get())
                        {
                            if (string.Equals(c.Name, "New York Style"))
                            {
                                ValidInput = true;
                                return c;
                            }
                        }
                        break;
                    case "TC":
                        foreach(Crust c in _cr.Get())
                        {
                            if (string.Equals(c.Name, "Thin Crust"))
                            {
                                ValidInput = true;
                                return c;
                            }
                        }
                        break;
                    case "DD":
                        foreach(Crust c in _cr.Get())
                        {
                            if (string.Equals(c.Name, "Deep Dish"))
                            {
                                ValidInput = true;
                                return c;
                            }
                        }
                        break;
                    case "GF":
                        foreach(Crust c in _cr.Get())
                        {
                            if (string.Equals(c.Name, "Gluten Free"))
                            {
                                ValidInput = true;
                                return c;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }      
            }
            return new Crust();
        }
    
        public PizzaType GetPizzaType()
        {
            string input="";
            bool ValidInput = false;
            while(ValidInput == false)
            {
                foreach(PizzaType t in _tr.Get())
                {
                    Console.WriteLine(t.Name + "\t$" + t.Price);
                }
                Console.WriteLine("Select your Pizza:");
                Console.WriteLine("CH - Cheese \t\tPP - Pepperoni \t\tMT - All Meat");
                Console.WriteLine("SS - Super Supreme \t\tHW - Hawaiian");
                
                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "CH":
                        foreach(PizzaType t in _tr.Get())
                        {
                            if (string.Equals(t.Name, "Cheese"))
                            {
                                ValidInput = true;
                                return t;
                            }
                        }
                        break;
                    case "PP":
                        foreach(PizzaType t in _tr.Get())
                        {
                            if (string.Equals(t.Name, "Pepperoni"))
                            {
                                ValidInput = true;
                                return t;
                            }
                        }
                        break;
                    case "MT":
                        foreach(PizzaType t in _tr.Get())
                        {
                            if (string.Equals(t.Name, "All Meat"))
                            {
                                ValidInput = true;
                                return t;
                            }
                        }
                        break;
                    case "SS":
                        foreach(PizzaType t in _tr.Get())
                        {
                            if (string.Equals(t.Name, "Super Supreme"))
                            {
                                ValidInput = true;
                                return t;
                            }
                        }
                        break;
                    case "HW":
                        foreach(PizzaType t in _tr.Get())
                        {
                            if (string.Equals(t.Name, "Hawaiian"))
                            {
                                ValidInput = true;
                                return t;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }      
            }
            return new PizzaType();
        }

        public Order OrderPlace()
        {
            Order o = new Order();

            Store s = SelectStore();
            o.StoreId = s.StoreId;

            User u = Program.LoggedUser;
            o.UserId = u.UserId;
            //o.User = u;

            o.Pizzas = new List<Pizza> {};

            bool OrderConfirmed=false;
            bool validinput = false;
            string input = "";
            while(OrderConfirmed==false)
            {
                //print order so far
                Console.WriteLine("\n" + u.Name + "\t\t\tStore: " + s.Name + "\n");
                foreach(Pizza p in o.Pizzas)
                {
                    Console.WriteLine(_sr.Get(p.SizeId).Name + " " +_cr.Get(p.CrustId).Name + " " +_tr.Get(p.PizzaTypeId).Name + "\t\t$" + p.Price);
                }
                Console.WriteLine("\n\n" + o.Pizzas.Count + " Pizzas\t\t$" + o.Total);

                validinput=false;
                while(validinput==false)
                {
                    Console.WriteLine("C - Confirm Order\tA - Add Pizza\t X - Cancel Order");
                    input = Console.ReadLine().ToUpper();
                    if (string.Equals(input, "C"))
                    {
                          if(o.Pizzas.Count >=1 && o.Pizzas.Count <=25 && o.Total<=250)
                          {
                              validinput = true;
                              OrderConfirmed = true;
                              OrderConfirm(o);
                              return o;
                          }            
                          else if (o.Pizzas.Count<1)
                          {
                              Console.WriteLine("You must have at least one pizza in order");
                          }
                          else if(o.Pizzas.Count >25)
                          {
                              Console.WriteLine("The maximum number of pizzas in an order is 25, you have " + o.Pizzas.Count);
                          }
                          else if(o.Total >25)
                          {
                              Console.WriteLine("The maximum order size is $250, your total is currently " + o.Total);
                          }
                    }
                    else if (string.Equals(input, "A"))
                    {
                        validinput = true;
                        o.Pizzas.Add(CreatePizza(o.OrderId));
                    }
                    else if (string.Equals(input, "X"))
                    {
                        validinput=true;
                        OrderConfirmed = true;
                        UserMenuMain();
                        return null;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input\n");
                    }
                }

            }

            return o;
        }

        public Store SelectStore()
        {
            string input="";
            bool ValidInput = false;
            while(ValidInput == false)
            {
                Console.WriteLine("\nWhich store do you want to order from?:");
                Console.WriteLine("1 - Big Rico's Grease Extravaganza");
                Console.WriteLine("2 - Peace of Pie");
                Console.WriteLine("3 - 'za by Tony");
                input = Console.ReadLine();
                if (string.Equals(input, "1"))
                {
                    foreach(Store s in _str.Get())
                    {
                        if (string.Equals(s.Name, "Big Rico's Grease Extravaganza"))
                        {
                            ValidInput = true;
                            return s;
                        }
                    }                    
                }
                else if (string.Equals(input, "2"))
                {
                    foreach(Store s in _str.Get())
                    {
                        if (string.Equals(s.Name, "Peace of Pie"))
                        {
                            ValidInput = true;
                            return s;
                        }
                    }
                }
                else if (string.Equals(input, "3"))
                {
                    foreach(Store s in _str.Get())
                    {
                        if (string.Equals(s.Name, "'za by Tony"))
                        {
                            ValidInput = true;
                            return s;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return new Store();
        }
        public Pizza CreatePizza(long O_Id)
        {
            var s = GetSize();
            var c = GetCrust();
            var t = GetPizzaType();
            string input = "";
            bool confirmed=false;


            var p = new Pizza(){
                SizeId = s.SizeId, CrustId = c.CrustId, PizzaTypeId = t.PizzaTypeId
            };
            p.Price =s.Price+c.Price+t.Price;
            Console.WriteLine("\n\nYour Pizza:");
            Console.WriteLine(s.Name + " " +c.Name + " " +t.Name + "\t\t$" + p.Price);
            Console.WriteLine("Add this pizza to order? [Y/N]");
            input = Console.ReadLine().ToUpper();
            while(confirmed==false)
            {
                if(string.Equals(input, "Y"))
                {
                    c.Pizzas = new List<Pizza>{p};
                    s.Pizzas = new List<Pizza>{p};
                    t.Pizzas = new List<Pizza>{p};
                    confirmed = true;
                    return p;
                }
                else if(string.Equals(input, "N"))
                {
                    confirmed=true;
                    return CreatePizza(O_Id);
                }
                else Console.WriteLine("Invalid input");
            }
            return new Pizza();

        }
    
        public void OrderConfirm(Order o)
        {
            bool OrderPosted=false;
            o.TimeOrdered=DateTime.Now;
            OrderPosted=_os.Post(o);
            UserMenuMain();
        }
    }

}