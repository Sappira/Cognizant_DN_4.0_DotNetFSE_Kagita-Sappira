using System;
using System.Collections.Generic;

// Product class
public class Product
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string Category { get; set; }

    public override string ToString() =>
        $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
}

// Search utility
public static class ProductSearch
{
    public static Product? LinearSearch(Product[] products, string name)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    public static Product? BinarySearch(Product[] sortedProducts, string name)
    {
        int left = 0, right = sortedProducts.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cmp = string.Compare(name, sortedProducts[mid].ProductName, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0) return sortedProducts[mid];
            if (cmp < 0) right = mid - 1;
            else left = mid + 1;
        }
        return null;
    }
}

public class Program
{
    public static void Main()
    {
        Product[] products = {
            new Product { ProductId = 1, ProductName = "Laptop", Category = "Electronics" },
            new Product { ProductId = 2, ProductName = "Book", Category = "Stationery" },
            new Product { ProductId = 3, ProductName = "Phone", Category = "Electronics" }
        };

        // Linear Search
        var linearResult = ProductSearch.LinearSearch(products, "Book");
        Console.WriteLine("Linear Search Result: " + (linearResult != null ? linearResult.ToString() : "Not found"));

        // Sort for Binary Search
        Array.Sort(products, (a, b) => string.Compare(a.ProductName, b.ProductName, StringComparison.OrdinalIgnoreCase));

        // Binary Search
        var binaryResult = ProductSearch.BinarySearch(products, "Phone");
        Console.WriteLine("Binary Search Result: " + (binaryResult != null ? binaryResult.ToString() : "Not found"));
    }
} 