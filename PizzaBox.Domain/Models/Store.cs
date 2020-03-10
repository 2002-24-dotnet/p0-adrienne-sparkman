using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain
{
    public class Store : AModel
    {
        public long StoreId { get; set; } 
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> OrderHistory { get; set; }

        public Store()
        {
            //StoreId = DateTime.Now.Ticks;
        }

        public override long GetID() {
			return StoreId;
		}
        
        

    }
}