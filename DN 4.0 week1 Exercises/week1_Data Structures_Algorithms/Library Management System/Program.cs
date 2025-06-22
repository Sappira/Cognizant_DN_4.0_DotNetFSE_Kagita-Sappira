﻿using System;

// Book class
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public override string ToString() =>
        $"ID: {BookId}, Title: {Title}, Author: {Author}";
}

// Search Utility
public static class BookSearch
{
    public static Book LinearSearch(Book[] books, string title)
    {
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return book;
        }
        return null;
    }

    public static Book BinarySearch(Book[] books, string title)
    {
        int left = 0, right = books.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cmp = string.Compare(title, books[mid].Title, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0) return books[mid];
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
        Book[] books = {
            new Book { BookId = 1, Title = "Data Structures", Author = "Narasimha Karumanchi" },
            new Book { BookId = 2, Title = "C# in Depth", Author = "Jon Skeet" },
            new Book { BookId = 3, Title = "Clean Code", Author = "Robert C. Martin" }
        };

        // Linear Search
        var linear = BookSearch.LinearSearch(books, "C# in Depth");
        Console.WriteLine("Linear Search Result: " + (linear != null ? linear.ToString() : "Not found"));

        // Sort for Binary Search
        Array.Sort(books, (a, b) => string.Compare(a.Title, b.Title, StringComparison.OrdinalIgnoreCase));

        // Binary Search
        var binary = BookSearch.BinarySearch(books, "Clean Code");
        Console.WriteLine("Binary Search Result: " + (binary != null ? binary.ToString() : "Not found"));
    }
} 