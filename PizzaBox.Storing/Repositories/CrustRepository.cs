using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace PizzaBox.Storing.Repositories
{
    public class CrustRepository : ARepository<Crust>
    {
        public CrustRepository() : base(Context.Crust) {

		}

        public override Crust Get(long ID) {
			return Table.SingleOrDefault(c => c.CrustId == ID);
		}
    }
}