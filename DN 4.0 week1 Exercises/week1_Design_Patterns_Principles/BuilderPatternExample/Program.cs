using System;

public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }

    public override string ToString() =>
        $"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, GPU: {GPU}";
}

public class ComputerBuilder
{
    private readonly Computer _computer = new();

    public ComputerBuilder SetCPU(string cpu) { _computer.CPU = cpu; return this; }
    public ComputerBuilder SetRAM(string ram) { _computer.RAM = ram; return this; }
    public ComputerBuilder SetStorage(string storage) { _computer.Storage = storage; return this; }
    public ComputerBuilder SetGPU(string gpu) { _computer.GPU = gpu; return this; }
    public Computer Build() => _computer;
}

public class Program
{
    public static void Main()
    {
        var gamingPC = new ComputerBuilder()
            .SetCPU("Intel i9")
            .SetRAM("32GB")
            .SetStorage("1TB SSD")
            .SetGPU("RTX 4090")
            .Build();

        var officePC = new ComputerBuilder()
            .SetCPU("Intel i5")
            .SetRAM("8GB")
            .SetStorage("512GB SSD")
            .Build();

        Console.WriteLine("Gaming PC: " + gamingPC);
        Console.WriteLine("Office PC: " + officePC);
    }
} 
