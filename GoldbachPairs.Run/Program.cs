using System;
using System.Linq;

namespace GoldbachPairs.Run;

internal static class Program
{
    public static void Main()
    {
        var sieve = GoldbachHelper.Primes.SieveOfEratosthenes;
        var pjSequence =
            GoldbachHelper
                .GeneratePjSequence(2000, 5)
                .Except(GoldbachHelper.GeneratePjSequence(2000, 7))
                .ToList();

        for (int i = 1; i < 7; i++)
        {
            var power = (int)Math.Pow(10, i);
            var min5 = GoldbachHelper.GeneratePjSequence(power, 5).Count;
            var min7 = GoldbachHelper.GeneratePjSequence(power, 7).Count;

            var result = min5 - min7;

            Console.Write($"power: {power}: {result}, ");
        }

        // pjSequence.ForEach(x => Console.Write($"{x}, "));
    }
}
