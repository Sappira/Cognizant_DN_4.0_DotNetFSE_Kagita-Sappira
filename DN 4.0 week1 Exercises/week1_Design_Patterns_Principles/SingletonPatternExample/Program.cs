class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("This is the first log message.");
        logger2.Log("This is the second log message.");

        Console.WriteLine(Object.ReferenceEquals(logger1, logger2) 
            ? "Same instance" 
            : "Different instances");
    }
}
