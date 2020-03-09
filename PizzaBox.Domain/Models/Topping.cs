using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AModel
  {
    public string Name { get; set; }
    public int ToppingId { get; set; }
    public List<TypeTopping> TypeToppings { get; set; }

    public override long GetID() {
			return ToppingId;
		}

    // public Topping()
    // {
    //   ToppingId = DateTime.Now.Ticks;
    // }
  }
}
