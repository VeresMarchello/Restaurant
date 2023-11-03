using RestaurantConsoleApp.Models.Foods.Enums;

namespace RestaurantConsoleApp.Models.Foods;

public class Burger : IFood
{
    private readonly BurgerType _type;

    public Burger(BurgerType type)
    {
        _type = type;
    }
    public double Cost => _type switch
    {
        BurgerType.Classic => 800,
        BurgerType.Cheese => 900,
        BurgerType.BaconWithCheese => 1100,
        _ => throw new ArgumentOutOfRangeException()
    };
    
    public override string ToString()
    {
        return $"{_type} Burger ({Cost})";
    }
}