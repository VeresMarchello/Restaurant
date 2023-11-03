using RestaurantConsoleApp.Models.Foods.Enums;

namespace RestaurantConsoleApp.Models.Foods;

public class Pizza : IFood
{
    private readonly PizzaType _type;
    private readonly FoodSize _size;

    public Pizza(PizzaType type, FoodSize size = FoodSize.Normal)
    {
        _type = type;
        _size = size;
    }

    public override string ToString()
    {
        return $"{_size} {_type} Pizza ({Cost})";
    }

    public double Cost => _size switch
    {
        FoodSize.Small => 800,
        FoodSize.Normal => 1200,
        FoodSize.Large => 1500,
        _ => throw new ArgumentOutOfRangeException()
    };
}