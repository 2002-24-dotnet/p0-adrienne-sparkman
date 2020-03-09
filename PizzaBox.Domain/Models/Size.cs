using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : APizzaComponent
  {
    public long SizeId { get; set; }
    public List<Pizza> Pizzas { get; set; }


    public override long GetID() {
			return SizeId;
		}
  }
}
