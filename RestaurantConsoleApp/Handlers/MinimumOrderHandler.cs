using RestaurantConsoleApp.Models.Orders;

namespace RestaurantConsoleApp.Handlers;

public class MinimumOrderHandler: AbstractHandler
{
    public override IOrder? Handle(IOrder request)
    {
        var minimumOrder = request switch
        {
            OnlineOrder => 3600,
            _ => 300,
        };

        return request.Cost >= minimumOrder ? base.Handle(request) : null;
    }
}