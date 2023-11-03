using RestaurantConsoleApp.Models;
using RestaurantConsoleApp.Models.Drinks;
using RestaurantConsoleApp.Models.Drinks.Enums;
using RestaurantConsoleApp.Models.Foods;
using RestaurantConsoleApp.Models.Foods.Enums;

namespace RestaurantConsoleApp.Menu;

public class NormalPizzaMenuBuilder : IMenuBuilder
{
    private readonly PizzaType _pizza;
    private readonly DrinkName _drink;
    private readonly bool _tappedDrink;
    private IEnumerable<IProduct> _menu = Enumerable.Empty<IProduct>();

    public NormalPizzaMenuBuilder(PizzaType pizza, DrinkName drink, bool tappedDrink = true)
    {
        _pizza = pizza;
        _drink = drink;
        _tappedDrink = tappedDrink;
        Reset();
    }

    public void AddFood()
    {
        _menu = _menu.Append(new Pizza(_pizza, FoodSize.Normal));
    }

    public void AddDrink()
    {
        IDrink drink = _tappedDrink ? new TappedDrink(_drink) : new BottledDrink(_drink);
        _menu = _menu.Append(drink);
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