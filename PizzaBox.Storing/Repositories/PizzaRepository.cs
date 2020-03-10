using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository : ARepository<Pizza>
  {

	public override bool Post(Pizza p) {
		bool success = false;
		Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizza ON");
		Table.Add(p);
		success = Context.SaveChanges() == 1;
		Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Pizza OFF");
		return success;
	}

    public override List<Pizza> Get() {
		return Table
			.Include(p => p.Crust)
			.Include(p => p.Size)
			.Include(p => p.PizzaType)
			.Include(p => p.Order)
			.ToList();
	}
	public PizzaRepository() : base(Context.Pizza) {

	}
  }
}
