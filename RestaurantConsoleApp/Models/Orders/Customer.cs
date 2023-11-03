namespace RestaurantConsoleApp.Models.Orders;

public class Customer
{
    public required string SureName { get; set; }
    public required string ForeName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }

    public override string ToString()
    {
        return $"{ForeName} {SureName}, Phone:{Phone}, Email:{Email}";
    }
}