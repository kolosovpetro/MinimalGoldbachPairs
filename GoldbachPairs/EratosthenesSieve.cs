using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GoldbachPairs;

public static class EratosthenesSieve
{
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

    private const string fileName = "sieve.json";

    private static readonly string filePath = Path.Combine(
        AppContext.BaseDirectory, "..", "..", "..", "..", fileName);


    public static bool[] SieveOfEratosthenes(int upperBound)
    {
        var primes = new bool[upperBound + 1];

        for (var i = 0; i < primes.Length; i++)
        {
            primes[i] = true;
        }

        primes[0] = false;
        primes[1] = false;

        for (var p = 2; p * p < upperBound; p++)
        {
            if (!primes[p])
            {
                continue;
            }

            for (var i = p * p; i < upperBound; i += p)
            {
                primes[i] = false;
            }
        }

        for (var i = 0; i < primes.Length - 1; i++)
        {
            var lastItem = upperBound;

            if (!primes[i])
            {
                continue;
            }

            if (lastItem % i == 0)
            {
                primes[lastItem] = false;
                break;
            }
        }

        return primes;
    }

    public static IEnumerable<int> PrimesList(int upperBound)
    {
        var sieve = SieveOfEratosthenes(upperBound);

        for (var i = 2; i < sieve.Length - 1; i++)
        {
            if (sieve[i])
            {
                yield return i;
            }
        }
    }

    public static void SerializeSieve(bool[] sieve)
    {
        var sieveFilePath = Path.GetFullPath(filePath);
        var json = JsonSerializer.Serialize(sieve, options);
        File.WriteAllText(sieveFilePath, json);
        Console.WriteLine($"Sieve saved to: {filePath}");
    }

    public static bool[] DeserializeSieve()
    {
        var sieveFilePath = Path.GetFullPath(filePath);

        var loadedSieve = JsonSerializer.Deserialize<bool[]>(File.ReadAllText(sieveFilePath));

        return loadedSieve;
    }
}