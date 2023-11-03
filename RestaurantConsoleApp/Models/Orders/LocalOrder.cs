using System.Text;
namespace RestaurantConsoleApp.Models.Orders;

public class LocalOrder : IOrder
{
    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append("Local Order");
        stringBuilder.Append("\nProducts:\n");

        foreach (var p in Products)
        {
            stringBuilder.Append(p + "\n");
        }
        stringBuilder.Append("Total: ");
        stringBuilder.Append(((IOrder)this).Cost);
        return stringBuilder.ToString();
    }

    public IEnumerable<IProduct> Products { get; set; } = Enumerable.Empty<IProduct>();

    public void Serve()
    {
        Console.WriteLine("Order is ready!");
    }
}