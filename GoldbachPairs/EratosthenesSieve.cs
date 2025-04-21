using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GoldbachPairs;

public class EratosthenesSieve
{
    private readonly JsonSerializerOptions _options;

    private const string FileName = "sieve.json";

    private const int DefaultSieveSize = 2 * 1_000_000;

    private readonly string _cachedSieveAbsPath;

    public bool[] SieveOfEratosthenes { get; }

    private bool SieveExists => SieveOfEratosthenes != null;

    public EratosthenesSieve()
    {
        _options = new JsonSerializerOptions { WriteIndented = true };
        _cachedSieveAbsPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", FileName));

        var sieveFileExists = Path.Exists(_cachedSieveAbsPath);

        if (sieveFileExists)
        {
            var cachedSieve = DeserializeSieve();

            var sameLength = cachedSieve.Length == DefaultSieveSize + 1;

            if (sameLength)
            {
                SieveOfEratosthenes = cachedSieve;
                return;
            }
        }

        SieveOfEratosthenes = GenerateSieveOfEratosthenes(DefaultSieveSize);
    }


    private bool[] GenerateSieveOfEratosthenes(int sieveSize)
    {
        if (SieveExists && sieveSize <= DefaultSieveSize)
        {
            return SieveOfEratosthenes;
        }

        var primes = new bool[sieveSize + 1];

        for (var i = 2; i < primes.Length; i++)
        {
            primes[i] = true;
        }

        for (var p = 2; p * p < sieveSize; p++)
        {
            if (!primes[p])
            {
                continue;
            }

            for (var i = p * p; i < sieveSize; i += p)
            {
                primes[i] = false;
            }
        }

        for (var i = 0; i < primes.Length - 1; i++)
        {
            var lastItem = sieveSize;

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

        SerializeSieve(primes);

        return primes;
    }

    public IEnumerable<int> PrimesList(int upperBound)
    {
        var sieve = GenerateSieveOfEratosthenes(upperBound);

        for (var i = 2; i < sieve.Length - 1; i++)
        {
            if (sieve[i])
            {
                yield return i;
            }
        }
    }

    private void SerializeSieve(bool[] sieve)
    {
        var sieveFilePath = Path.GetFullPath(_cachedSieveAbsPath);
        var json = JsonSerializer.Serialize(sieve, _options);
        File.WriteAllText(sieveFilePath, json);
        Console.WriteLine($"Sieve saved to: {_cachedSieveAbsPath}");
    }

    private bool[] DeserializeSieve()
    {
        var sieveFilePath = Path.GetFullPath(_cachedSieveAbsPath);

        var loadedSieve = JsonSerializer.Deserialize<bool[]>(File.ReadAllText(sieveFilePath));

        return loadedSieve;
    }
}
