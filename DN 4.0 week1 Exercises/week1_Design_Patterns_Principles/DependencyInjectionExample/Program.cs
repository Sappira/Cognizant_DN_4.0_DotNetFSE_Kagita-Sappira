using System;

// Repository Interface
public interface ICustomerRepository
{
    string FindCustomerById(int id);
}

// Concrete Repository
public class CustomerRepositoryImpl : ICustomerRepository
{
    public string FindCustomerById(int id)
    {
        return $"Customer #{id}: John Doe";
    }
}

// Service Class (depends on repository)
public class CustomerService
{
    private readonly ICustomerRepository _repository;

    // Constructor Injection
    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public void DisplayCustomer(int id)
    {
        string customer = _repository.FindCustomerById(id);
        Console.WriteLine(customer);
    }
}

// Main
public class Program
{
    public static void Main(string[] args)
    {
        // Manual DI (could later be replaced by a DI container)
        ICustomerRepository repository = new CustomerRepositoryImpl();
        CustomerService service = new CustomerService(repository);

        service.DisplayCustomer(101);
    }
}