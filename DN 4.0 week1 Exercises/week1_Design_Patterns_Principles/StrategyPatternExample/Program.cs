using System;

public interface IPaymentStrategy
{
    void Pay(double amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(double amount) => Console.WriteLine($"Paid {amount:C} with Credit Card");
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(double amount) => Console.WriteLine($"Paid {amount:C} with PayPal");
}

public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public void SetStrategy(IPaymentStrategy strategy) => _strategy = strategy;

    public void Pay(double amount)
    {
        if (_strategy == null)
            Console.WriteLine("No strategy set.");
        else
            _strategy.Pay(amount);
    }
}

public class Program
{
    public static void Main()
    {
        var context = new PaymentContext();

        context.SetStrategy(new CreditCardPayment());
        context.Pay(500);

        context.SetStrategy(new PayPalPayment());
        context.Pay(750);
    }
}
