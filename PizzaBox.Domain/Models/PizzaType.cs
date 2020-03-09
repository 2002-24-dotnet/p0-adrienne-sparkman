using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PizzaType: APizzaComponent
    {
        public long PizzaTypeId { get; set; }
        public List<TypeTopping> TypeToppings { get; set; }
        public List<Pizza> Pizzas { get; set; }

        
        public PizzaType()
        {
            PizzaTypeId = DateTime.Now.Ticks;
        }
        
        public override long GetID() {
			return PizzaTypeId;
		}
    }
}