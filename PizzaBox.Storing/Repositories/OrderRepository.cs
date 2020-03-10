using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class OrderRepository : ARepository<Order>
    {
        public OrderRepository() : base(Context.Order) {
		}


        public override List<Order> Get() {
		return Table
			 .Include(p => p.Pizzas)
			// .Include(p => p.Size)
			// .Include(p => p.PizzaType)
			.ToList();
	}

        public override bool Post(Order o) {
            bool success = false;
            Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizza ON");
            Table.Add(o);
            success = Context.SaveChanges() == 1;
            Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizza OFF");
		    return success;
	    }
    }
}