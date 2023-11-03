using RestaurantConsoleApp.Handlers;
using RestaurantConsoleApp.Menu;
using RestaurantConsoleApp.Models.Drinks;
using RestaurantConsoleApp.Models.Drinks.Enums;
using RestaurantConsoleApp.Models.Foods;
using RestaurantConsoleApp.Models.Foods.Enums;
using RestaurantConsoleApp.Models.Orders;


var builder = new CouplePizzaMenuBuilder(PizzaType.Hawaiian, DrinkName.Cola, DrinkName.Fanta);
var employer = new MenuDirector(builder);

var products = employer.BuildMenu();
products = products.Append(new Burger(BurgerType.BaconWithCheese));
products = products.Append(new BottledDrink(DrinkName.Water));

// to prevent multiple enumeration
products = products.ToList();

IOrder order = new LocalOrder
{
    Products = products,
};

order = new OnlineOrder
{
    Products = products,
    PersonalData = new Customer()
    {
        ForeName = "Jakab",
        SureName = "Gipsz",
        Email = "email@address.sample",
        Phone = "+45454545"
    },
    Address = new Address
    {
        City = "Miskolc",
        StreetName = "Egyetemváros",
        StreetNumber = "1"
    }
};
Console.WriteLine(order);
Console.WriteLine();

var orderHandler = new MinimumOrderHandler();
var addressHandler = new AddressHandler();
var customerHandler = new CustomerHandler();

orderHandler.SetNext(addressHandler).SetNext(customerHandler);

var validOrder = orderHandler.Handle(order) is not null;

if (!validOrder)
{
    Console.WriteLine("Order does not meet the requirements.");
    return;
}

order.Serve();