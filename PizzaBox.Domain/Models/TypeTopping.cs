using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class TypeTopping
  {
    public long PizzaTypeId { get; set; }
    public PizzaType PizzaType { get; set; }
    public int ToppingId { get; set; }
    public Topping Topping { get; set; }
  }
}
