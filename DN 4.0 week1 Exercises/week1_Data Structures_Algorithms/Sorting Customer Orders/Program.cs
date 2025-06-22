﻿using System;
using System.Collections.Generic;

// Order class
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double TotalPrice { get; set; }

    public override string ToString()
    {        if (string.IsNullOrEmpty(CustomerName))
        {
            throw new ArgumentException("Customer name cannot be null or empty.");
        }
        return $"OrderID: {OrderId}, Customer: {CustomerName}, Total: {TotalPrice:C}";
    }
}

public static class OrderSorter
{
    public static void BubbleSort(Order[] orders)
    {
        int n = orders.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    (orders[j], orders[j + 1]) = (orders[j + 1], orders[j]);
                }
            }
        }
    }

    public static void QuickSort(Order[] orders, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(orders, low, high);
            QuickSort(orders, low, pivotIndex - 1);
            QuickSort(orders, pivotIndex + 1, high);
        }
    }

    private static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice < pivot)
            {
                i++;
                (orders[i], orders[j]) = (orders[j], orders[i]);
            }
        }
        (orders[i + 1], orders[high]) = (orders[high], orders[i + 1]);
        return i + 1;
    }
}

public class Program
{
    public static void Main()
    {
        Order[] orders = {
            new Order { OrderId = 1, CustomerName = "Alice", TotalPrice = 1500 },
            new Order { OrderId = 2, CustomerName = "Bob", TotalPrice = 4500 },
            new Order { OrderId = 3, CustomerName = "Charlie", TotalPrice = 2500 }
        };

        Console.WriteLine("Original Orders:");
        foreach (var order in orders) Console.WriteLine(order);

        // Bubble Sort
        Order[] bubbleSorted = (Order[])orders.Clone();
        OrderSorter.BubbleSort(bubbleSorted);
        Console.WriteLine("\nOrders Sorted by Bubble Sort:");
        foreach (var order in bubbleSorted) Console.WriteLine(order);

        // Quick Sort
        Order[] quickSorted = (Order[])orders.Clone();
        OrderSorter.QuickSort(quickSorted, 0, quickSorted.Length - 1);
        Console.WriteLine("\nOrders Sorted by Quick Sort:");
        foreach (var order in quickSorted) Console.WriteLine(order);
    }
}