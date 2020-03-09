using PizzaBox.Storing.Repositories;
using PizzaBox.Client.Singletons;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class PizzaTests
  {
    [Fact]
    public void Test_RepositoryGet()
    {
      var sut = new PizzaRepository();
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

  }
}
