namespace GoldbachPairs.Run;

internal static class Program
{
    public static void Main(string[] args)
    {
        var primeSieve = EratosthenesSieve.SieveOfEratosthenes(50);

        var primes = EratosthenesSieve.PrimesList(50).ToList();

        var goldbachPairs = GoldbachHelper.GetGoldbachPairs(50);
        var goldbachPairsMin = GoldbachHelper.GetMinimalGoldbachPairs(50);

        var count = GoldbachHelper.CountMinPairs(1000000, 3);

        var list = new List<int>();

        for (int i = 5; i <= 100; i++)
        {
            var p = GoldbachHelper.CountMinPairs(i, 3) + 1;
            
            list.Add(p);
        }

        foreach (var i in list)
        {
            Console.Write($"{i}, ");
        }
    }
}