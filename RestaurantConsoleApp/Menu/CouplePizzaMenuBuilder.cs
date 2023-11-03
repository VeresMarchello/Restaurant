using RestaurantConsoleApp.Models;
using RestaurantConsoleApp.Models.Drinks;
using RestaurantConsoleApp.Models.Drinks.Enums;
using RestaurantConsoleApp.Models.Foods;
using RestaurantConsoleApp.Models.Foods.Enums;

namespace RestaurantConsoleApp.Menu;

public class CouplePizzaMenuBuilder : IMenuBuilder
{
    private readonly PizzaType _pizza;
    private readonly DrinkName _drink1;
    private readonly DrinkName _drink2;
    private IEnumerable<IProduct> _menu = Enumerable.Empty<IProduct>();

    public CouplePizzaMenuBuilder(PizzaType pizza, DrinkName drink1, DrinkName drink2)
    {
        _pizza = pizza;
        _drink1 = drink1;
        _drink2 = drink2;
        Reset();
    }

    public void AddFood()
    {
        _menu = _menu.Append(new Pizza(_pizza, FoodSize.Large));
    }

    public void AddDrink()
    {
        _menu = _menu.Append(new TappedDrink(_drink1, DrinkSize.Medium));
        _menu = _menu.Append(new TappedDrink(_drink2, DrinkSize.Medium));
    }

    public void Reset()
    {
        _menu = Enumerable.Empty<IProduct>();
    }

    public IEnumerable<IProduct> GetMenu()
    {
        var results = _menu;
        Reset();

        return results;
    }
}