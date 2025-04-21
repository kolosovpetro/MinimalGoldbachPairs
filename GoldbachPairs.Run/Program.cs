using System;
using System.Linq;

namespace GoldbachPairs.Run;

internal static class Program
{
    public static void Main()
    {
        var sieve = GoldbachHelper.Primes.SieveOfEratosthenes;
        var pjSequence = GoldbachHelper
            .GeneratePjSequence(2000, 5)
            .Except(GoldbachHelper.GeneratePjSequence(2000, 7))
            .ToList();

        // for (int i = 0; i < pjSequence.Count-1; i++)
        // {
        //     var diff = pjSequence[i + 1] - pjSequence[i];
        //
        //     Console.Write($"{diff}, ");
        // }

         pjSequence.ForEach(x => Console.Write($"{x}, "));
    }
}
