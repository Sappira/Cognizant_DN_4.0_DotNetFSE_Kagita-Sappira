using System;

public sealed class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new();

    private Logger()
    {
        Console.WriteLine("Logger initialized.");
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Logger();
            }
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}

public class Program
{
    public static void Main()
    {
        var logger1 = Logger.GetInstance();
        logger1.Log("First message");

        var logger2 = Logger.GetInstance();
        logger2.Log("Second message");

        Console.WriteLine($"Same instance? {ReferenceEquals(logger1, logger2)}");
    }
} 