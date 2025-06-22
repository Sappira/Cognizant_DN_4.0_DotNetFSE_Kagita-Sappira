using System;

public interface IDocument
{
    void Open();
}

public class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening PDF document...");
}

public class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Word document...");
}

public class ExcelDocument : IDocument
{
    public void Open() => Console.WriteLine("Opening Excel document...");
}

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

public class PdfFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new PdfDocument();
}

public class WordFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new WordDocument();
}

public class ExcelFactory : DocumentFactory
{
    public override IDocument CreateDocument() => new ExcelDocument();
}

public class Program
{
    public static void Main()
    {
        DocumentFactory pdf = new PdfFactory();
        pdf.CreateDocument().Open();

        DocumentFactory word = new WordFactory();
        word.CreateDocument().Open();

        DocumentFactory excel = new ExcelFactory();
        excel.CreateDocument().Open();
    }
} 