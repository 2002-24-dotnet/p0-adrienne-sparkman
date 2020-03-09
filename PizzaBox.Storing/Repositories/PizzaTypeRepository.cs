using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class PizzaTypeRepository : ARepository<PizzaType>
    {
        public PizzaTypeRepository() : base(Context.Type) {


		}

        public override PizzaType Get(long ID) {
			return Table.SingleOrDefault(t => t.PizzaTypeId == ID);
		}
    }
}