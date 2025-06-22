using System;

public static class Forecast
{
    // Recursive method to calculate future value with compound interest
    public static double PredictValue(double currentValue, double growthRate, int years)
    {
        if (years == 0)
            return currentValue;

        return PredictValue(currentValue * (1 + growthRate), growthRate, years - 1);
    }

    // Optimized version using memoization
    public static double PredictValueMemo(double currentValue, double growthRate, int years, double[] memo)
    {
        if (years == 0)
            return currentValue;

        if (memo[years] != 0)
            return memo[years];

        memo[years] = PredictValueMemo(currentValue, growthRate, years - 1, memo) * (1 + growthRate);
        return memo[years];
    }
}

public class Program
{
    public static void Main()
    {
        double initial = 10000;
        double rate = 0.08; // 8% growth rate
        int years = 5;

        double forecast1 = Forecast.PredictValue(initial, rate, years);
        Console.WriteLine($"Recursive Forecast (Year {years}): {forecast1:C}");

        double[] memo = new double[years + 1];
        double forecast2 = Forecast.PredictValueMemo(initial, rate, years, memo);
        Console.WriteLine($"Memoized Forecast (Year {years}): {forecast2:C}");
    }
}