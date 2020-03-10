using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;


namespace PizzaBox.Domain
{
    public class Order : AModel
    {
        
        public long OrderId {get;set;}
        public List<Pizza> Pizzas {get; set;}
        public decimal Total 
        {
            get
            {
                decimal sum=0;
                foreach(Pizza p in Pizzas)
                {
                    sum += p.Price;
                }
                return sum;

            }
        }
        const int costLimit = 250;
        const int pizzaLimit = 50;
        public User User { get; set;}
        public long UserId {get;set;}
        public Store Store {get;set;} 
        public long StoreId { get; set; }
        public DateTime TimeOrdered { get; set; }

        public Order()
        {
            //OrderId= DateTime.Now.Ticks;
        }

        public override long GetID() {
			return OrderId;
		}

    }
}