using RestaurantConsoleApp.Models.Orders;

namespace RestaurantConsoleApp.Handlers;

public class BaseHandler: IHandler
{
    private IHandler? _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual IOrder? Handle(IOrder request)
    {
        return _nextHandler is null ? request : _nextHandler.Handle(request);
    }
}