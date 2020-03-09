using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class PizzeriaSingleton
  {
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly SizeRepository _sr = new SizeRepository();
    private static readonly PizzeriaSingleton _ps = new PizzeriaSingleton();
    private static readonly UserMenuSingleton _ums = UserMenuSingleton.Instance;

    public static PizzeriaSingleton Instance
    {
      get
      {
        return _ps;
      }
    }

    private PizzeriaSingleton() { }


    public List<Pizza> Get()
    {
      return _pr.Get();
    }

    public bool Post(Pizza p)
    {
      return _pr.Post(p);
    }
  }
}