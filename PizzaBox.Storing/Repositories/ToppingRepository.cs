using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class ToppingRepository : ARepository<Topping>
    {
        public ToppingRepository() : base(Context.Topping) {

		}
    }
}