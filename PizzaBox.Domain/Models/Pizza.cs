using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
  public class Pizza : AModel
  {
    public long PizzaId { get; set; }
    public decimal Price { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public Order Order { get;set; }
    public long OrderId { get; set; }
    public Crust Crust { get; set; }
    public long CrustId { get; set; }
    public Size Size { get; set; }
    public long SizeId { get; set; }
    public PizzaType PizzaType { get; set; }
    public long PizzaTypeId { get; set; }
    //public List<PizzaTopping> PizzaToppings { get; set; }

    #endregion

    public Pizza()
    {
      //PizzaId = DateTime.Now.Ticks;
    }

    public override string ToString()
    {
      return $"{PizzaId} {Price} {Crust.Name ?? "N/A"} {Size.Name ?? "N/A"} {PizzaType.Name}";
    }

    public override long GetID() {
			return PizzaId;
		}
  }
}
