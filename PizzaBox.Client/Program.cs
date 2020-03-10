using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;
    private static readonly UserMenuSingleton _ums = UserMenuSingleton.Instance;
    private static readonly StoreMenuSingleton _sms = StoreMenuSingleton.Instance;

    public static User LoggedUser = new User();
    public static Store LoggedStore = new Store();

    private static void Main(string[] args)
    {
      Intro();
    }

    private static void GetAllPizzas()
    {
      foreach (var p in _ps.Get())
      {
        Console.WriteLine(p);
      }
    }

    private static void PostAllPizzas()
    {
  
    }

    public static void Intro()
    {
      string input="";
      bool PassedToLogin =false;
      Console.WriteLine("Welcome to Pizza");
      while(PassedToLogin == false){
        Console.WriteLine("Press U for User Login, and S for Store Login:");
        input = Console.ReadLine().ToUpper();
        if (string.Equals(input, "S"))
        {
          _sms.Login();
          PassedToLogin = true;
        }
        else if (string.Equals(input, "U"))
        {
          LoggedUser = _ums.Login();
          PassedToLogin = true;
        }
        else{
          Console.WriteLine("Invalid input");
        }
      }

    }
  }
}
