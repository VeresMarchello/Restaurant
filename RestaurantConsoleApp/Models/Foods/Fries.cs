using RestaurantConsoleApp.Models.Foods.Enums;

namespace RestaurantConsoleApp.Models.Foods;

public class Fries : IFood
{
    private readonly FoodSize _size;

    public Fries(FoodSize size)
    {
        _size = size;
    }
    
    public double Cost => _size switch
    {
        FoodSize.Small => 200,
        FoodSize.Normal => 300,
        FoodSize.Large => 500,
        _ => throw new ArgumentOutOfRangeException()
    };
    
    public override string ToString()
    {
        return $"{_size} Fries ({Cost})";
    }
}