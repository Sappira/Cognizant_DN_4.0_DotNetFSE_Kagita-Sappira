using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string stock, double price);
}

public interface IStock
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class StockMarket : IStock
{
    private readonly List<IObserver> _observers = new();
    private string _symbol;
    private double _price;

    public StockMarket(string symbol, double price)
    {
        _symbol = symbol;
        _price = price;
    }

    public void SetPrice(double price)
    {
        _price = price;
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer) => _observers.Add(observer);
    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var o in _observers)
            o.Update(_symbol, _price);
    }
}

public class MobileApp : IObserver
{
    public void Update(string stock, double price) =>
        Console.WriteLine($"[MobileApp] {stock} updated to {price:C}");
}

public class WebApp : IObserver
{
    public void Update(string stock, double price) =>
        Console.WriteLine($"[WebApp] {stock} updated to {price:C}");
}

public class Program
{
    public static void Main()
    {
        var stock = new StockMarket("AAPL", 180);
        var mobile = new MobileApp();
        var web = new WebApp();

        stock.RegisterObserver(mobile);
        stock.RegisterObserver(web);

        stock.SetPrice(185);
        stock.SetPrice(190);
    }
}