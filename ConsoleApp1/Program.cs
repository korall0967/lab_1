using WarehouseLibrary;
class Program
{
    static void Print(string name, int count, string text, int nowCount)
    {
        Console.WriteLine($"{text} {count}. Товар: {name}. Количество: {nowCount}.");
    }

    static void PrintInv(string name, int count, string text)
    {
        Console.WriteLine($"{text} Товар: {name}. Количество: {count}.");
    }

    static void Main(string[] args)
    {
        Product milk = new Product("Молоко", 10, 3);
        milk.CountOfProduct += Print;
        milk.Inventerization += PrintInv;
        milk.Sell(3);
        milk.Sell(8);
        milk.Sell(6);
        milk.Add(10);
        milk.Remove(5);
        milk.Invent(7);
        milk.Invent(7);
    }
}