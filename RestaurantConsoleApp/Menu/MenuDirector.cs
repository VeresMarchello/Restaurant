using RestaurantConsoleApp.Models;

namespace RestaurantConsoleApp.Menu;

public class MenuDirector
{
    private readonly IMenuBuilder _builder;

    public MenuDirector(IMenuBuilder builder)
    {
        _builder = builder;
    }

    public IEnumerable<IProduct> BuildMenu()
    {
        _builder.AddFood();
        _builder.AddDrink();
        return _builder.GetMenu();
    }
}