using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
    public abstract class ARepository<T> where T : AModel
    {
        protected static readonly PizzaBoxDbContext Context = new PizzaBoxDbContext();
		protected DbSet<T> Table = null;
		public ARepository(DbSet<T> table) {
			Table = table;
		}
		public virtual List<T> Get() {
			return Table.ToList();
		}
		public virtual T Get(long ID) {
			return Table.SingleOrDefault(t => t.GetID() == ID);
		}
		public virtual bool Post(T entity) {
			Table.Add(entity);
			return Context.SaveChanges() == 1;
		}
		public bool Put(T entity) {
			T t = Get(entity.GetID());
			t = entity;
			return Context.SaveChanges() == 1;
		}
		public bool Delete(T entity) {
			Table.Remove(entity);
			return Context.SaveChanges() == 1;
		}
	}
}
