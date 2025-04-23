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
                .GeneratePjSequence(2000, 7)
                // .Except(GoldbachHelper.GeneratePjSequence(2000, 11))
                .ToList();

        // for (int i = 0; i < 2000; i++)
        // {
        //     var isPrime6 = sieve[i + 8];
        //     if (isPrime6)
        //     {
        //         Console.Write($"{i}, ");
        //     }
        // }

        // foreach (var i in pjSequence)
        // {
        //     var isPrime6 = sieve[i + 20];
        //     if (isPrime6)
        //     {
        //         Console.Write($"{i}, ");
        //     }
        // }

        // for (int i = 1; i < 7; i++)
        // {
        //     var power = (int)Math.Pow(10, i);
        //     var min5 = GoldbachHelper.GeneratePjSequence(power, 5).Count;
        //     var min7 = GoldbachHelper.GeneratePjSequence(power, 7).Count;
        //
        //     var result = min5 - min7;
        //
        //     Console.Write($"power: {power}: {result}, ");
        // }

        pjSequence.ForEach(x => Console.Write($"{x}, "));
    }
}
