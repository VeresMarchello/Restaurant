namespace RestaurantConsoleApp;

public sealed class IdGenerator
{
    private static readonly Lazy<IdGenerator> Lazy = new(() => new IdGenerator());

    private static long _id;

    public static IdGenerator Instance => Lazy.Value;

    private IdGenerator()
    {
        _id = 1;
    }

    public long GenerateNewId()
    {
        return _id++;
    }
}