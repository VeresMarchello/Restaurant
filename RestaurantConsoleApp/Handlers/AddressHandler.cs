using RestaurantConsoleApp.Models.Orders;

namespace RestaurantConsoleApp.Handlers;

public class AddressHandler : BaseHandler
{
    public override IOrder? Handle(IOrder request)
    {
        if (request is not OnlineOrder onlineOrder)
        {
            return base.Handle(request);
        }

        var address = onlineOrder.Address;

        var addressValid =
            !string.IsNullOrEmpty(address.City) &&
            !string.IsNullOrEmpty(address.StreetName) &&
            !string.IsNullOrEmpty(address.StreetNumber);

        return addressValid ? base.Handle(request) : null;
    }
}