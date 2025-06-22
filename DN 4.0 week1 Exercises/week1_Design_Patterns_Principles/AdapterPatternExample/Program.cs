using System;

public interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

public class PayPal
{
    public void SendPayment(double amount) => Console.WriteLine($"PayPal: {amount:C} processed.");
}

public class Stripe
{
    public void MakePayment(double amount) => Console.WriteLine($"Stripe: {amount:C} processed.");
}

public class PayPalAdapter : IPaymentProcessor
{
    private readonly PayPal _payPal;
    public PayPalAdapter(PayPal payPal) { _payPal = payPal; }
    public void ProcessPayment(double amount) => _payPal.SendPayment(amount);
}

public class StripeAdapter : IPaymentProcessor
{
    private readonly Stripe _stripe;
    public StripeAdapter(Stripe stripe) { _stripe = stripe; }
    public void ProcessPayment(double amount) => _stripe.MakePayment(amount);
}

public class Program
{
    public static void Main()
    {
        IPaymentProcessor paypal = new PayPalAdapter(new PayPal());
        paypal.ProcessPayment(1000);

        IPaymentProcessor stripe = new StripeAdapter(new Stripe());
        stripe.ProcessPayment(2500);
    }
} 
