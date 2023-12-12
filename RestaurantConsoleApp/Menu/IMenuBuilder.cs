using RestaurantConsoleApp.Models;

namespace RestaurantConsoleApp.Menu;

public interface IMenuBuilder
{
    void AddFood();
    void AddDrink();
    IEnumerable<IProduct> GetMenu();
}