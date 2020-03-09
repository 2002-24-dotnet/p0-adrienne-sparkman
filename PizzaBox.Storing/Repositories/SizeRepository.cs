using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class SizeRepository : ARepository<Size>
    {
        public SizeRepository() : base(Context.Size) {

		}

        public override Size Get(long ID) {
			return Table.SingleOrDefault(s => s.SizeId == ID);
		}
        public override List<Size> Get() {
		    return Table.ToList();
	    }
    }
}