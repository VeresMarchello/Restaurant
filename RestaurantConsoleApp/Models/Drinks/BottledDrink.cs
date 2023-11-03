using RestaurantConsoleApp.Models.Drinks.Enums;

namespace RestaurantConsoleApp.Models.Drinks;

public class BottledDrink : IDrink
{
    public double Cost => 500;
    public DrinkName Name { get; }

    public BottledDrink(DrinkName drinkName)
    {
        Name = drinkName;
    }
    
    public override string ToString()
    {
        return $"{Name} ({Cost})";
    }
}