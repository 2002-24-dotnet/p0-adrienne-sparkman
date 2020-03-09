using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class UserRepository : ARepository<User>
    {
        public UserRepository() : base(Context.User) {

		}
    }
}