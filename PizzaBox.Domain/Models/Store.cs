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
        
        //TODO: getorders()
            //See list of recent orders as:
            //order number----time----user----order total
            //xxxx            tttt    [user]  $yy.yy
        //TODO: getorders(user)
            //see list of recent orders by user as:
            //order number----time----order total
            //xxxx            tttt    $yy.yy
        
        //TODO:vieworder(ordernumber)
            //see, in order:
            //user      order number
            //time ordered
            //order total
            //list of all items

        //TODO: getsales() (parameter as a range of time)
            //return within time range:
            //Pizza type    Count   Revenue
            //pizza1        xx      $yy.yy
            //pizza2        xx      $yy.yy
            //etc

        //TODO: getinventory()
            //

    }
}