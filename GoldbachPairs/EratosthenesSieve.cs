using System.Collections.Generic;

namespace GoldbachPairs;

public static class EratosthenesSieve
{
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
}