using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class StoreRepository : ARepository<Store>
    {
        public StoreRepository() : base(Context.Store) {

		}
    }
}