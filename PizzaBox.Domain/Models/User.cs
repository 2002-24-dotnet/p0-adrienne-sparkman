using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain
{
    public class User : AModel
    {
        public string Name { get; set; }
        public long UserId { get;set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> OrderHistory { get; set; }
        public Store LastLocationOrderedFrom { get; set;}
        public int LastOrderTime { get; set; }

       public User()
       {
           UserId = DateTime.Now.Ticks;
       }

        public override long GetID() {
			return UserId;
	    }

       //GetOrderHistory()

       

    }
}