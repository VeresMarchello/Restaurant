using RestaurantConsoleApp.Models.Orders;

namespace RestaurantConsoleApp.Handlers;

public class CustomerHandler : AbstractHandler
{
    public override IOrder? Handle(IOrder request)
    {
        if (request is not OnlineOrder order)
        {
            return base.Handle(request);
        }

        var person = order.PersonalData;

        var userValid =
            !string.IsNullOrEmpty(person.Email) &&
            !string.IsNullOrEmpty(person.Phone) &&
            !string.IsNullOrEmpty(person.SureName) &&
            !string.IsNullOrEmpty(person.ForeName);

        return userValid ? base.Handle(request) : null;
    }
}