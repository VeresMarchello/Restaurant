namespace RestaurantConsoleApp.Models.Orders;

public interface IOrder
{
    long Id => IdGenerator.Instance.GenerateNewId();
    IEnumerable<IProduct> Products { get; }
    double Cost => Products.Sum(x => x.Cost);
    DateTime Date => DateTime.UtcNow;

    void Serve();
}