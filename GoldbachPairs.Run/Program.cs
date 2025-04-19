namespace GoldbachPairs.Run;

internal static class Program
{
    public static void Main(string[] args)
    {
        var goldbachPairsMin = GoldbachHelper.GetMinimalGoldbachPairs(10_000);

        goldbachPairsMin.Where(t => t.Value.Left == 3).ToList()
            .ForEach(k => Console.Write($"{k.Value.Right}, "));
        // GoldbachHelper.WriteMinimalGoldbachPairsToFile("min_pairs_up_to_10000.txt", goldbachPairsMin);
        // GoldbachHelper.WriteMinimalGoldbachPairsToFile("min_pairs_up_to_10000_having_left_3.txt",
        //     goldbachPairsMin.Where(t => t.Value.Left == 3).ToDictionary());
        // GoldbachHelper.WriteMinimalGoldbachPairsToFile("min_pairs_up_to_10000_having_left_5.txt",
        //     goldbachPairsMin.Where(t => t.Value.Left == 5).ToDictionary());
        // GoldbachHelper.WriteMinimalGoldbachPairsToFile("min_pairs_up_to_10000_having_left_7.txt",
        //     goldbachPairsMin.Where(t => t.Value.Left == 7).ToDictionary());
        // GoldbachHelper.WriteMinimalGoldbachPairsToFile("min_pairs_up_to_10000_having_left_11.txt",
        //     goldbachPairsMin.Where(t => t.Value.Left == 11).ToDictionary());
    }
}