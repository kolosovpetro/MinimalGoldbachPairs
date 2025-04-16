namespace GoldbachPairs.Run;

internal static class Program
{
    public static void Main(string[] args)
    {
        // var primeSieve = EratosthenesSieve.SieveOfEratosthenes(1_000_000);
        // EratosthenesSieve.SerializeSieve(primeSieve);

        var deserializeSieve = EratosthenesSieve.DeserializeSieve();

        var primes = EratosthenesSieve.PrimesList(50).ToList();

        var goldbachPairs = GoldbachHelper.GetGoldbachPairs(50);
        var goldbachPairsMin = GoldbachHelper.GetMinimalGoldbachPairs(50);

        // var count = GoldbachHelper.CountMinPairs(1000000, 3);
        //
        // var list = new List<int>();
        //
        // Console.WriteLine("PI(N) sequence");
        //
        // for (int i = 5; i <= 100; i++)
        // {
        //     var p = GoldbachHelper.CountMinPairs(i, 3) + 1;
        //
        //     list.Add(p);
        // }
        //
        // foreach (var i in list)
        // {
        //     Console.Write($"{i}, ");
        // }
        //
        // Console.WriteLine();
        // Console.WriteLine();
        // list.Clear();
        //
        // for (var i = 1; i < 9; i++)
        // {
        //     var pow = (int)Math.Pow(10, i);
        //     var t = GoldbachHelper.CountMinPairs(pow + 3, 3) - GoldbachHelper.CountMinPairs(pow+5, 5);
        //     list.Add(t);
        // }
        //
        // foreach (var i in list)
        // {
        //     Console.Write($"{i}, ");
        // }
    }
}