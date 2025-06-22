﻿using System;
using System.Collections.Generic;

// Product class
public class Product
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public override string ToString() =>
        $"ID: {ProductId}, Name: {ProductName}, Quantity: {Quantity}, Price: {Price:C}";
}

// Inventory system using Dictionary (like HashMap)
public class Inventory
{
    private readonly Dictionary<int, Product> _products = new();

    public void AddProduct(Product product)
    {
        if (_products.ContainsKey(product.ProductId))
        {
            Console.WriteLine("Product already exists.");
            return;
        }
        _products[product.ProductId] = product;
        Console.WriteLine("Product added.");
    }

    public void UpdateProduct(Product product)
    {
        if (!_products.ContainsKey(product.ProductId))
        {
            Console.WriteLine("Product not found.");
            return;
        }
        _products[product.ProductId] = product;
        Console.WriteLine("Product updated.");
    }

    public void DeleteProduct(int productId)
    {
        if (_products.Remove(productId))
            Console.WriteLine("Product deleted.");
        else
            Console.WriteLine("Product not found.");
    }

    public void PrintInventory()
    {
        Console.WriteLine("\nInventory:");
        foreach (var product in _products.Values)
        {
            Console.WriteLine(product);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Inventory inventory = new Inventory();

        // Adding products
        inventory.AddProduct(new Product { ProductId = 1, ProductName = "Laptop", Quantity = 10, Price = 75000 });
        inventory.AddProduct(new Product { ProductId = 2, ProductName = "Mouse", Quantity = 100, Price = 500 });
        inventory.PrintInventory();

        // Updating a product
        inventory.UpdateProduct(new Product { ProductId = 1, ProductName = "Laptop", Quantity = 8, Price = 72000 });

        // Deleting a product
        inventory.DeleteProduct(2);
        inventory.PrintInventory();
    }
}