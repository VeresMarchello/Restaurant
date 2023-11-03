using RestaurantConsoleApp.Models.Orders;

namespace RestaurantConsoleApp.Handlers;

public interface IHandler
{
    IHandler SetNext(IHandler handler);
    IOrder? Handle(IOrder request);
}