using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoldbachPairs;

public static class GoldbachHelper
{
    public static EratosthenesSieve Primes { get; } = new();

    public static Dictionary<int, GoldbachPair> GetMinimalGoldbachPairs(int bound)
    {
        var primeSieve = Primes.SieveOfEratosthenes;
        var dictionary = new Dictionary<int, GoldbachPair>();

        for (int i = 4; i <= bound; i += 2)
        {
            var key = i;

            for (int k = 2; k <= i; k++)
            {
                var left = k;
                var right = i - k;

                if (right == 1)
                {
                    continue;
                }

                var bothPrimes = primeSieve[left] && primeSieve[right];

                if (bothPrimes)
                {
                    var goldbachPair = new GoldbachPair(left, right);
                    dictionary.Add(key, goldbachPair);
                    break;
                }
            }
        }

        return dictionary;
    }

    public static int CountMinimalGoldbachPairsHavingPi(int bound, int p)
    {
        var goldbachPairs = GetMinimalGoldbachPairs(bound);

        var count = 0;

        foreach (var pair in goldbachPairs)
        {
            if (pair.Value.Left == p)
            {
                count++;
            }
        }

        return count;
    }

    public static int CountPrimesSieve(int bound)
    {
        var primes = Primes.SieveOfEratosthenes;

        var count = 0;

        var step = 0;

        while (step <= bound)
        {
            var isPrime = primes[step];

            if (isPrime)
            {
                count++;
            }

            step++;
        }

        return count;
    }

    public static void WriteMinimalGoldbachPairsToFile(string fileName, Dictionary<int, GoldbachPair> dict)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", fileName);

        using var writer = new StreamWriter(path);

        foreach (var kv in dict)
        {
            writer.WriteLine($"{kv.Key} = {kv.Value.Left} + {kv.Value.Right}");
        }
    }

    public static List<int> GeneratePjSequence(int bound, int pi)
    {
        var goldbachPairsMin = GoldbachHelper.GetMinimalGoldbachPairs(bound);

        var result = goldbachPairsMin.Where(t => t.Value.Left == pi)
            .Select(k => k.Value.Right).ToList();

        return result;
    }

    public static List<int> Generate2NSequence(int bound, int pi)
    {
        var goldbachPairsMin = GoldbachHelper.GetMinimalGoldbachPairs(bound);

        var result = goldbachPairsMin.Where(t => t.Value.Left == pi)
            .Select(k => k.Key).ToList();

        return result;
    }
}
