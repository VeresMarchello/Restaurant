using System.Text;

namespace RestaurantConsoleApp.Models.Orders;

public class OnlineOrder : IOrder
{
    public IEnumerable<IProduct> Products { get; set; } = Enumerable.Empty<IProduct>();

    public required Customer PersonalData { get; set; }
    public required Address Address { get; set; }

    public void Serve()
    {
        Console.WriteLine($"Transporting to address: {Address}");
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append("Online Order to ");
        stringBuilder.Append(PersonalData);
        stringBuilder.Append(" with address: ");
        stringBuilder.Append(Address);

        stringBuilder.Append("\nProducts:\n");

        foreach (var p in Products)
        {
            stringBuilder.Append(p + "\n");
        }

        stringBuilder.Append("Total: ");
        stringBuilder.Append(((IOrder)this).Cost);
        return stringBuilder.ToString();
    }
}