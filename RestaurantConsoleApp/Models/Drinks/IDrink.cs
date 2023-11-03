using RestaurantConsoleApp.Models.Drinks.Enums;

namespace RestaurantConsoleApp.Models.Drinks;

public interface IDrink : IProduct
{
    DrinkName Name { get; }
}