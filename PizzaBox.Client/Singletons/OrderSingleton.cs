using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
    public class OrderSingleton
    {
        private static readonly OrderSingleton _os= new OrderSingleton();

        public static OrderSingleton Instance
        {
            get
            {
                return _os;
            }
        }
        private OrderSingleton(){}



        private static readonly OrderRepository _or = new OrderRepository();

        public List<Order> Get()
        {
            return _or.Get();
        }

        public bool Post(Order p)
        {
            return _or.Post(p);
        }

    }
}