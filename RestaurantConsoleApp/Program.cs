using RestaurantConsoleApp.Handlers;
using RestaurantConsoleApp.Menu;
using RestaurantConsoleApp.Models;
using RestaurantConsoleApp.Models.Drinks;
using RestaurantConsoleApp.Models.Drinks.Enums;
using RestaurantConsoleApp.Models.Foods;
using RestaurantConsoleApp.Models.Foods.Enums;
using RestaurantConsoleApp.Models.Orders;

Console.WriteLine("Welcome to Sample Restaurant.");
Console.WriteLine("Choose a meal:");
Console.WriteLine("(1) Burger");
Console.WriteLine("(2) Pizza");
Console.WriteLine("(3) Drink");
Console.WriteLine("(4) Fries");

int SubMenu(string[] options)
{
    Console.Clear();
    Console.WriteLine("Choose an option:");
    for (int i = 0; i < options.Length; i++)
    {
        Console.WriteLine("{0}) {1}", i + 1, options[i]);
    }

    Console.Write("\r\nSelect an option: ");
    var selected = Console.ReadLine();
    int.TryParse(selected, out var index);
    return index - 1;
}

T GetType<T>() where T : struct
{
    var types = Enum.GetNames(typeof(T));
    var index = SubMenu(types);

    Enum.TryParse(types[index], out T type);
    return type;
}

IProduct BurgerSubMenu()
{
    var types = Enum.GetNames<BurgerType>();
    var index = SubMenu(types);

    Enum.TryParse(types[index], out BurgerType type);
    return new Burger(type);
}

IProduct PizzaSubMenu()
{
    var types = Enum.GetNames<PizzaType>();
    var sizes = Enum.GetNames<FoodSize>();

    var typeIndex = SubMenu(types);
    Enum.TryParse(types[typeIndex], out PizzaType type);

    var sizeIndex = SubMenu(sizes);
    Enum.TryParse(sizes[sizeIndex], out FoodSize size);

    return new Pizza(type, size);
}

IProduct DrinkSubMenu()
{
    var types = new[] { nameof(BottledDrink), nameof(TappedDrink) };
    var names = Enum.GetNames<DrinkName>();
    var sizes = Enum.GetNames<DrinkSize>();

    var typeIndex = SubMenu(types);
    var bottledDrink = typeIndex == 0;

    var nameIndex = SubMenu(names);
    Enum.TryParse(names[nameIndex], out DrinkName name);

    IDrink drink;
    if (!bottledDrink)
    {
        var sizeIndex = SubMenu(sizes);
        Enum.TryParse(sizes[sizeIndex], out DrinkSize size);
        drink = new TappedDrink(name, size);
    }
    else
    {
        drink = new BottledDrink(name);
    }

    return drink;
}

IProduct FriesSubMenu()
{
    var sizes = Enum.GetNames<FoodSize>();

    var sizeIndex = SubMenu(sizes);
    Enum.TryParse(sizes[sizeIndex], out FoodSize size);

    return new Fries(size);
}

IEnumerable<IProduct> MenusSubMenu()
{
    var menus = new[] { "Burger Menu", "Pizza Menu", "Pizza Menu for Couples" };
    var index = SubMenu(menus);

    IMenuBuilder builder = index switch
    {
        0 => builder = new BurgerMenuBuilder(GetType<BurgerType>(), GetType<DrinkName>()),
        1 => builder = new NormalPizzaMenuBuilder(GetType<PizzaType>(), GetType<DrinkName>()),
        2 => builder = new CouplePizzaMenuBuilder(GetType<PizzaType>(), GetType<DrinkName>(), GetType<DrinkName>()),
        _ => throw new ArgumentOutOfRangeException(),
    };

    var employer = new MenuDirector(builder);
    return employer.BuildMenu();
}

var products = Enumerable.Empty<IProduct>();
IOrder order;

IOrder OrderSubMenu()
{
    var types = new[] { nameof(LocalOrder), nameof(OnlineOrder) };

    var typeIndex = SubMenu(types);
    var localOrder = typeIndex == 0;

    if (!localOrder)
    {
        Console.WriteLine("Forename:");
        var foreName = Console.ReadLine();

        Console.WriteLine("Surename:");
        var sureName = Console.ReadLine();

        Console.WriteLine("Email:");
        var email = Console.ReadLine();

        Console.WriteLine("Phone:");
        var phone = Console.ReadLine();

        var personalData = new Customer()
        {
            ForeName = foreName,
            SureName = sureName,
            Email = email,
            Phone = phone
        };

        Console.WriteLine("City:");
        var city = Console.ReadLine();

        Console.WriteLine("Street:");
        var streetName = Console.ReadLine();

        Console.WriteLine("Street number:");
        var number = Console.ReadLine();

        var address = new Address
        {
            City = city,
            StreetName = streetName,
            StreetNumber = number
        };

        return new OnlineOrder()
        {
            Products = products,
            Address = address,
            PersonalData = personalData
        };
    }

    return new LocalOrder()
    {
        Products = products
    };
}

void MainMenu()
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("Products({0})", products.Count());
        foreach (var p in products)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Burger");
        Console.WriteLine("2) Pizza");
        Console.WriteLine("3) Drink");
        Console.WriteLine("4) Fries");
        Console.WriteLine("5) Menu");
        Console.WriteLine("6) Make Order");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                products = products.Append(BurgerSubMenu());
                break;
            case "2":
                products = products.Append(PizzaSubMenu());
                break;
            case "3":
                products = products.Append(DrinkSubMenu());
                break;
            case "4":
                products = products.Append(FriesSubMenu());
                break;
            case "5":
                foreach (var p in MenusSubMenu())
                {
                    products = products.Append(p);
                }

                break;
            case "6":
                order = OrderSubMenu();
                return;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

MainMenu();


// var builder = new CouplePizzaMenuBuilder(PizzaType.Hawaiian, DrinkName.Cola, DrinkName.Fanta);
// var employer = new MenuDirector(builder);

// products = products.Append(new Burger(BurgerType.BaconWithCheese));
// products = products.Append(new BottledDrink(DrinkName.Water));

// to prevent multiple enumeration
// products = products.ToList();

// IOrder order = new LocalOrder
// {
//     Products = products,
// };

// order = new OnlineOrder
// {
//     Products = products,
//     PersonalData = new Customer()
//     {
//         ForeName = "Jakab",
//         SureName = "Gipsz",
//         Email = "email@address.sample",
//         Phone = "+45454545"
//     },
//     Address = new Address
//     {
//         City = "Miskolc",
//         StreetName = "Egyetemváros",
//         StreetNumber = "1"
//     }
// };
Console.WriteLine();
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