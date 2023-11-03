namespace RestaurantConsoleApp.Models.Orders;

public class Address
{
    public required string City { get; set; }
    public required string StreetName { get; set; }
    public required string StreetNumber { get; set; }

    public override string ToString()
    {
        return $"{StreetName} {StreetNumber}, {City}";
    }
}