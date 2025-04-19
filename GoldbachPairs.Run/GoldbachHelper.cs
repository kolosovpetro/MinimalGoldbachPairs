namespace GoldbachPairs.Run;

public static class GoldbachHelper
{
    public static Dictionary<int, GoldbachPair[]> GetAllGoldbachPairs(int bound)
    {
        var primeSieve = EratosthenesSieve.SieveOfEratosthenes(bound);
        var dictionary = new Dictionary<int, GoldbachPair[]>();
        var list = new List<GoldbachPair>();

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
                    list.Add(new GoldbachPair(left, right));
                }
            }

            dictionary.Add(key, list.ToArray());

            list.Clear();
        }

        return dictionary;
    }

    public static Dictionary<int, GoldbachPair> GetMinimalGoldbachPairs(int bound)
    {
        var primeSieve = EratosthenesSieve.SieveOfEratosthenes(bound);
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

    public static int CountMinPairs(int n, int x)
    {
        var goldbachPairs = GetMinimalGoldbachPairs(n);

        var count = 0;

        foreach (var pair in goldbachPairs)
        {
            if (pair.Value.Left == x)
            {
                count++;
            }
        }

        return count;
    }

    public static int CountPrimesSieve(int bound)
    {
        var primes = EratosthenesSieve.SieveOfEratosthenes(bound);

        var count = primes.Count(x => x);

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
}