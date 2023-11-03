using RestaurantConsoleApp.Models.Drinks.Enums;

namespace RestaurantConsoleApp.Models.Drinks;

public class TappedDrink : IDrink
{
    public TappedDrink(DrinkName drinkName, DrinkSize size = DrinkSize.Medium)
    {
        Name = drinkName;
        Size = size;
    }

    public override string ToString()
    {
        return $"{Size} {Name} ({Cost})";
    }

    public double Cost => Size switch
    {
        DrinkSize.Large => 500,
        DrinkSize.Medium => 300,
        DrinkSize.Small => 200,
        _ => throw new ArgumentOutOfRangeException()
    };

    public DrinkName Name { get; }
    public DrinkSize Size { get; }
}