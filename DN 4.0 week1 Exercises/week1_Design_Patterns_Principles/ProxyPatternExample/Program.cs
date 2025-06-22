using System;

public interface IImage
{
    void Display();
}

public class RealImage : IImage
{
    private readonly string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromDisk();
    }

    private void LoadFromDisk() => Console.WriteLine($"Loading {_filename}...");

    public void Display() => Console.WriteLine($"Displaying {_filename}");
}

public class ProxyImage : IImage
{
    private RealImage _realImage;
    private readonly string _filename;

    public ProxyImage(string filename) => _filename = filename;

    public void Display()
    {
        _realImage ??= new RealImage(_filename);
        _realImage.Display();
    }
}

public class Program
{
    public static void Main()
    {
        IImage image = new ProxyImage("image1.jpg");

        Console.WriteLine("First call:");
        image.Display();

        Console.WriteLine("\nSecond call:");
        image.Display();
    }
}