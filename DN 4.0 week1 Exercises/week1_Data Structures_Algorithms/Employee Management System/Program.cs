﻿using System;

// Employee class
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public override string ToString() =>
        $"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: {Salary:C}";
}

// Employee manager using array
public class EmployeeManager
{
    private Employee[] employees = new Employee[100];
    private int count = 0;

    public void AddEmployee(Employee emp)
    {
        if (count >= employees.Length)
        {
            Console.WriteLine("Employee list is full.");
            return;
        }
        employees[count++] = emp;
        Console.WriteLine("Employee added.");
    }

    public void DeleteEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                for (int j = i; j < count - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }
                employees[--count] = null;
                Console.WriteLine("Employee deleted.");
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }

    public Employee SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
                return employees[i];
        }
        return null;
    }

    public void TraverseEmployees()
    {
        Console.WriteLine("\nEmployee List:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(employees[i]);
        }
    }
}

public class Program
{
    public static void Main()
    {
        EmployeeManager manager = new EmployeeManager();

        manager.AddEmployee(new Employee { EmployeeId = 101, Name = "Ameen", Position = "Developer", Salary = 60000 });
        manager.AddEmployee(new Employee { EmployeeId = 102, Name = "Zara", Position = "Designer", Salary = 55000 });

        manager.TraverseEmployees();

        var found = manager.SearchEmployee(101);
        Console.WriteLine("\nSearch Result: " + (found != null ? found.ToString() : "Not found"));

        manager.DeleteEmployee(101);
        manager.TraverseEmployees();
    }
}